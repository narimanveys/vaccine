using System.Linq;
using System.Text.RegularExpressions;

namespace PattientVaccinationApp.CustomValidators
{
    public static class SNILSChecksum
    {
        #region Fields

        private const string patternDigitsOnly = "^[0-9]+$";
        private const string patternThreeRepetitionsInRow = @"([0-9])\1{2}";

        #endregion

        #region Methods

        public static bool VerifySnils(string data)
        {
            var formatData = data.Replace("-", string.Empty);
            formatData = formatData.Replace(" ", string.Empty);

            if (!Regex.IsMatch(formatData, patternDigitsOnly))
                return false;
            if (!formatData.Length.Equals(11))
                return false;
            if (Regex.IsMatch(formatData.Substring(0, 9),patternThreeRepetitionsInRow))
                return false;

            var sum = GetSum(formatData);

            var rest = GetRest(sum);

            var last = formatData.Substring(formatData.Length - 2);
            var inputSum = int.Parse(last);

            return inputSum == rest;
        }

        private static int GetSum(string data)
        {
            var array = GetIntArrayFromString(data, 9);
            var sum = array.Reverse().Select((element, i) => element * (i + 1)).Sum();

            return sum;
        }

        private static int GetRest(int data)
        {
            if (data < 100) return data;

            if (data == 100 || data == 101) return 0;

            return data % 101;
        }


        private static int[] GetIntArrayFromString(string str, int lenght)
        {
            return str.Select(x => int.Parse(x.ToString())).TakeWhile((element, index) => index < lenght).ToArray();
        }

        #endregion
    }
}