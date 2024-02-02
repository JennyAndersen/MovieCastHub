namespace Application.Exceptions
{
    public class EntityNotFoundException : BaseCustomException
    {
        public EntityNotFoundException(string name, string filter, string searchWord )
            : base($"Entity {name} by {filter} {searchWord} was not found.") { }
        public EntityNotFoundException(string name, object key)
            : base($"Entity {name} with Id of {key} was not found in the database.") { }
    }
}
