using NUnit.Framework;
using Social.RepositoriesLibrary.Entities;
using Social.RepositoriesLibrary.Entities.Common;
using Social.RepositoriesLibrary.Entities.Crawler;
using Social.RepositoriesLibrary.Repositories;
using Social.RepositoriesLibrary.Repositories.EF;
using Social.RepositoriesLibrary.Repositories.Files;
using Social.RepositoriesLibrary.TransportObjects;
using Social.ServicesLibrary.Factories;
using Social.ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.UnitTests
{
    [TestFixture]
    public class FileUnitTest
    {

        private string path = @"D:\CVC\Divers\Social\NET\Social\Social.EurekaSanteCrawlerConsole\bin\Debug\output\";

        [Test]
        [Category("File")]
        public void TF01ComputeNameTest()
        {
            Medicine m = new Medicine { FileName = "medicament_ZYMAD_80_000_et_200_000_UI.htm" };
            string s = m.ComputeName;
            Assert.AreEqual("ZYMAD 80 000 et 200 000 UI", s);
        }

        [Test]
        [Category("File")]
        public void TF02GetByFileNameTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            Medicine m = r.GetByFileName("medicament_A_313_capsule.htm", true);
            Assert.NotNull(m.Content);
        }

        [Test]
        [Category("File")]
        public void TF03GetAllFileNameTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            List<string> l = r.GetAllFileNames();
            Assert.IsTrue(l.Count > 0);
        }

        [Test]
        [Category("File")]
        public void TF04PrefixTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            Medicine m = r.GetByFileName("medicament_ZYMAD_80_000_et_200_000_UI.htm", false);
            Assert.AreEqual(MedicineType.Medicament, m.Type);
        }

        [Test]
        [Category("File")]
        public void TF05GetAllTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            r.Load();
            List<Medicine> l = r.GetAll().ToList();
            Assert.IsTrue(l.Count>0);
        }

        [Test]
        [Category("File")]
        public void TF07GetByTypeTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            r.Load();
            List<Medicine> l = r.GetByType(MedicineType.Medicament).ToList();
            Assert.IsTrue(l.Count > 0);
        }

        [Test]
        [Category("File")]
        public void TF08GetByNameTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            r.Load();
            List<Medicine> l = r.GetByName("abbe").ToList();
            Assert.IsTrue(l.Count > 0);
        }

        [Test]
        [Category("File")]
        public void TF09GetByTypeAndNameTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            r.Load();
            List<Medicine> l = r.GetByTypeAndName(MedicineType.Medicament, "abbe").ToList();
            Assert.IsTrue(l.Count > 0);
        }

        [Test]
        [Category("File")]
        public void TF10GetByNamePerfTest()
        {
            MedicineFileRepository r = new MedicineFileRepository { Path = path };
            r.Load();
            List<Medicine> l = r.GetByName("e").ToList();
            Assert.IsTrue(l.Count > 0);
        }
    }
}
