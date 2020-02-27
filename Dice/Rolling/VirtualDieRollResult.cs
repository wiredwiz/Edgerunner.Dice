#region Apache License 2.0
// <copyright file="VirtualDieRollResult.cs" company="Edgerunner.org">
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
using Org.Edgerunner.Dice.Exceptions;
using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Rolling
{
   /// <summary>
   /// Class that represents the result of a virtual die roll (such as an exploding compounding die).
   /// Implements the <see cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDieRollResult" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDieRollResult" />
   public class VirtualDieRollResult : IDieRollResult
   {
      private readonly IResultValueSet _Value;

      private int _RolledNumber;

      private bool _IsCriticalFailure;

      private bool _IsCriticalSuccess;

      /// <summary>
      /// Initializes a new instance of the <see cref="VirtualDieRollResult" /> class.
      /// </summary>
      /// <param name="die">The die.</param>
      /// <param name="rolledNumber">The rolled number.</param>
      /// <param name="criticalSuccess">if set to <c>true</c> the result is marked as a critical success.</param>
      /// <param name="criticalFailure">if set to <c>true</c> the result is marked as a critical failure.</param>
      // ReSharper disable once TooManyDependencies
      public VirtualDieRollResult(IDie die, int rolledNumber, bool criticalSuccess, bool criticalFailure)
      {
         Die = die;
         _RolledNumber = rolledNumber;
         _Value = new ResultValueSet { { "Number", rolledNumber } };
         _IsCriticalFailure = criticalFailure;
         _IsCriticalSuccess = criticalSuccess;
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
         get => _IsCriticalSuccess;
         set => _IsCriticalSuccess = value;
      }

      /// <inheritdoc/>
      public virtual bool IsCriticalFailure
      {
         get => _IsCriticalFailure;
         set => _IsCriticalFailure = value;
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
      public virtual IResultValueSet Value => _Value;

      /// <inheritdoc/>
      /// <exception cref="T:Org.Edgerunner.Dice.Exceptions.DiceOperationException">Virtual dice cannot be re-rolled.</exception>
      public virtual IDieRollResult ReRoll()
      {
         throw new DiceOperationException("Virtual dice cannot be re-rolled.");
      }

      /// <inheritdoc/>
      /// <exception cref="T:Org.Edgerunner.Dice.Exceptions.DiceOperationException">Virtual dice cannot explode.</exception>
      public virtual IDieRollResult Explode()
      {
         throw new DiceOperationException("Virtual dice cannot explode.");
      }

      /// <inheritdoc/>
      /// <exception cref="T:Org.Edgerunner.Dice.Exceptions.DiceOperationException">Virtual dice cannot compound.</exception>
      public virtual IDieRollResult ExplodeCompounding()
      {
         throw new DiceOperationException("Virtual dice cannot compound.");
      }

      /// <inheritdoc/>
      /// <exception cref="T:Org.Edgerunner.Dice.Exceptions.DiceOperationException">Virtual dice cannot penetrate.</exception>
      public IDieRollResult ExplodePenetrating()
      {
         throw new DiceOperationException("Virtual dice cannot penetrate.");
      }
   }
}