#region Apache License 2.0
// <copyright file="DiceRollOption.cs" company="Edgerunner.org">
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

using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Rolling
{
   /// <summary>
   /// Class that represents a dice rolling option.
   /// Implements the <see cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDiceRollOption" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDiceRollOption" />
   public class DiceRollOption : IDiceRollOption
   {
      /// <inheritdoc/>
      public Type OptionType { get; }

      /// <inheritdoc/>
      public virtual void ExecutePostRollLogic(IEnumerable<IDieRollResult> result)
      {
      }

      /// <inheritdoc/>
      public bool AllowReRoll(IDieRollResult result)
      {
         throw new System.NotImplementedException();
      }

      /// <inheritdoc/>
      public IEnumerable<IDieRollResult> ExecuteReRollLogic(IEnumerable<IDieRollResult> result)
      {
         throw new System.NotImplementedException();
      }

      /// <inheritdoc/>
      public IEnumerable<IDieRollResult> ExecuteAdditionalRollLogic(IEnumerable<IDieRollResult> result)
      {
         throw new System.NotImplementedException();
      }

      /// <inheritdoc/>
      public IEnumerable<IDieRollResult> ExecutePreResultCalculation(IEnumerable<IDieRollResult> result)
      {
         throw new System.NotImplementedException();
      }

      /// <inheritdoc/>
      public IEnumerable<IDieRollResult> ExecutePostResultCalculation(IEnumerable<IDieRollResult> result)
      {
         throw new System.NotImplementedException();
      }
   }
}