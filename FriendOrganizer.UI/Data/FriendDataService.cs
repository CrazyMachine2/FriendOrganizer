using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Data
{
    public class FriendDataService : IFriendDataService
    {

        public IEnumerable<Friend> GetAll()
        {
            yield return new Friend { FirstName = "Bobe", LastName = "Turboto" };
            yield return new Friend { FirstName = "Stefko", LastName = "Oboista" };
            yield return new Friend { FirstName = "Mario", LastName = "Kitarista" };
            yield return new Friend { FirstName = "Forever", LastName = "Alone" };
        }
    }
}
