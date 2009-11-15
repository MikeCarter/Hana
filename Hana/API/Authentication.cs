using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Hana.API {
    public interface IAuthentication{
        bool UserIsValid(string userName, string password);
    }

    public class ASPMembershipAuthentication : IAuthentication{

        public bool UserIsValid(string userName, string password){
            return Membership.ValidateUser(userName, password);
        }

    }
}
