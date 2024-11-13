namespace weekTwoDayFive.Models
{
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }

        public TaskModel(int taskid,string taskname) {
            this.TaskId = taskid;
            this.TaskName = taskname;
        }
    }
}
