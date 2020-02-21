#region Apache License 2.0
// <copyright file="DiceFactory.cs" company="Edgerunner.org">
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

using Org.Edgerunner.Dice.Exceptions;
using Org.Edgerunner.Dice.Types;
using Org.Edgerunner.Dice.Types.Interfaces;

namespace Org.Edgerunner.Dice
{
   /// <summary>
   /// Class that represents a dice factory.
   /// Implements the <see cref="IDiceFactory" />
   /// </summary>
   /// <seealso cref="IDiceFactory" />
   public class DiceFactory : IDiceFactory
   {
      #region IDieFactory Members

      /// <inheritdoc/>
      /// <exception cref="T:Org.Edgerunner.Dice.Exceptions.DieCodeException">The dice code was unrecognized.</exception>
      public virtual List<IDie> Create(string diceCode)
      {
         if (!ParseDieCode(diceCode, out var quantity, out var faces))
            throw new DieCodeException($"\"{diceCode}\" is not a recognized dice code");

         return Create(quantity, faces);
      }

      /// <inheritdoc/>
      /// <exception cref="T:System.ArgumentOutOfRangeException">Quantity is less than 1 or faces is less than 2.</exception>
      public virtual List<IDie> Create(int quantity, int faces)
      {
         if (quantity < 1)
            throw new ArgumentOutOfRangeException(nameof(quantity), "must be greater than 0");

         if (faces < 2)
            throw new ArgumentOutOfRangeException(nameof(faces), "must be 2 or greater");

         // figure out what type of die we need and return 1 or more instances based on the die code
         var dice = new List<IDie>();

         for (int i = 0; i < quantity; i++)
            dice.Add(new Die(faces));

         return dice;
      }

      #endregion

      /// <summary>
      /// Parses a dice code into its individual components.
      /// </summary>
      /// <param name="diceCode">The dice code to parse.</param>
      /// <param name="quantity">The quantity of dice to roll.</param>
      /// <param name="faces">The number of faces each die has.</param>
      /// <returns><c>true</c> if the dice code parses correctly, <c>false</c> otherwise.</returns>
      protected virtual bool ParseDieCode(string diceCode, out int quantity, out int faces)
      {
         quantity = 1;
         faces = 0;
         var index = diceCode.IndexOf('d');

         if ((index == -1) || (index == (diceCode.Length - 1)))
            return false;

         if (index != 0)
         {
            var quantityText = diceCode.Substring(0, index);
            if (!int.TryParse(quantityText, out quantity))
               return false;
         }

         var facesText = diceCode.Substring(index + 1);
         return int.TryParse(facesText, out faces);
      }
   }
}