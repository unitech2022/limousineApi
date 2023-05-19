namespace LimousineApi.Models;

public class City
{
    public int Id { get; set; }
    public string? Name { get; set; }

    //  public string? NameEnG { get; set; }
    public int CountyId { get; set; }
    public string? Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public City()
    {
        CreatedAt = DateTime.Now;
        Status = "ACTIVE";
    }
}