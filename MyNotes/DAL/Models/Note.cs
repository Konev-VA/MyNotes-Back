using System.ComponentModel.DataAnnotations;

namespace MyNotes.DAL.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int? AuthorID { get; set; }
    }
}
