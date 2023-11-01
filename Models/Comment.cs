using System;
using System.Collections.Generic;

namespace TaskAssignmentAndNotificationApi.Models
{
    public partial class Comment
    {
        public Guid CommentId { get; set; }
        public Guid? DiscussionId { get; set; }
        public string CommentText { get; set; } = null!;
        public Guid? CreatedById { get; set; }

        public virtual User? CreatedBy { get; set; }
        public virtual Discussion? Discussion { get; set; }
    }
}
