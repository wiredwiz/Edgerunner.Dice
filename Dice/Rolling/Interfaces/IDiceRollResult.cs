#region Apache License 2.0
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
      /// Gets or sets the initial set of rolled die results.
      /// </summary>
      /// <value>The initial dice.</value>
      IList<IDieRollResult> InitialDice { get; set; }

      /// <summary>
      /// Gets or sets the set of all rolled dice.
      /// </summary>
      /// <value>The set of all rolled dice.</value>
      IList<IDieRollResult> RawDice { get; set; }

      /// <summary>
      /// Gets or sets the final set of result dice.
      /// </summary>
      /// <value>The logical dice.</value>
      IList<IDieRollResult> LogicalDice { get; set; }

      /// <summary>
      /// Gets or sets the discarded dice.
      /// </summary>
      /// <value>The discarded dice.</value>
      IList<IDieRollResult> DiscardedDice { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether this instance is botched roll.
      /// </summary>
      /// <value><c>true</c> if this instance is botched roll; otherwise, <c>false</c>.</value>
      bool IsBotchedRoll { get; set; }

      /// <summary>
      /// Gets or sets the total value for the roll.
      /// </summary>
      /// <value>The total value.</value>
      int TotalValue { get; set; }
   }
}