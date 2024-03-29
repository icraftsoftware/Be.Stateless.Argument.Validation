﻿#region Copyright & License

// Copyright © 2012 - 2022 François Chabot
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
	public class ObjectArgumentConstraintsFixture
	{
		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		[Fact]
		public void IsDefaultClass()
		{
			var tuple = new Tuple<int, int>(1, 2);

			Action act = () => Arguments.Validation.Constraints
				.IsDefault(tuple, nameof(tuple))
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'{nameof(tuple)}' reference type must be null.*");
		}

		[SuppressMessage("ReSharper", "ConvertToConstant.Local")]
		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		[Fact]
		public void IsDefaultStruct()
		{
			var integer = 12;

			Action act = () => Arguments.Validation.Constraints
				.IsDefault(integer, nameof(integer))
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'{nameof(integer)}' value type must be default.*");
		}

		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		[Fact]
		public void IsNotDefaultClass()
		{
			Tuple<int, int> tuple = default;

			Action act = () => Arguments.Validation.Constraints
				.IsNotDefault(tuple, nameof(tuple))
				.Check();

			act.Should().Throw<ArgumentNullException>()
				.WithMessage($"'{nameof(tuple)}' reference type cannot be null.*");
		}

		[SuppressMessage("ReSharper", "ConvertToConstant.Local")]
		[SuppressMessage("ReSharper", "ExpressionIsAlwaysNull")]
		[Fact]
		public void IsNotDefaultStruct()
		{
			int integer = default;

			Action act = () => Arguments.Validation.Constraints
				.IsNotDefault(integer, nameof(integer))
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'{nameof(integer)}' value type cannot be default.*");
		}

		[Fact]
		public void IsNotNullThrows()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotNull((string) null, "value")
				.Check();

			act.Should().Throw<ArgumentNullException>()
				.WithMessage("'value' cannot be null.*");
		}

		[Fact]
		public void IsNotNullThrowsForNestedProperties()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotNull(this, "value")
				.Check()
				.IsNotNull((string) null, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' cannot be null.*");
		}

		[Fact]
		public void IsNotNullThrowsNothing()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNotNull(this, "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsNullThrows()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNull(this, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'value' must be null.*");
		}

		[Fact]
		public void IsNullThrowsForNestedProperties()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNull((string) null, "value")
				.Check()
				.IsNull(this, "object.Property")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage("'object.Property' must be null.*");
		}

		[Fact]
		public void IsNullThrowsNothing()
		{
			Action act = () => Arguments.Validation.Constraints
				.IsNull((string) null, "value")
				.Check();

			act.Should().NotThrow();
		}
	}
}
