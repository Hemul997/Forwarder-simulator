using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Forwarder.Controllers.Graphics.Animation
{
    using Data;
    class LeftJoystickController : JoystickAnimationController
    {
        public override void GetJoystickState(out float xRotation, out float yRotation)
        {
            xRotation = Input.GetAxis(ArmAxisNames.ARM_ROTATOR_AXIS);
            yRotation = -Input.GetAxis(ArmAxisNames.ARM_ARROW_AXIS);
        }


    }
}

