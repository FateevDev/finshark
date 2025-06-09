namespace FinShark.API.Exceptions;

public class EntityNotFoundException(string entityName, int id)
    : InvalidOperationException($"{entityName} with id: {id} not found");