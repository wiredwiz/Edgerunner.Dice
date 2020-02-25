#region Apache License 2.0
// <copyright file="DieModifier.cs" company="Edgerunner.org">
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

using Org.Edgerunner.Dice.Core.Interfaces;

namespace Org.Edgerunner.Dice.Core
{
   /// <summary>
   /// Class that represents a modifier to a single die.
   /// </summary>
   public class DieModifier : IDieModifier
   {
      /// <summary>
      /// Initializes a new instance of the <see cref="DieModifier"/> class.
      /// </summary>
      /// <param name="type">The type.</param>
      /// <param name="value">The value.</param>
      public DieModifier(ModifierType type, int value)
      {
         Type = type;
         Value = value;
      }

      /// <inheritdoc/>
      public ModifierType Type { get; set; }

      /// <inheritdoc/>
      public int Value { get; set; }

      /// <inheritdoc/>
      public IDieModifier Modifier { get; set; }

      /// <inheritdoc/>
      public IDieModifier Add(int value)
      {
         Modifier = new DieModifier(ModifierType.Add, value);
         return Modifier;
      }

      /// <inheritdoc/>
      public IDieModifier Subtract(int value)
      {
         Modifier = new DieModifier(ModifierType.Subtract, value);
         return Modifier;
      }

      /// <inheritdoc/>
      public IDieModifier MultiplyBy(int value)
      {
         Modifier = new DieModifier(ModifierType.Multiply, value);
         return Modifier;
      }
      
      /// <inheritdoc/>
      public IDieModifier DivideBy(int value)
      {
         Modifier = new DieModifier(ModifierType.Divide, value);
         return Modifier;
      }
   }
}
