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
using System.Linq;

namespace Be.Stateless.Argument.Validation
{
	public static class ArgumentValidatorExtensions
	{
		public static T AddException<T>(this T validator, Exception exception) where T : IArgumentValidator
		{
			if (typeof(T) == typeof(INestedArgumentValidator))
			{
				var argumentValidator = validator as NestedNestedArgumentValidator ?? new NestedNestedArgumentValidator();
				argumentValidator.AddException(exception);
				return (T) (INestedArgumentValidator) argumentValidator;
			}
			else
			{
				var argumentValidator = validator as ArgumentValidator ?? new ArgumentValidator();
				argumentValidator.AddException(exception);
				return (T) (IArgumentValidator) argumentValidator;
			}
		}

		public static INestedArgumentValidator Validate(this IArgumentValidator validator)
		{
			if (validator != null)
			{
				if (!validator.Exceptions.Skip(1).Any()) throw validator.Exceptions.Single();
				throw new AggregateException("Argument validation failed for several reasons.", validator.Exceptions);
			}
			return null;
		}
	}
}
