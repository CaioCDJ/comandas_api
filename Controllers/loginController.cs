using Microsoft.AspNetCore.Mvc;
using comandas_api.Models.DTOs;

[ApiController]
[Route("login")]
public class LoginController : ControllerBase {
  
  [HttpPost]
  public async Task<IActionResult> Login([FromBody] LoginDTO login){
    
    
    return Ok(); 
  }

}
