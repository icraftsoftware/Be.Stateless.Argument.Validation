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
using System.Diagnostics.CodeAnalysis;

namespace Be.Stateless.Argument.Validation
{
	public static class TypeArgumentValidatorExtensions
	{
		[SuppressMessage("ReSharper", "UnusedParameter.Global")]
		public static ArgumentValidator IsNullable<T>(this ArgumentValidator validator, T parameter, string parameterName)
		{
			var type = typeof(T);
			return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)
				? validator
				: (validator ?? new ArgumentValidator()).AddException(
					new ArgumentException($"'{parameterName}' must be a nullable type, but is of type '{typeof(T)}', which is not.", parameterName));
		}

		public static ArgumentValidator IsOfType<T>(this ArgumentValidator validator, object parameter, string parameterName)
		{
			return parameter is T
				? validator
				: (validator ?? new ArgumentValidator()).AddException(
					new ArgumentException($"'{parameterName}' must be of the type '{typeof(T)}', but was of type '{parameter.GetType()}'.", parameterName));
		}

		public static ArgumentValidator IsOfType(this ArgumentValidator validator, object parameter, Type type, string parameterName)
		{
			return type.IsInstanceOfType(parameter)
				? validator
				: (validator ?? new ArgumentValidator()).AddException(
					new ArgumentException($"'{parameterName}' must be of the type '{type}', but was of type '{parameter.GetType()}'.", parameterName));
		}
	}
}
