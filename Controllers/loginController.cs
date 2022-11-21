using Microsoft.AspNetCore.Mvc;
using comandas_api.Models.DTOs;
using comandas_api.Repositories;

[ApiController]
[Route("login")]
public class LoginController : ControllerBase {
  
  private readonly LoginRepository _repository;

  public LoginController(){
    _repository = new LoginRepository();
  }

  [HttpPost]
  public async Task<IActionResult> Login([FromBody] LoginDTO login){
    
    if(!ModelState.IsValid) return BadRequest();

    if(login.role == "client"){
      
      var client =  await _repository.getUser(login);
      
      return ( client  is not null )
        ? Ok(client)
        : NotFound("usuario não encontrado");
    } 
    else if(login.role == "restaurant"){

      var restaurant =  await _repository.GetRestaurant(login);
      
      return ( restaurant is not null )
        ? Ok(restaurant)
        : NotFound("usuario não encontrado");
    }

    return BadRequest();
  }

}
