using MusicPlayerVinyls.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MusicPlayerVinyls
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    break;
                case GestureStatus.Running:
                    ((MainViewModel)this.BindingContext).PanValue = e.TotalX;
                    break;
                case GestureStatus.Completed:
                    AnimateToZero();
                    break;
                case GestureStatus.Canceled:
                    break;
            }
        }

        private void AnimateToZero()
        {
            var vm = ((MainViewModel)this.BindingContext);
            var start = vm.PanValue;
            var end = 0;

            var movement = new Animation((v) => vm.PanValue = v, start, end, Easing.SpringOut);

            var animation = new Animation();
            animation.Add(0, 1, movement);
            animation.Commit(this, "ZeroAnimation", 16, 400);
        }
    }
}