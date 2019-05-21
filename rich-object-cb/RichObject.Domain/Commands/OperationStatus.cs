namespace RichObject.Domain.Commands
{
    public enum OperationStatus
    {
        ValidationFailure,
        EntityNotFound,
        Conflict,
        NotFound,
        Success
    }
}