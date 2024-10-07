using ErrorOr;

namespace BuberDinner.Domain.Common
{
    public static partial class Errors
    {
        public static class Login
        {
            public static Error DoesNotExist => Error.Conflict(code: "User.DoesNotExist",
                                                                 description: "User with given email does not exists");
            public static Error InvalidPassword => Error.Validation(code: "User.InvalidPassword",
                                                     description: "Invalid password");
        }
    }
}
