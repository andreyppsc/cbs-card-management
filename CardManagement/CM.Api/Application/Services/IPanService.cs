namespace CM.Api.Application.Services;

public interface IPanService
{
    Task<string> Generate();
}