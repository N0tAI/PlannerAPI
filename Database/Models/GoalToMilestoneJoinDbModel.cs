namespace TaskPlanner.API.Database.Models;

public record class GoalToMilestoneJoinDbModel : IDbModel
{
        public GoalDbModel ParentGoal { get; set; }
 
        public GoalDbModel ChildGoal { get; set; }
}
