using Microsoft.AspNetCore.Mvc;
using comandas_api.Models.DTOs;
using comandas_api.Models;
using comandas_api.Repositories;

namespace comandas_api.Controllers;

[ApiController]
[Route("[controller]")]
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

    return NotFound();
  }

  [HttpPost]
  public async Task<IActionResult> newClient([FromBody] ClientDTO clientDTO){

    return BadRequest(clientDTO);
  }

  [HttpPatch]
  [Route("{id}/password")]
  public async Task<IActionResult> updatePassword(
      [FromRoute] string id, [FromBody] PasswordUpdate passwordUpdate ){
    
    return BadRequest();
  }
  
  [HttpPut]
  [Route("{id}")]
  public async Task<IActionResult> updateClient([FromRoute] string id, [FromBody] ClientDTO clientDTO){
    
    return NotFound();
  }

  [HttpDelete]
  [Route("{id}")]
  public async Task<IActionResult> deleteClient([FromRoute] string id){
    
    return NotFound(id);
  }

}
