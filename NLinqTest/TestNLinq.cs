using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLinq;
using System.Linq;

namespace NLinqTest
{
    [TestClass]
    public class TestNLinq
    {
        [TestMethod]
        public void TestWhereExpression()
        {
            MyDbContext db = new MyDbContext();
            var query = db.User.Where(o => o.Name == "").Select(o => new { o.ID, o.Name });
            foreach (var item in query)
            { }
        }
    }

    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    public class MyDbContext:DbContext
    {
        public DbSet<User> User { get; set; }

        public MyDbContext()
        {
            User = Set<User>();
        }
    }
}
