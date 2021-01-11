﻿using System;
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
    }
}
