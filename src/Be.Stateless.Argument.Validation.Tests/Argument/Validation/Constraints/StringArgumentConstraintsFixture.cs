﻿#region Copyright & License

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
	public class StringArgumentConstraintsFixture
	{
		[Fact]
		public void IsNotNullOrEmptyThrows()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotNullOrEmpty(string.Empty, "value")
				.Check();

			act.Should().Throw<ArgumentNullException>()
				.WithMessage("'value' cannot be null or empty.*");
		}

		[Fact]
		public void IsNotNullOrEmptyThrowsNothing()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotNullOrEmpty("non empty string", "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNotNullOrWhiteSpaceThrows()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotNullOrWhiteSpace("   ", "value")
				.Check();

			act.Should().Throw<ArgumentNullException>()
				.WithMessage("'value' cannot be null, empty, or contain only white spaces.*");
		}

		[Fact]
		public void IsNotNullOrWhiteSpaceThrowsNothing()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotNullOrWhiteSpace("non empty string", "value")
				.Check();

			act.Should().NotThrow();
		}
	}
}
