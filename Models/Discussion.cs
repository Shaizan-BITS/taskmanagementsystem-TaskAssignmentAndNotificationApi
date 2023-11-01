using System;
using System.Collections.Generic;

namespace TaskAssignmentAndNotificationApi.Models
{
    public partial class Discussion
    {
        public Discussion()
        {
            Comments = new HashSet<Comment>();
        }

        public Guid DiscussionId { get; set; }
        public Guid? TaskId { get; set; }
        public string Title { get; set; } = null!;
        public Guid? CreatedById { get; set; }

        public virtual User? CreatedBy { get; set; }
        public virtual Task? Task { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
