using FirstMVCApp.DataContext;
using FirstMVCApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstMVCApp.Repositories
{
    // clase repository sunt clase care implementeaza operatiile CRUD pe Baza de Date
    public class AnnouncementsRepository
    {
        private readonly ProgrammingClubDataContext _context;
        public AnnouncementsRepository(ProgrammingClubDataContext context)
        {
            _context = context;
        }

        public DbSet<AnnouncementModel> GetAnnouncements()  //get all drom table
        {
            return _context.Announcements;
        }

        public void Add(AnnouncementModel model)
        {
            model.IdAnnouncement = Guid.NewGuid(); //setam id-ul
            _context.Announcements.Add(model); //adaugam modelul in layer-ul ORM (ProgrammingClubDataContext)
            _context.SaveChanges(); //commit to database
        }

        public AnnouncementModel GetAnnouncementById(Guid id)  //get announcement for a cartain ID -> page Details
        {
            AnnouncementModel announcement = _context.Announcements.FirstOrDefault(x => x.IdAnnouncement == id);
            return announcement;
        }

        public void Update(AnnouncementModel model)
        {
            AnnouncementModel announcement = GetAnnouncementById(model.IdAnnouncement);
            if (announcement != null)
            {
                _context.Announcements.Update(model);
                _context.SaveChanges();
            }
        }

        public void Delete(Guid id)
        {
            AnnouncementModel announcement = GetAnnouncementById(id);
            if (announcement != null)
            {
                _context.Announcements.Remove(announcement);
                _context.SaveChanges();
            }
        }
    }
}