namespace WebAPI.Requests;

public record AddAddressRequest
{
    public required string CityName { get; set; }
    public required string StreetName { get; set; }
    public required int StreetNumber { get; set; }
};