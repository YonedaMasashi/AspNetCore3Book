using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SampleRazorApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }

        [Display(Name="名前")]
        [Required(ErrorMessage = "必須項目です。")]
        public string Name { get; set; }

        [Display(Name="メールアドレス")]
        [EmailAddress(ErrorMessage = "メールアドレスが必要です。")]
        public string Mail { get; set; }

        [Display(Name="年齢")]
        [Required(ErrorMessage = "必須項目です。")]
        [Range(0, 200, ErrorMessage = "ゼロ以上200以下の値にして下さい。")]
        public int Age { get; set; }

        [Display(Name = "投稿")]
        public ICollection<Message> Messages { get; set; }

    }
}