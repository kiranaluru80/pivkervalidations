using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SampleDB
{
    public partial class PickerBinding : ContentPage
    {
        public PickerBinding()
        {
            InitializeComponent();
            this.BindingContext = new PickerBindingViewModel();
            majorGropName.Focused += (sender, e) => {
                deprtmentTitle.Title = "Select DepartmentName";
            };
        }
    }
}
