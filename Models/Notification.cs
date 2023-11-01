using System;
using System.Collections.Generic;

namespace TaskAssignmentAndNotificationApi.Models
{
    public partial class Notification
    {
        public Guid NotificationId { get; set; }
        public Guid? UserId { get; set; }
        public string? Message { get; set; }
        public DateTime? NotificationDate { get; set; }

        public virtual User? User { get; set; }
    }
}
