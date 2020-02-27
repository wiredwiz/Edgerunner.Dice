#region Apache License 2.0
// <copyright file="KeepLow.cs" company="Edgerunner.org">
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
using System.Linq;

using Org.Edgerunner.Dice.Rolling.Interfaces;
using Org.Edgerunner.Dice.Rolling.Options.Types;

namespace Org.Edgerunner.Dice.Rolling.Options
{
   /// <summary>
   /// Class that identifies a "keep low" dice roll option.
   /// </summary>
   public class KeepLow : DiceOptionDropKeep
   {
      private readonly int _NumberToKeep;

      /// <summary>
      /// Initializes a new instance of the <see cref="KeepLow"/> class.
      /// </summary>
      /// <param name="numberToKeep">The number to keep.</param>
      public KeepLow(int numberToKeep)
      {
         _NumberToKeep = numberToKeep;
      }

      /// <inheritdoc />
      public override void ExecuteDropKeepLogic(IEnumerable<IDieRollResult> result)
      {
         var dice = (from die in result
                    orderby die.SideRolled descending
                    select die).ToList();

         for (int i = 0; i < dice.Count - _NumberToKeep; i++) dice[i].WasDiscarded = true;
      }
   }
}