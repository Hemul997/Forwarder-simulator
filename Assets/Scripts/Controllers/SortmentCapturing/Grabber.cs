using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forwarder.Controllers.SortmentCapturing
{
    /// <summary>
    /// Class keept references on sortment capturing gameobjects
    /// </summary>
    [Serializable]
    public class Grabber
    {
        public GameObject LeftClaw;
        public GameObject RightClaw;
        public GameObject LocalParent;

        public GameObject Plane;
        public Collider triggerLeftCollider;
        public Collider triggerRightCollider;

        public Collider MainPlatform;
    }
}
