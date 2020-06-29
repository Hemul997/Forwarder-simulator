using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Forwarder.Controllers.Graphics.Animation
{
    using Data;
    using HandleInput;

    /// <summary>
    /// Base class for controlling game joysticks animation.
    /// Implements MonoBehaviour functions
    /// </summary>
    public abstract class JoystickAnimationController : MonoBehaviour
    {
        private float xRotation, yRotation;
        private Animator Animator;

        // Use this for initialization
        void Awake()
        {
            xRotation = 0;
            yRotation = 0;
            Animator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            GetJoystickState(out xRotation, out yRotation);
            CheckRotation(xRotation, yRotation);
        }

        public abstract void GetJoystickState(out float xRotation, out float yRotation);

        private void CheckRotation(float xRotation, float yRotation)
        {
            string animateAction;

            if (JoystickRotationChecker.IsPositiveRotated(xRotation))
            {
                animateAction = AnimationActions.RIGHT;
            }
            else if (JoystickRotationChecker.IsNegativeRotated(xRotation))
            {
                animateAction = AnimationActions.LEFT;
            }
            else if (JoystickRotationChecker.IsPositiveRotated(yRotation))
            {
                animateAction = AnimationActions.BACK;
            }
            else if (JoystickRotationChecker.IsNegativeRotated(yRotation))
            {
                animateAction = AnimationActions.FORWARD;
            }
            else
            {
                animateAction = AnimationActions.STAY;
            }

            Animator.Play(animateAction);
        }

    }
}

