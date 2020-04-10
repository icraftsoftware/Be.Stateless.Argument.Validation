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
using System.Linq;

namespace Be.Stateless.Argument.Validation
{
	internal sealed class ArgumentValidatorStage2 : IArgumentValidatorStage2
	{
		internal ArgumentValidatorStage2()
		{
			// optimization for most cases, which will have only one exception
			ExceptionList = new List<Exception>(1);
		}

		#region IArgumentValidatorStage2 Members

		public IEnumerable<Exception> Exceptions => ExceptionList.ToArray();

		#endregion

		private IList<Exception> ExceptionList { get; }

		internal void AddException(Exception exception)
		{
			ExceptionList.Add(new InvalidOperationException(exception.Message));
		}
	}
}
