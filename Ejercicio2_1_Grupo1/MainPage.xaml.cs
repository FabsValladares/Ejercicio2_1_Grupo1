using Ejercicio2_1_Grupo1.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xam.Forms.VideoPlayer;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Ejercicio2_1_Grupo1
{
    public partial class MainPage : ContentPage
    {
        String Videopath;
        public MainPage()
        {
            InitializeComponent();
        }

         //Capturar video con la camara

        public async void CapturarVideoCamara()
        {
            try
            {
                var video = await MediaPicker.CaptureVideoAsync();
                await LoadVideoAsync(video);
                Console.WriteLine($"CapturePhotoAsync COMPLETED: {Videopath}");
                //await DisplayAlert("as", PhotoPath, "ok");

                UriVideoSource uriVideoSurce = new UriVideoSource()
                {
                    Uri = Videopath
                };

                videoPlayer.Source = uriVideoSurce;

            }
            catch (FeatureNotSupportedException)
            {
                await DisplayAlert("Alerta", "La funcionalidad no es compatible con el dispositivo", "OK");

            }
            catch (PermissionException)
            {
                await DisplayAlert("Alerta","Los permisos necesarios no se han concedido", "OK");

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", $"CapturePhotoAsync THREW: {ex.Message}", "OK");
            }
        }

             async Task LoadVideoAsync(FileResult video)
             {
            // canceled
            if (video == null)
            {
                Videopath = null;
                return;
            }
            // guardar el video en el local storage
            var nuevoArchivo = System.IO.Path.Combine(FileSystem.CacheDirectory, video.FileName);
            using (var stream = await video.OpenReadAsync())
            using (var newStream = File.OpenWrite(nuevoArchivo))
                await stream.CopyToAsync(newStream);

              Videopath = nuevoArchivo; 
             }


        private void btnTomarVideo_Clicked(object sender, EventArgs e)
        {
           CapturarVideoCamara();

        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            IngresarDatos();
        }
        public async void IngresarDatos()
        {
            var videos = new Models.videos
            {
                videoUrl = Videopath,
                nombre = txtNombre.Text,
                descripcion = txtdescripcion.Text
            };

            var resultado = await App.Instancia.GuardarVideos(videos);

            if (resultado == 1)
            {
                await DisplayAlert("Mensaje", "Registro ingreso con exito", "ok");
                txtNombre.Text = txtdescripcion.Text = String.Empty;
            }
            else
            {
                await DisplayAlert("Error", "No se pudo Guardar el registro", "ok");
            }
        }

        private async void btnVerListado_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListadoVideos());
        }

        private void videoPlayer_PlayCompletion(object sender, EventArgs e)
        {

        }

      
    }
}
