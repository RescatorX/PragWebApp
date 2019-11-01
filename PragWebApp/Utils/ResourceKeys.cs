using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PragWebApp.Utils
{
    public static class ResourceKeys
    {
        public class Controllers
        {
            public class AccountController
            {
                public const string FirstName = "AccountViewModels_RegisterViewModel_FirstName";
            }

            public class CustomerController
            {
                public const string FirstName = "CustomerEntity_FirstName";
                public const string LastName = "CustomerEntity_LastName";
                public const string Email = "CustomerEntity_Email";
                public const string PhoneNumber = "CustomerEntity_PhoneNumber";
                public const string SendEmails = "CustomerEntity_SendEmails";
                public const string SendSmss = "CustomerEntity_SendSmss";
                public const string Description = "CustomerEntity_Description";
                public const string Created = "CustomerEntity_Created";
                public const string Status = "CustomerEntity_Status";
            }
        }
    }
}
