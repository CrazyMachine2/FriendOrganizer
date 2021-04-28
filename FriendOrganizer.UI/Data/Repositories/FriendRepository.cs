using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Repositories
{
    public class FriendRepository : GenericRepository<Friend, FriendOrganizerContext>, IFriendRepository
    {
        public FriendRepository(FriendOrganizerContext context)
            : base(context)
        {
        }

        public override async Task<Friend> GetByIdAsync(int friendId)
        {
            return await _context.Friends
                .Include(f => f.PhoneNumbers)
                .SingleAsync(f => f.ID == friendId);
        }

        public void RemovePhoneNumber(FriendPhoneNumber model)
        {
            _context.FriendPhoneNumbers.Remove(model);
        }
    }
}
