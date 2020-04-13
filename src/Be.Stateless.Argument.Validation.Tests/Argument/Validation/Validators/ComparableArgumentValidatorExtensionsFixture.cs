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
			Action act = () => Validation.Setup()
				.IsEqualTo(1, 2, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be equal to 2, but was 1.*");
		}

		[Fact]
		public void IsEqualToThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsEqualTo(7, 7, "value")
				.Validate()
				.IsEqualTo(1, 2, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be equal to 2, but was 1.*");
		}

		[Fact]
		public void IsEqualToThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsEqualTo(7, 7, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsGreaterOrEqualThanThrows()
		{
			Action act = () => Validation.Setup()
				.IsGreaterOrEqualThan(1, 2, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be greater or equal than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterOrEqualThanThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsGreaterOrEqualThan(7, 7, "value")
				.Validate()
				.IsGreaterOrEqualThan(1, 2, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be greater or equal than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterOrEqualThanThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsGreaterOrEqualThan(7, 7, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsGreaterThanThrows()
		{
			Action act = () => Validation.Setup()
				.IsGreaterThan(1, 2, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be greater than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterThanThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsGreaterThan(7, 6, "value")
				.Validate()
				.IsGreaterThan(1, 2, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be greater than 2, but was 1.*");
		}

		[Fact]
		public void IsGreaterThanThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsGreaterThan(7, 6, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsLessOrEqualThanThrows()
		{
			Action act = () => Validation.Setup()
				.IsLessOrEqualThan(2, 1, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be less or equal than 1, but was 2.*");
		}

		[Fact]
		public void IsLessOrEqualThanThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsLessOrEqualThan(6, 7, "value")
				.Validate()
				.IsLessOrEqualThan(2, 1, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be less or equal than 1, but was 2.*");
		}

		[Fact]
		public void IsLessOrEqualThanThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsLessOrEqualThan(6, 7, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsLessThanThrows()
		{
			Action act = () => Validation.Setup()
				.IsLessThan(2, 1, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be less than 1, but was 2.*");
		}

		[Fact]
		public void IsLessThanThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsLessThan(6, 7, "value")
				.Validate()
				.IsLessThan(2, 1, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be less than 1, but was 2.*");
		}

		[Fact]
		public void IsLessThanThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsLessThan(6, 7, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNotEqualToThrows()
		{
			Action act = () => Validation.Setup()
				.IsNotEqualTo(1, 1, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' cannot be equal to 1.*");
		}

		[Fact]
		public void IsNotEqualToThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsNotEqualTo(1, 2, "value")
				.Validate()
				.IsNotEqualTo(1, 1, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' cannot be equal to 1.*");
		}

		[Fact]
		public void IsNotEqualToThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNotEqualTo(1, 2, "value")
				.Validate();

			act.Should().NotThrow();
		}
	}
}
