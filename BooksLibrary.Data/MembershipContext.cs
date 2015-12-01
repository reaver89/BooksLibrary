using System.Security.Principal;
using BooksLibrary.Membership;

namespace BooksLibrary.Data
{
    public class MembershipContext
    {
        public IPrincipal Principal { get; set; }
        public User User { get; set; }
        public bool IsValid() { return Principal != null; }
    }
}
