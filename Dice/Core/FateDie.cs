#region Apache License 2.0
// <copyright file="FateDie.cs" company="Edgerunner.org">
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

using Org.Edgerunner.Dice.Core.Interfaces;
using Org.Edgerunner.Dice.Random;
using Org.Edgerunner.Dice.Rolling;
using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Core
{
   /// <summary>
   /// Class that represents a Fate die.
   /// Implements the <see cref="IDie" />
   /// </summary>
   /// <seealso cref="IDie"/>
   public class FateDie : IDie
   {
      /// <inheritdoc/>
      public int Sides => 6;

      /// <inheritdoc/>
      /// <exception cref="T:System.Security.Cryptography.CryptographicException">The cryptographic service provider (CSP) cannot be acquired.</exception>
      public IDieRollResult Roll()
      {
         var roll = NumberGenerator.Instance.Next(1, Sides + 1);
         return new DieRollResult(this, roll > 4 ? 1 : roll > 2 ? 0 : -1, false, false);
      }

      /// <inheritdoc/>
      public bool[] CriticalSuccessSides { get; }

      /// <inheritdoc/>
      public bool[] CriticalFailureSides { get; }

      /// <inheritdoc/>
      public Modifier Modifier { get; set; }

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