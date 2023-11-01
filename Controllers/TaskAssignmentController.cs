using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskAssignmentAndNotificationApi.Dto.Request;
using TaskAssignmentAndNotificationApi.Service;

namespace TaskAssignmentAndNotificationApi.Controllers
{
    [ApiController]
    [Route("taskassignmentservice/api/task-assignments")]
    public class TaskAssignmentController : ControllerBase
    {
        private readonly TaskAssignmentService _taskAssignmentService;

        public TaskAssignmentController(TaskAssignmentService taskAssignmentService)
        {
            _taskAssignmentService = taskAssignmentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AssignTask([FromBody] TaskAssignmentCreateRequestDto assignment)
        {
            var newAssignment = await _taskAssignmentService.AssignTaskAsync(assignment);
            return new ObjectResult(new { assignmentId = newAssignment.AssignmentId }) { StatusCode = 200 };
        }

        [HttpGet("{assignmentId}")]
        [Authorize]
        public async Task<IActionResult> GetAssignment(Guid assignmentId)
        {
            var assignment = await _taskAssignmentService.GetAssignmentAsync(assignmentId);
            if (assignment == null)
            {
                return NotFound("Assignment not found.");
            }
            return Ok(assignment);
        }

        [HttpPut("{assignmentId}")]
        [Authorize]
        public async Task<IActionResult> UpdateAssignment(Guid assignmentId, [FromBody] TaskAssignmentUpdateRequestDto updatedAssignment)
        {
            var assignment = await _taskAssignmentService.UpdateAssignmentAsync(assignmentId, updatedAssignment);
            if (assignment == null)
            {
                return NotFound("Assignment not found.");
            }
            return Ok("Assignment updated successfully.");
        }

        [HttpDelete("{assignmentId}")]
        [Authorize]
        public async Task<IActionResult> DeleteAssignment(Guid assignmentId)
        {
            await _taskAssignmentService.DeleteAssignmentAsync(assignmentId);
            return Ok("Assignment deleted successfully.");
        }
    }

}
