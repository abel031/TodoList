using TodoList.helpers;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TodoList.model
{
    [Table("Tareas")]
    public class Tarea : NotifyPropertyBase
    {
        [PrimaryKey,AutoIncrement]
        private long ID { get; set; }
        private string _FechaCreacion;
        private string _FechaFinalizacion;
        private string _FechaPlazo;
        private string _Descripcion;
        private bool _Edicion;

        public Tarea()
        {
            FechaCreacion = DateTime.Now.ToString("dd/MM/yyyy");
            FechaFinalizacion = DateTime.Now.ToString("dd/MM/yyyy");
            FechaPlazo = DateTime.Now.ToString("dd/MM/yyyy");
            Edicion = false;
        }

        public string FechaCreacion
        {
            get { return _FechaCreacion; }
            set
            {
                _FechaCreacion = value;
                OnPropertyChanged();
            }
        }

        public string FechaFinalizacion
        {
            get { return _FechaFinalizacion; }
            set
            {
                _FechaFinalizacion = value;
                OnPropertyChanged();
            }
        }

        public string FechaPlazo
        {
            get { return _FechaPlazo; }
            set
            {
                _FechaPlazo = value;
                OnPropertyChanged();
            }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set
            {
                _Descripcion = value;
                OnPropertyChanged();
            }
        }

        public bool Edicion
        {
            get { return _Edicion; }
            set
            {
                _Edicion = value;
                OnPropertyChanged();
            }
        }
    }
}
