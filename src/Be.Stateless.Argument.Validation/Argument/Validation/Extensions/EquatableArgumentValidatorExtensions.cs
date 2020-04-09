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

namespace Be.Stateless.Argument.Validation.Extensions
{
	/// <summary>
	/// Support equality validation for arguments that only implements <see cref="IEquatable{T}"/>.
	/// </summary>
	/// <remarks>
	/// This class is in a separate namespace and thus yields precedence to <see cref="ComparableArgumentValidatorExtensions"/>
	/// for equality validation. This namespace therefore only needs to be included if the arguments to validate only implements
	/// <see cref="IEquatable{T}"/> but not <see cref="IComparable"/> nor <see cref="IComparable{T}"/>.
	/// </remarks>
	public static class EquatableArgumentValidatorExtensions
	{
		public static ArgumentValidator IsEqualTo<T>(this ArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IEquatable<T>
		{
			return comparand.Equals(comparator)
				? validator
				: (validator ?? new ArgumentValidator()).AddException(
					new ArgumentException($"'{parameterName}' must be equal to {comparator}, but was {comparand}.", parameterName));
		}

		public static ArgumentValidator IsNotEqualTo<T>(this ArgumentValidator validator, T comparand, T comparator, string parameterName)
			where T : IEquatable<T>
		{
			return !comparand.Equals(comparator)
				? validator
				: (validator ?? new ArgumentValidator()).AddException(
					new ArgumentException($"'{parameterName}' cannot be equal to {comparator}.", parameterName));
		}
	}
}
