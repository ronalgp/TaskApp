using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskApp.API.Interfaces;
using TaskApp.API.Models;

namespace TaskApp.API.Controllers
{
    [Authorize]
    public class TaskController(ITaskDetailRepository taskDetailRepository) : BaseController
    {
        [HttpGet]
        public IActionResult GetTasks()
        {
            var userNameIdentifierClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userNameIdentifierClaim))
                return BadRequest("Could not get the user id");
            if (!int.TryParse(userNameIdentifierClaim, out int userId))
                return BadRequest("User id is not valid.");
            var tasks = taskDetailRepository.GetAllTasks(userId);
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public IActionResult GetTask(int id)
        {
            var task = taskDetailRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }
        [HttpPost]
        public IActionResult CreateTask([FromBody] TaskDetails task)
        {
            var userNameIdentifierClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userNameIdentifierClaim))
                return BadRequest("Could not get the user id");
            if (!int.TryParse(userNameIdentifierClaim, out int userId))
                return BadRequest("User id is not valid.");

            taskDetailRepository.CreateTask(task, userId);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, [FromBody] TaskDetails updatedTask)
        {
            var task = taskDetailRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            taskDetailRepository.UpdateTask(updatedTask);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = taskDetailRepository.GetTaskById(id);
            if (task == null)
            {
                return NotFound();
            }
            taskDetailRepository.DeleteTask(id);
            return NoContent();
        }
    }
}
