#region Apache License 2.0
// <copyright file="FateDiceFactory.cs" company="Edgerunner.org">
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
using System.Collections.Generic;

using JetBrains.Annotations;

using Org.Edgerunner.Dice.Core;
using Org.Edgerunner.Dice.Core.Interfaces;
using Org.Edgerunner.Dice.Exceptions;

namespace Org.Edgerunner.Dice.Factory
{
   /// <summary>
   /// Class that represents a Fate dice factory.
   /// Implements the <see cref="IDiceFactory" />
   /// </summary>
   /// <seealso cref="IDiceFactory" />
   public class FateDiceFactory : IDiceFactory
   {
      #region IDieFactory Members

      /// <inheritdoc/>
      /// <exception cref="T:Org.Edgerunner.Dice.Exceptions.DieCodeException">The dice code was unrecognized.</exception>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="diceCode"/> is <see langword="null"/> or empty</exception>
      public virtual IDiceSet Create(string diceCode)
      {
         if (string.IsNullOrEmpty(diceCode)) throw new ArgumentNullException(nameof(diceCode));

         if (!ParseDieCode(diceCode, out var quantity))
            throw new DieCodeException($"\"{diceCode}\" is not a recognized dice code");

         return Create(quantity, 0);
      }

      /// <inheritdoc/>
      /// <exception cref="T:System.ArgumentOutOfRangeException">Quantity is less than 1.</exception>
      /// <exception cref="T:System.ArgumentException">Type was supplied when it should have been null.</exception>
      public virtual IDiceSet Create(int quantity, int? type)
      {
         if (quantity < 1)
            throw new ArgumentOutOfRangeException(nameof(quantity), "must be greater than 0.");

         if (type.HasValue)
            throw new ArgumentException("must not be supplied.", nameof(type));

         var dice = new DiceSet();

         for (int i = 0; i < quantity; i++)
            // ReSharper disable once ExceptionNotDocumented
            dice.Add(new FateDie());

         return dice;
      }

      /// <inheritdoc/>
      public IDiceSet Create(int quantity)
      {
         return Create(quantity, null);
      }

#endregion

      /// <summary>
      /// Parses a dice code into its individual components.
      /// </summary>
      /// <param name="diceCode">The dice code to parse.</param>
      /// <param name="quantity">The quantity of dice to roll.</param>
      /// <returns><c>true</c> if the dice code parses correctly, <c>false</c> otherwise.</returns>
      protected virtual bool ParseDieCode([NotNull] string diceCode, out int quantity)
      {
         quantity = 1;

         if (string.IsNullOrEmpty(diceCode))
            return false;

         var index = diceCode.LastIndexOf("df", 0, StringComparison.InvariantCultureIgnoreCase);

         if (index != diceCode.Length - 2)
            return false;

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

         return true;
      }
   }
}