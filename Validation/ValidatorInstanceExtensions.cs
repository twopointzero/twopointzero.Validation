﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace twopointzero.Validation
{
    public static class ValidatorInstanceExtensions
    {
        private static ValidatorInstance Add(this ValidatorInstance self, Exception exception)
        {
            ValidatorInstance validatorInstance = self ?? new ValidatorInstance();
            validatorInstance.AddException(exception);

            return validatorInstance;
        }

        public static ValidatorInstance HasLengthInclusive(this ValidatorInstance self, string actualValue,
                                                           string paramName, int minimumLength, int maximumLength)
        {
            return self.HasLengthInclusive(actualValue, paramName, minimumLength, maximumLength, null);
        }

        public static ValidatorInstance HasLengthInclusive(this ValidatorInstance self, string actualValue,
                                                           string paramName, int minimumLength, int maximumLength,
                                                           string message)
        {
            if (actualValue == null)
            {
                return self.IsNotNull(actualValue, paramName, message);
            }

            if (actualValue.Length < minimumLength || actualValue.Length > maximumLength)
            {
                return
                    self.Add(new ArgumentOutOfRangeException(paramName, actualValue,
                                                             message ??
                                                             string.Format(
                                                                 "Expected a string of between {0} and {1} characters inclusive.",
                                                                 minimumLength, maximumLength)));
            }

            return self;
        }

        public static ValidatorInstance IsEqualTo<T>(this ValidatorInstance self, T actualValue, string paramName,
                                                     T expectedValue) where T : class
        {
            return self.IsEqualTo(actualValue, paramName, expectedValue, null);
        }

        public static ValidatorInstance IsEqualTo<T>(this ValidatorInstance self, T actualValue, string paramName,
                                                     T expectedValue, string message) where T : class
        {
            if (actualValue != expectedValue)
            {
                if (actualValue == null)
                {
                    return self.IsNotNull(actualValue, paramName, message);
                }
                return
                    self.Add(new ArgumentOutOfRangeException(paramName, actualValue,
                                                             message ?? "Expected: " + expectedValue));
            }

            return self;
        }

        public static ValidatorInstance IsLessThan(this ValidatorInstance self, byte actualValue, string paramName,
                                                   byte expectedValue)
        {
            return self.IsLessThan(actualValue, paramName, expectedValue, null);
        }

        public static ValidatorInstance IsLessThan(this ValidatorInstance self, byte actualValue, string paramName,
                                                   byte expectedValue, string message)
        {
            if (actualValue >= expectedValue)
            {
                return
                    self.Add(new ArgumentOutOfRangeException(paramName, actualValue,
                                                             message ??
                                                             string.Format("Expected a value less than {0}.",
                                                                           expectedValue)));
            }

            return self;
        }

        public static ValidatorInstance IsNotNull<T>(this ValidatorInstance self, T actualValue, string paramName)
            where T : class
        {
            return self.IsNotNull(actualValue, paramName, null);
        }

        public static ValidatorInstance IsNotNull<T>(this ValidatorInstance self, T actualValue, string paramName,
                                                     string message) where T : class
        {
            if (actualValue == null)
            {
                return
                    self.Add(message == null
                                 ? new ArgumentNullException(paramName)
                                 : new ArgumentNullException(paramName, message));
            }

            return self;
        }

        public static ValidatorInstance IsNotNullOrEmpty<T>(this ValidatorInstance self, IEnumerable<T> actualValue,
                                                            string paramName)
        {
            return self.IsNotNullOrEmpty(actualValue, paramName, null);
        }

        public static ValidatorInstance IsNotNullOrEmpty<T>(this ValidatorInstance self, IEnumerable<T> actualValue,
                                                            string paramName, string message)
        {
            if (actualValue == null)
            {
                return self.IsNotNull(actualValue, paramName, message);
            }

            if (!actualValue.Any())
            {
                return
                    self.Add(new ArgumentOutOfRangeException(paramName, actualValue,
                                                             message ?? "Expected a non-empty enumerable."));
            }

            return self;
        }

        public static ValidatorInstance IsNotNullOrEmpty(this ValidatorInstance self, string actualValue,
                                                         string paramName)
        {
            return self.IsNotNullOrEmpty(actualValue, paramName, null);
        }

        public static ValidatorInstance IsNotNullOrEmpty(this ValidatorInstance self, string actualValue,
                                                         string paramName, string message)
        {
            if (string.IsNullOrEmpty(actualValue))
            {
                if (actualValue == null)
                {
                    return self.IsNotNull(actualValue, paramName, message);
                }
                return
                    self.Add(new ArgumentOutOfRangeException(paramName, actualValue,
                                                             message ?? "Expected a non-empty string."));
            }

            return self;
        }

        public static ValidatorInstance Validate(this ValidatorInstance self)
        {
            if (self != null)
            {
                self.Throw();
            }

            return self;
        }
    }
}