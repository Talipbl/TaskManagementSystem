﻿using DataAccess.Abstracts;
using Entity.Concretes.Models;

namespace DataAccess.Concretes.EntityFrameworks
{
    public class EfInformationDal : EfEntityRepositoryDal<Information, TaskManagementContext>, IInformationDal
    {
    }
}
