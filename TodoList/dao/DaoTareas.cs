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
            return this.connection.QueryAsync<Tarea>("select * from Tareas where descripcion like '%" + text+"%'");
        }
    }
}
