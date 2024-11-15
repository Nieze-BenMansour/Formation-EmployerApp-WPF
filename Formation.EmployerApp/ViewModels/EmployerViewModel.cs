using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Formation.EmployerApp.Enums;
using Formation.EmployerApp.Models;
using Formation.EmployerApp.Services;
using System.Collections.ObjectModel;

namespace Formation.EmployerApp.ViewModels;

public partial class EmployerViewModel : ObservableObject
{
    private readonly EmployerService _employerService;

    [ObservableProperty]
    private ObservableCollection<Employer> filteredEmployers;

    [ObservableProperty]
    private ObservableCollection<Poste> postes;

    [ObservableProperty]
    private Employer selectedEmployer;

    [ObservableProperty]
    private ObservableCollection<Departement> departements;

    [ObservableProperty]
    private string searchQuery;

    [ObservableProperty]
    double progressBarValue;

    public IRelayCommand AddEmployerCommand { get; }

    public IRelayCommand EditEmployerCommand { get; }

    public IRelayCommand CancelCommand { get; }




    public EmployerViewModel()
    {
        _employerService = new EmployerService();
        SearchQuery = string.Empty;
        Postes = new ObservableCollection<Poste>(Enum.GetValues(typeof(Poste)).Cast<Poste>());
        Departements = new ObservableCollection<Departement>(DepartementService.GetAll());
        FilteredEmployers = new ObservableCollection<Employer>(_employerService.GetAllEmployers());
        AddEmployerCommand = new RelayCommand(AddEmployer);
        SelectedEmployer = Employer.Empty();
        EditEmployerCommand = new RelayCommand(EditEmployer, CanEditOrDelete);
        CancelCommand = new RelayCommand(CancelAndRefresh);

    }

    private void AddEmployer()
    {
        var newEmployer = new Employer
        (
            id: FilteredEmployers.Count + 1,
            prenom: SelectedEmployer.Prenom,
            nom: SelectedEmployer.Nom,
            age: SelectedEmployer.Age,
            poste: SelectedEmployer.Poste,
            identifiantNationale: SelectedEmployer.IdentifiantNationale,
            dateNaissance: SelectedEmployer.DateNaissance,
            departementCode: SelectedEmployer.DepartementCode,
            departement: Departements.FirstOrDefault(d => d.Code == SelectedEmployer.DepartementCode)
        );

        _employerService.AddNew(newEmployer);

        CancelAndRefresh();
    }

    private void EditEmployer()
    {
        _employerService.Edit(selectedEmployer);

        CancelAndRefresh();
    }

    partial void OnSearchQueryChanged(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            FilteredEmployers = new ObservableCollection<Employer>(_employerService.GetAllEmployers());
            return;
        }

        List<Employer> tmpFiltredEmployerList = _employerService.GetAllEmployers()
            .FindAll(e => e.Nom.Contains(value, StringComparison.OrdinalIgnoreCase) ||
                          e.Prenom.Contains(value, StringComparison.OrdinalIgnoreCase));

        FilteredEmployers = new ObservableCollection<Employer>(tmpFiltredEmployerList);
    }

    private async void CancelAndRefresh()
    {
        SelectedEmployer = Employer.Empty();

        ProgressBarValue = 0;

        for (int i = 0; i < 5; i++)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));
            ProgressBarValue += 20;
        }

        FilteredEmployers = new ObservableCollection<Employer>(_employerService.GetAllEmployers());
        ProgressBarValue = 0;
    }

    private bool CanEditOrDelete()
    {
        return SelectedEmployer != null;
    }
}
