using Autofac;
using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFrameworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryManager>().As<ICategoryService>().SingleInstance();
            builder.RegisterType<EfCategoryDal>().As<ICategoryDal>().SingleInstance();

            builder.RegisterType<InformationManager>().As<IInformationService>().SingleInstance();
            builder.RegisterType<EfInformationDal>().As<IInformationDal>().SingleInstance();

            builder.RegisterType<PasswordManager>().As<IPasswordService>().SingleInstance();
            builder.RegisterType<EfPasswordDal>().As<IPasswordDal>().SingleInstance();

            builder.RegisterType<TaskDetailManager>().As<ITaskDetailService>().SingleInstance();
            builder.RegisterType<EfTaskDetailDal>().As<ITaskDetailDal>().SingleInstance();

            builder.RegisterType<ToDoManager>().As<IToDoService>().SingleInstance();
            builder.RegisterType<EfToDoDal>().As<IToDoDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();
        }
    }
}
