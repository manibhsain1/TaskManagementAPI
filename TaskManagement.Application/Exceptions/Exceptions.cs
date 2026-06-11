namespace TaskManagement.Application.Exceptions;

public class NotFoundException : Exception
{

    public NotFoundException(string entityName, object key) 
        : base($"{entityName} with id {key} was not found in the db") {}

}

public class BusinessRuleException : Exception
{
    public BusinessRuleException(string message) : base(message){}
}
