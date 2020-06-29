using UnityEngine;

namespace Forwarder.Controllers.Manipulator
{
    using HandleInput;
    using Data;

    public class ArmMainAxisController : ArmController
    {
        public readonly float rotateSpeed = 600;

        /// <summary>
        /// MonoBehaviour function
        /// called when the script instance is being loaded. 
        /// </summary>
        protected override void InitConstraints() { }

        protected override void Move(float rotation)
        {
            ArmInfo.ArmRigidbody.AddRelativeTorque(Vector3.up * rotateSpeed * rotation, ForceMode.Acceleration);
        }

        protected override bool IsCanMove(float rotation)
        {
            return JoystickRotationChecker.IsRotated(rotation);
        }

        protected override ArmAxisInfo InitializeArmInfo()
        {
            return new ArmAxisInfo(ArmAxisNames.ARM_MAIN_AXIS, GetComponent<Rigidbody>());
        }
    }
}