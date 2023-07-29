using static RestfulApiAssignment.Models.BookOperationModel;
using FluentValidation;

namespace RestfulApiAssignment.BookValidation
{
    public class UpdateBookInputModelValidator : AbstractValidator<UpdateBookInputModel>
    {
        public UpdateBookInputModelValidator()
        {
            RuleFor(model => model.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MinimumLength(5).WithMessage("Title must be at least 5 characters long.");

            RuleFor(model => model.Author)
                .NotEmpty().WithMessage("Author is required.")
                .MinimumLength(5).WithMessage("Author must be at least 5 characters long.");
        }
    }

    public class DeleteBookInputModelValidator : AbstractValidator<DeleteBookInputModel>
    {
        public DeleteBookInputModelValidator()
        {
            RuleFor(model => model.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }

    public class GetByIdInputModelValidator : AbstractValidator<GetByIdInputModel>
    {
        public GetByIdInputModelValidator()
        {
            RuleFor(model => model.Id)
                .GreaterThan(0).WithMessage("Id must be greater than 0.");
        }
    }
}
