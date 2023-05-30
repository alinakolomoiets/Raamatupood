using Raamatupood.Models;
using System;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Raamatupood.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DBRaamatPage : ContentPage
    {
        public DBRaamatPage()
        {
            InitializeComponent();
        }
        private void SaveRaamat(object sender, EventArgs e)
        {
            var raamat = (Raamat)BindingContext;
            if (!String.IsNullOrEmpty(raamat.RaamatuPealkiri))
            {
                App.Database.SaveItem(raamat);
            }
            this.Navigation.PopAsync();
        }
        private void DeleteRaamat(object sender, EventArgs e)
        {
            var raamat = (Raamat)BindingContext;
            App.Database.DeleteItem(raamat.Id);
            this.Navigation.PopAsync();
        }
        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}