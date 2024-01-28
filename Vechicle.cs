using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSalonSamochodowy
{
    internal abstract class Vechicle
    {
        protected string Brand = "-brak danych-";
        protected string Model = "-brak danych-";
        protected int Year = 0;
        protected string Color = "-brak danych-";
        protected string Fuel = "-brak danych-";
        protected int MileAge = 0;
        protected int HorsePower = 0;
        protected float Price = 0f;
        protected string RegNumber = "-brak danych";
        public abstract void AddVechicle();
        public abstract void ShowVechicles();
        public abstract void UpdateVechicle();
        public abstract void RemoveVechicle();
    }
}