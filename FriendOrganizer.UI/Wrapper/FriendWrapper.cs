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
            set
            { SetValue(value); }
        }
        public string LastName
        {
            get { return GetValue<string>(); }
            set
            { SetValue(value); }
        }

        public string Email
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }
    }
}
