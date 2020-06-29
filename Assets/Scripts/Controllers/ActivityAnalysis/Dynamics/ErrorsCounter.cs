using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Forwarder.Controllers.ActivityAnalysis.Dynamics
{
    using static Data.WorkingErrorRanges;

    public enum ErrorLevel
    {
        LOW, MIDDLE, HIGH
    }

    /// <summary>
    /// Unity components class for trainable error counting.
    /// </summary>
    public class ErrorsCounter : MonoBehaviour
    {
        private int ErrorsCount { get; set; }

        private bool InErrorZone;

        [SerializeField]
        private Transform TrackedTransform;

        public ErrorLevel Level { get; private set; }

        public int Count
        {
            get
            {
                return ErrorsCount;
            }
        }

        // Use this for initialization
        void Awake()
        {
            ErrorsCount = 0;
            Level = ErrorLevel.LOW;
            InErrorZone = false;
        }

        public void OnError()
        {
            if (!InErrorZone)
            {
                ErrorsCointInc();

                if (ErrorsCount >= START_RANGE_MIDDLE_ERRORS_LEVEL && ErrorsCount < START_RANGE_HIGH_ERROR_LEVEL)
                {
                    Level = ErrorLevel.MIDDLE;
                }
                else if (ErrorsCount >= START_RANGE_HIGH_ERROR_LEVEL)
                {
                    Level = ErrorLevel.HIGH;
                }
                InErrorZone = true;
            }
        }

        public void OnErrorZoneLeft()
        {
            InErrorZone = false;
        }

        private void ErrorsCointInc()
        {
            ++ErrorsCount;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            if (IsErrorChecked())
            {
                OnError();
            }
            else
            {
                OnErrorZoneLeft();
            }
        }

        private bool IsErrorChecked()
        {
            return (TrackedTransform.rotation.eulerAngles.x > MAX_OX_ANGLE && TrackedTransform.rotation.eulerAngles.x < 180)
                || (TrackedTransform.rotation.eulerAngles.y > MAX_OY_ANGLE && TrackedTransform.rotation.eulerAngles.y < 180)
                || ((TrackedTransform.rotation.eulerAngles.x > 180) && (TrackedTransform.rotation.eulerAngles.x - 360f) < MIN_OX_ANGLE)
                || ((TrackedTransform.transform.rotation.eulerAngles.y - 360f) < MIN_OY_ANGLE && TrackedTransform.rotation.eulerAngles.y > 180f);
        }
    }
}
