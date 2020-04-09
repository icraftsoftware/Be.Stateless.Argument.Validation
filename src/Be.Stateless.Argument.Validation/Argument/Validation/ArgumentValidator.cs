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
	public sealed class ArgumentValidator
	{
		internal ArgumentValidator()
		{
			// optimization for most cases, which will have only one exception
			_exceptions = new List<Exception>(1);
		}

		public IEnumerable<Exception> Exceptions => _exceptions.ToArray();

		private IList<Exception> ExceptionList => _exceptions;

		public ArgumentValidator AddException(Exception exception)
		{
			ExceptionList.Add(exception);
			return this;
		}

		private readonly List<Exception> _exceptions;
	}
}
