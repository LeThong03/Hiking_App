using System.Collections.ObjectModel;

namespace Hiking_App;

public partial class MainPage : ContentPage
{
    int count = 0;
    App thisApp = Microsoft.Maui.Controls.Application.Current as App;
    private MySQLiteDatabase myDB;

    public MainPage()
    {
        InitializeComponent();

        thisApp.TripList = new ObservableCollection<Trip>();
        myDB = new MySQLiteDatabase();
    }

    private async void btnSubmit_Clicked(object sender, EventArgs e)
    {
        var response = await DisplayAlert("Confirmation", "Do you want to save?", "OK", "Cancel");
        if (response)
        {
            Trip p = new Trip(count++, this.txtName.Text,
                                        this.txtLocation.Text, this.dtpDateofHike.Date, this.cbxDifficult.SelectedItem.ToString(),
                                        this.swtParking.IsToggled, this.txtDescription.Text);
            thisApp.TripList.Add(p);
            myDB.insertTrip(p);
            await DisplayAlert("Information", "Information Confirmed", "OK");
        }
        SemanticScreenReader.Announce(btnSubmit.Text);
    }

    private void btnView_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new TripList(), true);
    }

    private void btnLoad_Trip_Clicked(object sender, EventArgs e)
    {
        thisApp.TripList = myDB.loadTrip();
    }
}

