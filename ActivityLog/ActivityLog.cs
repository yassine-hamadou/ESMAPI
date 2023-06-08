using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using ServiceManagerApi.UserModels;
using System.IdentityModel.Tokens.Jwt;

namespace ServiceManagerApi.ActivityLog
{
    public class ActivityLog :IActionFilter
    {
        private readonly UserDbContext ?_context;
        public ActivityLog(UserDbContext context) => _context = context;

        public UserDbContext Context { get; }

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string data = "";

            var routeData = context.RouteData;
            var controller = routeData.Values["controller"];
            var action = routeData.Values["action"];

            var url = $"{controller}/{action}";

            if (!string.IsNullOrEmpty(context.HttpContext.Request.QueryString.Value))
            {
                data = context.HttpContext.Request.QueryString.Value;
            }
            else
            {
                var arguments = context.ActionArguments;
                var value = arguments.FirstOrDefault().Value;
                var convertedValue = JsonConvert.SerializeObject(value);
                data = convertedValue;
            }

            var ipAddress = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var userToken = context.HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", string.Empty);

            if (userToken != "")
            {
                var handler = new JwtSecurityTokenHandler();

                var jsonToken = handler.ReadJwtToken(userToken.Trim()) as JwtSecurityToken;

                var username = jsonToken.Claims.FirstOrDefault(x => x.Type == "username")?.Value;


                Console.WriteLine(
                    $"\tUsername: {username}"+
                    $"\tIP: {ipAddress}"+
                    $"\tData: {data}"+
                    $"\tUrl: {url}"                    
                    );
                var userActivity = new UserActivity
                {
                    DataItem = data,
                    Ipaddress = ipAddress,
                    Username = username,
                    Url = url,
                    RequestTime = DateTime.Now,
                };


                _context.UserActivities.Add(userActivity);
                _context.SaveChanges();

            }

            else
            {
                Console.WriteLine(
                   $"\tIP: {ipAddress}" +
                   $"\tData: {data}" +
                   $"\tUrl: {url}"
                   );
                var userActivity = new UserActivity
                {
                    DataItem = data,
                    Ipaddress = ipAddress,
                    Url = url,
                    RequestTime = DateTime.Now,
                };
                _context.UserActivities.Add(userActivity);
                _context.SaveChanges();
            }

        }
    }
}
