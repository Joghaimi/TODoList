using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace TODoList.Models
{
    public class Note
    {
        [Key]
        public int id { get; set; }
        public int userId { get; set; }
        public string noteString { get; set; }
        public string assignTo { get; set; }
        public bool completed { get; set; }
    }
}
