namespace FinShark.API.Exceptions;

public class EntityNotFoundException<T>(string entityName, T id, string? paramName = "id")
    : InvalidOperationException($"{entityName} with {paramName}: {id} not found") where T : notnull;