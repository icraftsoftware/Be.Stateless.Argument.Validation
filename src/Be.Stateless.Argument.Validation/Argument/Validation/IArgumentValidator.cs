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
using System.Collections.Generic;

namespace Be.Stateless.Argument.Validation
{
	/// <summary>
	/// Support argument validations.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Simple, i.e. scalar, argument validators can be chained and evaluated altogether through one single <see
	/// cref="ArgumentValidatorExtensions.Check"/> method call.
	/// </para>
	/// <para>
	/// Compound arguments, i.e. nested object properties, however can only be validated via a subsequent call to the <see
	/// cref="ArgumentValidatorExtensions.Check"/> method; that is to say, once it has been established that the objects whose
	/// nested properties are to be validated have themselves been validated. These validations can be written as a separate
	/// validation setup, see <see cref="Arguments.Constraints">Arguments.Constraints</see>, or they can be chained directly after the
	/// first <see cref="ArgumentValidatorExtensions.Check"/> method call.
	/// </para>
	/// </remarks>
	public interface IArgumentValidator
	{
		IEnumerable<Exception> Exceptions { get; }
	}
}
