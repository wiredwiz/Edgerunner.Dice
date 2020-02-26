#region Apache License 2.0
// <copyright file="IDiceSet.cs" company="Edgerunner.org">
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

using JetBrains.Annotations;

using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Core.Interfaces
{
   /// <summary>
   /// Interface representing a set of like dice.
   /// </summary>
   public interface IDiceSet : IList<IDie>, IRollableSet
   {
      /// <summary>
      /// Gets or sets the dice roll options.
      /// </summary>
      /// <value>The dice roll options.</value>
      [NotNull]
      IDiceRollOptions RollOptions { get; set; }
   }
}