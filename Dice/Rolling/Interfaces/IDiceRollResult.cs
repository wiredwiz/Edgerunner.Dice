﻿#region Apache License 2.0
// <copyright file="IDiceRollResult.cs" company="Edgerunner.org">
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

using System.Collections.Generic;

namespace Org.Edgerunner.Dice.Rolling.Interfaces
{
   /// <summary>
   /// Interface that represents a dice roll result.
   /// </summary>
   public interface IDiceRollResult
   {
      /// <summary>
      /// Gets the initial set of rolled die results.
      /// </summary>
      /// <value>The initial dice.</value>
      IList<IDieRollResult> InitialDice { get; }

      /// <summary>
      /// Gets the set of all rolled dice.
      /// </summary>
      /// <value>The set of all rolled dice.</value>
      IList<IDieRollResult> RawDice { get; }

      /// <summary>
      /// Gets the final set of result dice.
      /// </summary>
      /// <value>The logical dice.</value>
      IList<IDieRollResult> LogicalDice { get; }

      /// <summary>
      /// Gets the sets of result dice matches.
      /// </summary>
      /// <value>The logical dice.</value>
      IList<IDieRollResult> MatchingDiceSets { get; }

      /// <summary>
      /// Gets the discarded dice.
      /// </summary>
      /// <value>The discarded dice.</value>
      IList<IDieRollResult> DiscardedDice { get; }

      /// <summary>
      /// Gets a value indicating whether this instance is botched roll.
      /// </summary>
      /// <value><c>true</c> if this instance is botched roll; otherwise, <c>false</c>.</value>
      bool IsBotchedRoll { get; }

      /// <summary>
      /// Gets the total value for the roll.
      /// </summary>
      /// <value>The total value.</value>
      int TotalValue { get; }

      /// <summary>
      /// Overrides the total value of the roll with a new value.
      /// </summary>
      /// <param name="newValue">The new value to override with.</param>
      void OverrideTotalValue(decimal? newValue);

      /// <summary>
      /// Clears any existing override of the total value.
      /// </summary>
      void ClearOverride();
   }
}