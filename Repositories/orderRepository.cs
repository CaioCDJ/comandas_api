using comandas_api.Models;
using comandas_api.Models.DTOs;

public class OrderRepository{

  private readonly DataContext _context;

  public OrderRepository(){
    _context = new DataContext();
  }

  public async Task Update(Order changedOrder){
  
    _context.Orders.Update(changedOrder);
    
    await _context.SaveChangesAsync(); 
  }
  
  public async Task<Order> getById(string id) 
    => await _context.Orders.SingleOrDefaultAsync(x=> x.Id == id);

  public async Task<bool> statusUpdate(string id){
  
    var order = await getById(id);

    if(order is null){
      return false;
    }
    
    order.Status = true;
    order.DeliveredAt = DateTime.Now;

    _context.Update(order);

    await _context.SaveChangesAsync();

    return true;

  }
}
