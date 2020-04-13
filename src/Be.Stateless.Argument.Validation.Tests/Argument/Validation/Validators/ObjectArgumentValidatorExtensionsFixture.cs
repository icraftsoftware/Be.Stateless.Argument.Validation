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
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using Xunit;

namespace Be.Stateless.Argument.Validation
{
	public class ObjectArgumentValidatorExtensionsFixture
	{
		[Fact]
		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		public void IsDefaultClass()
		{
			Tuple<int, int> tuple = new Tuple<int, int>(1, 2);

			Action act = () => Validation.Setup()
				.IsDefault(tuple, nameof(tuple))
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'{nameof(tuple)}' reference type must be null.*");
		}

		[Fact]
		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		public void IsDefaultStruct()
		{
			int integer = 12;

			Action act = () => Validation.Setup()
				.IsDefault(integer, nameof(integer))
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'{nameof(integer)}' value type must be default.*");
		}

		[Fact]
		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		public void IsNotDefaultClass()
		{
			Tuple<int, int> tuple = default;

			Action act = () => Validation.Setup()
				.IsNotDefault(tuple, nameof(tuple))
				.Validate();

			act.Should().Throw<ArgumentNullException>()
				.WithMessage($"'{nameof(tuple)}' reference type cannot be null.*");
		}

		[Fact]
		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		public void IsNotDefaultStruct()
		{
			int integer = default;

			Action act = () => Validation.Setup()
				.IsNotDefault(integer, nameof(integer))
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'{nameof(integer)}' value type cannot be default.*");
		}

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
		public void IsNotNullThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsNotNull(this, "value")
				.Validate()
				.IsNotNull((string) null, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' cannot be null.*");
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
		public void IsNullThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsNull((string) null, "value")
				.Validate()
				.IsNull(this, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be null.*");
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
