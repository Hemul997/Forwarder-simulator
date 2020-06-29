using UnityEngine;

namespace Forwarder.Controllers.Manipulator
{
    public class RightClawMoveController : MonoBehaviour
    {
        private Rigidbody rb;
        public readonly float rotateSpeed = 20f;

        // Use this for initialization
        void Awake()
        {
            rb = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            if (Input.GetKey(KeyCode.Joystick1Button1))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddRelativeTorque(Vector3.back * rotateSpeed, ForceMode.Acceleration);
            }

            else if (Input.GetKey(KeyCode.Joystick2Button1))
            {
                rb.constraints = RigidbodyConstraints.None;
                rb.AddRelativeTorque(Vector3.forward * rotateSpeed, ForceMode.Acceleration);
            }
        }
    }
}