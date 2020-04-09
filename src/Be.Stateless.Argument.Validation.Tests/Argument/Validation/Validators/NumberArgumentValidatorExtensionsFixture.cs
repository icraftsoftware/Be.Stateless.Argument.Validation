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
			Action act = () => Validation.Setup()
				.IsNegative(1d, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeDoubleThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNegative(-1d, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeFloatThrows()
		{
			Action act = () => Validation.Setup()
				.IsNegative(1f, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeFloatThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNegative(-1f, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeIntThrows()
		{
			Action act = () => Validation.Setup()
				.IsNegative(1, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeIntThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNegative(-1, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeLongThrows()
		{
			Action act = () => Validation.Setup()
				.IsNegative(1L, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeLongThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNegative(-1L, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNegativeShortThrows()
		{
			Action act = () => Validation.Setup()
				.IsNegative((short) 1, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be negative (<= 0), but was 1.*");
		}

		[Fact]
		public void IsNegativeShortThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNegative((short) -1, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveDoubleThrows()
		{
			Action act = () => Validation.Setup()
				.IsPositive(-1d, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveDoubleThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsPositive(1d, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveFloatThrows()
		{
			Action act = () => Validation.Setup()
				.IsPositive(-1f, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveFloatThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsPositive(1f, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveIntThrows()
		{
			Action act = () => Validation.Setup()
				.IsPositive(-1, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveIntThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsPositive(1, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveLongThrows()
		{
			Action act = () => Validation.Setup()
				.IsPositive(-1L, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveLongThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsPositive(1L, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsPositiveShortThrows()
		{
			Action act = () => Validation.Setup()
				.IsPositive((short) -1, "value")
				.Validate();

			act.Should().Throw<ArgumentOutOfRangeException>()
				.WithMessage("Number 'value' must be positive (>= 0), but was -1.*");
		}

		[Fact]
		public void IsPositiveShortThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsPositive((short) 1, "value")
				.Validate();

			act.Should().NotThrow();
		}
	}
}
