#region Apache License 2.0
// <copyright file="IRollable.cs" company="Edgerunner.org">
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
   /// Interface that defines a roll-able polygon of some sort
   /// </summary>
   public interface IRollable
   {
      /// <summary>
      /// Gets the number of sides.
      /// </summary>
      /// <value>The number of sides.</value>
      int Sides { get; }

      /// <summary>
      /// Rolls this polygon instance.
      /// </summary>
      /// <returns>An <see cref="System.Int32"/> that represents the rolled value.</returns>
      int Roll();
   }
}