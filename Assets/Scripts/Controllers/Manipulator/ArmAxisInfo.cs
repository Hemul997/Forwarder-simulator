using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Forwarder.Controllers.Manipulator
{

    /// <summary>
    /// Class, incapsulates arm axis data
    /// </summary>
    [Serializable]
    public class ArmAxisInfo
    {
        public string ArmName { get; private set; }
        public Rigidbody ArmRigidbody { get; private set; }

        [SerializeField]
        public bool IsArmRegistrated = false;

        public ArmAxisInfo(string name, Rigidbody rb)
        {
            ArmName = name;
            ArmRigidbody = rb;
        }
    }
}
