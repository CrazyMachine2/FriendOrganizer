using Prism.Events;

namespace FriendOrganizer.UI.Event
{
    public class OpenDetailViewEvent : PubSubEvent<OpenDetailViewEventArgs>
    {
    }

    public class OpenDetailViewEventArgs
    {
        public int? ID { get; set; }
        public string ViewModelName { get; set; }
    }
}
