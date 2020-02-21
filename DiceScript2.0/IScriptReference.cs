#region Dansko LLC License
// <copyright file="IScriptReference.cs" company="Dansko LLC">
// Copyright 2020 Dansko LLC
// </copyright>
// This code is property of Dansko LLC and is not licensed for use by any other parties.
#endregion

namespace DiceScript2._0
{
   /// <summary>
   /// An Interface used by the DiceScript interpreter to handle substitution values and non-core function calls
   /// </summary>
   public interface IScriptReference
   {
      /// <summary>
      /// Gets the value for a specified substitution name.
      /// </summary>
      /// <param name="name">The name to get the value for.</param>
      /// <returns>A <see cref="decimal"/> value.</returns>
      decimal GetValue(string name);

      /// <summary>
      /// Attempts to find an execute a specified function given the supplied parameters.
      /// </summary>
      /// <param name="name">The name of the function to execute.</param>
      /// <param name="parameters">The parameters to pass to the function.</param>
      /// <returns>A <see cref="decimal"/> value.</returns>
      decimal ExecuteFunction(string name, decimal[] parameters);
   }
}