#region Apache License 2.0
// <copyright file="IDieModifier.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.Dice.Core.Interfaces
{
   /// <summary>
   /// Interface that defines a die modifier.
   /// </summary>
   public interface IDieModifier
   {
      /// <summary>
      /// Gets or sets the modifier type.
      /// </summary>
      /// <value>The modifier type.</value>
      ModifierType Type { get; set; }

      /// <summary>
      /// Gets or sets the modifier value.
      /// </summary>
      /// <value>The modifier value.</value>
      int Value { get; set; }

      /// <summary>
      /// Gets or sets the next modifier in the operation chain.
      /// </summary>
      /// <value>The next modifier or null if there is not another.</value>
      IDieModifier Modifier { get; set; }

      /// <summary>
      /// Creates a new modifier instance with an addition operation and chains it off this instance as the next modifier.
      /// </summary>
      /// <param name="value">The value to use in the addition operation.</param>
      /// <returns>A new <see cref="IDieModifier"/> instance.</returns>
      IDieModifier Add(int value);

      /// <summary>
      /// Creates a new modifier instance with a subtraction operation and chains it off this instance as the next modifier.
      /// </summary>
      /// <param name="value">The value to use in the subtraction operation.</param>
      /// <returns>A new <see cref="IDieModifier"/> instance.</returns>
      IDieModifier Subtract(int value);

      /// <summary>
      /// Creates a new modifier instance with a multiplication operation and chains it off this instance as the next modifier.
      /// </summary>
      /// <param name="value">The value to use in the multiplication operation.</param>
      /// <returns>A new <see cref="IDieModifier"/> instance.</returns>
      IDieModifier MultiplyBy(int value);

      /// <summary>
      /// Creates a new modifier instance with a division operation and chains it off this instance as the next modifier.
      /// </summary>
      /// <param name="value">The value to use in the division operation.</param>
      /// <returns>A new <see cref="IDieModifier"/> instance.</returns>
      IDieModifier DivideBy(int value);
   }
}