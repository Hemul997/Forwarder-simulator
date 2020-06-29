using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Forwarder.Controllers.Graphics
{
    /// <summary>
    /// Unity components class for switching active camera
    /// </summary>
    public class CameraCantroller : MonoBehaviour
    {
        [SerializeField]
        private Camera[] Cameras;


        // Use this for initialization
        void Start()
        {
            SetActiveCamera(0);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKey(KeyCode.Alpha1))
            {
                SetActiveCamera(0);
            }
            else if (Input.GetKey(KeyCode.Alpha2))
            {
                SetActiveCamera(1);
            }
            else if (Input.GetKey(KeyCode.Alpha3))
            {
                SetActiveCamera(2);
            }
            else if (Input.GetKey(KeyCode.Alpha4))
            {
                SetActiveCamera(3);
            }
        }



        private void SetActiveCamera(int index)
        {
            if (Cameras[index] != null)
            {
                foreach (Camera camera in Cameras)
                {
                    camera.gameObject.SetActive(false);
                }
                Cameras[index].gameObject.SetActive(true);
            }
        }
    }
}
