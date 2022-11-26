using comandas_api.Models.DTOs;

namespace comandas_api.Repositories;

public class ClientRepository{

  private readonly DataContext _context;

  public ClientRepository(){
    _context = new DataContext();
  }

  public async Task<Client> getUser(string id) =>
    await _context.Clients?.SingleOrDefaultAsync( x => x.Id == id );    
 

  public async Task<Client> exists (ClientDTO clientDTO)
    => await _context.Clients.SingleOrDefaultAsync( x=> 
        x.Email == clientDTO.email
        || x.Password == clientDTO.password
        || x.Cpf == clientDTO.cpf );

  public async Task<Order> getLastOrder(string id)
    => await _context.Orders.SingleOrDefaultAsync( x =>
        x.ClientId == id && x.Status == false);

  public async Task<List<Order>> getOrders(string id){

    var orders = await _context.Orders
      .Where(x=> x.ClientId == id)
      .Include(x=> x.Restaurant.Name).ToListAsync();
  
    return orders; 
    
  }
  
  public async Task<Client> newClient(ClientDTO clientDTO){

    string newId = Guid.NewGuid().ToString();

    Console.WriteLine(newId);

    _context.Clients.Add(new Client{
      Id = newId,
      FirstName = clientDTO.firstName,
      LastName = clientDTO.lastName,
      Email = clientDTO.email,
      Cpf = clientDTO.cpf,
      Password = clientDTO.password
    });
    
    await _context.SaveChangesAsync();

    return await getUser(newId);
  }

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
