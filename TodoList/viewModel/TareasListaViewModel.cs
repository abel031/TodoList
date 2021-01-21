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
        //private ObservableCollection<Tarea> _Tareas { get; set; }
        private ObservableCollection<Tarea> _TareasAcabadas { get; set; }
        private ObservableCollection<Tarea> _TareasInacabadas { get; set; }
        public Tarea TareaSeleccionada { get; set; }
        /*public ObservableCollection<Tarea> Tareas
        {
            get { return _Tareas; }
            set
            {
                _Tareas = value;
                OnPropertyChanged();
            }
        }*/
        public ObservableCollection<Tarea> TareasAcabadas
        {
            get { return _TareasAcabadas; }
            set
            {
                _TareasAcabadas = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<Tarea> TareasInacabadas
        {
            get { return _TareasInacabadas; }
            set
            {
                _TareasInacabadas = value;
                OnPropertyChanged();
            }
        }

        public TareasListaViewModel()
        {
            /*Task<List<Tarea>> tTarea = Providers.daoTareas.AllTareasAsync();
            Tareas = new ObservableCollection<Tarea>(tTarea.Result);*/

            Carga();
        }

        private Boolean sorted { get; set; } = false;

        internal void AddTarea()
        {
            TareaSeleccionada = new Tarea();
            OnPropertyChanged("TareaSeleccionada");
            TareasInacabadas.Insert(0, TareaSeleccionada);
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
            this.TareasInacabadas.Remove(TareaSeleccionada);
            this.TareasAcabadas.Remove(TareaSeleccionada);
            TareaSeleccionada = null;
        }

        internal void Sort()
        {
            if (!sorted)
            {
                Task<List<Tarea>> oTareaI = Providers.daoTareas.SortTareasInacabadasAsync();
                TareasInacabadas = new ObservableCollection<Tarea>(oTareaI.Result);
                Task<List<Tarea>> oTareaA = Providers.daoTareas.SortTareasAcabadasAsync();
                TareasAcabadas = new ObservableCollection<Tarea>(oTareaA.Result);
                sorted = true;
            }
            else
            {
                Carga();
                sorted = false;
            }   
        }

        internal void Busqueda(string text)
        {
            Task<List<Tarea>> bTareaA = Providers.daoTareas.BusquedaAcabadas(text);
            TareasAcabadas = new ObservableCollection<Tarea>(bTareaA.Result);
            Task<List<Tarea>> bTareaI = Providers.daoTareas.BusquedaInacabadas(text);
            TareasInacabadas = new ObservableCollection<Tarea>(bTareaI.Result);
        }

        internal void Acabar()
        {
            TareaSeleccionada.FechaFinalizacion = DateTime.Now;
            TareaSeleccionada.Terminada = true;
            Providers.daoTareas.Insert(TareaSeleccionada);
            TareaSeleccionada.Edicion = false;
            TareaSeleccionada.Guardada = true;
            Carga();
        }

        internal void Carga()
        {
            Task<List<Tarea>> tTareaI = Providers.daoTareas.AllTareasInac();
            TareasInacabadas = new ObservableCollection<Tarea>(tTareaI.Result);
            Task<List<Tarea>> tTareaA = Providers.daoTareas.AllTareasAcab();
            TareasAcabadas = new ObservableCollection<Tarea>(tTareaA.Result);
        }
    }
}
