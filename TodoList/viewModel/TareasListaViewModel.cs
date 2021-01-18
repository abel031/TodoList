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
    }
}
