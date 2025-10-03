namespace Infrastructure.Utilities;

public record JwtConfig(byte[] Key, string Issuer, string Audience);