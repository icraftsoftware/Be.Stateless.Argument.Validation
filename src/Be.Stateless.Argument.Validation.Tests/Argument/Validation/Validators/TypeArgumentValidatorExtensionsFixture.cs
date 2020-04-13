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
using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace Be.Stateless.Argument.Validation
{
	public class TypeArgumentValidatorExtensionsFixture
	{
		[Fact]
		public void IsNullableThrows()
		{
			Action act = () => Validation.Setup()
				.IsNullable(0, "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'value' must be a nullable type, but is of type '{typeof(int)}', which is not.*");
		}

		[Fact]
		public void IsNullableThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsNullable((int?) 0, "value")
				.Validate()
				.IsNullable(0, "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'object.Property' must be a nullable type, but is of type '{typeof(int)}', which is not.*");
		}

		[Fact]
		public void IsNullableThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsNullable((int?) 0, "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsOfTypeGenericThrows()
		{
			Action act = () => Validation.Setup()
				.IsOfType<IEnumerable<int>>("string parameter", "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'value' must be of the type '{typeof(IEnumerable<int>)}', but was of type '{typeof(string)}'.*");
		}

		[Fact]
		public void IsOfTypeGenericThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsOfType<IEnumerable<int>>(new List<int>(), "value")
				.Validate()
				.IsOfType<IEnumerable<int>>("string parameter", "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'object.Property' must be of the type '{typeof(IEnumerable<int>)}', but was of type '{typeof(string)}'.*");
		}

		[Fact]
		public void IsOfTypeGenericThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsOfType<IEnumerable<int>>(new List<int>(), "value")
				.Validate();

			act.Should().NotThrow();
		}

		[Fact]
		public void IsOfTypeThrows()
		{
			Action act = () => Validation.Setup()
				.IsOfType("string parameter", typeof(IEnumerable<int>), "value")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'value' must be of the type '{typeof(IEnumerable<int>)}', but was of type '{typeof(string)}'.*");
		}

		[Fact]
		public void IsOfTypeThrowsForNestedProperties()
		{
			Action act = () => Validation.Setup()
				.IsOfType(new List<int>(), typeof(IEnumerable<int>), "value")
				.Validate()
				.IsOfType("string parameter", typeof(IEnumerable<int>), "object.Property")
				.Validate();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'object.Property' must be of the type '{typeof(IEnumerable<int>)}', but was of type '{typeof(string)}'.*");
		}

		[Fact]
		public void IsOfTypeThrowsNothing()
		{
			Action act = () => Validation.Setup()
				.IsOfType(new List<int>(), typeof(IEnumerable<int>), "value")
				.Validate();

			act.Should().NotThrow();
		}
	}
}
