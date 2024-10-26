using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        public TaskContext taskContext;

        public TaskItemsController(TaskContext taskContext)
        {
            this.taskContext = taskContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = taskContext.TaskItems.ToList();
            return Ok(data);
        }
        [HttpGet ("single")]
        public IActionResult Get(int id)
        {
            var data = taskContext.TaskItems.FirstOrDefault(x => x.Id == id);
            return Ok(data);
        }
        [HttpPost]
        public IActionResult Add(TaskItem item)
        {
            taskContext.TaskItems.Add(item);
            taskContext.SaveChanges();
            return Ok(item);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = taskContext.TaskItems.FirstOrDefault(x => x.Id == id);
            taskContext.TaskItems.Remove(item);
            taskContext.SaveChanges();
            return Ok(item);
        }
        [HttpPut]
        public IActionResult Update(TaskItem Uitem)
        {
            
            taskContext.TaskItems.Update(Uitem);
            taskContext.SaveChanges();
            return Ok(Uitem);
        }
    }
}
