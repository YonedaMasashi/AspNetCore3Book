using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SampleRazorApp.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        [Display(Name="名前")]
        [Required]

        public string Comment { get; set; }
        
        [Display(Name="投稿者")]
        public int PersonId { get; set; }
        
        [ForeignKey("PersonId")]
        public Person Person { get; set; }
    }
}