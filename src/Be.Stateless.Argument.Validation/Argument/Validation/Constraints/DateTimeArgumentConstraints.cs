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
using System.Diagnostics.Contracts;

namespace Be.Stateless.Argument.Validation
{
	public static class DateTimeArgumentConstraints
	{
		[Pure]
		public static T IsLocalTime<T>(this T validator, DateTime value, string parameterName) where T : IArgumentConstraint
		{
			return value.Kind == DateTimeKind.Local
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be a local time, but was of kind {value.Kind}.", parameterName));
		}

		[Pure]
		public static T IsUniversalTime<T>(this T validator, DateTime value, string parameterName) where T : IArgumentConstraint
		{
			return value.Kind == DateTimeKind.Utc
				? validator
				: validator.AddException(new ArgumentException($"'{parameterName}' must be a universal time, but was of kind {value.Kind}.", parameterName));
		}
	}
}
