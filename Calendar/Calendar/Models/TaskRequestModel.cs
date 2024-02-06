using FluentValidation;
using System.ComponentModel.DataAnnotations;

namespace Calendar.Models
{
    public class TaskRequestModel
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public string? Color { get; set; }
    }

    public class TaskRequestModelValidator : AbstractValidator<TaskRequestModel>
    {
        public TaskRequestModelValidator() 
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .MaximumLength(30).WithMessage("Title is too long")
                .MinimumLength(3).WithMessage("Title is too short");

            RuleFor(x => x.Date)
                .NotEmpty().WithMessage("Date cannot be empty");
        }
    }
}
