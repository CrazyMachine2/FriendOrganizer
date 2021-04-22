using FriendOrganizer.Model;
using System.Collections.Generic;

namespace FriendOrganizer.UI.Wrapper
{
    public class FriendWrapper : ModelWrapper<Friend>
    {
        public FriendWrapper(Friend model) : base(model)
        {

        }

        public int ID { get { return Model.ID; } }

        public string FirstName
        {
            get { return GetValue<string>(); }
            set{ SetValue(value); }
        }
        public string LastName
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public int? FavoriteLanguageID
        {
            get { return GetValue<int?>(); }
            set { SetValue(value); }
        }

        public ICollection<FriendPhoneNumber> PhoneNumbers
        {
            get { return GetValue<ICollection<FriendPhoneNumber>>(); }
            set { SetValue(value); }
        }
    }
}
