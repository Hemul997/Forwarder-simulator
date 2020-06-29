using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forwarder.Controllers.SortmentCapturing
{
    using static Data.CaptureAnglesAxiesRanges;
    public static class GrabberAnglesChecker
    {
        public static bool CheckCaptureAngles(Grabber grabber)
        {
            float leftAngle = grabber.LeftClaw.transform.rotation.eulerAngles.z - 360f;
            float rightAngle = grabber.RightClaw.transform.rotation.eulerAngles.z;

            return CheckCaptureAngles(leftAngle, rightAngle);

        }
        private static bool CheckCaptureAngles(float leftAngle, float rightAngle)
        {
            return rightAngle < MAX_RIGHT_ANGLE_AXIS
                    && rightAngle > OPTIMAL_CAPTURE_RIGHT_ANGLE_AXIS
                    && leftAngle > MAX_LEFT_ANGLE_AXIS
                    && leftAngle < OPTIMAL_CAPTURE_LEFT_ANGLE_AXIS;
        }
    }
}
