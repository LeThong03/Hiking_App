
namespace Hiking_App;

public partial class TripList : ContentPage
{
    private App thisApp = Application.Current as App;
    private MySQLiteDatabase myDB;
    public TripList()
    {
        InitializeComponent();
        myDB = new MySQLiteDatabase();
        collectionView.ItemsSource = thisApp.TripList;
    }

    private async void OnDeleteAllClicked(object sender, EventArgs e)
    {
        var confirm = await DisplayAlert("Confirm", "Do you want to delete all trip", "Yes", "No");
        if (confirm)
        {
            myDB.DeleteAllTrips();
            thisApp.TripList.Clear();
            await DisplayAlert("Info","All data has been delete","OK");
        }
    }
}