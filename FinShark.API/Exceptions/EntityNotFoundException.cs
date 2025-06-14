namespace FinShark.API.Exceptions;

public class EntityNotFoundException<T>(string entityName, T id)
    : InvalidOperationException($"{entityName} with id: {id} not found") where T : notnull;