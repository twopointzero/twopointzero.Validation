using System.Collections.Generic;

namespace twopointzero.Validation
{
    public static class Validator
    {
        public static ValidatorInstance Create()
        {
            return null;
        }

        public static void HasLengthInclusive(string actualValue, string paramName, int minimumLength, int maximumLength)
        {
            ValidatorInstanceExtensions.HasLengthInclusive(null, actualValue, paramName, minimumLength, maximumLength,
                                                           null).Validate();
        }

        public static void HasLengthInclusive(string actualValue, string paramName, int minimumLength, int maximumLength,
                                              string message)
        {
            ValidatorInstanceExtensions.HasLengthInclusive(null, actualValue, paramName, minimumLength, maximumLength,
                                                           message).Validate();
        }

        public static void IsEqualTo<T>(T actualValue, string paramName, T expectedValue) where T : class
        {
            ValidatorInstanceExtensions.IsEqualTo(null, actualValue, paramName, expectedValue, null).Validate();
        }

        public static void IsEqualTo<T>(T actualValue, string paramName, T expectedValue, string message)
            where T : class
        {
            ValidatorInstanceExtensions.IsEqualTo(null, actualValue, paramName, expectedValue, message).Validate();
        }

        public static void IsLessThan(byte actualValue, string paramName, byte expectedValue)
        {
            ValidatorInstanceExtensions.IsLessThan(null, actualValue, paramName, expectedValue, null).Validate();
        }

        public static void IsLessThan(byte actualValue, string paramName, byte expectedValue, string message)
        {
            ValidatorInstanceExtensions.IsLessThan(null, actualValue, paramName, expectedValue, message).Validate();
        }

        public static void IsNotNull<T>(T actualValue, string paramName) where T : class
        {
            ValidatorInstanceExtensions.IsNotNull(null, actualValue, paramName, null).Validate();
        }

        public static void IsNotNull<T>(T actualValue, string paramName, string message) where T : class
        {
            ValidatorInstanceExtensions.IsNotNull(null, actualValue, paramName, message).Validate();
        }

        public static void IsNotNullOrEmpty<T>(IEnumerable<T> actualValue, string paramName)
        {
            ValidatorInstanceExtensions.IsNotNullOrEmpty(null, actualValue, paramName, null).Validate();
        }

        public static void IsNotNullOrEmpty<T>(IEnumerable<T> actualValue, string paramName, string message)
        {
            ValidatorInstanceExtensions.IsNotNullOrEmpty(null, actualValue, paramName, message).Validate();
        }

        public static void IsNotNullOrEmpty(string actualValue, string paramName)
        {
            ValidatorInstanceExtensions.IsNotNullOrEmpty(null, actualValue, paramName, null).Validate();
        }

        public static void IsNotNullOrEmpty(string actualValue, string paramName, string message)
        {
            ValidatorInstanceExtensions.IsNotNullOrEmpty(null, actualValue, paramName, message).Validate();
        }
    }
}