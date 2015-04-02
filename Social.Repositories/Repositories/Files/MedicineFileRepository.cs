using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.Repositories.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.RepositoriesLibrary.Repositories.Files
{
    public class MedicineFileRepository : AbstractFileRepository<Medicine>
    {

        private static Dictionary<string, Medicine> dico = null;

        public MedicineFileRepository() {
            Prefix = "/medicament_";
            Path = "./output";
            Suffix = ".htm";
        }

        public override void Insert(Medicine m) {
            if (!File.Exists(Path))
                Directory.CreateDirectory(Path);
            string path = Path + Prefix + m.ComputeFileName + Suffix;
            Writer = new StreamWriter(path, false, Encoding.UTF8); //Encoding.GetEncoding("ISO-8859-1"));
            Console.WriteLine(path);
            Writer.Write("<h1>"+m.Name+"</h1> "+ m.Content);
        }

        public Medicine GetByFileName(string fileName, bool withContent = true)
        {
            string path = Path + fileName;
            Medicine m = new Medicine { FileName = fileName };
            if (withContent)
            {
                lock (new Object())
                {
                    Reader = new StreamReader(path, true);
                    m.Content = Reader.ReadToEnd();
                    Reader.Close();
                }
            }
            string prefix = fileName.Substring(0, fileName.IndexOf("_"));
            if (prefix == MedicineType.Medicament.ToString().ToLower())
                m.Type = MedicineType.Medicament;
            else if (prefix == MedicineType.Para.ToString().ToLower())
                m.Type = MedicineType.Para;
            else if (prefix == MedicineType.Phyto.ToString().ToLower())
                m.Type = MedicineType.Phyto;
            else if (prefix == MedicineType.Substance.ToString().ToLower())
                m.Type = MedicineType.Substance;
            else throw new RepositoryException("Bad file prefix " + prefix, null);
            return m;
        }

        public void Reset()
        {
            List<string> l = GetAllFileNames();
            lock (new Object())
            {
                dico = new Dictionary<string, Medicine>();
                foreach (string s in l)
                {
                    string fileName = s.Substring(s.LastIndexOf("\\") + 1);
                    Medicine m = GetByFileName(fileName, false);
                    dico.Add(m.FileName, m);
                }
            }
        }

        public void Load()
        {
            if (!isLoaded) Reset();
        }

        public bool isLoaded
        {
            get {return dico != null;}
        }

        public List<string> GetAllFileNames()
        {
            return Directory.GetFiles(Path).OrderBy(s => s).ToList();
        }

        public override IQueryable<Medicine> GetAll()
        {
            return dico.Values.OrderBy(m => m.FileName).AsQueryable();
        }

        public IEnumerable<Medicine> GetByType(MedicineType type)
        {
            return GetAll().Where(m => m.Type == type);
        }

        public IEnumerable<Medicine> GetByName(string name)
        {
            //return GetAll().Where(m => m.FileName.ToLower().RemoveDiacritics().Contains(name.ToLower()));
            IEnumerable<Medicine> firsts = GetAll().Where(m => m.ComputeName.ToLower().RemoveDiacritics().StartsWith(name.ToLower()));
            IEnumerable<Medicine> seconds = GetAll().Where(m => m.ComputeName.ToLower().RemoveDiacritics().Contains(name.ToLower()));
            return firsts.Union(seconds);
        }

        public IEnumerable<Medicine> GetByTypeAndName(MedicineType type, string name)
        {
            return GetByName(name).Where(m => m.Type == type);
        }
    }
}
