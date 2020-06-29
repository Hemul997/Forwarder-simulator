using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Forwarder.Controllers.Transmission
{
    [System.Serializable]
    public enum ManipulatorState
    {
        WORKS, STOPPED
    }

    /// <summary>
    /// Unity components class for switching manipulator working state. It must-be feature for forwarder moving.
    /// </summary>
    public class ManipulatorSwitcher : MonoBehaviour
    {
        [SerializeField]
        private ArmsBlocker Blocker;

        public ManipulatorState CurrentState { get; private set; }

        public bool CanMove;

        // Use this for initialization
        void Start()
        {
            CurrentState = ManipulatorState.WORKS;
            CanMove = false;
        }

        void FixedUpdate()
        {

            if (Input.GetKey(KeyCode.Joystick1Button3))
            {
                ChangeStatus();
                Blocker.SetBlockingState(CurrentState);
            }
        }

        //TODO Добавить звук при отключении стрелы
        void ChangeStatus()
        {
            if (CurrentState == ManipulatorState.WORKS)
            {
                CurrentState = ManipulatorState.STOPPED;
                CanMove = true;
            }
            else
            {
                CurrentState = ManipulatorState.WORKS;
                CanMove = false;
            }
        }


        void ChangeStatus(ManipulatorState State)
        {
            CurrentState = State;
        }
    }
}