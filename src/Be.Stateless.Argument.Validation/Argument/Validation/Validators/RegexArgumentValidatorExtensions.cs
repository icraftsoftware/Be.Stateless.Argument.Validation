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
using System.Text.RegularExpressions;

namespace Be.Stateless.Argument.Validation
{
	public static class RegexArgumentValidatorExtensions
	{
		public static T Matches<T>(this T validator, string parameter, Regex regularExpression, string parameterName) where T : IArgumentValidator
		{
			if (regularExpression == null) throw new ArgumentNullException(nameof(regularExpression));
			return regularExpression.IsMatch(parameter)
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must match '{regularExpression}', but was '{parameter}'.", parameterName));
		}

		public static T Matches<T>(this T validator, string parameter, string pattern, string parameterName) where T : IArgumentValidator
		{
			return Regex.IsMatch(parameter, pattern)
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must match '{pattern}', but was '{parameter}'.", parameterName));
		}
	}
}
