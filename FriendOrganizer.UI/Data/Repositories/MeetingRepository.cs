using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class MeetingRepository : GenericRepository<Meeting, FriendOrganizerContext>, IMeetingRepository
    {
        public MeetingRepository(FriendOrganizerContext context) : base(context)
        {
        }

        public async override Task<Meeting> GetByIdAsync(int id)
        {
            return await _context.Meetings
                .Include(m => m.Friends)
                .SingleAsync(m => m.ID == id);
        }
    }
}
