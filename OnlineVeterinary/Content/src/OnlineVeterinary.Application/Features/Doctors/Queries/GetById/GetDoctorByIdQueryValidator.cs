using FluentValidation;

namespace OnlineVeterinary.Application.Features.Doctors.Queries.GetById
{
    public class GetDoctorByIdQueryValidator : AbstractValidator<GetDoctorByIdQuery>
    {
        public GetDoctorByIdQueryValidator()
        {
            RuleFor(x => x.Id).NotEmpty().WithMessage("plz enter Id");
        }
    }
}