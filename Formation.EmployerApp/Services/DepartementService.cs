using Formation.EmployerApp.Models;

namespace Formation.EmployerApp.Services;

internal class DepartementService
{
    public static List<Departement> GetAll()
    {
        return new List<Departement>
        {
            new Departement { Nom = "Ressources Humaines", Code = "RH" },
            new Departement { Nom = "Informatique", Code = "IT" },
            new Departement { Nom = "Finance", Code = "FIN" },
            new Departement { Nom = "Marketing", Code = "MKT" },
            new Departement { Nom = "Logistique", Code = "LOG" },
            new Departement { Nom = "COMPTA", Code = "COMPTA" },
            new Departement { Nom = "QUALITE", Code = "QUALITE" }
        };
    }
}
