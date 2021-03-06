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

namespace Be.Stateless.Argument.Validation.Equatable
{
	public class EquatableArgumentConstraintsFixture
	{
		[Fact]
		public void IsEqualToThrows()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsEqualTo(1, 2, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be equal to 2, but was 1.*");
		}

		[Fact]
		public void IsEqualToThrowsForNestedProperties()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsEqualTo(1, 1, "value")
				.Check()
				.IsEqualTo(1, 2, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be equal to 2, but was 1.*");
		}

		[Fact]
		public void IsEqualToThrowsNothing()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsEqualTo(7, 7, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNotEqualToThrows()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotEqualTo(1, 1, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' cannot be equal to 1.*");
		}

		[Fact]
		public void IsNotEqualToThrowsForNestedProperties()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotEqualTo(1, 2, "value")
				.Check()
				.IsNotEqualTo(1, 1, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' cannot be equal to 1.*");
		}

		[Fact]
		public void IsNotEqualToThrowsNothing()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotEqualTo(1, 2, "value")
				.Check();

			act.Should().NotThrow();
		}
	}
}
