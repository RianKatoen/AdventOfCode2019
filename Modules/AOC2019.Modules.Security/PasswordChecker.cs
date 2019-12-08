using System.Linq;

namespace AOC2019.Modules.Security
{
    public class PasswordChecker
    {
        private int[] ToIntArray(string password)
        {
            return password
                .ToCharArray()
                .Select(p => int.Parse(p.ToString()))
                .ToArray();
        }

        public bool Valid(string password) => Valid(ToIntArray(password));
        public virtual bool Valid(int[] password)
        {
            var adjecentNumbers = false;
            var increasingNumbers = true;
            for (var i = 1; i < password.Length; i++)
            {
                var val0 = password[i - 1];
                var val1 = password[i];

                increasingNumbers = increasingNumbers && (val0 <= val1);
                if (!increasingNumbers)
                {
                    return false;
                }

                adjecentNumbers = adjecentNumbers || (val0 == val1);
            }

            return adjecentNumbers;
        }
    }
}
