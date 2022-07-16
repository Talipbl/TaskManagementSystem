using Business.Abstracts;
using Business.Concretes;
using DataAccess.Abstracts;
using DataAccess.Concretes.EntityFrameworks;
using Entity.Concretes.DTO;
using System;

namespace ConsoleTestUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            //GetCategories();
            //RegisterUser();
            //LoginUser();

        }

        private static void LoginUser()
        {
            IUserService userService = new UserManager(new EfUserDal());
            IAuthenticationService authenticationService = new AuthenticationManager(
                userService, new PasswordManager(new EfPasswordDal()));

            UserLoginDTO user = new UserLoginDTO()
            {
                EMail = "talip@talip.com",
                Password = "ebegümeci"
            };
            if (authenticationService.Login(user))
            {
                Console.WriteLine("Giriş Başarılı");
            }
            else
            {
                Console.WriteLine("Giriş Başarısız");
            }
        }

        private static void GetCategories()
        {
            ICategoryService categoryService = new CategoryManager(new EfCategoryDal());
            var result = categoryService.GetCategories();
            foreach (var category in result)
            {
                Console.WriteLine(category.Name);
            }
        }

        private static void RegisterUser()
        {
            IUserService userService = new UserManager(new EfUserDal());
            IAuthenticationService authenticationService = new AuthenticationManager(
                userService, new PasswordManager(new EfPasswordDal()));
            UserRegisterDTO user = new UserRegisterDTO()
            {
                FirstName = "Ali",
                LastName = "KORUKCU",
                MailAdress = "ali@ali.com",
                PhoneNumber = "+90132456",
                Password = "sıddık"//ebegümeci
            };
            authenticationService.Register(user);
        }
    }
}
