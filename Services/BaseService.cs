using System;
using System.Collections.Generic;

namespace MovieCatalog.Services 
{
    public abstract class BaseService<T> {
        
        //возвращает все сущности
        
        public abstract IEnumerable<T> GetAll();

        //возвращает сущность по id
        public abstract T GetById(int id);

        //добавляет новую сущность
        public abstract void Add(T entity);

        //обновляет существующую сущность

        public abstract void Update(T entity);

        //удаляет сущность по id

        public abstract void Delete(int id);
    }
}