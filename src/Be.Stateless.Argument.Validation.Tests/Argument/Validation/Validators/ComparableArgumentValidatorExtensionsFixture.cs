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
	public class ComparableArgumentValidatorExtensionsFixture
	{
		[Fact]
		public void IsEqualToThrows()
		{
			Action act = () => Arguments.Constraints
				.IsEqualTo(1, 2, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be equal to 2, but was 1.*");
		}

		[Fact]
		public void IsEqualToThrowsForNestedProperties()
		{
			Action act = () => Arguments.Constraints
				.IsEqualTo(7, 7, "value")
				.Check()
				.IsEqualTo(1, 2, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be equal to 2, but was 1.*");
		}

		[Fact]
		public void IsEqualToThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsEqualTo(7, 7, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsGreaterOrEqualThanThrows()
		{
			Action act = () => Arguments.Constraints
				.IsGreaterOrEqualThan(1, 2, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be greater or equal than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterOrEqualThanThrowsForNestedProperties()
		{
			Action act = () => Arguments.Constraints
				.IsGreaterOrEqualThan(7, 7, "value")
				.Check()
				.IsGreaterOrEqualThan(1, 2, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be greater or equal than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterOrEqualThanThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsGreaterOrEqualThan(7, 7, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsGreaterThanThrows()
		{
			Action act = () => Arguments.Constraints
				.IsGreaterThan(1, 2, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be greater than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterThanThrowsForNestedProperties()
		{
			Action act = () => Arguments.Constraints
				.IsGreaterThan(7, 6, "value")
				.Check()
				.IsGreaterThan(1, 2, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be greater than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterThanThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsGreaterThan(7, 6, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsLessOrEqualThanThrows()
		{
			Action act = () => Arguments.Constraints
				.IsLessOrEqualThan(2, 1, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be less or equal than 1, but was 2.*");
		}

		[Fact]
		public void IsLessOrEqualThanThrowsForNestedProperties()
		{
			Action act = () => Arguments.Constraints
				.IsLessOrEqualThan(6, 7, "value")
				.Check()
				.IsLessOrEqualThan(2, 1, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be less or equal than 1, but was 2.*");
		}

		[Fact]
		public void IsLessOrEqualThanThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsLessOrEqualThan(6, 7, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsLessThanThrows()
		{
			Action act = () => Arguments.Constraints
				.IsLessThan(2, 1, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be less than 1, but was 2.*");
		}

		[Fact]
		public void IsLessThanThrowsForNestedProperties()
		{
			Action act = () => Arguments.Constraints
				.IsLessThan(6, 7, "value")
				.Check()
				.IsLessThan(2, 1, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be less than 1, but was 2.*");
		}

		[Fact]
		public void IsLessThanThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.IsLessThan(6, 7, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNotEqualToThrows()
		{
			Action act = () => Arguments.Constraints
				.IsNotEqualTo(1, 1, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' cannot be equal to 1.*");
		}

		[Fact]
		public void IsNotEqualToThrowsForNestedProperties()
		{
			Action act = () => Arguments.Constraints
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
			Action act = () => Arguments.Constraints
				.IsNotEqualTo(1, 2, "value")
				.Check();

			act.Should().NotThrow();
		}
	}
}
