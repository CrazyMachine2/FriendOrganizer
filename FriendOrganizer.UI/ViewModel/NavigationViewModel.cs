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
        private readonly IMeetingLookupDataService _meetingLookupService;
        private readonly IEventAggregator _eventAggregator;

        public NavigationViewModel(IFriendLookupDataService friendLookupService,
            IMeetingLookupDataService meetingLookupService,
            IEventAggregator eventAggregator)
        {
            
            _friendLookupService = friendLookupService;
            _meetingLookupService = meetingLookupService;

            Friends = new ObservableCollection<NavigationItemViewModel>();
            Meetings = new ObservableCollection<NavigationItemViewModel>();

            _eventAggregator = eventAggregator;
            _eventAggregator.GetEvent<AfterDetailSavedEvent>().Subscribe(AfterDetailSaved);
            _eventAggregator.GetEvent<AfterDetailDeletedEvent>().Subscribe(AfterDetailDeleted);
        }

        public ObservableCollection<NavigationItemViewModel> Friends { get; set; }

        public ObservableCollection<NavigationItemViewModel> Meetings { get; set; }

        public async Task LoadAsync()
        {
            var lookups = await _friendLookupService.GetFriendLookupAsync();
            Friends.Clear();
            foreach (var item in lookups)
            {
                Friends.Add(new NavigationItemViewModel(item.ID, item.DisplayMember,
                    nameof(FriendDetailViewModel),
                    _eventAggregator));
            }

            lookups = await _meetingLookupService.GetMeetingLookupAsync();
            Meetings.Clear();
            foreach (var item in lookups)
            {
                Meetings.Add(new NavigationItemViewModel(item.ID, item.DisplayMember,
                    nameof(MeetingDetailViewModel),
                    _eventAggregator));
            }
        }

        private void AfterDetailSaved(AfterDetailSavedEventArgs args)
        {
            switch (args.ViewModelName)
            {
                case nameof(FriendDetailViewModel):
                    AfterDetailSaved(Friends, args);
                    break;

                case nameof(MeetingDetailViewModel):
                    AfterDetailSaved(Meetings, args);
                    break;
            }
        }

        private void AfterDetailSaved(ObservableCollection<NavigationItemViewModel> items, AfterDetailSavedEventArgs args)
        {
            var lookupItem = items.SingleOrDefault(l => l.ID == args.ID);
            if (lookupItem == null)
            {
                items.Add(new NavigationItemViewModel(args.ID, 
                    args.DisplayMember,
                    args.ViewModelName,
                    _eventAggregator));
            }
            else
            {
                lookupItem.DisplayMember = args.DisplayMember;
            }
        }

        private void AfterDetailDeleted(AfterDetailDeletedEventArgs args)
        {
            switch (args.ViewModelName)
            {
                case nameof(FriendDetailViewModel):
                    AfterDetailDeleted(Friends, args);
                    break;
                case nameof(MeetingDetailViewModel):
                    AfterDetailDeleted(Meetings, args);
                    break;
            }
        }

        private void AfterDetailDeleted(ObservableCollection<NavigationItemViewModel> items, AfterDetailDeletedEventArgs args)
        {
            var item = items.SingleOrDefault(i => i.ID == args.ID);
            if (items != null)
            {
                items.Remove(item);
            }
        }
    }
}
