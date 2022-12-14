using comandas_api.Models.DTOs;

public class RestaurantRepository{

  private readonly DataContext _context = null;

  public RestaurantRepository(){
    _context = new DataContext();
  }

  public async Task<Restaurant> getRestaurant(string id)
    => await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);

  public async Task<List<Order>> getOrders(string id )
    =>await _context.Orders.Where(x=> x.RestaurantId == id ).ToListAsync();

  public async Task<bool> exists(LoginDTO login){

    Restaurant restaurant = await _context.Restaurants.FirstOrDefaultAsync( x=>
      x.Email == login.email && x.Password == login.password  );

    return (restaurant is not null)
      ? true
      : false;
  }

  public async Task<bool> newRestaurant(NewRestaurantDTO restaurantDTO){

    string id = Guid.NewGuid().ToString();

    _context.Restaurants.Add(new Restaurant{
      Id = id,
      Name = restaurantDTO.name,
      Email = restaurantDTO.email,
      Password = restaurantDTO.password,
      Address = restaurantDTO.address,
      Cnpj = restaurantDTO.cnpj,
      CreatedAt = DateTime.Now
    });

    await _context.SaveChangesAsync();

    var restaurant = await getRestaurant(id);

    return (restaurant is not null)
      ? true
      : false;
  }

  public async Task Update(Restaurant restaurant){
 
    _context.Restaurants.Update(restaurant);

    await _context.SaveChangesAsync();

  }

  public async Task remove(Restaurant restaurant){

    _context.Restaurants.Remove(restaurant);

    await _context.SaveChangesAsync();
  }
 
  public async Task<Client>getClientByCpf(int cpf)
    => await _context.Clients.SingleOrDefaultAsync(x=> x.Cpf == cpf);

 
  public async Task<Order> newOrder(Order newOrder){
    await _context.Orders.AddAsync(newOrder);
    await _context.SaveChangesAsync();

    return await _context.Orders.SingleOrDefaultAsync( x=> x.Id == newOrder.Id );
  }
}
