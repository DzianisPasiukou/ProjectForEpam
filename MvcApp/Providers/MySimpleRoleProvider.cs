using LogicLayer;
using LogicLayer.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebMatrix.WebData;

namespace MvcApp.Providers
{
    public class MySimpleRoleProvider : SimpleRoleProvider
    {
        ISecurityHelper _securityHelper;

        public MySimpleRoleProvider()
            : base()
        {
            _securityHelper = (ISecurityHelper)DependencyResolver.Current.GetService(typeof(ISecurityHelper));

            if (_securityHelper == null)
            {
                throw new InvalidOperationException("ISecurityHelper is not resolved.");
            }
        }

        public override string[] GetRolesForUser(string username)
        {
            return new string[] { _securityHelper.GetGroupForUser(username) };
        }
    }
}