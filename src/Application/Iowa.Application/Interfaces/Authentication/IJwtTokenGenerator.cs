namespace Iowa.Application.Interfaces.Authentication; 
public interface IJwtTokenGenerator {
    Task<string> GenerateToken(string userCode);
}