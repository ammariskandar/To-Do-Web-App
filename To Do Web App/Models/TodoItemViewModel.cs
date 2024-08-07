using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class TodoViewModel
    {
        public long Id { get; set; }
        [Display(Name = "Label")]
        [Required(ErrorMessage = "Label is required")]
        [StringLength(36, ErrorMessage = "Must be between 5 and 36 characters", MinimumLength = 5)]
        public string Name { get; set; }
        [Display(Name = "I have done it.")]
        public bool IsComplete { get; set; }
    }
}