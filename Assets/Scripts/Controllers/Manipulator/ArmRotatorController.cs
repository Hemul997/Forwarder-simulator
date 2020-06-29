using UnityEngine;

namespace Forwarder.Controllers.Manipulator
{
    using HandleInput;
    using Data;

    public class ArmRotatorController : ArmController
    {

        private readonly float rotateSpeed = 25f;

        protected override void InitConstraints()
        {
            ArmInfo.ArmRigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
        }

        protected override ArmAxisInfo InitializeArmInfo()
        {
            return new ArmAxisInfo(ArmAxisNames.ARM_CLAW_CAPTURE, GetComponent<Rigidbody>());
        }

        protected override bool IsCanMove(float rotation)
        {
            return JoystickRotationChecker.IsRotated(rotation);
        }

        protected override void Move(float rotation)
        {
            ArmInfo.ArmRigidbody.constraints = RigidbodyConstraints.None;
            ArmInfo.ArmRigidbody.AddRelativeTorque(Vector3.up * rotateSpeed * rotation, ForceMode.Acceleration);
        }
    }
}


