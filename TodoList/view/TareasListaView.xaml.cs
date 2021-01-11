using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TodoList.viewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareasListaView : ContentPage
    {
        private TareasListaViewModel vm = new TareasListaViewModel();

        public TareasListaView()
        {
            InitializeComponent();
            BindingContext = vm;
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;

            await DisplayAlert("Item Tapped", "An item was tapped.", "OK");

            //Deselect Item
            ((ListView)sender).SelectedItem = null;
        }

        private void ToolbarItemAdd_Clicked(object sender, EventArgs e)
        {

        }
    }
}
