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
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Be.Stateless.Argument.Validation
{
	public class ArgumentValidatorExtensionsFixture
	{
		[Fact]
		[SuppressMessage("ReSharper", "AccessToModifiedClosure")]
		[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
		public void ValidateArgumentsAndTheirState()
		{
			Tuple<int, int, int> tuple = null;
			Action act = () => Validation.Setup()
				.IsNotNull(tuple, nameof(tuple))
				.Validate()
				.IsPositive(tuple.Item1, $"{nameof(tuple)}.{nameof(tuple.Item1)}")
				.IsPositive(tuple.Item2, $"{nameof(tuple)}.{nameof(tuple.Item2)}")
				.IsPositive(tuple.Item3, $"{nameof(tuple)}.{nameof(tuple.Item3)}")
				.Validate();

			act.Should().Throw<ArgumentNullException>()
				.Where(e => e.ParamName == nameof(tuple));

			tuple = new Tuple<int, int, int>(1, -1, -1);

			act.Should().Throw<AggregateException>()
				.Where(e => e.InnerExceptions.OfType<ArgumentOutOfRangeException>().Count() == 2);
		}

		[Fact]
		public void ValidateThrowsAggregateException()
		{
			Action act = () => Validation.Setup()
				.IsEqualTo(1, 2, "arg1")
				.IsEqualTo(1, 3, "arg2")
				.Validate();

			act.Should().Throw<AggregateException>()
				.WithMessage("Argument validation failed for several reasons.*")
				.Where(
					e => e.InnerExceptions.OfType<ArgumentException>().Count() == 2
						&& e.InnerExceptions[0].Message.StartsWith("'arg1' must be equal to 2, but was 1.")
						&& e.InnerExceptions[1].Message.StartsWith("'arg2' must be equal to 3, but was 1.")
				);
		}
	}
}
