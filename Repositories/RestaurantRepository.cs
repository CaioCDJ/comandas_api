using comandas_api.Models;
using comandas_api.Models.DTOs;
using Microsoft.EntityFrameworkCore;

public class RestaurantRepository{

  private readonly DataContext _context = null;

  public RestaurantRepository(){
    _context = new DataContext();
  }

  public async Task<Restaurant> getRestaurant(string id)
    => await _context.Restaurants.FirstOrDefaultAsync(x => x.Id == id);

  public async Task<bool> exists(LoginDTO login){

    Restaurant restaurant = await _context.Restaurants.FirstOrDefaultAsync( x=>
      x.Email == login.email && x.Password == login.password  );

    if(restaurant is not null){
      return true;
    }
    else{
      return false;
    }
  }

  public async Task remove(string id){

    Restaurant restaurant = await getRestaurant(id);

    _context.Restaurants.Remove(restaurant);

    await _context.SaveChangesAsync();
  }

}
