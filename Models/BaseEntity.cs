using System;

namespace MovieCatalog.Models {
    //асбтрактный класс для всех сущностей
    public abstract class BaseEntity {
        public int Id {get; set; }
    }  
}