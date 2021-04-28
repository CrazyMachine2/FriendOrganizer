using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendOrganizer.UI.Event
{
    public class AfterDetailSavedEvent : PubSubEvent<AfterDetailSavedEventArgs>
    {
    }

    public class AfterDetailSavedEventArgs
    {
        public int ID { get; set; }
        public string DisplayMember { get; set; }
        public string ViewModelName { get; set; }
    }
}
