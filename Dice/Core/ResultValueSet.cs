#region Apache License 2.0
// <copyright file="ResultValueSet.cs" company="Edgerunner.org">
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

using Org.Edgerunner.Dice.Core.Interfaces;

namespace Org.Edgerunner.Dice.Core
{
   /// <summary>
   /// Class that represents a set of result values.
   /// Implements the <see cref="Org.Edgerunner.Dice.Core.Interfaces.IResultValueSet" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.Dice.Core.Interfaces.IResultValueSet" />
   public class ResultValueSet : IResultValueSet
   {
      private readonly Dictionary<string, int> _Storage;

      /// <summary>
      /// Initializes a new instance of the <see cref="ResultValueSet"/> class.
      /// </summary>
      public ResultValueSet()
      {
         _Storage = new Dictionary<string, int>();
      }

      /// <inheritdoc/>
      public int this[string key]
      {
         get => _Storage[key];
         set => _Storage[key] = value;
      }

      /// <inheritdoc/>
      public IEnumerable<string> Keys => _Storage.Keys;

      /// <inheritdoc/>
      public int Count => _Storage.Count;

      /// <inheritdoc/>
      public bool Remove(string key)
      {
         return _Storage.Remove(key);
      }

      /// <inheritdoc/>
      public void Add(string key, int value)
      {
         _Storage.Add(key, value);
      }

      /// <inheritdoc/>
      public void Clear()
      {
         _Storage.Clear();
      }
   }
}