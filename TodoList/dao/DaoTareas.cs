using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TodoList.model;

namespace TodoList.dao
{
    public class DaoTareas
    {
        private SQLiteAsyncConnection connection;

        public DaoTareas(SQLiteAsyncConnection connection)
        {
            this.connection = connection;
        }

        public Task<List<Tarea>> AllTareasAsync()
        {
            return this.connection.Table<Tarea>().ToListAsync();
        }

        public int Insert(Tarea tarea)
        {
            if(tarea.ID == 0)
            {
                return this.connection.InsertAsync(tarea).Result;
            }
            else
            {
                return this.connection.UpdateAsync(tarea).Result;
            }
            
        }

        public int Borrar(Tarea tarea)
        {
            return this.connection.DeleteAsync(tarea).Result;
        }

        public Task<List<Tarea>> SortTareasAsync()
        {
            return this.connection.Table<Tarea>().OrderBy(x => x.FechaPlazo).ToListAsync();
        }

        public Task<List<Tarea>> Busqueda(string text)
        {
            return this.connection.QueryAsync<Tarea>("select * from Tareas where descripcion like '%" + text + "%'");
        }

        //Tareas Acabadas
        public Task<List<Tarea>> AllTareasAcab()
        {
            return this.connection.QueryAsync<Tarea>("select * from Tareas where Terminada=true");
        }

        public Task<List<Tarea>> SortTareasAcabadasAsync()
        {
            return this.connection.Table<Tarea>().Where(x=>x.Terminada == true).OrderBy(x => x.FechaPlazo).ToListAsync();
        }

        public Task<List<Tarea>> BusquedaAcabadas(string text)
        {
            return this.connection.QueryAsync<Tarea>("select * from Tareas where descripcion like '%" + text + "%' and Terminada = true");
        }

        //Tareas Inacabadas

        public Task<List<Tarea>> AllTareasInac()
        {
            return this.connection.QueryAsync<Tarea>("select * from Tareas where Terminada=false");
        }

        public Task<List<Tarea>> BusquedaInacabadas(string text)
        {
            return this.connection.QueryAsync<Tarea>("select * from Tareas where descripcion like '%" + text + "%' and Terminada = false");
        }

        public Task<List<Tarea>> SortTareasInacabadasAsync()
        {
            return this.connection.Table<Tarea>().Where(x=>x.Terminada == false).OrderBy(x => x.FechaPlazo).ToListAsync();
        }
    }
}
