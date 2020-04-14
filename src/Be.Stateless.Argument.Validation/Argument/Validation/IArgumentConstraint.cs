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
	/// Support the definition of argument validation constraints that have to be checked.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Simple, i.e. scalar, argument validation constraints can be chained and evaluated all together through one single <see
	/// cref="ArgumentConstraintValidationExtensions.Check"/> method call.
	/// </para>
	/// <para>
	/// Compound arguments, i.e. nested object properties, however should only be validated via a subsequent call to the <see
	/// cref="ArgumentConstraintValidationExtensions.Check"/> method; that is to say, once it has been established that the
	/// objects whose nested properties are to be checked have themselves been validated. These validation constraints can be
   /// written as a separate set of constraint, see <see cref="Arguments.Validation.Constraints">Arguments.Constraints</see>, or
	/// they can be chained directly after the first call to the <see cref="ArgumentConstraintValidationExtensions.Check"/>
	/// method.
	/// </para>
	/// </remarks>
	public interface IArgumentConstraint
	{
		IEnumerable<Exception> Exceptions { get; }
	}
}
