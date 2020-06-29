using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Forwarder.HandleInput
{
    /// <summary>
    /// Class for checking joysticks rotation output values.
    /// </summary>
    public static class JoystickRotationChecker
    {
        private const float POSITIVE_ROTATION_FLAG = 1.0f;
        private const float NEGATIVE_ROTATION_FLAG = -1.0f;


        public static bool IsRotated(float rotation)
        {
            return IsNegativeRotated(rotation) || IsPositiveRotated(rotation);
        }

        public static bool IsPositiveRotated(float rotation)
        {
            return IsFloatNumbersEqual(rotation, POSITIVE_ROTATION_FLAG);       
        }

        public static bool IsNegativeRotated(float rotation)
        {
            return IsFloatNumbersEqual(rotation, NEGATIVE_ROTATION_FLAG);
        }

        private static bool IsFloatNumbersEqual(float first, float second)
        {
            return Mathf.Abs(first - second) < Mathf.Epsilon;
        }

    }
}
