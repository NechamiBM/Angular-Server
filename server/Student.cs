namespace WebApplication1
{
    public enum Year { First = 1, Second, Third }
    public class Student
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        public bool isActive { get; set; }
        public int courseId { get; set; }
        public int avgMarks { get; set; }
        public DateTime lastDay { get; set; }
        public int year { get; set; }
    }
}
