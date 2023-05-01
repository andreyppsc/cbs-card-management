namespace CM.Api.Application.Services;

public interface IIbanService
{
    Task<string> Generate();
}