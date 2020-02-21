#region Apache License 2.0
// <copyright file="IRandomNumberGenerator.cs" company="Edgerunner.org">
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

namespace Org.Edgerunner.Dice.Random
{
   /// <summary>
   /// Interface that defines a random number generator.
   /// </summary>
   public interface IRandomNumberGenerator
   {
      /// <summary>
      ///    Gets a random non-negative number less than max.
      /// </summary>
      /// <param name="max">The exclusive upper bound of the random number generated.  max must be greater than or equal to 0.</param>
      /// <returns>A non-negative random integer within the supplied bounds.</returns>
      int Next(int max);

      /// <summary>
      ///    Gets a random number less than max but greater than or equal to min.
      /// </summary>
      /// <param name="min">The inclusive lower bound of the random number generated.</param>
      /// <param name="max">The exclusive upper bound of the random number generated.  max must be equal to or greater than min.</param>
      /// <returns>A non-negative random integer within the supplied bounds.</returns>
      int Next(int min, int max);
   }
}