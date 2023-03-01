using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly AnnouncementsRepository _repository;
        public AnnouncementsController(AnnouncementsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var announcements = _repository.GetAnnouncements();
            return View("Index", announcements);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            AnnouncementModel announcement= new AnnouncementModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(announcement); //se mapeaza datele din formular pe modelul announcement
                _repository.Add(announcement);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            AnnouncementModel announcement = _repository.GetAnnouncementById(id);
            return View("Edit", announcement);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            AnnouncementModel announcement = new();
            TryUpdateModelAsync(announcement);
            _repository.Update(announcement);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            AnnouncementModel announcement = _repository.GetAnnouncementById(id);
            return View("Delete", announcement);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            AnnouncementModel announcement = _repository.GetAnnouncementById(id);
            return View("Details", announcement);
        }
    }
}