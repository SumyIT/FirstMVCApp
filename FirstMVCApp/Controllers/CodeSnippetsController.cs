using FirstMVCApp.Models;
using FirstMVCApp.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FirstMVCApp.Controllers
{
    public class CodeSnippetsController : Controller
    {
        private readonly CodeSnippetsRepository _repository;

        private readonly MembersRepository _membersRepository;
        public CodeSnippetsController(CodeSnippetsRepository repository, MembersRepository membersRepository)
        {
            _repository = repository;
            _membersRepository = membersRepository;
        }

        public IActionResult Index()
        {
            var codeSnippets = _repository.GetCodeSnippets();
            return View("Index", codeSnippets);
        }

        public IActionResult Create()
        {
            var members = _membersRepository.GetMembers();
            ViewBag.data = members;
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(IFormCollection collection)
        {
            CodeSnippetModel codeSnippet = new CodeSnippetModel();
            if (ModelState.IsValid)
            {
                TryUpdateModelAsync(codeSnippet);
                _repository.Add(codeSnippet);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Edit(Guid id)
        {
            CodeSnippetModel codeSnippet = _repository.GetCodeSnippetById(id);
            return View("Edit", codeSnippet);
        }

        [HttpPost]
        public IActionResult Edit(Guid id, IFormCollection collection)
        {
            CodeSnippetModel codeSnippet = new();
            TryUpdateModelAsync(codeSnippet);
            _repository.Update(codeSnippet);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(Guid id)
        {
            CodeSnippetModel codeSnippet = _repository.GetCodeSnippetById(id);
            return View("Delete", codeSnippet);
        }

        [HttpPost]
        public IActionResult Delete(Guid id, IFormCollection collection)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid id)
        {
            CodeSnippetModel codeSnippet = _repository.GetCodeSnippetById(id);
            return View("Details", codeSnippet);
        }
    }
}
