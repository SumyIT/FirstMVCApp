using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace FirstMVCApp.Tests.RepositoriesTests
{
    [TestClass]
    public class AnnouncementRepositoryTests
    {
        private readonly AnnouncementsRepository _repository;
        private readonly ProgrammingClubDataContext _contextInMemory;

        public AnnouncementRepositoryTests()
        {
            _contextInMemory = Helpers.DBContextHelper.GetDatabaseContext();
            _repository = new AnnouncementsRepository(_contextInMemory);
        }

        [TestMethod]
        public void GetAllAnnouncements_ExistAnnouncements()
        {
            //Arrange -> vom crea niste announcements fake
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "Tags1",
                Text = "Announcemment",
                Title = "Event1",
            };

            AnnouncementModel announcement2 = new AnnouncementModel
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "Tags1",
                Text = "Announcemment",
                Title = "Event1",
            };

            List<AnnouncementModel> list = new List<AnnouncementModel>();
            list.Add(announcement1);
            list.Add(announcement2);
            Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);
            Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement2);

            //Act -> chemam metoda din repository
            List<AnnouncementModel> dbAnnouncements = _repository.GetAnnouncements().ToList();

            //Assert -> verifica rezultatul 
            Assert.AreEqual(list.Count, dbAnnouncements.Count);
        }

        [TestMethod]
        public void GetAnnouncements_WithoutDataInDB()
        {
            //Act -> chemam metoda din repository
            List<AnnouncementModel> dbAnnouncements = _repository.GetAnnouncements().ToList();

            //Assert -> verifica rezultatul 
            Assert.AreEqual(0, dbAnnouncements.Count);
        }

        [TestMethod]
        public void GetAnnouncementById()
        {
            //Arrange -> vom crea niste announcements fake
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "Tags1",
                Text = "Announcemment",
                Title = "Event1",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);

            Guid id = (Guid)announcement1.IdAnnouncement;

            //Act -> chemam metoda din repository
            var result = _repository.GetAnnouncementById(id);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(announcement1.Title, result.Title);
            Assert.AreEqual(announcement1.Tags, result.Tags);
            Assert.AreEqual(announcement1.ValidFrom, result.ValidFrom);
            Assert.AreEqual(announcement1.ValidTo, result.ValidTo);
            Assert.AreEqual(announcement1.EventDate, result.EventDate);
        }

        [TestMethod]
        public void GetAnnouncementById_WhenNotExists()
        {
            // Arrange 
            Guid id = Guid.NewGuid();

            // Act
            var result = _repository.GetAnnouncementById(id);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteAnnouncement_AnnouncementNotExist()
        {
            //Arrange 
            Guid id = Guid.NewGuid();

            //Act
            _repository.Delete(id);
            var result = _repository.GetAnnouncementById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void DeleteAnnouncement_AnnouncementExists()
        {
            //Arrange -> vom crea un announcement
            Guid id = Guid.NewGuid();
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = id,
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "Tags1",
                Text = "Announcemment",
                Title = "Event1",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);

            //Act
            _repository.Delete(id);
            var result = _repository.GetAnnouncementById(id);

            //Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void UpdateAnnouncement_AnnouncementExist()
        {
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "tags1",
                Text = "Announcemment",
                Title = "Event1",
            };
            AnnouncementModel announcement = Helpers.DBContextHelper.AddAnnouncement(_contextInMemory, announcement1);
            announcement.Tags = "tagsUpdated";
            _repository.Update(announcement);

            AnnouncementModel updatedModel = _repository.GetAnnouncementById((Guid)announcement1.IdAnnouncement);

            Assert.IsNotNull(updatedModel);
            Assert.AreEqual(announcement.Tags, updatedModel.Tags);
        }

        [TestMethod]
        public void UpdateAnnouncement_AnnouncementNotExist()
        {
            AnnouncementModel announcement1 = new AnnouncementModel
            {
                IdAnnouncement = Guid.NewGuid(),
                ValidFrom = new DateTime(2023, 10, 10),
                ValidTo = new DateTime(2023, 10, 10),
                EventDate = new DateTime(2023, 11, 11),
                Tags = "Tags1",
                Text = "Announcemment",
                Title = "Event1",
            };

            _repository.Update(announcement1);

            AnnouncementModel updatedModel = _repository.GetAnnouncementById((Guid)announcement1.IdAnnouncement);

            Assert.IsNull(updatedModel);
        }
    }
}
