namespace Company.WebApi.Models.AccountViewModels
{
    using System;
    using System.Collections.Generic;

    public class UserLoginInfoViewModel
    {
        public string LoginProvider { get; set; }

        public string ProviderKey { get; set; }
    }
}
