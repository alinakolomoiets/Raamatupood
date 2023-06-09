using Raamatupood.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Raamatupood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBListPage : ContentPage
    {
        public DBListPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            raamatList.ItemsSource = App.Database.GetItems();
            base.OnAppearing();
        }
        private async void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Raamat selectedRaamat = (Raamat)e.SelectedItem;
            DBRaamatPage raamatPage = new DBRaamatPage();
            raamatPage.BindingContext = selectedRaamat;
            await Navigation.PushAsync(raamatPage);
        }
        private async void CreateRaamat(object sender, EventArgs e)
        {
            Raamat raamat = new Raamat();
            DBRaamatPage raamatPage = new DBRaamatPage();
            raamatPage.BindingContext = raamat;
            await Navigation.PushAsync(raamatPage);
        }
        private async void ShowAllBooks(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DBListPage());
        }

        private async void KategooriaRaamat(object sender, EventArgs e)
        {
            var kategooriad = App.Database.GetDistinctKategooriad(); 
            var selectedKategooria = await DisplayActionSheet("Vali kategooria", "Tühista", null, kategooriad.ToArray());
            if (selectedKategooria != null && selectedKategooria != "Tühista")
            {
                var filteredRaamatud = App.Database.GetItemsByKategooria(selectedKategooria); 
                raamatList.ItemsSource = filteredRaamatud;
            }
        }
        private async void SortButton_Clicked(object sender, EventArgs e)
        {
            var kapp = await DisplayActionSheet("Vali kapp", "Tühista", null, "Kapp: 1", "Kapp: 2", "Kapp: 3", "Kapp: 4", "Kapp: 5", "Kapp: 6", "Kapp: 7", "Kapp: 8", "Kapp: 9");
            if (kapp != null && kapp != "Tühista")
            {
                var riul = await DisplayActionSheet("Vali riiul", "Tühista", null, "Riul: 1", "Riul: 2", "Riul: 3", "Riul: 4", "Riul: 5", "Riul: 6");
                if (riul != null && riul != "Tühista")
                {
                    var filteredRaamatud = App.Database.GetItemsByKappAndRiul(kapp, riul); 
                    raamatList.ItemsSource = filteredRaamatud;
                }
            }
        }



    }
}