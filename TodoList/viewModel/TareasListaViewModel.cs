using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using TodoList.helpers;
using TodoList.model;

namespace TodoList.viewModel
{
    class TareasListaViewModel : ViewModelBase
    {
        private ObservableCollection<Tarea> _Tareas { get; set; }
        public Tarea TareaSeleccionada { get; set; }
        public ObservableCollection<Tarea> Tareas
        {
            get { return _Tareas; }
            set
            {
                _Tareas = value;
                OnPropertyChanged();
            }
        }

        public TareasListaViewModel()
        {
            Task<List<Tarea>> tTarea = Providers.daoTareas.AllTareasAsync();
            Tareas = new ObservableCollection<Tarea>(tTarea.Result);
        }

        private Boolean sorted { get; set; } = false;

        internal void AddTarea()
        {
            TareaSeleccionada = new Tarea();
            OnPropertyChanged("TareaSeleccionada");
            Tareas.Insert(0, TareaSeleccionada);
        }

        internal void GuardaTarea()
        {
            Providers.daoTareas.Insert(TareaSeleccionada);
            TareaSeleccionada.Edicion = false;
            TareaSeleccionada.Guardada = true;
        }

        internal void BorrarTarea()
        {

            Providers.daoTareas.Borrar(TareaSeleccionada);
            this.Tareas.Remove(TareaSeleccionada);
            TareaSeleccionada = null;
        }

        internal void Sort()
        {
            if (!sorted)
            {
                Task<List<Tarea>> oTarea = Providers.daoTareas.SortTareasAsync();
                Tareas = new ObservableCollection<Tarea>(oTarea.Result);
                sorted = true;
            }
            else
            {
                Task<List<Tarea>> tTarea = Providers.daoTareas.AllTareasAsync();
                Tareas = new ObservableCollection<Tarea>(tTarea.Result);
                sorted = false;
            }   
        }

        internal void Busqueda(string text)
        {
            Task<List<Tarea>> bTarea = Providers.daoTareas.Busqueda(text);
            Tareas = new ObservableCollection<Tarea>(bTarea.Result);
        }
    }
}
