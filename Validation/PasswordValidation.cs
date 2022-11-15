using FluentValidation;
using comandas_api.Models.DTOs;

public class PasswordUpdateValidation : AbstractValidator<PasswordUpdate>{

  public PasswordUpdateValidation(){

    RuleFor(x=>x.password).NotEmpty().NotNull().MinimumLength(5);
    RuleFor(x=>x.newPassword).NotEmpty().NotNull().MinimumLength(5);
  }

}
