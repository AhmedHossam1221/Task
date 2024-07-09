using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Task1.DTO;
using Task1.Models;

namespace Task1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITIEntities context;

        public TasksController(ITIEntities _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult GetAllTasks()
        {
            List<taskDTO> tasks = context.Tasks.Select(tasks=>new taskDTO {
                taskId=tasks.taskId,
                description=tasks.description,
                endDate=tasks.endDate,
                name=tasks.name,
                memberId=tasks.memberId,
                startDate=tasks.startDate,
                status = tasks.status
            }).ToList();

            return Ok(tasks);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetTaskById(int id)
        {

            var task = context.Tasks.Where(t=>t.taskId==id).Select(tasks => new taskDTO
            {
                taskId = tasks.taskId,
                description = tasks.description,
                endDate = tasks.endDate,
                name = tasks.name,
                memberId = tasks.memberId,
                startDate = tasks.startDate,
                status = tasks.status
            }).FirstOrDefault();
            if (task != null) { return Ok(task); }
            return NotFound();
            
        }
        [HttpPost]
        public IActionResult AddTask(taskDTO taskDTO)
        {
            if(ModelState.IsValid)
            {
                var task = new Tasks
                {
                    taskId = taskDTO.taskId,
                    description = taskDTO.description,
                    endDate = taskDTO.endDate,
                    name = taskDTO.name,
                    memberId = taskDTO.memberId,
                    startDate = taskDTO.startDate,
                    status = taskDTO.status
                };
                try
                {
                    context.Tasks.Add(task);
                    context.SaveChanges();
                    return Ok(task);
                }
                catch (Exception ex) { return BadRequest(ex); }
                
            }
            return BadRequest(ModelState);
        }
        [HttpPut]
        public IActionResult UpdateTask(taskDTO taskDTO, int id)
        {
            if (ModelState.IsValid)
            {
                Tasks oldTask = context.Tasks.FirstOrDefault(e=>e.taskId == id);
                if (oldTask!=null)
                { 
                    oldTask.endDate = taskDTO.endDate;
                    oldTask.startDate = taskDTO.startDate;
                    oldTask.description = taskDTO.description;
                    oldTask.status = taskDTO.status;
                    oldTask.memberId = taskDTO.memberId;
                    oldTask.name = taskDTO.name;
                    context.Update(oldTask);
                    context.SaveChanges() ;
                    return StatusCode(StatusCodes.Status204NoContent);
                }
                return NotFound();
            }
            return BadRequest(ModelState);
        }
        [HttpDelete]
        public IActionResult DeleteTask(int id)
        {
            try
            {
                var task = context.Tasks.FirstOrDefault(e => e.taskId == id);
                if(task!=null)
                {
                    context.Remove(task);
                    context.SaveChanges();
                    return StatusCode(StatusCodes.Status204NoContent);

                }
                return NotFound();
            }catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
