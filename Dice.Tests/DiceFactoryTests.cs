#region Apache License 2.0
// <copyright file="DiceFactoryTests.cs" company="Edgerunner.org">
// Copyright 2020 Thaddeus Ryker
// </copyright>
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion---------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

using FluentAssertions;

using Org.Edgerunner.Dice.Types.Interfaces;

using Xbehave;

// ReSharper disable RedundantAssignment
namespace Org.Edgerunner.Dice.Tests
{
   /// <summary>
   /// A class containing various dice factory tests.
   /// </summary>
   public class DiceFactoryTests
   {
      /// <summary>
      /// Tests that an invalid dice quantity, sent to the dice factory, throws the proper exception.
      /// </summary>
      /// <param name="diceCount">The number of dice to create.</param>
      /// <param name="dieSides">The number of sides each of the dice should have.</param>
      /// <param name="factory">The created dice factory.</param>
      /// <param name="dice">The created dice.</param>
      /// <param name="act">The action used to create the dice.</param>
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

      /// <summary>
      /// Tests that an invalid number of die sides, sent to the dice factory, throws the proper exception.
      /// </summary>
      /// <param name="diceCount">The number of dice to create.</param>
      /// <param name="dieSides">The number of sides each of the dice should have.</param>
      /// <param name="factory">The created dice factory.</param>
      /// <param name="dice">The created dice.</param>
      /// <param name="act">The action used to create the dice.</param>
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
