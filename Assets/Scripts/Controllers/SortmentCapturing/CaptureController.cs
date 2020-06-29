using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Forwarder.Controllers.SortmentCapturing
{
    using ActivityAnalysis.Dynamics;
    using Auxiliary;

    /// <summary>
    /// Unity components class for processing collisions upon sortment capture
    /// </summary>
    public class CaptureController : MonoBehaviour
    {
        [SerializeField]
        private Grabber grabber;

        private Vector3 startPos;
        private Quaternion startQuaternion;

        [SerializeField]
        private TimeController timeController;

        [SerializeField]
        private DynamicsController dynamicsController;

        private bool isJoint;
        private bool canCatch;
        private bool canClone;


        void Start()
        {
            startQuaternion = transform.rotation;
            isJoint = false;
            canCatch = false;
            startPos = transform.position;
            GetComponent<Rigidbody>().angularDrag = 10;

            dynamicsController.AddTree(gameObject);

            if (gameObject.GetComponent<FixedJoint>() != null)
            {
                Destroy(gameObject.GetComponent<FixedJoint>());
            }
            if (gameObject.transform.parent != null)
            {
                gameObject.transform.parent = null;
            }
        }

        void OnTriggerEnter(Collider collider)
        {
            canCatch = (collider == grabber.triggerLeftCollider || collider == grabber.triggerRightCollider) && !isJoint;
        }

        void OnTriggerExit(Collider collider)
        {
            canCatch = collider != grabber.triggerLeftCollider && collider != grabber.triggerRightCollider;
        }

        void OnCollisionEnter(Collision collision)
        {
            if (IsCapturedByClaws(collision))
            {

                if (!isJoint && Input.GetKey(KeyCode.Joystick1Button1)
                    && GrabberAnglesChecker.CheckCaptureAngles(grabber)
                    && canCatch)
                {
                    timeController.OnCapture();
                    Catch();
                }
            }
            else if (IsPlacedSortmenttInTrail(collision))
            {
                timeController.OnDrop();
                Clone();
            }
        }

        bool IsCapturedByClaws(Collision collision)
        {
            return collision.gameObject.name == grabber.RightClaw.name || collision.gameObject.name == grabber.LeftClaw.name;
        }

        bool IsPlacedSortmenttInTrail(Collision collision)
        {
            return collision.gameObject.name == grabber.MainPlatform.gameObject.name && !isJoint;
        }

        public void FixedUpdate()
        {
            if (!Input.GetKey(KeyCode.Joystick1Button1) && isJoint && !canCatch)
            {
                Uncatch();
            }
        }

        public void Clone()
        {
            //Undo commit for Dynamics changes
            dynamicsController.RemoveTree(gameObject);
            Instantiate(gameObject, startPos, startQuaternion);
            canClone = false;
        }

        private void Catch()
        {
            canCatch = false;
            gameObject.GetComponent<Rigidbody>().useGravity = canCatch;
            gameObject.transform.parent = grabber.LocalParent.transform;
            gameObject.AddComponent<FixedJoint>().connectedBody = grabber.LocalParent.GetComponent<Rigidbody>();
            isJoint = true;
        }

        private void Uncatch()
        {
            Destroy(gameObject.GetComponent<FixedJoint>());
            gameObject.transform.parent = null;
            isJoint = false;

            gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
