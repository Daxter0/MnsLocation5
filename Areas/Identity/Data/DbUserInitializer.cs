using MnsLocation5.Data;

namespace MnsLocation5.Areas.Identity.Data
{
    public class DbUserInitializer
    {
        public static void Initialize(UserContext context)
        {
            if (context.Database.EnsureCreated())
            {
                User[] users = new User[]
                {
                new User{Email="Jacki"}

                };

                foreach (User user in users)
                {
                    context.Users.Add(user);
                }
            }
        }
    }
}
