using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TodoList.model;
using TodoList.viewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TodoList.view
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TareasListaInacabadasView : ContentPage
    {
        private TareasListaViewModel vm = new TareasListaViewModel();

        public TareasListaInacabadasView()
        {
            InitializeComponent();
            BindingContext = vm;
            vm.Carga();
        }

        async void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null)
                return;
            if (vm.TareaSeleccionada != null && !vm.TareaSeleccionada.Guardada )
            {
                await DisplayAlert("Error","Elemento no Guardado","OK");
            }
            else
            {
                if (e.Item != vm.TareaSeleccionada && vm.TareaSeleccionada != null)
                {
                    vm.TareaSeleccionada.Edicion = false;
                }
                vm.TareaSeleccionada = (Tarea)e.Item;
                vm.TareaSeleccionada.Edicion = true;
                vm.TareaSeleccionada.Guardada = false;
            }

        }

        private void ToolbarItemAdd_Clicked(object sender, EventArgs e)
        {
            vm.AddTarea();
        }

        private void Guardar(object sender, EventArgs e)
        {
            vm.GuardaTarea();
        }

        private async void Borrar(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Borrar", "Esta seguro de que quiere borrar", "Si", "No");
            if (answer)
            {
                vm.BorrarTarea();
            }
            
        }

        private void Sort(object sender, EventArgs e)
        {
            vm.Sort();
        }

        private void cambia(object sender, TextChangedEventArgs e)
        {
            vm.Busqueda(e.NewTextValue);
        }

        private void Acabar(object sender, EventArgs e)
        {
            vm.Acabar();
        }
    }
}
