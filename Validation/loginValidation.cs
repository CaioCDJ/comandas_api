using FluentValidation;
using comandas_api.Models.DTOs;

namespace comandas_api;

public class LoginValidation : AbstractValidator<LoginDTO>{

  public LoginValidation(){
    RuleFor(x=> x.email).NotEmpty().NotNull().EmailAddress();
    RuleFor(x=>x.password).NotEmpty().NotNull().MinimumLength(5);    
  }

}
