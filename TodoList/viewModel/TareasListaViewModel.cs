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

    }
}
