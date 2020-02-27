#region Apache License 2.0
// <copyright file="Die.cs" company="Edgerunner.org">
// Copyright  Thaddeus Ryker
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
using System.Collections.Generic;

using JetBrains.Annotations;

using Org.Edgerunner.Dice.Core.Interfaces;
using Org.Edgerunner.Dice.Random;
using Org.Edgerunner.Dice.Rolling;
using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Core
{
   /// <summary>
   /// Class that represents a die.
   /// Implements the <see cref="RollableBase" />
   /// </summary>
   /// <seealso cref="RollableBase" />
   /// <seealso cref="IDie"/>
   public class BasicDie : RollableBase, IDie
   {
      #region Constructors/Destructors/Disposal

      /// <summary>
      ///    Initializes a new instance of the Die class.
      /// </summary>
      /// <param name="sides">The number of sides the die should have.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">sides was less than 2.</exception>
      public BasicDie(int sides)
      {
         if (sides <= 2)
            throw new ArgumentOutOfRangeException(nameof(sides), "must be 2 or greater");

         Sides = sides;
         CriticalSuccessSides = new bool[sides];
         CriticalFailureSides = new bool[sides];
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BasicDie" /> class.
      /// </summary>
      /// <param name="sides">The number of sides the die should have.</param>
      /// <param name="criticalSuccessSides">The critical success sides.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">sides was less than 2.</exception>
      public BasicDie(int sides, List<int> criticalSuccessSides)
      : this(sides)
      {
         foreach (var side in criticalSuccessSides) CriticalSuccessSides[side] = true;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="BasicDie" /> class.
      /// </summary>
      /// <param name="sides">The number of sides the die should have.</param>
      /// <param name="criticalSuccessSides">The critical success sides.</param>
      /// <param name="criticalFailureSides">The critical failure sides.</param>
      /// <exception cref="T:System.ArgumentOutOfRangeException">sides was less than 2.</exception>
      public BasicDie(int sides, List<int> criticalSuccessSides, List<int> criticalFailureSides)
      : this(sides, criticalSuccessSides)
      {
         foreach (var side in criticalFailureSides) CriticalFailureSides[side] = true;
      }
      #endregion

      /// <inheritdoc/>
      public override int Sides { get; }

      /// <inheritdoc/>
      public bool[] CriticalSuccessSides { get; }

      /// <inheritdoc/>
      public bool[] CriticalFailureSides { get; }

      /// <inheritdoc/>
      public virtual Modifier Modifier { get; set; }

      /// <inheritdoc/>
      /// <exception cref="T:System.Security.Cryptography.CryptographicException">The cryptographic service provider (CSP) cannot be acquired.</exception>
      public override IDieRollResult Roll()
      {
         var roll = GenerateRolledNumber();
         return new DieRollResult(this, roll);
      }

      /// <inheritdoc/>
      public virtual Modifier Add(int value)
      {
         Modifier = new Modifier(ModifierType.Add, value);
         return Modifier;
      }

      /// <inheritdoc/>
      public virtual Modifier Subtract(int value)
      {
         Modifier = new Modifier(ModifierType.Subtract, value);
         return Modifier;
      }

      /// <inheritdoc/>
      public virtual Modifier MultiplyBy(int value)
      {
         Modifier = new Modifier(ModifierType.Multiply, value);
         return Modifier;
      }

      /// <inheritdoc/>
      public virtual Modifier DivideBy(int value)
      {
         Modifier = new Modifier(ModifierType.Divide, value);
         return Modifier;
      }
   }
}