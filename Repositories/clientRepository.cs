using comandas_api.Models;
using comandas_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace comandas_api.Repositories;

public class ClientRepository{

  private readonly DataContext _context;

  public ClientRepository(){
    _context = new DataContext();
  }

  public async Task<Client> getUser(string id) =>
    await _context.Clients?.FirstOrDefaultAsync( x => x.Id == id);    

  public async Task<bool> exists(LoginDTO login){

    Client client = await _context.Clients.FirstOrDefaultAsync(x => 
        x.Email == login.email && x.Password == login.password);

    if(client is not null){
      return true;
    } 
    else{
      return false;
    }
  }

  /*
  // criar um dto de resposta
  public async Task<T> getOrders(string id){
    return await _context.Orders
      .Where(x=> x.ClientId == id)
      .Include(x=>x.Restaurant.Name)
      .ToListAsync();
  }

  */
  
  public async Task<Client> changePassword(string id,PasswordUpdate passwordUpdateDTO ){
    
    Client user =  await getUser(id);

    user.Password = passwordUpdateDTO.newPassword;

    _context.Clients.Update(user);
  
    await _context.SaveChangesAsync();

    return user;
  }

  public async Task remove(string id){

    var user = await getUser(id);

    _context.Clients.Remove(user);

    await _context.SaveChangesAsync();
  }
}
