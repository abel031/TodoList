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

        public Task<int> InsertAsync(Tarea tarea)
        {
            return this.connection.InsertAsync(tarea);
        }
    }
}
