using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forwarder.Data
{
    struct DynamicsEnvParameterRanges
    {
        public const int START_MIDDLE_SPEED_RANGE = 15;
        public const int START_LOW_SPEED_RANGE = 30;

        public const float LOW_START_RANGE_TREE_DIAMETER = 0.4f;
        public const float LOW_END_RANGE_TREE_DIAMETER = 0.6f;
        
        public const float LOW_START_RANGE_TREE_LENGTH = 3f;
        public const float LOW_END_RANGE_TREE_LENGTH = 4f;
         
        public const float LOW_START_RANGE_LIGHT_INTENSIVITY = 0.7f;
        public const float LOW_END_RANGE_LIGHT_INTENSIVITY = 1f;
         
        public const float MIDDLE_START_RANGE_TREE_DIAMETER = 0.7f;
        public const float MIDDLE_END_RANGE_TREE_DIAMETER = 0.8f;
         
        public const float MIDDLE_START_RANGE_TREE_LENGTH = 4f;
        public const float MIDDLE_END_RANGE_TREE_LENGTH = 5f;
         
        public const float MIDDLE_START_RANGE_LIGHT_INTENSIVITY = 0.4f;
        public const float MIDDLE_END_RANGE_LIGHT_INTENSIVITY = 0.7f;
         
        public const float FAST_START_RANGE_TREE_DIAMETER = 0.9f;
        public const float FAST_END_RANGE_TREE_DIAMETER = 1f;
         
        public const float FAST_START_RANGE_TREE_LENGTH = 6f;
        public const float FAST_END_RANGE_TREE_LENGTH = 7f;
         
        public const float FAST_START_RANGE_LIGHT_INTENSIVITY = 0.01f;
        public const float FAST_END_RANGE_LIGHT_INTENSIVITY = 0.1f;
    }    
}
