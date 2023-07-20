using Ejercicio2_1_Grupo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ejercicio2_1_Grupo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListadoVideos : ContentPage
    {
        public ListadoVideos()
        {
            InitializeComponent();
            verlistadoVideos();

        }

        public async void verlistadoVideos()
        {
            var listado =await App.Instancia.VerlistaVideos();
            listavideos.ItemsSource = listado;
        }

        private void listavideos_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            
        }

        private void listavideos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            listavideos.SelectedItem = null;
        }

        private async void Vervideo(object sender, EventArgs e)
        {
            SwipeItem item = sender as SwipeItem;
            videos models = item.BindingContext as videos;
            await Navigation.PushAsync(new  InformacionVideos(models));

        }

      
        
    }
}