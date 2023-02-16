using Messenger.Entities.UserEnity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Messenger.Tests
{
    [TestClass]
    public class UserTests
    {
        [ExpectedException(typeof(Exception))]
        [TestMethod]
        public void CreatePersonalChat_NoInterlocutor_Exception()
        {
            var user = new User("124", "124", "124");

            
        }
    }
}
