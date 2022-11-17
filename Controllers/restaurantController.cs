using Microsoft.AspNetCore.Mvc;
using comandas_api.Models;
using comandas_api.Models.DTOs;
using comandas_api.Repositories;

namespace comandas_api.Controllers;

[ApiController]
[Route("[controller]")]
public class RestaurantController : ControllerBase{

  private readonly RestaurantRepository _repository;

  public RestaurantController(){
    _repository = new RestaurantRepository();
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> getResturant([FromRoute]string id){

    var restaurant = await _repository.getRestaurant(id);

    return (restaurant is not null) 
      ? Ok(restaurant)
      : NotFound("Restaurante não encontrodo");
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
