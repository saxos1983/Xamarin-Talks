using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Phoneword.Forms.Views
{
    public partial class CallHistoryPage : ContentPage
    {
        public CallHistoryPage()
        {
            InitializeComponent();

            Title = "Call History";

            BindingContext = App.AppViewModel;
        }
    }
}
