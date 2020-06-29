using UnityEngine;


namespace Forwarder.Controllers.Manipulator
{
    using Controllers.ActivityAnalysis;
    using Data;

    public class LeftClawMoveController : MonoBehaviour
    {
        private Rigidbody ArmRigidbody;
        private readonly float rotateSpeed = 20f;

        [SerializeField]
        private ArmsWorkRegistrator WorkRegistrator;

        void Awake()
        {
            ArmRigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Joystick1Button1) || Input.GetKey(KeyCode.Joystick2Button1))
            {
                if (Input.GetKey(KeyCode.Joystick1Button1)) {
                    ArmRigidbody.constraints = RigidbodyConstraints.None;
                    ArmRigidbody.AddRelativeTorque(Vector3.forward * rotateSpeed, ForceMode.Acceleration);
                    
                } else if (Input.GetKey(KeyCode.Joystick2Button1)) {
                    ArmRigidbody.constraints = RigidbodyConstraints.None;
                    ArmRigidbody.AddRelativeTorque(Vector3.back * rotateSpeed, ForceMode.Acceleration);

                }
                WorkRegistrator.RegistrateWorkTime(ArmAxisNames.ARM_CLAW_CAPTURE);
            }  
        }
    }
}