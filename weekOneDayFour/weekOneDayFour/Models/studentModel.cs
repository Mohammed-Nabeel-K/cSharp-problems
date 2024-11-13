namespace weekOneDayFour.Models
{
    public class studentModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Course { get; set; }

        public studentModel(int id, string name, string place , string course)
        {
            this.Id = id;
            this.Name = name;
            this.Place = place;
            this.Course = course;
        }
    }
}
