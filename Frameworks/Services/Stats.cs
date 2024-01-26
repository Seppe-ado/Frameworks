using Frameworks.Areas.Identity.Data;

namespace Frameworks.Services
{
    public class Stats
    {
        readonly RequestDelegate requestDelegate;

        struct UserStatistics
        {
            public FrameworksUser User { get; set; }
            public DateTime FirstConnected { get; set; }
            public int NumberOfRequests { get; set; }
            public DateTime LastConnected { get; set; }
        }
        static Dictionary<string, UserStatistics> Dict = null;

        public Stats(RequestDelegate next)
        {
            Dict = new Dictionary<string, UserStatistics>();

            requestDelegate = next;
        }

        public async Task Invoke(HttpContext context, IMyUser user)
        {
            try
            {
                UserStatistics stat = Dict[user.User().UserName];
                stat.LastConnected = DateTime.Now;
                stat.NumberOfRequests = stat.NumberOfRequests + 1;
                Dict[user.User().UserName] = stat;
            } catch
            {
                UserStatistics stat = new UserStatistics();
                stat.User= user.User();
                stat.FirstConnected = DateTime.Now;
                stat.NumberOfRequests = 1;
                stat.LastConnected = DateTime.Now;
                Dict[user.User().UserName] = stat;
            }
            await requestDelegate(context);
        }

        public static int GetNumberRequests(string name)
        {
            return Dict[name].NumberOfRequests;
        }


    }

}
