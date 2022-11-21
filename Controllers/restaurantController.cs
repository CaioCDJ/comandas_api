using Microsoft.AspNetCore.Mvc;
using comandas_api.Models;
using comandas_api.Models.DTOs;
using comandas_api.Repositories;
using comandas_api.Mappers;

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

  [HttpPost]
 public async Task<IActionResult> newResturant([FromBody]NewRestaurantDTO restaurantDTO){

    bool isCreated = await _repository.newRestaurant(restaurantDTO);

    return isCreated
      ? Ok()
      : BadRequest();
  }

  [HttpPut]
  [Route("{id}")]
  public async Task<IActionResult> update([FromRoute]string id, [FromBody]NewRestaurantDTO restaurantDTO){

    var restaurant = await _repository.getRestaurant(id);
    
    if(restaurant is null) return NotFound();

    // mapear objetos

    return Ok();
  }
  
  [HttpPatch]
  [Route("{id}/passwod")]
  public async Task<IActionResult> updatePassword([FromRoute]string id, [FromBody] PasswordUpdate passwordUpdateDTO){

    var restaurant = await _repository.getRestaurant(id);
    
    if(restaurant is null) return NotFound();

    if(passwordUpdateDTO.password != restaurant.Password){ 
      return BadRequest("Senha incorreta");
    }

    restaurant.Password = passwordUpdateDTO.newPassword;

    await _repository.Update(restaurant);

    return Ok();
  }

  [HttpDelete]
  [Route("{id}")]
  public async Task<IActionResult> deleteResturant([FromRoute]string id){
   
    Restaurant restaurant =  await _repository.getRestaurant(id);

    if(restaurant is null) return NotFound("Conta não encontroda.");

    await _repository.remove(restaurant);

    return Ok();
  }

  // -- Order section --

  [HttpGet]
  [Route("{id}/orders")] 
  public async Task<IActionResult> getOrders([FromRoute]string id){


    return Ok();
  }

  [HttpPost]
  [Route("{id}/order")]
  public async Task<IActionResult> order([FromRoute]string id,[FromBody]NewOrderDTO newOrderDTO){
    
    Restaurant restaurant =  await _repository.getRestaurant(id);

    if(restaurant is null) return NotFound("Conta não encontroda.");
    
    var client = await _repository.getClientByCpf(newOrderDTO.client_cpf);

    if(client is null) return BadRequest();

    Order newOrder = OrderMapper.toOrder(newOrderDTO);

    newOrder.RestaurantId = id;

    newOrder = await _repository.newOrder(newOrder);

    return Ok(newOrder);
  }  

}
