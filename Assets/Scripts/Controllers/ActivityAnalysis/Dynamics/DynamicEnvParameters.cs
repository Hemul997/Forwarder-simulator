using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forwarder.Controllers.ActivityAnalysis.Dynamics
{
    [Serializable]
    public class DynamicEnvParameters
    {
        public float SortmentLength { get; private set; }

        public float SortmentDiameter { get; private set; }

        public float LightIntensivity { get; private set; }

        public DynamicEnvParameters(float treeLength, float treeDiameter, float lightIntensivity)
        {
            SortmentDiameter = treeDiameter;
            SortmentLength = treeLength;
            LightIntensivity = lightIntensivity;
        }

    }
}
