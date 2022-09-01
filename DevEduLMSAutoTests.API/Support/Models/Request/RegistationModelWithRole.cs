using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevEduLMSAutoTests.API.Support.Models.Request
{
    public class RegistationModelWithRole
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string City { get; set; }

        public string BirthDate { get; set; }

        public string GitHubAccount { get; set; }

        public string PhoneNumber { get; set; }

        public string Role { get; set; }

        public RegisterRequest CreateRegisterRequest(RegistationModelWithRole model)
        {
            RegisterRequest registerRequest = new RegisterRequest()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Patronymic = model.Patronymic,
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                City = model.City,
                BirthDate = model.BirthDate,
                GitHubAccount = model.GitHubAccount,
                PhoneNumber = model.PhoneNumber
            };
            return registerRequest;
        }
    }
}
