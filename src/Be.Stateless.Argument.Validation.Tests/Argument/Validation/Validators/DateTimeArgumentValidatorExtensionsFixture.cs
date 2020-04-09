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
using FluentAssertions;
using Xunit;

namespace Be.Stateless.Argument.Validation
{
	public class DateTimeArgumentValidatorExtensionsFixture
	{
		[Fact]
		public void IsLocalTimeThrows()
		{
			Action act = () => Validation.Setup()
				.IsLocalTime(DateTime.UtcNow, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be a local time, but was of kind UTC.*");
		}

		[Fact]
		public void IsLocalTimeThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsLocalTime(DateTime.Now, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsUniversalTimeThrows()
		{
			Action act = () => Validation.Setup()
				.IsUniversalTime(DateTime.Now, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be a universal time, but was of kind Local.*");
		}

		[Fact]
		public void IsUniversalTimeThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsUniversalTime(DateTime.UtcNow, "value")
				.Validate();

			act.Should().NotThrow();
		}
	}
}
