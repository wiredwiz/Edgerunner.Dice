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

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Org.Edgerunner.Dice.Exceptions;
using Org.Edgerunner.Dice.Rolling;
using Org.Edgerunner.Dice.Rolling.Interfaces;
using Org.Edgerunner.Dice.Types.Interfaces;

namespace Org.Edgerunner.Dice.Types
{
   /// <summary>
   /// Class representing a set of dice.
   /// Implements the <see cref="Org.Edgerunner.Dice.Types.Interfaces.IDiceSet" />
   /// </summary>
   /// <seealso cref="Org.Edgerunner.Dice.Types.Interfaces.IDiceSet" />
   /// <seealso cref="Org.Edgerunner.Dice.Types.Interfaces.IDie" />
   public class DiceSet : IDiceSet
   {
      private readonly List<IDie> _Storage;

      private int _Sides;

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceSet"/> class.
      /// </summary>
      public DiceSet()
      {
         _Storage = new List<IDie>();
         RollOptions = new DiceRollOptions();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceSet"/> class.
      /// </summary>
      /// <param name="dice">The dice to initialize the set with.</param>
      public DiceSet(IEnumerable<IDie> dice)
      {
         var enumerable = dice as IDie[] ?? dice.ToArray();
         CheckForMismatch(enumerable);
         _Storage = new List<IDie>(enumerable);
         RollOptions = new DiceRollOptions();
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceSet" /> class.
      /// </summary>
      /// <param name="dice">The dice to initialize the set with.</param>
      /// <param name="options">The dice roll options to apply.</param>
      public DiceSet(IEnumerable<IDie> dice, IEnumerable<IDiceRollOption> options)
      : this(dice)
      {
         foreach (var option in options) RollOptions.Add(option);
      }

      /// <summary>
      /// Initializes a new instance of the <see cref="DiceSet" /> class.
      /// </summary>
      /// <param name="dice">The dice to initialize the set with.</param>
      /// <param name="options">The dice roll options to apply.</param>
      public DiceSet(IEnumerable<IDie> dice, IDiceRollOptions options)
      {
         var enumerable = dice as IDie[] ?? dice.ToArray();
         CheckForMismatch(enumerable);
         _Storage = new List<IDie>(enumerable);
         RollOptions = options;
      }

      private void CheckForMismatch(IEnumerable<IDie> dice)
      {
         using (IEnumerator<IDie> enumerator = dice?.GetEnumerator())
         {
            if (enumerator?.Current != null)
            {
               _Sides = enumerator.Current.Sides;
               while (enumerator.MoveNext())
               {
                  if (enumerator.Current != null && _Sides != enumerator.Current.Sides)
                     throw new DiceMismatchException("A dice set cannot contain dice with differing numbers of sides");
               }
            }
         }         
      }

      /// <inheritdoc/>
      public IEnumerator<IDie> GetEnumerator()
      {
         return _Storage.GetEnumerator();
      }

      /// <inheritdoc/>
      IEnumerator IEnumerable.GetEnumerator()
      {
         return ((IEnumerable)_Storage).GetEnumerator();
      }

      /// <inheritdoc/>
      /// <exception cref="T:System.ArgumentNullException"><paramref name="item"/> is <see langword="null"/></exception>
      /// <exception cref="T:Org.Edgerunner.Dice.Exceptions.DiceMismatchException">A dice set cannot contain dice with differing numbers of sides</exception>
      public void Add(IDie item)
      {
         if (item == null)
            throw new ArgumentNullException(nameof(item));

         if (_Sides == 0)
            _Sides = item.Sides;
         else if (_Sides != item.Sides)
            throw new DiceMismatchException("A dice set cannot contain dice with differing numbers of sides");
            
         _Storage.Add(item);
      }

      /// <inheritdoc/>
      public void Clear()
      {
         _Storage.Clear();
         _Sides = 0;
      }

      /// <inheritdoc/>
      public bool Contains(IDie item)
      {
         return _Storage.Contains(item);
      }

      /// <inheritdoc/>
      public void CopyTo(IDie[] array, int arrayIndex)
      {
         _Storage.CopyTo(array, arrayIndex);
      }

      /// <inheritdoc/>
      public bool Remove(IDie item)
      {
         var success = _Storage.Remove(item);

         if (_Storage.Count == 0)
            _Sides = 0;

         return success;
      }

      /// <inheritdoc/>
      public int Count => _Storage.Count;

      /// <inheritdoc/>
      public bool IsReadOnly => ((ICollection<IDie>)_Storage).IsReadOnly;

      /// <inheritdoc/>
      public int IndexOf(IDie item)
      {
         return _Storage.IndexOf(item);
      }

      /// <inheritdoc/>
      public void Insert(int index, IDie item)
      {
         _Storage.Insert(index, item);
      }

      /// <inheritdoc/>
      public void RemoveAt(int index)
      {
         _Storage.RemoveAt(index);
         if (_Storage.Count == 0)
            _Sides = 0;
      }

      /// <inheritdoc/>
      public IDie this[int index]
      {
         get => _Storage[index];
         set => _Storage[index] = value;
      }

      /// <inheritdoc/>
      public IDiceRollOptions RollOptions { get; set; }

      /// <inheritdoc/>
      public IDiceRollResult Roll()
      {
         throw new System.NotImplementedException();
      }
   }
}