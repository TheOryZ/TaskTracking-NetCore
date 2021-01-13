using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ToDoList.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using ToDoList.DataAccess.Interfaces;
using ToDoList.Entities.Interfaces;

namespace ToDoList.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDAL<Table> where Table : class, ITable, new()
    {
        // NOTES : context.Works == context.Set<Works>(); Bu ikisi birbirine eşit. Aynı şey demektir.
        public void Delete(Table table)
        {
            using var context = new ToDoContext();
            //context.Entry(work).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            context.Set<Table>().Remove(table);
            context.SaveChanges();
        }

        public Table Get(int Id)
        {
            using var context = new ToDoContext();
            return context.Set<Table>().Find(Id);
        }

        public List<Table> GetAll()
        {
            using var context = new ToDoContext();
            return context.Set<Table>().ToList();
        }

        public void Save(Table table)
        {
            using var context = new ToDoContext();
            //context.Entry(work).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            context.Set<Table>().Add(table);
            context.SaveChanges();
        }

        public void Update(Table table)
        {
            using var context = new ToDoContext();
            //context.Entry(work).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.Set<Table>().Update(table);
            context.SaveChanges();
        }
    }
}
