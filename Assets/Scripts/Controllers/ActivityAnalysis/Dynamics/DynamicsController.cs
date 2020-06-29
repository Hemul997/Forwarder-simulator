using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Diagnostics;


namespace Forwarder.Controllers.ActivityAnalysis.Dynamics
{
    using static Data.DynamicsEnvParameterRanges;

    public enum CaptureSpeedLevel
    {
        FAST, MIDDLE, LOW
    }

    /// <summary>
    /// Unity components class for switching enviroment parameters. Switch this parameters depends on level of training.
    /// </summary>
    public class DynamicsController : MonoBehaviour
    {
        [SerializeField]
        private Light DirectionalLight;

        private List<GameObject> listTrees;

        public CaptureSpeedLevel SpeedLevel { get; set; }
        public bool SystemChanged { get; set; }

        // Use this for initialization
        void Awake()
        {
            listTrees = new List<GameObject>();
            SpeedLevel = CaptureSpeedLevel.MIDDLE;
            SystemChanged = true;
        }

        public void AddTree(GameObject tree)
        {
            listTrees.Add(tree);
        }

        public void RemoveTree(GameObject tree)
        {
            listTrees.Remove(tree);
        }

        public void OnDrop(int droppedTreeTime)
        {
            if (droppedTreeTime <= START_MIDDLE_SPEED_RANGE)
            {
                SpeedLevel = CaptureSpeedLevel.FAST;
            }
            else if (droppedTreeTime <= START_LOW_SPEED_RANGE)
            {
                SpeedLevel = CaptureSpeedLevel.MIDDLE;
            }
            else
            {
                SpeedLevel = CaptureSpeedLevel.LOW;
            }
            SystemChanged = true;
        }


        void FixedUpdate()
        {
            if (SystemChanged)
            {
                ChangeDynamicsValues(DynamicEnvParametersGenerator.GenerateDynamicParameters(SpeedLevel));
                SystemChanged = false;
            }
        }

        private void ChangeDynamicsValues(DynamicEnvParameters envParameters)
        {
            foreach (GameObject tree in listTrees)
            {
                ChangeTreeScale(tree.transform, envParameters.SortmentLength, envParameters.SortmentDiameter);
            }
            DirectionalLight.intensity = envParameters.LightIntensivity;
        }


        private void ChangeTreeScale(Transform transform, float length, float diameter)
        {
            transform.localScale = new Vector3(diameter, length, diameter);
        }
    }
}
