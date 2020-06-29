using UnityEngine;
using Forwarder.HandleInput;

namespace Forwarder.Controllers.Manipulator
{
    using Data;
    public class ArmElbowController : ArmController
    {
        private readonly float rotateSpeed = 200f;
        private readonly float liftRatio = 1.75f;

        /// <summary>
        /// MonoBehaviour function
        /// called when the script instance is being loaded. 
        /// </summary>

        protected override void InitConstraints()
        {
            ArmInfo.ArmRigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
        }

        protected override void Move(float rotation)
        {
            if (JoystickRotationChecker.IsNegativeRotated(rotation))
            {
                ArmInfo.ArmRigidbody.constraints = RigidbodyConstraints.None;
                ArmInfo.ArmRigidbody.AddRelativeTorque(Vector3.right * rotateSpeed * rotation, ForceMode.Acceleration);
            }
            else if (JoystickRotationChecker.IsPositiveRotated(rotation))
            {
                ArmInfo.ArmRigidbody.constraints = RigidbodyConstraints.None;
                ArmInfo.ArmRigidbody.AddRelativeTorque(Vector3.right * rotateSpeed * liftRatio * rotation, ForceMode.Acceleration);
            }
        }

        protected override bool IsCanMove(float rotation)
        {
            return JoystickRotationChecker.IsRotated(rotation);
        }

        protected override ArmAxisInfo InitializeArmInfo()
        {
            return new ArmAxisInfo(ArmAxisNames.ARM_ELBOW_AXIS, GetComponent<Rigidbody>());
        }
    }
}