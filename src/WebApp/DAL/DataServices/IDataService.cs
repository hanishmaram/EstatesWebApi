﻿using System.Collections.Generic;

namespace WebApp.DAL.DataServices
{
    public interface IDataService<T> where T: class
    {
        IReadOnlyList<T> GetAll();

        IReadOnlyList<T> GetFilteredBy(string name);

        int? Create(T dto);

        bool Update(T dto);

        void Delete(int id);
    }
}
