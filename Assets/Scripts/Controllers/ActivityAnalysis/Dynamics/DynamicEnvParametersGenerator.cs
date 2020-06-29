using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forwarder.Controllers.ActivityAnalysis.Dynamics
{
    using static Data.DynamicsEnvParameterRanges;

    public static class DynamicEnvParametersGenerator
    {
        public static DynamicEnvParameters GenerateDynamicParameters(CaptureSpeedLevel level)
        {
            float length, diameter, lightIntensivity;
            switch (level)
            {
                case (CaptureSpeedLevel.MIDDLE):
                    GenerateRandomFloat(MIDDLE_START_RANGE_TREE_LENGTH, MIDDLE_END_RANGE_TREE_LENGTH, out length);
                    GenerateRandomFloat(MIDDLE_START_RANGE_TREE_DIAMETER, MIDDLE_END_RANGE_TREE_DIAMETER, out diameter);
                    GenerateRandomFloat(MIDDLE_START_RANGE_LIGHT_INTENSIVITY, MIDDLE_END_RANGE_LIGHT_INTENSIVITY, out lightIntensivity);
                    break;
                case (CaptureSpeedLevel.FAST):
                    GenerateRandomFloat(FAST_START_RANGE_TREE_LENGTH, FAST_END_RANGE_TREE_LENGTH, out length);
                    GenerateRandomFloat(FAST_START_RANGE_TREE_DIAMETER, FAST_END_RANGE_TREE_DIAMETER, out diameter);
                    GenerateRandomFloat(FAST_START_RANGE_LIGHT_INTENSIVITY, FAST_END_RANGE_LIGHT_INTENSIVITY, out lightIntensivity);
                    break;
                default:
                    GenerateRandomFloat(LOW_START_RANGE_TREE_LENGTH, LOW_END_RANGE_TREE_LENGTH, out length);
                    GenerateRandomFloat(LOW_START_RANGE_TREE_DIAMETER, LOW_END_RANGE_TREE_DIAMETER, out diameter);
                    GenerateRandomFloat(LOW_START_RANGE_LIGHT_INTENSIVITY, LOW_END_RANGE_LIGHT_INTENSIVITY, out lightIntensivity);
                    break;
            }
            return new DynamicEnvParameters(length, diameter, lightIntensivity);
        }

        private static void GenerateRandomFloat(float minVal, float maxVal, out float randomNum)
        {
            randomNum = Random.Range(minVal, maxVal);
        }
    }
}
