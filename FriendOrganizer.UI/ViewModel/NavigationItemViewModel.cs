namespace FriendOrganizer.UI.ViewModel
{
    public class NavigationItemViewModel : ViewModelBase
    {

        public NavigationItemViewModel(int id, string displayMember)
        {
            ID = id;
            DisplayMember = displayMember;
        }
        private string _displayMember;

        public string DisplayMember
        {
            get { return _displayMember; }
            set
            {
                _displayMember = value;
                OnPropertyChanged();
            }
        }

        public int ID { get; }
    }
}
