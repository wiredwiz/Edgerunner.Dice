#region Apache License 2.0
// <copyright file="ExplodePenetratingIfCriticalSuccess.cs" company="Edgerunner.org">
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

using Org.Edgerunner.Dice.Rolling.Interfaces;
using Org.Edgerunner.Dice.Rolling.Options.Types;

namespace Org.Edgerunner.Dice.Rolling.Options
{
   /// <summary>
   /// Class that represents a dice rolling option for exploding penetrating dice when the result is a critical success.
   /// Implements the <see cref="DiceOptionExplode" />
   /// </summary>
   /// <seealso cref="DiceOptionExplode" />
   public class ExplodePenetratingIfCriticalSuccess : DiceOptionExplode
   {
      /// <inheritdoc />
      public override IEnumerable<IDieRollResult> ExecuteAdditionalRollLogic(IEnumerable<IDieRollResult> result)
      {
         var additional = new List<IDieRollResult>();
         foreach (var die in result)
            if (die.IsCriticalSuccess)
               additional.Add(die.ExplodePenetrating());

         return additional;
      }

      /// <inheritdoc />
      public override IEnumerable<IDieRollResult> ExecuteVirtualDiceCreationLogic(IEnumerable<IDieRollResult> initialDiceResults)
      {
         var virtualDice = new List<IDieRollResult>();
         var totalValue = 0;
         var compoundingFound = false;
         foreach (var die in initialDiceResults)
            if (die.NextRoll != null)
            {
               var workingDie = die;
               while (workingDie != null)
               {
                  if (!workingDie.WasDiscarded && workingDie.IsCompounding)
                  {
                     compoundingFound = compoundingFound || workingDie.IsCompounding;
                     totalValue += workingDie.Value;
                  }

                  workingDie = workingDie.NextRoll;
               }

               if (compoundingFound)
                  virtualDice.Add(new VirtualDieRollResult(die.Die, totalValue, true, false));
            }

         return virtualDice;
      }
   }
}