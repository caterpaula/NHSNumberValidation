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

            //if checkDigit would be 11, mod 11 will set it to 0
            var checkDigit = (11 - aggregationModulus) % 11;

            return aggregationModulus == checkDigit;
        }
    }
}