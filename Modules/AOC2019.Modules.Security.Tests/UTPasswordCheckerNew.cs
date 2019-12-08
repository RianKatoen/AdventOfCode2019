using System.Linq;
using Xunit;

namespace AOC2019.Modules.Security.Tests
{
    public class UTPasswordCheckerNew
    {
        [Theory(DisplayName = "Test Validate() of password checker")]
        [InlineData("111111", false)]
        [InlineData("223450", false)]
        [InlineData("123789", false)]
        [InlineData("112233", true)]
        [InlineData("123444", false)]
        [InlineData("111122", true)]
        [InlineData("111444", false)]
        [InlineData("111445", true)]
        [InlineData("111456", false)]
        [InlineData("111156", false)]
        [InlineData("122346", true)]
        public void TestValidate(string password, bool result)
        {
            var sut = new PasswordCheckerNew();
            var splitPassword = password.ToCharArray().Select(p => int.Parse(p.ToString())).ToArray();
            Assert.Equal(result, sut.Valid(splitPassword));
        }
    }
}
