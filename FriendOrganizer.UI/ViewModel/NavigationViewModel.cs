using FriendOrganizer.UI.Data.Lookups;
using FriendOrganizer.UI.Event;
using Prism.Events;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationViewModel : ViewModelBase, INavigationViewModel
    {
        private readonly IFriendLookupDataService _friendLookupService;
        private readonly IEventAggregator _eventAggregator;

        public NavigationViewModel(IFriendLookupDataService friendLookupService,
            IEventAggregator eventAggregator)
        {
            Friends = new ObservableCollection<NavigationItemViewModel>();
            _friendLookupService = friendLookupService;
            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterFriendSavedEvent>().Subscribe(AfterFriendSaved);
            _eventAggregator.GetEvent<AfterFriendDeletedEvent>().Subscribe(AfterFriendDeleted);
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        public async Task LoadAsync()
        {
            var lookups = await _friendLookupService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookups)
            {
                Friends.Add(new NavigationItemViewModel(item.ID, item.DisplayMember, _eventAggregator));
            }
        }

        private void AfterFriendSaved(AfterFriendSavedEventArgs obj)
        {
            var lookupItem = Friends.SingleOrDefault(l => l.ID == obj.ID);
            if(lookupItem == null)
            {
                Friends.Add(new NavigationItemViewModel(obj.ID, obj.DisplayMember, _eventAggregator));
            } else
            {
                lookupItem.DisplayMember = obj.DisplayMember;
            }
        }

        private void AfterFriendDeleted(int friendId)
        {
            var friend = Friends.SingleOrDefault(f => f.ID == friendId);
            if(friend != null)
            {
                Friends.Remove(friend);
            }
        }
    }
}
