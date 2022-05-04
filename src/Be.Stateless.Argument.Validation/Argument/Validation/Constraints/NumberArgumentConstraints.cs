#region Copyright & License

// Copyright © 2012 - 2022 François Chabot
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
using System.Diagnostics.CodeAnalysis;
using System.Diagnostics.Contracts;

namespace Be.Stateless.Argument.Validation
{
	[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Public API.")]
	[SuppressMessage("ReSharper", "UnusedType.Global", Justification = "Public API.")]
	public static class NumberArgumentConstraints
	{
		[Pure]
		public static T IsNegative<T>(this T validator, double parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter > 0d
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be negative (<= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsNegative<T>(this T validator, float parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter > 0f
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be negative (<= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsNegative<T>(this T validator, int parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter > 0
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be negative (<= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsNegative<T>(this T validator, long parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter > 0L
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be negative (<= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsNegative<T>(this T validator, short parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter > 0
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be negative (<= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsPositive<T>(this T validator, double parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter < 0d
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be positive (>= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsPositive<T>(this T validator, float parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter < 0f
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be positive (>= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsPositive<T>(this T validator, int parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter < 0
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be positive (>= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsPositive<T>(this T validator, long parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter < 0L
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be positive (>= 0), but was {parameter}."))
				: validator;
		}

		[Pure]
		public static T IsPositive<T>(this T validator, short parameter, string parameterName) where T : IArgumentConstraint
		{
			return parameter < 0
				? validator.AddException(new ArgumentOutOfRangeException(parameterName, $"Number '{parameterName}' must be positive (>= 0), but was {parameter}."))
				: validator;
		}
	}
}
