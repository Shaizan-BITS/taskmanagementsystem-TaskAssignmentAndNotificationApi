using Microsoft.EntityFrameworkCore;
using TaskAssignmentAndNotificationApi.Database;
using TaskAssignmentAndNotificationApi.Dto.Request;
using TaskAssignmentAndNotificationApi.Models;

namespace TaskAssignmentAndNotificationApi.Service
{
    public class TaskAssignmentService
    {
        private readonly TaskAssignmentAndNotificationDbContext _context;

        public TaskAssignmentService(TaskAssignmentAndNotificationDbContext context)
        {
            _context = context;
        }

        public async Task<TaskAssignment> AssignTaskAsync(TaskAssignmentCreateRequestDto assignment)
        {
            var newTaskAssignment = new TaskAssignment()
            {
                TaskId = assignment.TaskId, 
                AssigneeId = assignment.AssigneeId,
                AssignerId = assignment.AssignerId,
                AssignmentDate = assignment.AssignmentDate  
            };
            _context.TaskAssignments.Add(newTaskAssignment);
            await _context.SaveChangesAsync();
            return newTaskAssignment;
        }

        public async Task<TaskAssignment> GetAssignmentAsync(Guid assignmentId)
        {
            return await _context.TaskAssignments.FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
        }

        public async Task<TaskAssignment> UpdateAssignmentAsync(Guid assignmentId, TaskAssignmentUpdateRequestDto updatedAssignment)
        {
            var existingAssignment = await _context.TaskAssignments.FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
            if (existingAssignment == null)
                return null;

            // Update assignment properties based on updatedAssignment fields
            existingAssignment.TaskId = updatedAssignment.TaskId;
            existingAssignment.AssignerId = updatedAssignment.AssignerId;
            existingAssignment.AssigneeId = updatedAssignment.AssigneeId;
            // Update other assignment properties...

            await _context.SaveChangesAsync();
            return existingAssignment;
        }

        public async System.Threading.Tasks.Task DeleteAssignmentAsync(Guid assignmentId)
        {
            var assignment = await _context.TaskAssignments.FirstOrDefaultAsync(a => a.AssignmentId == assignmentId);
            if (assignment != null)
            {
                _context.TaskAssignments.Remove(assignment);
                await _context.SaveChangesAsync();
            }
        }
    }

}
