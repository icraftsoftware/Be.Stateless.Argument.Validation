#region Copyright & License

// Copyright © 2012 - 2020 François Chabot
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
// http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

#endregion

using System;

namespace Be.Stateless.Argument.Validation
{
	public static class ComparableArgumentValidatorExtensions
	{
		public static IArgumentValidator IsEqualTo<T>(this IArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IComparable, IComparable<T>
		{
			return comparand.CompareTo(comparator) == 0
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be equal to {comparator}, but was {comparand}.", parameterName));
		}

		public static IArgumentValidator IsNotEqualTo<T>(this IArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IComparable, IComparable<T>
		{
			return comparand.CompareTo(comparator) != 0
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' cannot be equal to {comparator}.", parameterName));
		}

		public static IArgumentValidator IsGreaterThan<T>(this IArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IComparable, IComparable<T>
		{
			return comparand.CompareTo(comparator) > 0
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be greater than {comparator}, but was {comparand}.", parameterName));
		}

		public static IArgumentValidator IsGreaterOrEqualThan<T>(this IArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IComparable, IComparable<T>
		{
			return comparand.CompareTo(comparator) >= 0
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be greater or equal than {comparator}, but was {comparand}.", parameterName));
		}

		public static IArgumentValidator IsLessThan<T>(this IArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IComparable, IComparable<T>
		{
			return comparand.CompareTo(comparator) < 0
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be less than {comparator}, but was {comparand}.", parameterName));
		}

		public static IArgumentValidator IsLessOrEqualThan<T>(this IArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IComparable, IComparable<T>
		{
			return comparand.CompareTo(comparator) <= 0
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be less or equal than {comparator}, but was {comparand}.", parameterName));
		}
	}
}
