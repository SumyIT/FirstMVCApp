using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembershipsController : Controller
    {
        private readonly MembershipsRepository _repository;
        public MembershipsController(MembershipsRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var memberships = _repository.GetMemberships();
            return View("Index", memberships);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MembershipModel membership = new MembershipModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(membership);
                _repository.Add(membership);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            MembershipModel membership = _repository.GetMembershipById(id);
            return View("Edit", membership);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MembershipModel membership = new();
            TryUpdateModelAsync(membership);
            _repository.Update(membership);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            MembershipModel membership = _repository.GetMembershipById(id);
            return View("Delete", membership);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            MembershipModel membership = _repository.GetMembershipById(id);
            return View("Details", membership);
        }
    }
}
