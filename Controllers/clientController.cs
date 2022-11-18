using Microsoft.AspNetCore.Mvc;
using comandas_api.Models.DTOs;
using comandas_api.Models;
using comandas_api.Repositories;

namespace comandas_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClientController : ControllerBase{

  private readonly ClientRepository  _repository;

  public ClientController(){
    _repository = new ClientRepository();
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> getClient([FromRoute] string id){

    Client client = await _repository.getUser(id);

    if(client is null){
      return NotFound();
    }
    else{
      return Ok(client);
    }

  }
  
  [HttpGet]
  [Route("{id}/orders")]
  public async Task<IActionResult> getClientOrders([FromRoute] string id){

    var orders = await _repository.getOrders(id);

    return (orders is not null)
      ? Ok(orders) 
      : NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> newClient(ClientDTO clientDTO){
 
    if(!ModelState.IsValid)
      return NoContent();

    Console.WriteLine("ola");

    try{
      var exists = await _repository.exists(new LoginDTO {
        email = clientDTO.email,
        password = clientDTO.password
    });



    if(exists is not null) return BadRequest("email ou senha existente");
    
    var client = await _repository.newClient(clientDTO);

    return Ok(client);

    }catch(Exception e){
      throw e;
    }
  }

  [HttpPatch]
  [Route("{id}/password")]
  public async Task<IActionResult> updatePassword(
      [FromRoute] string id, [FromBody] PasswordUpdate passwordUpdate){
    
    await _repository.changePassword(id, passwordUpdate);

    
    return Ok();
  }
  
  [HttpPut]
  [Route("{id}")]
  public async Task<IActionResult> updateClient([FromRoute] string id, [FromBody] ClientDTO clientDTO){
   
    var client = await _repository.getUser(id);

    if (client is null) return NotFound();
  
    return BadRequest();
  }

  [HttpDelete]
  [Route("{id}")]
  public async Task<IActionResult> deleteClient([FromRoute] string id){
    
    await _repository.remove(id);

    return Ok("Usuario deletado");
  }

}
