#region Apache License 2.0
// <copyright file="IDie.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.Dice.Types.Interfaces
{
   /// <summary>
   /// Interface that represents a single die.
   /// </summary>
   public interface IDie : IRollable
   {
      /// <summary>
      /// Gets the critical success sides.
      /// </summary>
      /// <value>An array of boolean values where the index of a given die side is true if the result would be a critical success.</value>
      bool[] CriticalSuccessSides { get; }

      /// <summary>
      /// Gets the critical failure sides.
      /// </summary>
      /// <value>An array of boolean values where the index of a given die side is true if the result would be a critical failure.</value>
      bool[] CriticalFailureSides { get; }

      /// <summary>
      /// Gets or sets the die modifier.
      /// </summary>
      /// <value>The die modifier.</value>
      Modifier Modifier { get; set; }

      /// <summary>
      /// Sets the modifier to a new additive modifier with the specified value.
      /// </summary>
      /// <param name="value">The value to modify by.</param>
      /// <returns>the new <see cref="Die.Modifier"/>.</returns>
      Modifier Add(int value);

      /// <summary>
      /// Sets the modifier to a new subtractive modifier with the specified value.
      /// </summary>
      /// <param name="value">The value to modify by.</param>
      /// <returns>the new <see cref="Die.Modifier"/>.</returns>
      Modifier Subtract(int value);

      /// <summary>
      /// Sets the modifier to a new multiplicative modifier with the specified value.
      /// </summary>
      /// <param name="value">The value to modify by.</param>
      /// <returns>the new <see cref="Die.Modifier"/>.</returns>
      Modifier MultiplyBy(int value);

      /// <summary>
      /// Sets the modifier to a new divisive modifier with the specified value.
      /// </summary>
      /// <param name="value">The value to modify by.</param>
      /// <returns>the new <see cref="Die.Modifier"/>.</returns>
      Modifier DivideBy(int value);
   }
}