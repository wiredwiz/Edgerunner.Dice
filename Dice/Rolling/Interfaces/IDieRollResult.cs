#region Apache License 2.0
// <copyright file="IDieRollResult.cs" company="Edgerunner.org">
// Copyright 2020 
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

using Org.Edgerunner.Dice.Types.Interfaces;

namespace Org.Edgerunner.Dice.Rolling.Interfaces
{
   /// <summary>
   /// Interface that represents a single die roll result
   /// </summary>
   public interface IDieRollResult
   {
      /// <summary>
      /// Gets the die that was rolled.
      /// </summary>
      /// <value>The die.</value>
      /// <seealso cref="IDie"/>
      /// <seealso cref="Die"/>
      IDie Die { get; }

      /// <summary>Gets or sets a value indicating whether this instance was discarded.</summary>
      /// <value>
      /// <c>true</c> if this instance was discarded; otherwise, <c>false</c>.</value>
      bool WasDiscarded { get; set; }

      /// <summary>
      /// Gets or sets the next rolled die roll.
      /// </summary>
      /// <value>The next roll.</value>
      IDieRollResult NextRoll { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether the roll is success driven.
      /// </summary>
      /// <value><c>true</c> if the roll is success driven; otherwise, <c>false</c>.</value>
      bool SuccessDriven { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether this instance is critical a success.
      /// </summary>
      /// <value><c>true</c> if this instance is a critical success; otherwise, <c>false</c>.</value>
      bool IsCriticalSuccess { get; set; }

      /// <summary>
      /// Gets or sets a value indicating whether this instance is critical a failure.
      /// </summary>
      /// <value><c>true</c> if this instance is a critical failure; otherwise, <c>false</c>.</value>
      bool IsCriticalFailure { get; set; }

      /// <summary>
      /// Gets or sets the rolled die number.
      /// </summary>
      /// <value>The rolled die number.</value>
      int RolledNumber { get; set; }

      /// <summary>
      /// Gets or sets the final value for the die roll.
      /// </summary>
      /// <value>The resulting value.</value>
      int Value { get; set; }

      /// <summary>
      /// Re-rolls this die result and links the re-roll to this instance.
      /// </summary>
      /// <returns>The new <see cref="IDieRollResult"/>.</returns>
      IDieRollResult ReRoll();
   }
}