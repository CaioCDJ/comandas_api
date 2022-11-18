using comandas_api.Models;
using comandas_api.Models.DTOs;

namespace comandas_api.Mappers;

public class RestaurantMapper{

  public static Restaurant toRestaurant(NewRestaurantDTO newRestaurant){

    return new Restaurant{
      Name = newRestaurant.name,
      Email = newRestaurant.email,
      Cnpj = newRestaurant.cnpj,
      Password = newRestaurant.password,
      Address = newRestaurant.address   
    };
  }
}
