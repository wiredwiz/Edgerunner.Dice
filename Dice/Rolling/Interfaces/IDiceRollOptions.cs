#region Apache License 2.0
// <copyright file="IDiceRollOptions.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.Dice.Rolling.Interfaces
{
   /// <summary>
   /// Interface that represents a collection of dice roll options
   /// Implements the <see cref="System.Collections.Generic.IEnumerable{IDiceRollOption}" />
   /// </summary>
   /// <seealso cref="System.Collections.Generic.IEnumerable{IDiceRollOption}" />
   public interface IDiceRollOptions : IEnumerable<IDiceRollOption>
   {
      /// <summary>
      /// Adds the specified option.
      /// </summary>
      /// <param name="option">The <see cref="IDiceRollOption"/> to add.</param>
      /// <returns>this <see cref="IDiceRollOptions"/> instance.</returns>
      IDiceRollOptions Add(IDiceRollOption option);

      /// <summary>
      /// Determines whether this instance contains the specified option.
      /// </summary>
      /// <param name="option">The option.</param>
      /// <returns><c>true</c> if this contains the specified option; otherwise, <c>false</c>.</returns>
      bool Contains(IDiceRollOption option);
   }
}