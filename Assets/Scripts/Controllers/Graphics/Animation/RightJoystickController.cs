using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Forwarder.Controllers.Graphics.Animation
{
    using Data;
    class RightJoystickController : JoystickAnimationController
    {
        public override void GetJoystickState(out float xRotation, out float yRotation)
        {
            xRotation = Input.GetAxis(ArmAxisNames.ARM_MAIN_AXIS);
            yRotation = Input.GetAxis(ArmAxisNames.ARM_ELBOW_AXIS);
        }
    }
}