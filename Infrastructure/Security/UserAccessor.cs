using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Security.Claims;
using Application.Interfaces;

namespace Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        IHttpContextAccessor _httpContextAccessor;

        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        
        public string GetCurrentUserName()
        {
            var username = _httpContextAccessor.HttpContext.User?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;

            return username;
        }
    }
}