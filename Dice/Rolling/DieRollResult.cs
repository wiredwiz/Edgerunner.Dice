#region Apache License 2.0
// <copyright file="DieRollResult.cs" company="Edgerunner.org">
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

using Org.Edgerunner.Dice.Core;
using Org.Edgerunner.Dice.Core.Interfaces;
using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Rolling
{
   /// <summary>
   /// Class that represents a die roll result.
   /// Implements the <see cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDieRollResult" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDieRollResult" />
   public class DieRollResult : IDieRollResult
   {
      private readonly IResultValueSet _ValueSet;

      private int _RolledNumber;

      private bool _CriticalFailure;

      private bool _CriticalSuccess;

      /// <summary>
      /// Initializes a new instance of the <see cref="DieRollResult"/> class.
      /// </summary>
      /// <param name="die">The die.</param>
      /// <param name="rolledNumber">The rolled number.</param>
      public DieRollResult(IDie die, int rolledNumber)
      {
         Die = die;
         _RolledNumber = rolledNumber;
         _ValueSet = new ResultValueSet { { "Number", rolledNumber } };
         if (rolledNumber == 1)
            _CriticalFailure = true;
         if (rolledNumber == die.Sides)
            _CriticalSuccess = true;
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DieRollResult" /> class.
      /// </summary>
      /// <param name="die">The die.</param>
      /// <param name="rolledNumber">The rolled number.</param>
      /// <param name="criticalSuccess">if set to <c>true</c> roll result is a critical success.</param>
      /// <param name="criticalFailure">if set to <c>true</c> roll result is a critical failure.</param>
      public DieRollResult(IDie die, int rolledNumber, bool criticalSuccess, bool criticalFailure)
      {
         Die = die;
         _RolledNumber = rolledNumber;
         _ValueSet = new ResultValueSet { { "Number", rolledNumber } };
         _CriticalFailure = criticalFailure;
         _CriticalSuccess = criticalSuccess;
      }

      /// <inheritdoc/>
      public virtual IDie Die { get; }

      /// <inheritdoc/>
      public virtual bool WasDiscarded { get; set; }

      /// <inheritdoc/>
      public virtual IDieRollResult NextRoll { get; set; }

      /// <inheritdoc/>
      public virtual bool UseSuccesses { get; set; }

      /// <inheritdoc/>
      public virtual bool IsCriticalSuccess
      {
         get => _CriticalSuccess;
         set => _CriticalSuccess = value;
      }

      /// <inheritdoc/>
      public virtual bool IsCriticalFailure
      {
         get => _CriticalFailure;
         set => _CriticalFailure = value;
      }

      /// <inheritdoc/>
      public virtual bool IsCompounding { get; set; }

      /// <inheritdoc/>
      public virtual int SideRolled
      {
         get => _RolledNumber;
         set => _RolledNumber = value;
      }

      /// <inheritdoc/>
      public virtual IResultValueSet Value => _ValueSet;

      /// <inheritdoc/>
      public virtual IDieRollResult ReRoll()
      {
         var newResult = Die.Roll();
         WasDiscarded = true;
         NextRoll = newResult;
         return newResult;
      }

      /// <inheritdoc/>
      public virtual IDieRollResult Explode()
      {
         var newResult = Die.Roll();
         NextRoll = newResult;
         return newResult;
      }

      /// <inheritdoc/>
      public virtual IDieRollResult ExplodeCompounding()
      {
         var newResult = Die.Roll();
         IsCompounding = true;
         NextRoll = newResult;
         newResult.IsCompounding = true;
         return newResult;
      }

      /// <inheritdoc/>
      public IDieRollResult ExplodePenetrating()
      {
         var newResult = Die.Roll();
         IsCompounding = true;
         NextRoll = newResult;
         newResult.IsCompounding = true;
         newResult.Value["Number"] -= 1;
         return newResult;
      }
   }
}