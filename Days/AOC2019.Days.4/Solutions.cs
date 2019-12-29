using AOC2019.Modules.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace AOC2019.Days._4
{
    public class Solutions
    {
        private readonly ITestOutputHelper _output;
        public Solutions(ITestOutputHelper output)
        {
            _output = output;
        }


        [Fact(DisplayName = "Part One")]
        public void PartOne()
        {
            var nHits = 0;
            var passwordChecker = new PasswordChecker();
            for (var password = 353096; password <= 843212; password++)
            {
                if (passwordChecker.Valid(password.ToString()))
                {
                    nHits++;
                }
            }

            _output.WriteLine($"Number of valid passwords: {nHits}");
        }

        [Fact(DisplayName = "Part Two")]
        public void PartTwo()
        {
            var nHits = 0;
            var passwordChecker = new PasswordCheckerNew();
            for (var password = 353096; password <= 843212; password++)
            {
                if (passwordChecker.Valid(password.ToString()))
                {
                    nHits++;
                }
            }

            _output.WriteLine($"Number of valid passwords: {nHits}");
        }
    }
}
