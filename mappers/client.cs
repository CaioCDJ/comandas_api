using comandas_api.Models;
using comandas_api.Models.DTOs;

namespace comandas_api.Mappers;

public class ClientMapper{

  public static Client toClient(ClientDTO clientDTO){

    return new Client{
      FirstName = clientDTO.firstName,
      LastName = clientDTO.lastName,
      Email = clientDTO.email,
      PhoneNumber = clientDTO.phoneNumber,
      Password = clientDTO.password
    };
  }
}
