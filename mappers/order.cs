using comandas_api.Models;
using comandas_api.Models.DTOs;

namespace comandas_api.Mappers;

public class OrderMapper{

  public static Order toOrder(NewOrderDTO orderDTO){

    string id = Guid.NewGuid().ToString();

    return new Order{
      Id = id,
      CreatedAt = DateTime.Now,
      Description = orderDTO.description,
      Status = false,
    };
  }
}
