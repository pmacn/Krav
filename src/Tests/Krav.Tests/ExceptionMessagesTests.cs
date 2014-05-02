using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Krav.Tests
{
    public class ExceptionMessagesTests
    {
        [Fact]
        public void SettingCurrentExceptionMessages_RequirementsUseCustomMessages()
        {
            var message = "NULL LOL!";
            ExceptionMessages.Current = new CustomExceptionMessages { wasNull = message };

            var ex = Assert.Throws<ArgumentNullException>(
                () => Require.That((object)null, "foo").IsNotNull());

            Assert.Contains(message, ex.Message);
        }
    }

    public class CustomExceptionMessages : ExceptionMessages
    {
        public string wasNull;
        public override string WasNull { get { return wasNull; } }
    }
}
