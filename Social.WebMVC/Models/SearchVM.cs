using Social.RepositoriesLibrary.Entities.Crawler;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Social.WebMVC.Models
{
    public enum MedicineTypeVM
    {
        [Description("")]
        All,
        [Description("Médicament")]
        Medicament,
        [Description("Parapharmacie")]
        Para,
        [Description("Substance")]
        Substance,
        [Description("Phytothérapie")]
        Phyto
    }
    public class SearchVM<T>
    {


        public string Text { get; set; }

        public IEnumerable<T> Results { get; set; }

        public MedicineTypeVM Type { get; set; }

        public MedicineType GetMedicineType()
        {
            if (Type == MedicineTypeVM.All) throw new ArgumentException(Type + " not adaptable to MedicineType");
            MedicineType mt = (MedicineType)((int)Type - 1);
            return mt;
        }

        public SearchVM()
        {
            Results = new List<T>();
        }
    }
}