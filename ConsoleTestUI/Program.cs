using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFrameworks;
using Entity.Concretes.DTO;
using Entity.Concretes.Models;
using Services.Security.JWT;
using System;

namespace ConsoleTestUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string message = "{} eklendi";
            Console.WriteLine(String.Format(message,"Ürün"));


            //GetCategories();
            //RegisterUser();
            //LoginUser();

            //ToDo toDo = new ToDo()
            //{
            //    CategoryId = 1,
            //    Subject = "Mail servisi çalışmıyor",
            //    Description = "kullanıcı mail servsinden mail alamıyor",
            //    ToId = 1001
            //};
            //IToDoService toDoService = new ToDoManager(new EfToDoDal(), new TaskDetailManager(new EfTaskDetailDal()));
            //toDoService.Add(toDo, 1000);
            
        }

        //private static void LoginUser()
        //{
        //    IUserService userService = new UserManager(new EfUserDal());
        //    IAuthenticationService authenticationService = new AuthenticationManager(
        //        userService, new PasswordManager(new EfPasswordDal()), new AccessTokenService());

        //    UserLoginDTO user = new UserLoginDTO()
        //    {
        //        EMail = "talip@talip.com",
        //        Password = "ebegümeci"
        //    };
        //    if (authenticationService.Login(user))
        //    {
        //        Console.WriteLine("Giriş Başarılı");
        //    }
        //    else
        //    {
        //        Console.WriteLine("Giriş Başarısız");
        //    }
        //}

        private static void GetCategories()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            var result = categoryService.GetCategories();
            foreach (var category in result.Data)
            {
                Console.WriteLine(category.Name);
            }
        }

        //private static void RegisterUser()
        //{
        //    IUserService userService = new UserManager(new EfUserDal());
        //    IAuthenticationService authenticationService = new AuthenticationManager(
        //        userService, new PasswordManager(new EfPasswordDal()));
        //    UserRegisterDTO user = new UserRegisterDTO()
        //    {
        //        FirstName = "Ali",
        //        LastName = "KORUKCU",
        //        MailAdress = "ali@ali.com",
        //        PhoneNumber = "+90132456",
        //        Password = "sıddık"//ebegümeci
        //    };
        //    authenticationService.Register(user);
        //}
    }
}
