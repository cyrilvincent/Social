using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.Repositories.Files;
using Social.ServicesLibrary.Services.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.ServicesLibrary.Services
{
    public class MedicineService
    {
        private MedicineFileRepository repository;
        public MedicineService(string path)
        {
            repository = new MedicineFileRepository { Path = path };
            repository.Load();
        }

        public IEnumerable<Medicine> GetByName(string name, int take)
        {
            return repository.GetByName(name).Take(take);
        }
    }
}
