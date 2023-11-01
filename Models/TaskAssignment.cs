using System;
using System.Collections.Generic;

namespace TaskAssignmentAndNotificationApi.Models
{
    public partial class TaskAssignment
    {
        public Guid AssignmentId { get; set; }
        public Guid? TaskId { get; set; }
        public Guid? AssignerId { get; set; }
        public Guid? AssigneeId { get; set; }
        public DateTime? AssignmentDate { get; set; }

        public virtual User? Assignee { get; set; }
        public virtual User? Assigner { get; set; }
        public virtual Task? Task { get; set; }
    }
}
