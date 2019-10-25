using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using tictactoe.Domain;

namespace tictactoe.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.All)]
    public class Match_When_getting_has_winner
    {
        [Test]
        public void If_row_one_is_winning_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 0].State = FieldState.O;
            match.Fields[1, 0].State = FieldState.O;
            match.Fields[2, 0].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_row_two_is_winning_filled_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 1].State = FieldState.O;
            match.Fields[1, 1].State = FieldState.O;
            match.Fields[2, 1].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_row_three_is_winning_filled_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 2].State = FieldState.O;
            match.Fields[1, 2].State = FieldState.O;
            match.Fields[2, 2].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_columns_one_is_winning_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 0].State = FieldState.O;
            match.Fields[0, 1].State = FieldState.O;
            match.Fields[0, 2].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_columns_two_is_winning_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[1, 0].State = FieldState.O;
            match.Fields[1, 1].State = FieldState.O;
            match.Fields[1, 2].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_columns_three_is_winning_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[2, 0].State = FieldState.O;
            match.Fields[2, 1].State = FieldState.O;
            match.Fields[2, 2].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_diagonal_one_is_winning_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 0].State = FieldState.O;
            match.Fields[1, 1].State = FieldState.O;
            match.Fields[2, 2].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_diagonal_two_is_winning_Then_return_true()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 2].State = FieldState.O;
            match.Fields[1, 1].State = FieldState.O;
            match.Fields[2, 0].State = FieldState.O;

            match.IsWon.Should().BeTrue();
        }

        [Test]
        public void If_row_one_is_not_winning_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 0].State = FieldState.O;
            match.Fields[1, 0].State = FieldState.X;
            match.Fields[2, 0].State = FieldState.O;

            match.IsWon.Should().BeFalse();
        }

        [Test]
        public void If_row_two_is_not_winning_filled_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 1].State = FieldState.O;
            match.Fields[1, 1].State = FieldState.O;
            match.Fields[2, 1].State = FieldState.X;

            match.IsWon.Should().BeFalse();
        }

        [Test]
        public void If_row_three_is_not_winning_filled_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 2].State = FieldState.X;
            match.Fields[1, 2].State = FieldState.O;
            match.Fields[2, 2].State = FieldState.O;

            match.IsWon.Should().BeFalse();
        }

        [Test]
        public void If_columns_one_is_not_winning_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 0].State = FieldState.X;
            match.Fields[0, 1].State = FieldState.O;
            match.Fields[0, 2].State = FieldState.O;

            match.IsWon.Should().BeFalse();
        }

        [Test]
        public void If_columns_two_is_not_winning_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[1, 0].State = FieldState.O;
            match.Fields[1, 1].State = FieldState.X;
            match.Fields[1, 2].State = FieldState.O;

            match.IsWon.Should().BeFalse();
        }

        [Test]
        public void If_columns_three_is_not_winning_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[2, 0].State = FieldState.O;
            match.Fields[2, 1].State = FieldState.O;
            match.Fields[2, 2].State = FieldState.X;

            match.IsWon.Should().BeFalse();
        }

        [Test]
        public void If_diagonal_one_is_not_winning_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 0].State = FieldState.X;
            match.Fields[1, 1].State = FieldState.O;
            match.Fields[2, 2].State = FieldState.O;

            match.IsWon.Should().BeFalse();
        }

        [Test]
        public void If_diagonal_two_is_not_winning_Then_return_false()
        {
            var match = new Match(new FieldFactory());

            match.Fields[0, 2].State = FieldState.O;
            match.Fields[1, 1].State = FieldState.X;
            match.Fields[2, 0].State = FieldState.O;

            match.IsWon.Should().BeFalse();
        }

    }
}
