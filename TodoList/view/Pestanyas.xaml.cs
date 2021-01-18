using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Pestanyas : TabbedPage
    {
        public Pestanyas()
        {
            InitializeComponent();
        }
    }
}