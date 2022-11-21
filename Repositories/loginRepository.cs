using comandas_api.Models;
using comandas_api.Models.DTOs;

namespace comandas_api.Repositories;

public class LoginRepository{

  private readonly DataContext _context;

  public LoginRepository(){
    _context = new DataContext();
  }

  public async Task<Client>getUser(LoginDTO loginDTO) 
    => await _context.Clients.SingleOrDefaultAsync( x=>
      x.Email == loginDTO.email && x.Password == loginDTO.password);

  public async Task<Restaurant>GetRestaurant(LoginDTO loginDTO) 
    => await _context.Restaurants.SingleOrDefaultAsync( x=>
      x.Email == loginDTO.email && x.Password == loginDTO.password);
}
