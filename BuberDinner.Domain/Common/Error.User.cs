using ErrorOr;

namespace BuberDinner.Domain.Common
{
    public static partial class Errors
    {
        public static  class Register
        {
            public static Error DuplicateEmail => Error.Conflict(code: "User.DuplicateEmail",
                                                                 description: "Email is already in use");
        }
    }
}
