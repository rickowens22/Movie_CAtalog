using System;

namespace MovieCatalog.Models {
    //асбтрактный класс для всех моделей данных
    public abstract class BaseEntity {
        public int Id {get; set; }
    }  
}