namespace Application.Exceptions
{
    public class EntityNotFoundException : BaseCustomException
    {
        public EntityNotFoundException(string name, string filter, string searchWord)
            : base($"Entity {name} by {filter} \"{searchWord}\" was not found.") { }
        public EntityNotFoundException(string name)
            : base($"No entities of type {name} were found.") { }
        public EntityNotFoundException(string name, Guid id)
            : base($"Entity {name} with Id of {id} was not found in the database.") { }
    }
}
