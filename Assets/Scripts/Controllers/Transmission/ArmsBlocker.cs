using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Forwarder.Controllers.Transmission
{
    /// <summary>
    /// Unity components class for blocking arms rigidbodies.
    /// </summary>
    public class ArmsBlocker : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody[] arms;


        // Use this for initialization
        void Start()
        {
            SetBlockingState(false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isBlocking"></param>
        void SetBlockingState(bool isBlocking)
        {
            foreach (var arm in arms)
            {
                arm.isKinematic = isBlocking;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        public void SetBlockingState(ManipulatorState state)
        {

            if (state == ManipulatorState.STOPPED)
            {
                SetBlockingState(true);
            }
            else
            {
                SetBlockingState(false);
            }
        }
    }
}
