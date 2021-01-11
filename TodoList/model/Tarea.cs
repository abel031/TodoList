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
        public long ID { get; set; }
        private DateTime _FechaCreacion;
        private DateTime _FechaFinalizacion;
        private DateTime _FechaPlazo;
        private string _Descripcion;
        private bool _Edicion;
        private bool _Guardada;

        public Tarea()
        {
            FechaCreacion = DateTime.Now;
            FechaFinalizacion = DateTime.Now;
            FechaPlazo = DateTime.Now;
            Edicion = false;
            Guardada = true;
        }

        public DateTime FechaCreacion
        {
            get { return _FechaCreacion; }
            set
            {
                _FechaCreacion = value;
                OnPropertyChanged();
            }
        }

        public DateTime FechaFinalizacion
        {
            get { return _FechaFinalizacion; }
            set
            {
                _FechaFinalizacion = value;
                OnPropertyChanged();
            }
        }

        public DateTime FechaPlazo
        {
            get { return _FechaPlazo; }
            set
            {
                _FechaPlazo = value;
                OnPropertyChanged();
                OnPropertyChanged("DiasRestantes");
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

        [Ignore]
        public bool Edicion
        {
            get { return _Edicion; }
            set
            {
                _Edicion = value;
                OnPropertyChanged();
            }
        }

        [Ignore]
        public int DiasRestantes
        {
            get
            {
                return (FechaPlazo - DateTime.Now).Days;
            }
        }

        [Ignore]
        public bool Guardada
        {
            get { return _Guardada; }
            set
            {
                _Guardada = value;
                OnPropertyChanged();
            }
        }

    }
}
