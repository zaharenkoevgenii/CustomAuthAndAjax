using System.ComponentModel.DataAnnotations;

namespace qweMVC.DAL
{
    public class Comments
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
    }
}