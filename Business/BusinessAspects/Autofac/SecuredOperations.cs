using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Microsoft.AspNetCore.Http;
using System;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.IoC;
namespace Business.BusinessAspects.Autofac
{
    public class SecuredOperations : MethodInterception
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor; //create a http context foreach user.

        public SecuredOperations(string roles) //in the <Entity>Manager.cs file, before a function [SecuredOperations("Admin","delete")] etc..
        {
            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>(); //we get the IHttpContextAccessor's properties and methods, it comes from DependencyInjection.
        }

        //Execute the SecuredOperation aspect right before the function( Add, Delete etc...) 
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Message.AuthorizationDenied);
        }
    }
}
