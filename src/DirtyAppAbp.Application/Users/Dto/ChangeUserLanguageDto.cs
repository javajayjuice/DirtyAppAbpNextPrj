using System.ComponentModel.DataAnnotations;

namespace DirtyAppAbp.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}