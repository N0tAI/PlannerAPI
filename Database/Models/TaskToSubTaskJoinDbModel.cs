namespace TaskPlanner.API.Database.Models;

public class TaskToSubTaskJoinDbModel
{
        public TaskDbModel ParentTask { get; set; }
 
        public TaskDbModel ChildTask { get; set; }
}
