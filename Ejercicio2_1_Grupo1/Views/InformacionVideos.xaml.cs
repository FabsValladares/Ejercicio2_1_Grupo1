using Ejercicio2_1_Grupo1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Ejercicio2_1_Grupo1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InformacionVideos : ContentPage
    {
        public InformacionVideos(videos datos)
        {
            InitializeComponent();
            txtnombre.Text = datos.nombre;
            txtdescripcion.Text = datos.descripcion;
            UriVideoSource uriVideoSurce = new UriVideoSource()
            {
                Uri = datos.videoUrl
            };


            videoPlayer.Source = uriVideoSurce;
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {

        }
    }
}
