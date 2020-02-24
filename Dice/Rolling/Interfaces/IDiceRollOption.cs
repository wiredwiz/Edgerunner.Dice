#region Apache License 2.0
// <copyright file="IDiceRollOption.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.Dice.Rolling.Interfaces
{
   /// <summary>
   /// Interface that defines a dice roll option
   /// </summary>
   public interface IDiceRollOption
   {
      /// <summary>
      /// Gets the type of the option.
      /// </summary>
      /// <value>The type of the option.</value>
      Type OptionType { get; }

      /// <summary>
      /// Executes option logic that should happen immediately after the dice are rolled.
      /// </summary>
      /// <param name="results">The dice roll results to operate on.</param>
      void ExecutePostRollLogic(IEnumerable<IDieRollResult> results);

      /// <summary>
      /// Executes option logic to determine whether a die re-roll should be allowed for the specified result.
      /// </summary>
      /// <param name="result">The die roll result to operate on.</param>
      /// <returns><c>true</c> if the re-roll should be allowed to continue, <c>false</c> otherwise.</returns>
      bool AllowReRoll(IDieRollResult result);

      /// <summary>
      /// Executes option logic that should happen once it is time for any potential re-rolls.
      /// </summary>
      /// <param name="results">The dice roll results to operate on.</param>
      /// <returns>A new <see cref="IEnumerable{IDieRollResult}"/> containing any new dice that were rolled.</returns>
      /// <remarks>This should only be used for dice re-rolls, not for additional dice (such as exploding dice)</remarks>
      IEnumerable<IDieRollResult> ExecuteReRollLogic(IEnumerable<IDieRollResult> results);

      /// <summary>
      /// Executes option logic that should happen once it is time for any additional rolls.
      /// </summary>
      /// <param name="results">The dice roll results to operate on.</param>
      /// <returns>A new <see cref="IEnumerable{IDieRollResult}"/> containing any new dice that were rolled.</returns>
      IEnumerable<IDieRollResult> ExecuteAdditionalRollLogic(IEnumerable<IDieRollResult> results);

      /// <summary>
      /// Executes option logic that should happen prior to final die result calculations.
      /// </summary>
      /// <param name="results">The dice roll results to operate on.</param>
      /// <returns>A new <see cref="IEnumerable{IDieRollResult}"/> containing any new dice that were rolled.</returns>
      IEnumerable<IDieRollResult> ExecutePreResultCalculation(IEnumerable<IDieRollResult> results);

      /// <summary>
      /// Executes option logic that should happen after the final die result calculations.
      /// </summary>
      /// <param name="results">The dice roll results to operate on.</param>
      /// <returns>A new <see cref="IEnumerable{IDieRollResult}"/> containing any new dice that were rolled.</returns>
      IEnumerable<IDieRollResult> ExecutePostResultCalculation(IEnumerable<IDieRollResult> results);
   }
}