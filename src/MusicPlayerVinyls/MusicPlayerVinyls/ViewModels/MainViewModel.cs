using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace MusicPlayerVinyls.ViewModels  
{
    public class MainViewModel : BaseViewModel
    {
        private double panValue;

        public double PanValue { get => panValue;
            set => SetProperty(ref panValue, value); }
    }
}
