using Prism.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace FriendOrganizer.UI.Event
{
    public class AfterFriendSavedEvent : PubSubEvent<AfterFriendSavedEventArgs>
    {
    }

    public class AfterFriendSavedEventArgs
    {
        public int ID { get; set; }
        public string DisplayMember { get; set; }
    }
}
