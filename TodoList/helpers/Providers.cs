using System;
using System.Collections.Generic;
using System.Text;
using TodoList.dao;

namespace TodoList.helpers
{
    public class Providers
    {
        private static DaoTareas _daoTareas;

        public static DaoTareas daoTareas
        {
            get
            {
                if (_daoTareas == null) _daoTareas = new DaoTareas(TodoListDB.ConectionDatabase);
                return _daoTareas;
            }
        }

    }
}
