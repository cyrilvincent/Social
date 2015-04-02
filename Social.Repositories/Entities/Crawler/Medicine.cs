using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Social.RepositoriesLibrary;
using Social.RepositoriesLibrary.Entities.Common;

namespace Social.RepositoriesLibrary.Entities.Crawler
{
    public enum MedicineType { Medicament, Para, Substance, Phyto }

    public class Medicine : IEntity
    {
        public AHref AHref { get; set; }
        public string Name { get; set; }

        public MedicineType Type { get; set; }
        public string FileName { get; set; }
        public string ComputeFileName {
            get
            {
                string res = null;
                if(Name!=null)
                    res = Name.NormalizeForFile();
                return res;
            }
        }

        public string ComputeName
        {
            get
            {
                string s = FileName.Substring(FileName.IndexOf("_") + 1);
                s = s.Substring(0, s.Length - ".htm".Length);
                return s.Replace("_", " ");
            }
        }

        public string Content { get; set; }

        public Medicine()
        {
            Content = "";
        }

        public override string ToString()
        {
            return Name + " " + ComputeFileName;
        }


    }
}
