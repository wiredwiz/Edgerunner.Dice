#region Apache License 2.0
// <copyright file="RollableBase.cs" company="Edgerunner.org">
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
using Org.Edgerunner.Dice.Random;

namespace Org.Edgerunner.Dice.Core
{
   /// <summary>
   /// Base class for roll-able polygons.
   /// Implements the <see cref="IRollable" /> interface.
   /// </summary>
   /// <seealso cref="IRollable" />
   public abstract class RollableBase : IRollable
   {
      #region IRollable Members

      /// <inheritdoc/>
      public abstract int Sides { get; }

      /// <inheritdoc/>
      /// <exception cref="T:System.Security.Cryptography.CryptographicException">The cryptographic service provider (CSP) cannot be acquired.</exception>
      public virtual int Roll()
      {
         return NumberGenerator.Instance.Next(1, Sides + 1);
      }

      #endregion
   }
}