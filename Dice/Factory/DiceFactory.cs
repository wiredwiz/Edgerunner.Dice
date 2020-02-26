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

using JetBrains.Annotations;

using Org.Edgerunner.Dice.Core;
using Org.Edgerunner.Dice.Core.Interfaces;
using Org.Edgerunner.Dice.Exceptions;

namespace Org.Edgerunner.Dice.Factory
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
      /// <exception cref="T:System.ArgumentNullException"><paramref name="diceCode"/> is <see langword="null"/> or empty</exception>
      public virtual IDiceSet Create(string diceCode)
      {
         if (string.IsNullOrEmpty(diceCode)) throw new ArgumentNullException(nameof(diceCode));

         if (!ParseDieCode(diceCode, out var quantity, out var faces))
            throw new DieCodeException($"\"{diceCode}\" is not a recognized dice code");

         if (faces == 0)
            return CreateFate(quantity);

         return Create(quantity, faces);
      }

      /// <inheritdoc/>
      /// <exception cref="T:System.ArgumentOutOfRangeException">Quantity is less than 1 or faces is less than 2.</exception>
      public virtual IDiceSet Create(int quantity, int faces)
      {
         if (quantity < 1)
            throw new ArgumentOutOfRangeException(nameof(quantity), "must be greater than 0.");

         if (faces < 2)
            throw new ArgumentOutOfRangeException(nameof(faces), "must be 2 or greater.");

         // figure out what type of die we need and return 1 or more instances based on the die code
         var dice = new List<IDie>();

         for (int i = 0; i < quantity; i++)
            dice.Add(new Die(faces));

         return new DiceSet(dice);
      }

      /// <inheritdoc/>
      public IDiceSet CreateFate(int quantity)
      {
         var dice = new DiceSet();

         for (int i = 0; i < quantity; i++)
            // ReSharper disable once ExceptionNotDocumented
            dice.Add(new FateDie());

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
      /// <remarks>In the case of Fate dice, the <paramref name="faces"/> is returned as 0.</remarks>
      protected virtual bool ParseDieCode([NotNull] string diceCode, out int quantity, out int faces)
      {
         quantity = 1;
         faces = 0;

         var fate = false;

         if (string.IsNullOrEmpty(diceCode))
            return false;

         var index = diceCode.LastIndexOf("df", 0, StringComparison.InvariantCultureIgnoreCase);

         if (index == diceCode.Length - 2)
            fate = true;
         else
            index = diceCode.IndexOf('d');

         if (index == -1)
            return false;

         if (index != 0)
         {
            var quantityText = diceCode.Substring(0, index);
            if (!int.TryParse(quantityText, out quantity))
               return false;

            if (quantity < 1)
               return false;
         }

         if (fate)
            return true;

         var facesText = diceCode.Substring(index + 1);
         if (!int.TryParse(facesText, out faces))
            return false;

         if (faces < 2)
            return false;

         return true;
      }
   }
}