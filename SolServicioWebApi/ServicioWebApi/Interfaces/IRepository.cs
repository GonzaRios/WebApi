﻿namespace ServicioWebApi.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T entity);
        Task <T> Delete(int id);
        Task<T> Update(T entity);
    }
}
