﻿using System;
using System.Collections.Generic;
using System.Text;
using ToDoList.Entities.Interfaces;

namespace ToDoList.DataAccess.Interfaces
{
    public interface IGenericDAL<Table> where Table:class, ITable, new()
    {
        void Save(Table table);
        void Delete(Table table);
        void Update(Table table);
        Table Get(int Id);
        List<Table> GetAll();
    }
}
