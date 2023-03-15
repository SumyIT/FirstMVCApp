using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using FirstMVCApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class MembersController : Controller
    {
        private readonly MembersRepository _repository;
        public MembersController(MembersRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var members = _repository.GetMembers();
            return View("Index", members);
        }

        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            MemberModel member = new MemberModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(member);
                _repository.Add(member);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            MemberModel member = _repository.GetMemberById(id);
            return View("Edit", member);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            MemberModel member = new();
            TryUpdateModelAsync(member);
            _repository.Update(member);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            MemberModel member = _repository.GetMemberById(id);
            return View("Delete", member);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            MemberModel member = _repository.GetMemberById(id);
            return View("Details", member);
        }

        public IActionResult DetailsWithCodeSnippets(Guid id)
        {
            MemberCodeSnippetViewModel viewModel = _repository.GetMemberCodeSnippets(id);
            return View("DetailsWithCodeSnippets", viewModel);
        }
    }
}
