namespace comandas_api.Models.DTOs;

public class NewRestaurantDTO{
  
  public string name { get; set; }
  public string email { get; set; }
  public int cnpj  { get; set; }
  public string address { get; set; }
  public string password{ get; set; }
}
