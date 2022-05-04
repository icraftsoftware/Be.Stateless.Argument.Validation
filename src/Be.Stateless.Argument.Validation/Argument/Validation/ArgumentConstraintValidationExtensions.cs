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
using System.Linq;

namespace Be.Stateless.Argument.Validation
{
	public static class ArgumentConstraintValidationExtensions
	{
		public static T AddException<T>(this T validator, Exception exception) where T : IArgumentConstraint
		{
			if (typeof(T) == typeof(INestedArgumentConstraint))
			{
				var argumentValidator = validator as NestedArgumentConstraintValidator ?? new NestedArgumentConstraintValidator();
				argumentValidator.AddException(exception);
				return (T) (INestedArgumentConstraint) argumentValidator;
			}
			else
			{
				var argumentValidator = validator as ArgumentConstraintValidator ?? new ArgumentConstraintValidator();
				argumentValidator.AddException(exception);
				return (T) (IArgumentConstraint) argumentValidator;
			}
		}

		[SuppressMessage("ReSharper", "InvertIf")]
		[SuppressMessage("ReSharper", "UnusedMember.Global", Justification = "Public API.")]
		public static INestedArgumentConstraint Check(this IArgumentConstraint constraint)
		{
			if (constraint != null)
			{
				if (!constraint.Exceptions.Skip(1).Any()) throw constraint.Exceptions.Single();
				throw new AggregateException("Argument validation failed for several reasons.", constraint.Exceptions);
			}
			return null;
		}
	}
}
