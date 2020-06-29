using UnityEngine;

namespace Forwarder.Controllers.Manipulator
{
    using HandleInput;
    using Controllers.ActivityAnalysis;
    using Data;

    public class TelescopeController: MonoBehaviour
    {
        public readonly string AxisName = ArmAxisNames.ARM_TELESCOPE_AXIS;
        private Rigidbody ArmRigidbody;

        private GameObject ConnectedBody;
        private GameObject NestBody;
        private FixedJoint fxdJoint;
        public GameObject Neighbour;
        [SerializeField]
        private ArmsWorkRegistrator WorkRegistrator;

        private readonly float MoveSpeed = 20f;

        void Awake()
        {
            ArmRigidbody = GetComponent<Rigidbody>();
            fxdJoint = GetComponent<FixedJoint>();
            ConnectedBody = GameObject.Find("ArmElbow");
            NestBody = GameObject.Find("ArmTelescopeStabilizer");
        }

        void FixedUpdate()
        {
            float rotation = Input.GetAxis(AxisName);

            if (CanMove())
            {
                if (JoystickRotationChecker.IsPositiveRotated(rotation))
                {
                    Destroy(fxdJoint);
                    ArmRigidbody.mass = 50;
                    ArmRigidbody.AddRelativeTorque(Vector3.back * MoveSpeed, ForceMode.Acceleration);
                    WorkRegistrator.RegistrateWorkTime(AxisName);
                }
                else if (JoystickRotationChecker.IsNegativeRotated(rotation))
                {
                    Destroy(fxdJoint);
                    ArmRigidbody.AddRelativeForce(Vector3.forward * MoveSpeed, ForceMode.Acceleration);
                    WorkRegistrator.RegistrateWorkTime(AxisName);
                }
                else
                {
                    AddFixedJointToObject(gameObject, ConnectedBody);
                }
            }
            ArmRigidbody.mass = 150;
        }

        void AddFixedJointToObject(GameObject gameObject, GameObject connectedObject)
        {
            if (!gameObject.GetComponent<FixedJoint>())
            {
                fxdJoint = gameObject.AddComponent<FixedJoint>();
                fxdJoint.connectedBody = connectedObject.GetComponent<Rigidbody>();
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.name == NestBody.name)
            {
                SetTriggers(ref Neighbour, true);
            }
        }

        private void OnCollisionExit(Collision collision)
        {
            if (collision.gameObject.name == NestBody.name)
            {
                SetTriggers(ref Neighbour, false);
            }
        }

        private bool CanMove()
        {
            return NotRotate(Input.GetAxis(ArmAxisNames.ARM_ARROW_AXIS)) && NotRotate(Input.GetAxis(ArmAxisNames.ARM_ROTATOR_AXIS));
        }

        private bool NotRotate(float rotation)
        {
            return !JoystickRotationChecker.IsRotated(rotation);
        }

        private void SetTriggers(ref GameObject obj, bool value)
        {
            foreach (var col in obj.GetComponents<Collider>())
            {
                col.isTrigger = value;
            }
        }
    }
}