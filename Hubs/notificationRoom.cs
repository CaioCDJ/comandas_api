using Microsoft.AspNetCore.SignalR;
using comandas_api.Models.DTOs;
using comandas_api.Repositories;


public class NotificationRoom : Hub{

  private readonly ClientRepository _clientRepository;
  private readonly OrderRepository _orderRepository;
  
  static List<ConnectionModel> orderChat = new List<ConnectionModel>();

  public NotificationRoom(){

    _orderRepository = new OrderRepository();
    _clientRepository  = new ClientRepository();
  }

  public async Task connect(string id, string role){

    if( role == "client"){
      
      var connectId = Context.ConnectionId;

      var client = await _clientRepository.getUser(id);

      orderChat.Add(new ConnectionModel {
        id = connectId,
        userID = id,
        role = role
      });
    }
  }
  
  public async Task OrderUpdate( string orderId ){

    try{

      var connectId = Context.ConnectionId;

      var client = orderChat.SingleOrDefault( x => x.orderID == orderId );
    
      await _orderRepository.statusUpdate(orderId);

      await Clients.Client(client.id).SendAsync("OrderUpdate");

    }catch(Exception e){
    
    }
  }
}

public class ConnectionModel{
  public string id { get; set; }
  public string orderID { get; set; }
  public string userID { get; set; }
  public string role { get; set; }
}

