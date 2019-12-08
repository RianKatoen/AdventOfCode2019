using System.Linq;
using Xunit;

namespace AOC2019.Modules.Security.Tests
{
    public class UTPasswordChecker
    {
        [Theory(DisplayName = "Test Validate() of password checker")]
        [InlineData("111111", true)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        public void TestValidate(string password, bool result)
        {
            var sut = new PasswordChecker();
            var splitPassword = password.ToCharArray().Select(p => int.Parse(p.ToString())).ToArray();
            Assert.Equal(result, sut.Valid(splitPassword));
        }
    }
}
