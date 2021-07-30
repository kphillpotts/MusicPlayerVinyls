using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MusicPlayerVinyls.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumArtView : ContentView
    {
        private double panAmount;

        public AlbumArtView()
        {
            InitializeComponent();
        }





        public double PanAmount
        {
            get => panAmount;
            set
            {
                panAmount = value;
                const int MAX_TRANSLATION = 50;

                var scaledTranslation = value * .5;

                // translation
                VinylImageView.TranslationX = scaledTranslation;
                AlbumArtImageView.TranslationX = -VinylImageView.TranslationX;
                VinylCenterView.TranslationX = VinylImageView.TranslationX;

            }
        }
    }
}