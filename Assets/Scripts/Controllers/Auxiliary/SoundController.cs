using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Forwarder.Controllers.Auxiliary
{
    using HandleInput;
    using Data;

    /// <summary>
    /// Unity components class for change forwarder sound while using joysticks
    /// </summary>
    public class SoundController : MonoBehaviour
    {
        private float FirstJoystickOXRotating;
        private float FirstJoystickOYRotating;
        private float SecondJoystickOXRotating;
        private float SecondJoystickOYRotating;
        [SerializeField]
        AudioSource ForwarderSound;


        void GetValues()
        {
            FirstJoystickOXRotating = Input.GetAxis(ArmAxisNames.ARM_MAIN_AXIS);
            FirstJoystickOYRotating = Input.GetAxis(ArmAxisNames.ARM_ELBOW_AXIS);
            SecondJoystickOXRotating = Input.GetAxis(ArmAxisNames.ARM_ROTATOR_AXIS);
            SecondJoystickOYRotating = Input.GetAxis(ArmAxisNames.ARM_ARROW_AXIS);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (IsJoysticksMoving())
            {
                ForwarderSound.volume = 0.7f;
            }
            else
            {
                ForwarderSound.volume = 1f;
            }
        }

        private bool IsJoysticksMoving()
        {
            GetValues();
            return JoystickRotationChecker.IsRotated(FirstJoystickOXRotating)
                || JoystickRotationChecker.IsRotated(FirstJoystickOYRotating)
                || JoystickRotationChecker.IsRotated(SecondJoystickOXRotating)
                || JoystickRotationChecker.IsRotated(SecondJoystickOYRotating);
        }

    }
}