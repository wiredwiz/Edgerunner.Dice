#region Apache License 2.0
// <copyright file="NumberGenerator.cs" company="Edgerunner.org">
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

using System;
using System.Security.Cryptography;

// ReSharper disable ExceptionNotThrown
namespace Org.Edgerunner.Dice.Random
{
   /// <summary>
   ///    A class used to generate random numbers for the dice roller
   /// </summary>
   /// <remarks>
   ///    Uses the cryptographic random number generator to generate the seed number to be used in
   ///    the system random class, which is then used to generate the numbers
   /// </remarks>
   public class NumberGenerator : IRandomNumberGenerator
   {
      private const string InvalidLowNumberArgError = "Number must be non-negative";
      private static IRandomNumberGenerator _Instance;
      private readonly System.Random _Rand;

      #region Constructors/Destructors/Disposal

      /// <summary>
      /// Initializes a new instance of the <see cref="NumberGenerator"/> class.
      /// </summary>
      /// <exception cref="T:System.Security.Cryptography.CryptographicException">The cryptographic service provider (CSP) cannot be acquired.</exception>
      public NumberGenerator()
      {
         int seed;
         using (var rng = new RNGCryptoServiceProvider())
         {
            byte[] rndBytes = new byte[4];
            rng.GetBytes(rndBytes);
            var number = BitConverter.ToInt32(rndBytes, 0);
            // ReSharper disable once ExceptionNotDocumented
            // Since we can't pass the min integer value as a parameter to the absolute function we bump the value if we
            // happen to generate the min integer (the odds are exceedingly low).
            seed = Math.Abs(number == int.MinValue ? number + 1 : number);
         }

         _Rand = new System.Random(seed);
      }

      #endregion

      /// <summary>
      ///    Gets the current IRandomGenerator instance to be used for random number generation.
      /// </summary>
      /// <value>The current IRandomGenerator instance.</value>
      /// <remarks>If there is no instance currently, then a new instance of the Generator class is initialized</remarks>
      /// <exception cref="T:System.Security.Cryptography.CryptographicException" accessor="get">The cryptographic service provider (CSP) cannot be acquired.</exception>
      // ReSharper disable once ExceptionNotDocumented
      public static IRandomNumberGenerator Instance => _Instance ?? (_Instance = new NumberGenerator());

      #region IRandomNumberGenerator Members

      /// <summary>
      ///    Gets a random non-negative number less than max.
      /// </summary>
      /// <param name="max">The exclusive upper bound of the random number generated.  max must be greater than or equal to 0.</param>
      /// <returns>A non-negative random integer within the supplied bounds.</returns>
      /// <exception cref="T:System.ArgumentException">Max cannot be less than 0.</exception>
      public virtual int Next(int max)
      {
         if (max < 0)
            throw new ArgumentException(InvalidLowNumberArgError, nameof(max));

         return _Rand.Next(max);
      }

      /// <summary>
      ///    Gets a random number less than max but greater than or equal to min.
      /// </summary>
      /// <param name="min">The inclusive lower bound of the random number generated.</param>
      /// <param name="max">The exclusive upper bound of the random number generated.  max must be equal to or greater than min.</param>
      /// <returns>A non-negative random integer within the supplied bounds.</returns>
      /// <exception cref="T:System.ArgumentException">Min and Max must be non-negative numbers.</exception>
      public virtual int Next(int min, int max)
      {
         if (min < 0)
            throw new ArgumentException(InvalidLowNumberArgError, nameof(min));

         if (max < 0)
            throw new ArgumentException(InvalidLowNumberArgError, nameof(max));

         return _Rand.Next(min, max);
      }

      #endregion
   }
}