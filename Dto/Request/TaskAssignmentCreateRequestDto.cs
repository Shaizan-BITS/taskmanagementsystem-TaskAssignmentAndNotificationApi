namespace TaskAssignmentAndNotificationApi.Dto.Request
{
    public class TaskAssignmentCreateRequestDto
    {
        public Guid? TaskId { get; set; }
        public Guid? AssignerId { get; set; }
        public Guid? AssigneeId { get; set; }
        public DateTime? AssignmentDate { get; set; }
    }
}
