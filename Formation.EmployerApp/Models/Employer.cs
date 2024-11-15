using Formation.EmployerApp.Enums;

namespace Formation.EmployerApp.Models;

public class Employer
{
    // Code Smell (Mauvaise pratique de code)
    // DRY : Don't Repeat Yourself
    public static Employer Empty()
    {
        return new Employer
            (
            id: 0,
            prenom: string.Empty,
            nom: string.Empty,
            age: 0,
            poste: 0,
            identifiantNationale: string.Empty,
            dateNaissance: DateTime.UtcNow,
            departementCode: string.Empty,
            departement: null
            );
    }

    public Employer(int id,
        string nom,
        string prenom,
        int age,
        Poste poste,
        string identifiantNationale,
        DateTime dateNaissance,
        string departementCode,
        Departement departement)
    {
        Id = id;
        Nom = nom;
        Prenom = prenom;
        Age = age;
        Poste = poste;
        IdentifiantNationale = identifiantNationale;
        DateNaissance = dateNaissance;
        DepartementCode = departementCode;
        Departement = departement;
    }

    public int Id { get; set; }

    public string Nom { get; set; }

    public string Prenom { get; set; }

    public int Age { get; set; }

    public Poste Poste { get; set; } // Enum

    public string IdentifiantNationale { get; set; }

    public DateTime DateNaissance { get; set; } = DateTime.Now;

    public string DepartementCode { get; set; }

    public Departement Departement { get; set; }
}
