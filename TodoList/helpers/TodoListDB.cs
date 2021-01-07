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

        public TodoListDB()
        {
            ConectionDatabase.CreateTableAsync<Tarea>();
        }
    }
}
