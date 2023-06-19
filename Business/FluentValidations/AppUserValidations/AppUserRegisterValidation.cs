


using Dto.Dtos;
using FluentValidation;

namespace Business.FluentValidations.AppUserValidations;

public class AppUserRegisterValidation : AbstractValidator<AppUserRegisterDto>
{
	public AppUserRegisterValidation()
	{
		RuleFor(x=>x.Name)
            .NotEmpty().WithMessage("Bu alan boş geçilemez")
            .MaximumLength(30).WithMessage("Max karakter 30")
            .MinimumLength(5).WithMessage("Min karakter 5");
        RuleFor(x => x.Surname).NotEmpty().WithMessage("Bu alan boş geçilemez");
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Bu alan boş geçilemez")
            .NotNull().EmailAddress().WithMessage("Lütfen geçerli bir mail giriniz");
        RuleFor(x => x.Username).NotEmpty().WithMessage("Bu alan boş geçilemez");
        RuleFor(x => x.Password).NotEmpty().WithMessage("Bu alan boş geçilemez");
        RuleFor(x => x.ConfirmPassword)
            .NotEmpty().WithMessage("Bu alan boş geçilemez")
            .Equal(x=>x.Password).WithMessage("Parolar eşleşmiyor");
    }
}
