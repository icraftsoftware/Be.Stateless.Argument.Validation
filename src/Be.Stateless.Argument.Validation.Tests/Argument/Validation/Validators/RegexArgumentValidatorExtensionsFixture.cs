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
using System.Text.RegularExpressions;
using FluentAssertions;
using Xunit;

namespace Be.Stateless.Argument.Validation
{
	public class RegexArgumentValidatorExtensionsFixture
	{
		[Fact]
		public void MatchesPatternThrows()
		{
			Action act = () => Arguments.Constraints
				.Matches("acb", "a*bb", "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'value' must match 'a*bb', but was 'acb'.*");
		}

		[Fact]
		public void MatchesPatternThrowsNothing()
		{
			Action act = () => Arguments.Constraints
				.Matches("abb", "a*bb", "value")
				.Check();

			act.Should().NotThrow();
		}

		[Fact]
		public void MatchesRegexThrows()
		{
			var regex = new Regex("a*bb");

			Action act = () => Arguments.Constraints
				.Matches("acb", regex, "value")
				.Check();

			act.Should().Throw<ArgumentException>()
				.WithMessage($"'value' must match '{regex}', but was 'acb'.*");
		}

		[Fact]
		public void MatchesRegexThrowsNothing()
		{
			var regex = new Regex("a*bb");

			Action act = () => Arguments.Constraints
				.Matches("abb", regex, "value")
				.Check();

			act.Should().NotThrow();
		}
	}
}
