using FluentValidation;

namespace Calendar.Models
{
    public class EventRequestModel
    {
            public string Title { get; set; }
            public string? Description { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public EventRequestModelTheme Theme { get; set; }
            public EventRequestModelRepeat Repeat { get; set; }

        public class EventRequestModelTheme
        {
            public string Name { get; set; }
            public string BackgroundColor { get; set; }
            public string TextColor { get; set; }
            public bool IsStatic { get; set; }
        }

        public class EventRequestModelRepeat
        {
            public int RepeatsCount { get; set; }

            public bool Monday { get; set; }
            public bool Tuesday { get; set; }
            public bool Wednesday { get; set; }
            public bool Thursday { get; set; }
            public bool Friday { get; set; }
            public bool Saturday { get; set; }
            public bool Sunday { get; set; }

            public bool Day { get; set; }
            public bool Week { get; set; }
            public bool Month { get; set; }
            public bool Year { get; set; }
        }
    }

    public class EventRequestModelValidator : AbstractValidator<EventRequestModel>
    {
        public EventRequestModelValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title cannot be empty")
                .MaximumLength(30).WithMessage("Title is too long")
                .MinimumLength(3).WithMessage("Title is too short");

            RuleFor(x => x.StartDate)
                .NotEmpty().WithMessage("Start date cannot be empty");

            RuleFor(x => x.EndDate)
                .NotEmpty().WithMessage("End date cannot be empty")
                .GreaterThan(x => x.StartDate).WithMessage("The end of an event cannot be before the beginning");
        }
    }
}
