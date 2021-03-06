#region Apache License 2.0
// <copyright file="IDiceFactory.cs" company="Edgerunner.org">
// Copyright  Thaddeus Ryker
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

using JetBrains.Annotations;

using Org.Edgerunner.Dice.Core.Interfaces;

namespace Org.Edgerunner.Dice.Factory
{
   /// <summary>
   /// Interface that represents a dice factory.
   /// </summary>
   public interface IDiceFactory
   {
      /// <summary>
      /// Creates a list of dice corresponding to the supplied dice code.
      /// </summary>
      /// <param name="diceCode">The dice code.</param>
      /// <returns>A new <see cref="IDiceSet"/>.</returns>
      IDiceSet Create([NotNull] string diceCode);

      /// <summary>
      /// Creates a list of dice corresponding to the supplied dice parameters.
      /// </summary>
      /// <param name="quantity">The quantity of dice to create.</param>
      /// <param name="type">The type of die to create.</param>
      /// <returns>A new <see cref="IDiceSet" />.</returns>
      IDiceSet Create(int quantity, int? type);

      /// <summary>
      /// Creates a list of dice corresponding to the supplied dice parameters.
      /// </summary>
      /// <param name="quantity">The quantity of dice to create.</param>
      /// <returns>A new <see cref="IDiceSet" />.</returns>
      IDiceSet Create(int quantity);
   }
}