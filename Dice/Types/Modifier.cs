#region Apache License 2.0

// Copyright 2014 Thaddeus Ryker
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

namespace Org.Edgerunner.Dice.Types
{
   public class Modifier
   {
      #region Constructors/Destructors/Disposal

      /// <summary>
      ///    Initializes a new instance of the Modifier class.
      /// </summary>
      public Modifier(ModifierType type, int value)
      {
         Type = type;
         Value = value;
      }

      #endregion

      public ModifierType Type { get; set; }
      public int Value { get; set; }
      public Modifier Next { get; set; }

      public Modifier Add(int value)
      {
         Next = new Modifier(ModifierType.Add, value);
         return Next;
      }

      public Modifier Subtract(int value)
      {
         Next = new Modifier(ModifierType.Subtract, value);
         return Next;
      }

      public Modifier MultiplyBy(int value)
      {
         Next = new Modifier(ModifierType.Multiply, value);
         return Next;
      }

      public Modifier DivideBy(int value)
      {
         Next = new Modifier(ModifierType.Divide, value);
         return Next;
      }

      public int Process(int input)
      {
         switch (Type)
         {
            case ModifierType.Add:
               input += Value;
               break;
            case ModifierType.Subtract:
               input -= Value;
               break;
            case ModifierType.Multiply:
               input *= Value;
               break;
            case ModifierType.Divide:
               decimal result = input / (decimal)Value;
               input = (int)Math.Ceiling(result);
               break;
         }
         if (Next != null)
            input = Next.Process(input);
         return input;
      }

      public override string ToString()
      {
         string text = string.Empty;
         switch (Type)
         {
            case ModifierType.Add:
               text = "+" + Value;
               break;
            case ModifierType.Subtract:
               text = "-" + Value;
               break;
            case ModifierType.Multiply:
               text = "*" + Value;
               break;
            case ModifierType.Divide:
               text = "/" + Value;
               break;
            default:
               throw new Exception(string.Format("{0} is not a supported modifier operation", Type));
         }
         if (Next != null)
            text += Next.ToString();
         return text;
      }
   }
}