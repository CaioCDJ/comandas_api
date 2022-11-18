using FluentValidation;
using comandas_api.Models.DTOs;

public class newClientValidation : AbstractValidator<ClientDTO>{

  public newClientValidation(){

    RuleFor(x=>x.firstName).NotEmpty().NotNull();
    RuleFor(x=>x.lastName).NotEmpty().NotNull();
    RuleFor(x=>x.email).NotNull().NotEmpty().EmailAddress();
    RuleFor(x=>x.password).NotEmpty().NotNull().MinimumLength(5);
    RuleFor(x=>x.cpf).NotEmpty();
  }

}
