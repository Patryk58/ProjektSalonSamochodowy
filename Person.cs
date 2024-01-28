using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSalonSamochodowy
{
    internal abstract class Person
    {
        protected string FirstName = "-brak danych-";
        protected string LastName = "-brak danych-";
        protected string Address = "-brak danych-";
        protected string PhoneNumber = "-brak danych-";
        protected string Email = "-brak danych-"; 
        public abstract void AddPerson();
        public abstract void ShowPersons();
        public abstract void UpdatePerson();
        public abstract void RemovePerson();
    }
}