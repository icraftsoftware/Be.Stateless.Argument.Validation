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
	public static class StringArgumentConstraints
	{
		public static T IsNotNullOrEmpty<T>(this T validator, string parameter, string parameterName) where T : IArgumentConstraint
		{
			return string.IsNullOrEmpty(parameter)
				? validator.AddException(new ArgumentNullException(parameterName, $"'{parameterName}' cannot be null or empty."))
				: validator;
		}

		public static T IsNotNullOrWhiteSpace<T>(this T validator, string parameter, string parameterName) where T : IArgumentConstraint
		{
			return string.IsNullOrWhiteSpace(parameter)
				? validator.AddException(new ArgumentNullException(parameterName, $"'{parameterName}' cannot be null, empty, or contain only white spaces."))
				: validator;
		}
	}
}
