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
    public class Match_When_getting_is_finished
    {
        [Test]
        public void If_all_fields_are_filled_Then_return_true()
        {
            IFieldFactory fieldFactory = Substitute.For<IFieldFactory>();
            fieldFactory.Create().Returns(new Field() { State = FieldState.O }, new Field() { State = FieldState.O }, new Field() { State = FieldState.X });
            var match = new Match(fieldFactory);

            match.IsFinished.Should().BeTrue();
        }

        [Test]
        public void If_no_field_is_filled_Then_return_false()
        {
            IFieldFactory fieldFactory = Substitute.For<IFieldFactory>();
            fieldFactory.Create().Returns(new Field());
            var match = new Match(fieldFactory);

            match.IsFinished.Should().BeFalse();
        }

        [Test]
        public void If_some_fields_are_filled_Then_return_false()
        {
            IFieldFactory fieldFactory = Substitute.For<IFieldFactory>();
            fieldFactory.Create().Returns(
                new Field() { State = FieldState.O }, 
                new Field() { State = null }, 
                new Field() { State = FieldState.O }, 
                new Field() { State = FieldState.X }, 
                new Field() { State = null }, 
                new Field() { State = null },
                new Field() { State = FieldState.O },
                new Field() { State = FieldState.X },
                new Field() { State = null });
            var match = new Match(fieldFactory);

            match.IsFinished.Should().BeFalse();
        }
    }
}
