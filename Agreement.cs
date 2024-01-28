using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSalonSamochodowy
{
    internal abstract class Agreement
    {
        protected string DateConclusion = "-brak danych-";
        protected string ContractNumber = "-brak danych-";
        protected string VechicleRegNumber = "-brak danych-";
        protected string NameSurnameClient = "-brak danych-";
        protected string NameSurnameEmployee = "-brak danych-";
        public abstract void AddAgreement();
        public abstract void ShowAgreements();
        public abstract void UpdateAgreement();
        public abstract void RemoveAgreement();
    }
}