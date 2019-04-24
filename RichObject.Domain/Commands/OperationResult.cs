namespace RichObject.Domain.Commands
{
    public enum OperationResult
    {
        ValidationFailure,
        EntityNotFound,
        Conflict,
        Success
    }
}