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

namespace Org.Edgerunner.Dice.Rolling.Interfaces
{
   /// <summary>
   /// Interface that defines a dice roll option
   /// </summary>
   public interface IDiceRollOption
   {
      /// <summary>
      /// Executes option logic that should happen immediately after the dice are rolled.
      /// </summary>
      void ExecutePostRollLogic();

      /// <summary>
      /// Executes option logic to determine whether a die re-roll should be allowed.
      /// </summary>
      /// <returns><c>true</c> if the re-roll should be allowed to continue, <c>false</c> otherwise.</returns>
      bool AllowReRoll();

      /// <summary>
      /// Executes option logic that should happen once it is time for any potential re-rolls.
      /// </summary>
      void ExecuteReRollLogic();

      /// <summary>
      /// Executes option logic that should happen once it is time for any additional rolls.
      /// </summary>
      void ExecuteAdditionalRollLogic();

      /// <summary>
      /// Executes option logic that should happen prior to final die result calculations.
      /// </summary>
      void ExecutePreResultCalculation();

      /// <summary>
      /// Executes option logic that should happen after the final die result calculations.
      /// </summary>
      void ExecutePostResultCalculation();
   }
}