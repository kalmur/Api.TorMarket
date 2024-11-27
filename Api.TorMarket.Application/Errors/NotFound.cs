namespace Api.TorMarket.Application.Errors;

public class NotFound(string errorMessage, int id) : Error(errorMessage);