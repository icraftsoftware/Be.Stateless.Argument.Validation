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
	public class ObjectArgumentValidatorExtensionsFixture
	{
		[Fact]
		public void IsNotNullThrows()
		{
			Action act = () => Validation.Setup()
				.IsNotNull((string) null, "value")
				.Validate();

			act.Should().Throw<ArgumentNullException>()
				.WithMessage("'value' cannot be null.*");
		}

		[Fact]
		public void IsNotNullThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNotNull(this, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNullThrows()
		{
			Action act = () => Validation.Setup()
				.IsNull(this, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be null.*");
		}

		[Fact]
		public void IsNullThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNull((string) null, "value")
				.Validate();

			act.Should().NotThrow();
		}
	}
}
