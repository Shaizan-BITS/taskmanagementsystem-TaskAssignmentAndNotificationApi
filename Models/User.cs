using System;
using System.Collections.Generic;

namespace TaskAssignmentAndNotificationApi.Models
{
    public partial class User
    {
        public User()
        {
            Comments = new HashSet<Comment>();
            Discussions = new HashSet<Discussion>();
            Notifications = new HashSet<Notification>();
            TaskAssignees = new HashSet<Task>();
            TaskAssignmentAssignees = new HashSet<TaskAssignment>();
            TaskAssignmentAssigners = new HashSet<TaskAssignment>();
            TaskCreators = new HashSet<Task>();
        }

        public Guid UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Discussion> Discussions { get; set; }
        public virtual ICollection<Notification> Notifications { get; set; }
        public virtual ICollection<Task> TaskAssignees { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignmentAssignees { get; set; }
        public virtual ICollection<TaskAssignment> TaskAssignmentAssigners { get; set; }
        public virtual ICollection<Task> TaskCreators { get; set; }
    }
}
