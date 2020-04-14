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

namespace Be.Stateless.Argument.Validation
{
	/// <summary>
	/// Entry point to the definition of fluent C# argument validation constraints.
	/// </summary>
	/// <remarks>
	/// No objects are ever allocated unless one or more validation constraints could not be satisfied.
	/// </remarks>
	public static class Arguments
	{
		#region Nested Type: Validation

		public static class Validation
		{
			public static IArgumentConstraint Constraints => null;
		}

		#endregion
	}
}
