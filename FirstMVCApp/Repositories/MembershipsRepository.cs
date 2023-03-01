using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    public class MembershipsRepository
    {

        private readonly ProgrammingClubDataContext _context;
        public MembershipsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<MembershipModel> GetMemberships()
        {
            return _context.Memberships;
        }

        public void Add(MembershipModel model)
        {
            model.IdMembership = Guid.NewGuid();
            _context.Memberships.Add(model);
            _context.SaveChanges();
        }

        public MembershipModel GetMembershipById(Guid id)
        {
            MembershipModel membership = _context.Memberships.FirstOrDefault(x => x.IdMembership == id);
            return membership;
        }

        public void Update(MembershipModel model)
        {
            _context.Memberships.Update(model);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            MembershipModel membership = GetMembershipById(id);
            _context.Memberships.Remove(membership);
            _context.SaveChanges();
        }
    }
}