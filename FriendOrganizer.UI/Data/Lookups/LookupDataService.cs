using FriendOrganizer.DataAccess;
using FriendOrganizer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.Data.Lookups
{
    public class LookupDataService : IFriendLookupDataService, IProgrammingLanguageLookupDataService
    {
        private FriendOrganizerContext _context;

        public LookupDataService(FriendOrganizerContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LookupItem>> GetFriendLookupAsync()
        {
            return await _context.Friends
                .Select(f => new LookupItem { ID = f.ID, DisplayMember = f.FirstName + " " + f.LastName })
                .ToListAsync();
        }

        public async Task<IEnumerable<LookupItem>> GetProgrammingLanguageLookupAsync()
        {
            return await _context.ProgrammingLanguages
                .Select(pl => new LookupItem { ID = pl.ID, DisplayMember = pl.Name })
                .ToListAsync();
        }
    }
}
