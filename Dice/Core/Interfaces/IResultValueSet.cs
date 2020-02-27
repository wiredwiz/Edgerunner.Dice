#region Apache License 2.0
// <copyright file="IResultValueSet.cs" company="Edgerunner.org">
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

// ReSharper disable ExceptionNotThrown
namespace Org.Edgerunner.Dice.Core.Interfaces
{
   /// <summary>
   /// Interface that represents a set of integer value results keyed by a string.
   /// </summary>
   public interface IResultValueSet
   {
      /// <summary>
      /// Gets or sets the <see cref="System.Int32"/> with the specified key.
      /// </summary>
      /// <param name="key">The key.</param>
      /// <returns>The <see cref="System.Int32"/> value.</returns>
      /// <exception cref="System.ArgumentException"><paramref name="key"/> is <see langword="null" />.</exception>
      /// <exception cref="System.Collections.Generic.KeyNotFoundException">Key does not exist in the result set.</exception>
      int this[string key] { get; set; }

      /// <summary>
      /// Gets the keys for the result set.
      /// </summary>
      /// <value>The keys.</value>
      IEnumerable<string> Keys { get; }

      /// <summary>
      /// Gets the count of contained key/value pairs.
      /// </summary>
      /// <value>The count.</value>
      int Count { get; }

      /// <summary>
      /// Removes the specified key.
      /// </summary>
      /// <param name="key">The key.</param>
      /// <returns><c>true</c> if key is successfully found and removed, <c>false</c> otherwise.</returns>
      bool Remove(string key);

      /// <summary>
      /// Adds the specified key and value to the result set.
      /// </summary>
      /// <param name="key">The key.</param>
      /// <param name="value">The value.</param>
      /// <exception cref="System.ArgumentException">Key already exists in the result set.</exception>
      void Add(string key, int value);

      /// <summary>
      /// Removes all key/value pairs from this instance.
      /// </summary>
      void Clear();
   }
}