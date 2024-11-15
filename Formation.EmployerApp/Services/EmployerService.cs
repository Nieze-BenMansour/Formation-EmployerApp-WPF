using Formation.EmployerApp.Enums;
using Formation.EmployerApp.Models;
using System.ComponentModel;

namespace Formation.EmployerApp.Services;

internal class EmployerService
{
    private List<Employer> _dataSource = new List<Employer>
    {
        new Employer
        (
            id: 1,
            nom: "Dupont",
            prenom: "Jean",
            age: 35,
            poste: Poste.Developpeur,
            identifiantNationale: "123456789012345",
            dateNaissance: new DateTime(1989, 5, 10),
            departementCode: "RH",
            departement: DepartementService.GetAll().FirstOrDefault(t => t.Code == "RH")
        ),
        new Employer
        (
            id: 2,
            nom: "Lemoine",
            prenom: "Sarah",
            age: 28,
            poste: Poste.Analyste,
            identifiantNationale: "234567890123456",
            dateNaissance: new DateTime(1996, 2, 18),
            departementCode: "RH",
            departement: DepartementService.GetAll().FirstOrDefault(t => t.Code == "RH")
        ),
        new Employer
        (
            id: 3,
            nom: "Martins",
            prenom: "Pedro",
            age: 42,
            poste: Poste.Administrateur,
            identifiantNationale: "345678901234567",
            dateNaissance: new DateTime(1982, 8, 24),
            departementCode: "RH",
            departement: DepartementService.GetAll().FirstOrDefault(t => t.Code == "RH")
        ),
        new Employer
        (
            id: 4,
            nom: "Bernard",
            prenom: "Lucie",
            age: 30,
            poste: Poste.Manager,
            identifiantNationale: "456789012345678",
            dateNaissance: new DateTime(1994, 11, 30),
            departementCode: "RH",
            departement: DepartementService.GetAll().FirstOrDefault(t => t.Code == "RH")
        )
    };

    public List<Employer> GetAllEmployers()
    {
        return _dataSource;
    }

    public void AddNew(Employer employer)
    {
        _dataSource.Add( employer );
    }

    public void Edit(Employer employer)
    {
        if (employer is null)
        {
            return;
        }

        var employerToEdit = _dataSource.FirstOrDefault(e => e.Id == employer.Id);

        if (employerToEdit is null)
        {
            return;
        }

        employerToEdit.Nom = employer.Nom;
        employerToEdit.Prenom = employer.Prenom;
        employerToEdit.Age = employer.Age;
        employerToEdit.Poste = employer.Poste;
        employerToEdit.IdentifiantNationale = employer.IdentifiantNationale;
        employerToEdit.DateNaissance = employer.DateNaissance;
        employerToEdit.DepartementCode = employer.DepartementCode;
        employerToEdit.Departement = employer.Departement;
    }

    public void Delete(Employer selectedEmployer)
    {
        _dataSource.Remove( selectedEmployer ); 
    }
}
