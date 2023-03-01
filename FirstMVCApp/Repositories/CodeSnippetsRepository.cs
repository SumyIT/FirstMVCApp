using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class CodeSnippetsRepository
    {

        private readonly ProgrammingClubDataContext _context;
        public CodeSnippetsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<CodeSnippetModel> GetCodeSnippets()
        {
            return _context.CodeSnippets;
        }

        public void Add(CodeSnippetModel model)
        {
            model.IdCodeSnippet = Guid.NewGuid();
            _context.CodeSnippets.Add(model);
            _context.SaveChanges();
        }

        public CodeSnippetModel GetCodeSnippetById(Guid id)
        {
            CodeSnippetModel codeSnippet = _context.CodeSnippets.FirstOrDefault(x => x.IdCodeSnippet == id);
            return codeSnippet;
        }

        public void Update(CodeSnippetModel model)
        {
            _context.CodeSnippets.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            CodeSnippetModel codeSnippet = GetCodeSnippetById(id);
            _context.CodeSnippets.Remove(codeSnippet);
            _context.SaveChanges();
        }
    }
}