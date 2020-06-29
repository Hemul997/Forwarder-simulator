using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Forwarder.Controllers.Transmission
{
    [System.Serializable]
    public class AxleInfo
    {
        public WheelCollider leftWheel;
        public WheelCollider rightWheel;
        public bool motor;
        public bool steering;

    }
    /// <summary>
    /// Unity components class for forwarder driving. 
    /// </summary>
    public class WheelsController : MonoBehaviour
    {
        public List<AxleInfo> axleInfos;
        public float maxMotorTorque;
        public float maxSteeringAngle;
        public float maxHandbrake;
        [SerializeField]
        private ManipulatorSwitcher Switcher;


        // Update is called once per frame
        void FixedUpdate()
        {

            float handbrake = Input.GetAxis("Jump");

            float motor = maxMotorTorque * Input.GetAxis("Vertical");
            float steering = maxSteeringAngle * Input.GetAxis("Horizontal");

            if (Switcher.CanMove)
            {

                foreach (AxleInfo axleInfo in axleInfos)
                {
                    if (axleInfo.steering)
                    {
                        axleInfo.leftWheel.steerAngle = steering;
                        axleInfo.rightWheel.steerAngle = steering;
                    }
                    //if (handbrake > 0f)
                    //{
                    //	var hbTorque = handbrake*maxHandbrake;
                    //	axleInfo.leftWheel.brakeTorque = hbTorque;
                    //	axleInfo.leftWheel.brakeTorque = hbTorque;
                    //}
                    if (axleInfo.motor)
                    {
                        axleInfo.leftWheel.motorTorque = motor;
                        axleInfo.rightWheel.motorTorque = motor;
                    }
                    ApplyLocalPositionToVisuals(axleInfo.leftWheel);
                    ApplyLocalPositionToVisuals(axleInfo.rightWheel);
                }
                //Switcher.IsUpdated = false;
            }

        }


        // finds the corresponding visual wheel
        // correctly applies the transform
        public void ApplyLocalPositionToVisuals(WheelCollider collider)
        {
            if (collider.transform.childCount == 0)
            {
                return;
            }

            Transform visualWheel = collider.transform.GetChild(0);

            Vector3 position;
            Quaternion rotation;
            collider.GetWorldPose(out position, out rotation);

            visualWheel.transform.position = position;
            visualWheel.transform.rotation = rotation;
        }
    }
}
