using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Simple calculator script for the quizes.
/// </summary>
public class CalculatorScript
{
    /// <summary>
    /// Simple function to add 2 floats.
    /// </summary>
    /// <param name="num1">First float input.</param>
    /// <param name="num2">Second float input.</param>
    /// <returns>The result of adding the 2 numbers together.</returns>
    public static float AddNumbers(float num1, float num2)
    {
        return num1 + num2;
    }

    /// <summary>
    /// Simple function to substract 2 floats.
    /// </summary>
    /// <param name="num1">First float input.</param>
    /// <param name="num2">Second float input.</param>
    /// <returns>The result of adding the 2 numbers together.</returns>
    public static float SubstractNumbers(float num1, float num2)
    {
        return num1 - num2;
    }

    /// <summary>
    /// Simple function to multiply 2 floats.
    /// </summary>
    /// <param name="num1">First float input.</param>
    /// <param name="num2">Second float input.</param>
    /// <returns>The result of adding the 2 numbers together.</returns>
    public static float MultiplyNumbers(float num1, float num2)
    {
        return num1 * num2;
    }

    /// <summary>
    /// Simple function to divide 2 floats.
    /// </summary>
    /// <param name="num1">First float input.</param>
    /// <param name="num2">Second float input.</param>
    /// <returns>The result of adding the 2 numbers together.</returns>
    public static float DivideNumbers(float num1, float num2)
    {
        return num1 / num2;
    }

}
