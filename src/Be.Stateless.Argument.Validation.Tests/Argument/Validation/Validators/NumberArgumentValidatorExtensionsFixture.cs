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
	public class NumberArgumentValidatorExtensionsFixture
	{
		[Fact]
		public void IsNegativeDoubleThrows()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(1d, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeDoubleThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(-1d, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeFloatThrows()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(1f, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeFloatThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(-1f, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeIntThrows()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(1, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeIntThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(-1, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeLongThrows()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(1L, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeLongThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsNegative(-1L, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeShortThrows()
		{
			Action act = () => Arguments.Constraints
				.IsNegative((short) 1, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeShortThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsNegative((short) -1, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveDoubleThrows()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(-1d, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveDoubleThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(1d, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveFloatThrows()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(-1f, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveFloatThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(1f, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveIntThrows()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(-1, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveIntThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(1, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveLongThrows()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(-1L, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveLongThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsPositive(1L, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveShortThrows()
		{
			Action act = () => Arguments.Constraints
				.IsPositive((short) -1, "value")
				.Check();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveShortThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsPositive((short) 1, "value")
				.Check();

			act.Should().NotThrow();
		}
	}
}
