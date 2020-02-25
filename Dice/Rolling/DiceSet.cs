#region Apache License 2.0
// <copyright file="DiceSet.cs" company="Edgerunner.org">
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

using System.Collections;
using System.Collections.Generic;

using Org.Edgerunner.Dice.Core.Interfaces;
using Org.Edgerunner.Dice.Rolling.Interfaces;

namespace Org.Edgerunner.Dice.Rolling
{
   /// <summary>
   /// Class representing a set of dice to be rolled.
   /// Implements the <see cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDiceSet" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.Dice.Rolling.Interfaces.IDiceSet" />
   public class DiceSet : IDiceSet
   {
      private readonly List<IDie> _Dice;

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceSet"/> class.
      /// </summary>
      public DiceSet()
      {
         _Dice = new List<IDie>();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceSet"/> class.
      /// </summary>
      /// <param name="dice">The dice.</param>
      public DiceSet(IEnumerable<IDie> dice)
      {
         _Dice = new List<IDie>(dice);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceSet"/> class.
      /// </summary>
      /// <param name="die">The die.</param>
      public DiceSet(IDie die)
      {
         _Dice = new List<IDie> { die };
      }

      /// <inheritdoc/>
      public IEnumerator<IDie> GetEnumerator()
      {
         return _Dice.GetEnumerator();
      }

      /// <inheritdoc/>
      IEnumerator IEnumerable.GetEnumerator()
      {
         return ((IEnumerable)_Dice).GetEnumerator();
      }

      /// <inheritdoc/>
      public void Add(IDie item)
      {
         _Dice.Add(item);
      }

      /// <inheritdoc/>
      public void Clear()
      {
         _Dice.Clear();
      }

      /// <inheritdoc/>
      public bool Contains(IDie item)
      {
         return _Dice.Contains(item);
      }

      /// <inheritdoc/>
      public void CopyTo(IDie[] array, int arrayIndex)
      {
         _Dice.CopyTo(array, arrayIndex);
      }

      /// <inheritdoc/>
      public bool Remove(IDie item)
      {
         return _Dice.Remove(item);
      }

      /// <inheritdoc/>
      public int Count => _Dice.Count;

      /// <inheritdoc/>
      public bool IsReadOnly => ((ICollection<IDie>)_Dice).IsReadOnly;

      /// <inheritdoc/>
      public int IndexOf(IDie item)
      {
         return _Dice.IndexOf(item);
      }

      /// <inheritdoc/>
      public void Insert(int index, IDie item)
      {
         _Dice.Insert(index, item);
      }

      /// <inheritdoc/>
      public void RemoveAt(int index)
      {
         _Dice.RemoveAt(index);
      }

      /// <inheritdoc/>
      public IDie this[int index]
      {
         get => _Dice[index];
         set => _Dice[index] = value;
      }

      /// <inheritdoc/>
      public IDiceRollOptions RollOptions { get; set; }

      /// <inheritdoc/>
      public IList<IDieRollResult> Roll()
      {
         throw new System.NotImplementedException();
      }
   }
}