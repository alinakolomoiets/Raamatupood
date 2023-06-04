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
        private async void KategooriaRaamat(object sender, EventArgs e)
        {
            var kategooriad = App.Database.GetDistinctKategooriad(); // Получить список уникальных жанров книг
            var selectedKategooria = await DisplayActionSheet("Vali kategooria", "Cancel", null, kategooriad.ToArray());
            if (selectedKategooria != null && selectedKategooria != "Cancel")
            {
                var filteredRaamatud = App.Database.GetItemsByKategooria(selectedKategooria); // Получить книги по выбранному жанру
                raamatList.ItemsSource = filteredRaamatud;
            }
        }
        private async void HindRaamat(object sender, EventArgs e)
        {
            var hind = App.Database.GetDistinctHind(); 
            var selectedHind = await DisplayActionSheet("Vali kategooria", "Cancel", null, hind.ToArray());
            if (selectedHind != null && selectedHind != "Cancel")
            {
                var filteredRaamatud = App.Database.GetItemsByHind(selectedHind); 
                raamatList.ItemsSource = filteredRaamatud;
            }
        }
    }
}