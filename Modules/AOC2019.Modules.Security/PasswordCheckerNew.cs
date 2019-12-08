namespace AOC2019.Modules.Security
{
    public class PasswordCheckerNew : PasswordChecker
    {
        public override bool Valid(int[] password)
        {
            var adjecentNumbers = false;
            var increasingNumbers = true;
            var groupSize = 1;

            for (var i = 1; i < password.Length; i++)
            {
                var val0 = password[i - 1];
                var val1 = password[i];

                increasingNumbers = increasingNumbers && (val0 <= val1);
                if (!increasingNumbers)
                {
                    return false;
                }

                if (val0 == val1)
                {
                    groupSize++;
                }
                else
                {
                    adjecentNumbers = adjecentNumbers || groupSize == 2;
                    groupSize = 1;
                }

            }

            return adjecentNumbers || groupSize == 2;
        }
    }
}
