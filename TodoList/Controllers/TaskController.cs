using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TodoList.Models.Repository;
using Task = TodoList.Models.Task;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {

        private readonly ILogger<TaskController> _logger;
        private readonly IDataRepository<Task> _dataRepository;
        public TaskController(IDataRepository<Task> dataRepository,ILogger<TaskController> logger)
        {
            _dataRepository = dataRepository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var tasks = _dataRepository.GetAll().ToList();
            return Ok(tasks);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Task task)
        {
            var matching = _dataRepository.GetAll().FirstOrDefault(a=>a.Id == id);
            if (matching != null)
            {
                task.CompleteAt = DateTime.Now;
                _dataRepository.Update(matching,task);
                return Ok(matching);
            }
            return NotFound();
        }
        [HttpPost]
        public IActionResult Post( [FromBody] Task task)
        {
            task.CreatedAt = DateTime.Now;
            _dataRepository.Add(task);
            return Ok(task);
        }
    }
}
