using Microsoft.AspNetCore.Mvc;
using comandas_api.Models.DTOs;

namespace comandas_api.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase{

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> getResturant([FromRoute]string id){
    
    return BadRequest();

  }
 
  [HttpGet]
  [Route("{id}/orders")] 
  public async Task<IActionResult> getOrders([FromRoute]string id){

    return Ok();
  }

  [HttpPost]
  public async Task<IActionResult> newResturant(){
    
    return Ok();
  }

  [HttpPut]
  [Route("{id}")]
  public async Task<IActionResult> updateResturant(){
    return Ok();
  }
  
  [HttpPatch]
  [Route("{id}")]
  public async Task<IActionResult> updatePassword(){
    return NotFound();
  }

  [HttpDelete]
  [Route("{id}")]
  public async Task<IActionResult> deleteResturant(){
    return Ok();
  }

}
