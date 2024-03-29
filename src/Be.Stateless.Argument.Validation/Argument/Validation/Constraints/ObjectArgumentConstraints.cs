﻿#region Copyright & License

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
	public static class ObjectArgumentConstraints
	{
		[Pure]
		public static TV IsDefault<TV, TA>(this TV validator, TA parameter, string parameterName) where TV : IArgumentConstraint
		{
			return Equals(parameter, default(TA))
				? validator
				: typeof(TA).IsClass
					? validator.AddException(new ArgumentException($"'{parameterName}' reference type must be null.", parameterName))
					: validator.AddException(new ArgumentException($"'{parameterName}' value type must be default.", parameterName));
		}

		[Pure]
		public static TV IsNotDefault<TV, TA>(this TV validator, TA parameter, string parameterName) where TV : IArgumentConstraint
		{
			return !Equals(parameter, default(TA))
				? validator
				: typeof(TA).IsClass
					? validator.AddException(new ArgumentNullException(parameterName, $"'{parameterName}' reference type cannot be null."))
					: validator.AddException(new ArgumentException($"'{parameterName}' value type cannot be default.", parameterName));
		}

		[Pure]
		public static TV IsNotNull<TV, TA>(this TV validator, TA parameter, string parameterName)
			where TV : IArgumentConstraint
			where TA : class
		{
			return parameter is null
				? validator.AddException(new ArgumentNullException(parameterName, $"'{parameterName}' cannot be null."))
				: validator;
		}

		[Pure]
		public static TV IsNull<TV, TA>(this TV validator, TA parameter, string parameterName)
			where TV : IArgumentConstraint
			where TA : class
		{
			return parameter is null
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be null.", parameterName));
		}
	}
}
