using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using TodoList.model;

namespace TodoList.helpers
{
    public class TodoListDB
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        public static SQLiteAsyncConnection ConectionDatabase => lazyInitializer.Value;

        static TodoListDB()
        {
            ConectionDatabase.CreateTableAsync<Tarea>();
           /* Providers.daoTareas.InsertAsync(new Tarea
            {
                Descripcion = "test",
                FechaCreacion = "10/01/2021",
                FechaFinalizacion = "",
                FechaPlazo = DateTime.Now.ToString("dd/MM/yyyy"),
            });*/
        }
    }
}
