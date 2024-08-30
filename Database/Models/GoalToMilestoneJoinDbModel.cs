namespace TaskPlanner.API.Database.Models;

public class GoalToMilestoneJoinDbModel
{
        public GoalDbModel ParentGoal { get; set; }
 
        public GoalDbModel ChildGoal { get; set; }
}
