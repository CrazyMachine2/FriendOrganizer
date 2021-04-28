using FriendOrganizer.UI.Event;
using Prism.Commands;
using Prism.Events;
using System;
using System.Windows.Input;

namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {
        private string _displayMember;
        private string _detailViewModelName;

        public NavigationItemViewModel(int id, string displayMember, 
            string detailViewModelName,
            IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            ID = id;
            DisplayMember = displayMember;
            _detailViewModelName = detailViewModelName;

            OpenDetailViewCommand = new DelegateCommand(OnOpenDetailViewExecute);
        }

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        private IEventAggregator _eventAggregator;

        public int ID { get; }

        public ICommand OpenDetailViewCommand { get; }

        private void OnOpenDetailViewExecute()
        {
            _eventAggregator.GetEvent<OpenDetailViewEvent>()
                    .Publish(new OpenDetailViewEventArgs { ID = ID, ViewModelName = _detailViewModelName});
        }

    }
}
