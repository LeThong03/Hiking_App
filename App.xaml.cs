using System.Collections.ObjectModel;

namespace Hiking_App
{
    public partial class App : Application
    {
        public ObservableCollection<Trip> TripList { get; set; }
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
