using UnityEngine;

namespace Forwarder.Controllers.Manipulator
{
    using ActivityAnalysis;

    /// <summary>
    /// Base class for moves arms controllers
    /// Implements MonoBehaviour functions
    /// </summary>
    public abstract class ArmController : MonoBehaviour
    {
        [SerializeField]
        protected ArmAxisInfo ArmInfo;

        [SerializeField]
        private ArmsWorkRegistrator Registrator;

        void Awake()
        {
            ArmInfo = InitializeArmInfo();
        }

        void FixedUpdate()
        {
            InitConstraints();

            float rotation = Input.GetAxis(ArmInfo.ArmName);

            if (IsCanMove(rotation))
            {
                Move(rotation);
                if (ArmInfo.IsArmRegistrated)
                {
                    Registrator.RegistrateWorkTime(ArmInfo.ArmName);
                } 
            }
        }

        protected abstract ArmAxisInfo InitializeArmInfo();

        protected abstract void InitConstraints();

        protected abstract void Move(float rotation);
        protected abstract bool IsCanMove(float rotation);
        
    }
}
