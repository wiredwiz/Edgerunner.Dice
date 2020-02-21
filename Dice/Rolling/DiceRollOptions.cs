#region Apache License 2.0
// <copyright file="DiceRollOptions.cs" company="Edgerunner.org">
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
using System.Collections;
using System.Collections.Generic;

using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Rolling
{
   /// <summary>
   /// Class that represents a collection of dice roll options.
   /// </summary>
   public class DiceRollOptions : IDiceRollOptions
   {
      private readonly List<IDiceRollOption> _Options;

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceRollOptions"/> class.
      /// </summary>
      public DiceRollOptions()
      {
         _Options = new List<IDiceRollOption>();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceRollOptions"/> class.
      /// </summary>
      /// <param name="options">The options.</param>
      public DiceRollOptions(IEnumerable<IDiceRollOption> options)
      {
         _Options = new List<IDiceRollOption>(options);
      }

      /// <summary>
      /// Implements the | operator.
      /// </summary>
      /// <param name="optionsA">The options a.</param>
      /// <param name="optionsB">The options b.</param>
      /// <returns>The result of the operator.</returns>
      public static IDiceRollOptions operator |(DiceRollOptions optionsA, IDiceRollOptions optionsB)
      {
         if (optionsA == null && optionsB == null)
            return null;

         if (optionsA == null)
            return new DiceRollOptions(optionsB);

         if (optionsB == null)
            return new DiceRollOptions(optionsA);

         var options = new DiceRollOptions(optionsA);
         foreach (var option in optionsB) options.Add(option);
         return options;
      }

      /// <summary>
      /// Implements the &amp; operator.
      /// </summary>
      /// <param name="optionsA">The options a.</param>
      /// <param name="optionsB">The options b.</param>
      /// <returns>The result of the operator.</returns>
      public static IDiceRollOptions operator &(DiceRollOptions optionsA, IDiceRollOptions optionsB)
      {
         if (optionsA == null || optionsB == null)
            return null;

         var options = new DiceRollOptions();
         foreach (IDiceRollOption option in optionsA)
            if (optionsB.Contains(option))
               options.Add(option);

         return options;
      }

      /// <inheritdoc/>
      IEnumerator<IDiceRollOption> IEnumerable<IDiceRollOption>.GetEnumerator()
      {
         return _Options.GetEnumerator();
      }

      /// <exception cref="ArgumentNullException"></exception>
      /// <inheritdoc/>
      public IDiceRollOptions Add(IDiceRollOption option)
      {
         if (option == null)
            throw new ArgumentNullException(nameof(option));

         _Options.Add(option);
         return this;
      }

      /// <inheritdoc/>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="option"/> is <see langword="null"/></exception>
      public bool Contains(IDiceRollOption option)
      {
         if (option == null)
            throw new ArgumentNullException(nameof(option));

         return _Options.Contains(option);
      }

      /// <inheritdoc/>
      public IEnumerator GetEnumerator()
      {
         return ((IEnumerable)_Options).GetEnumerator();
      }      
   }
}