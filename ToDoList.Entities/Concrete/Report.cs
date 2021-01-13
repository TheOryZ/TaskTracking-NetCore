using ToDoList.Entities.Interfaces;

namespace ToDoList.Entities.Concrete
{
    public class Report : ITable
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public int WorkId { get; set; }
        public Work Work { get; set; }
    }
}
