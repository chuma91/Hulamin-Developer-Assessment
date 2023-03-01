using Hulamin_Developer__Assessment.Models;
using Hulamin_Developer__Assessment.ViewModels;
using System;
using System.Linq;
using System.Web;

namespace Hulamin_Developer__Assessment.BusinessLogic
{
    public class AccountBusinessLogic
    {

        NorthwingDatabaseEntities1 db = new NorthwingDatabaseEntities1();
        public User SearchExistingUser(string EmailAddress, string Password)
        {
            User List = new User();
            try
            {
                List = db.Users.Where(a => a.EmailAddress.ToLower().Equals(EmailAddress.ToLower()) && a.PasswordHash.Equals(Password) && a.IsDeleted == false).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
            return List;
        }

        public User CheckUserIfUserExist(string EmailAddress)
        {
            User List = new User();
            try
            {
                List = db.Users.Where(a => a.EmailAddress.ToLower().Equals(EmailAddress.ToLower()) && a.IsDeleted == false).FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }
            return List;
        }

        public bool RegisterNewUser(RegisterViewModel registerViewModel)
        {
            bool Saved = false;
            try
            {
                // checking if user exist
                var existing = CheckUserIfUserExist(registerViewModel.EmailAddress);
                if (existing == null)
                {
                    // calling a store procedure
                    int obj = db.RegisterNewUserToDatabase(registerViewModel.FirstName, registerViewModel.LastName, registerViewModel.EmailAddress, registerViewModel.PhoneNumber, registerViewModel.Password, registerViewModel.RoleId, registerViewModel.TerritoryId, false, DateTime.Now, false);
                    if (obj != 0)
                    {
                        Saved = true;
                    }
                }
                else
                {
                    Saved = false;
                }
            }
            catch
            {
                Saved = false;
            }

            return Saved;

        }
    }
}