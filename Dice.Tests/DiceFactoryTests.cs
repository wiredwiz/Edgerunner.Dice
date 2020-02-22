using System;
using System.Collections.Generic;
using FluentAssertions;
using Xbehave;

using Org.Edgerunner.Dice.Types.Interfaces;

namespace Org.Edgerunner.Dice.Tests
{
   public class DiceFactoryTests
   {
      [Scenario]
      [Example(0, 6)]
      [Example(-1, 6)]
      [Example(-2, 8)]
      public void TestInvalidDiceQuantityThrowsException(int diceCount, int dieSides, IDiceFactory factory, IList<IDie> dice, Action act)
      {
         "Given a new dice factory"
            .x(() => factory = new DiceFactory());

         "Creating a list of dice with an invalid quantity"
            .x(() => act = () => dice = factory.Create(diceCount, dieSides));

         "Should throw an exception"
            .x(() => act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("must be greater than 0.\r\nParameter name: quantity"));
      }

      [Scenario]
      [Example(1, 0)]
      [Example(12, 1)]
      [Example(30, -1)]
      public void TestInvalidDiceSidesThrowsException(int diceCount, int dieSides, IDiceFactory factory, IList<IDie> dice, Action act)
      {
         "Given a new dice factory"
            .x(() => factory = new DiceFactory());

         "Creating a list of dice with an invalid number of faces on each die"
            .x(() => act = () => dice = factory.Create(diceCount, dieSides));

         "Should throw an exception"
            .x(() => act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("must be 2 or greater.\r\nParameter name: faces"));
      }
   }
}
