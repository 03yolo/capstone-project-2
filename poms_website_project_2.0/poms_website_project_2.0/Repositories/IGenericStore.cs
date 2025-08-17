namespace poms_website_project_2._0.Repositories
{
    public interface IGenericStore<T> where T : class
    {
        // return all entities that "T" is using
        IQueryable<T> GetAll();

        // return an entity by its ID asynchronously
        Task<T> GetByIdAsync(int id);

        // create a new entity asynchronously
        Task CreateAsync(T entity);

        // update an existing entity asynchronously
        Task UpdateAsync(T entity);

        // delete an existing entity asynchronously
        Task DeleteAsync(T entity);

        // check if an entity exists by its ID asynchronously
        Task<bool> ExistAsync(int id);
    }
}
