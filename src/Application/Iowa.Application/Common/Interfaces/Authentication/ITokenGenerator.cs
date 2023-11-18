namespace Iowa.Application.Common.Interfaces.Authentication;
public interface ITokenGenerator
{
    Task<string> GenerateToken(string userCode);
}