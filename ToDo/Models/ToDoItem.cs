using System.ComponentModel.DataAnnotations;

namespace PracticeASP.NETCOREMVC.Models
{
    public class ToDoItem
    {
        //GUID:Identificador global unico
        public Guid id { get; set; }
        public bool isDone { get; set; }


        [Required]
        public string title { get; set; }
        public DateTimeOffset? dueAt { get; set; }
        public DateTime? createdAt { get; set; }
}
    }

