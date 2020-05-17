using System.Linq;

namespace NHSNumberValidation
{
    public class NhsNumberValidator
    {
        public bool NhsNumberIsValid(string nhsNumber)
        {
            if (nhsNumber.Length != 10)
                return false;

            if (!nhsNumber.All(char.IsDigit))
                return false;

            var digitStrings = nhsNumber.ToCharArray().Select(x => x.ToString());

            var digitArray = digitStrings.Select(int.Parse);

            var weightingFactor = 10;
            var multiplicationAggregation = 0;
            foreach (var digit in digitArray)
            {
                multiplicationAggregation += weightingFactor * digit;
                weightingFactor -= 1;
            }

            var aggregationModulus = multiplicationAggregation % 11;

            var checkDigit = 11 - aggregationModulus;

            if (checkDigit == 11)
                checkDigit = 0;

            return aggregationModulus == checkDigit;
        }
    }
}