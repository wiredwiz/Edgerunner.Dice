#region Apache License 2.0
// <copyright file="FateDiceFactoryTests.cs" company="Edgerunner.org">
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
#endregion

using System;
using System.Linq;

using FluentAssertions;

using Org.Edgerunner.Dice.Core;
using Org.Edgerunner.Dice.Core.Interfaces;
using Org.Edgerunner.Dice.Factory;

using Xbehave;

// ReSharper disable RedundantAssignment
namespace Org.Edgerunner.Dice.Tests
{
   /// <summary>
   /// A class containing various Fate dice factory tests.
   /// </summary>
   public class FateDiceFactoryTests
   {
      /// <summary>
      /// Tests that an invalid dice quantity, sent to the dice factory, throws the proper exception.
      /// </summary>
      /// <param name="diceCount">The number of dice to create.</param>
      /// <param name="dieType">The type the dice should have.</param>
      /// <param name="factory">The created dice factory.</param>
      /// <param name="dice">The created dice.</param>
      /// <param name="act">The action used to create the dice.</param>
      [Scenario]
      [Example(0, null)]
      [Example(-1, null)]
      [Example(-2, null)]
      public void TestInvalidDiceQuantityThrowsException(int diceCount, int? dieType, IDiceFactory factory, IDiceSet dice, Action act)
      {
         "Given a new Fate dice factory"
            .x(() => factory = new FateDiceFactory());

         "Creating a list of dice with an invalid quantity"
            .x(() => act = () => dice = factory.Create(diceCount, dieType));

         "Should throw an exception"
            .x(() => act.Should().Throw<ArgumentOutOfRangeException>()
            .WithMessage("must be greater than 0.\r\nParameter name: quantity"));
      }

      /// <summary>
      /// Tests that an invalid die type, sent to the dice factory, throws the proper exception.
      /// </summary>
      /// <param name="diceCount">The number of dice to create.</param>
      /// <param name="dieType">The type the dice should have.</param>
      /// <param name="factory">The created dice factory.</param>
      /// <param name="dice">The created dice.</param>
      /// <param name="act">The action used to create the dice.</param>
      [Scenario]
      [Example(1, 0)]
      [Example(12, 1)]
      [Example(30, -1)]
      [Example(8, 2)]
      public void TestInvalidDiceTypesThrowsException(int diceCount, int? dieType, IDiceFactory factory, IDiceSet dice, Action act)
      {
         "Given a new Fate dice factory"
            .x(() => factory = new FateDiceFactory());

         "Creating a list of dice with an invalid number of faces on each die"
            .x(() => act = () => dice = factory.Create(diceCount, dieType));

         "Should throw an exception"
            .x(() => act.Should().Throw<ArgumentException>()
            .WithMessage("must not be supplied.\r\nParameter name: type"));
      }
      
      /// <summary>
      /// Tests that a valid number of dice, sent to the dice factory, generates the correct quantity of dice.
      /// </summary>
      /// <param name="diceCount">The number of dice to create.</param>
      /// <param name="dieType">The type the dice should have.</param>
      /// <param name="factory">The created dice factory.</param>
      /// <param name="dice">The created dice.</param>
      [Scenario]
      [Example(1, null)]
      [Example(2, null)]
      [Example(22, null)]
      public void TestFactoryCreatesTheCorrectQuantityOfDice(int diceCount, int? dieType, IDiceFactory factory, IDiceSet dice)
      {
         "Given a new Fate dice factory"
            .x(() => factory = new FateDiceFactory());

         "Creating a list of dice with a valid quantity"
            .x(() => dice = factory.Create(diceCount, dieType));

         "Produces the correct quantity of dice"
            .x(() => dice.Count.Should().Be(diceCount));
      }

      /// <summary>
      /// Tests that a valid number of dice, sent to the dice factory, generates the dice of the correct class type.
      /// </summary>
      /// <param name="diceCount">The number of dice to create.</param>
      /// <param name="dieType">The type the dice should have.</param>
      /// <param name="factory">The created dice factory.</param>
      /// <param name="dice">The created dice.</param>
      [Scenario]
      [Example(1, null)]
      public void TestThatFactoryCreatesFateDice(int diceCount, int? dieType, IDiceFactory factory, IDiceSet dice)
      {
         "Given a new Fate dice factory"
            .x(() => factory = new FateDiceFactory());

         "Creating a list of dice"
            .x(() => dice = factory.Create(diceCount, dieType));

         "Produces the dice of the correct class type"
            .x(() => dice.First().Should().BeOfType<FateDie>());
      }
   }
}