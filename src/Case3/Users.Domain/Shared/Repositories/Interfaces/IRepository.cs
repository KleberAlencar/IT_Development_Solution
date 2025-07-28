using Users.Domain.Shared.Entities;

namespace Users.Domain.Shared.Repositories.Interfaces;

// only create repositories for entities that inherit from Entity
public interface IRepository<TEntity> where TEntity : Entity;