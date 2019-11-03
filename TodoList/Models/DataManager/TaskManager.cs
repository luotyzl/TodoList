using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoList.Models.Repository;

namespace TodoList.Models.DataManager
{
    public class TaskManager:IDataRepository<Task>
    {
        private readonly TodoContext _todoContext;

        public TaskManager(TodoContext context)
        {
            _todoContext = context;
        }
        public IQueryable<Task> GetAll()
        {
            return _todoContext.Tasks.AsQueryable();
        }

        public void Add(Task entity)
        {
            _todoContext.Tasks.Add(entity);
            _todoContext.SaveChanges();
        }

        public void Update(Task dbEntity, Task entity)
        {
            dbEntity.CompleteAt = entity.CompleteAt;
            dbEntity.IsComplete = entity.IsComplete;
            _todoContext.SaveChanges();
        }

    }
}
