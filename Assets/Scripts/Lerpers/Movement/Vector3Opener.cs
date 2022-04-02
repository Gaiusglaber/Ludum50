using UnityEngine;

namespace Pathfinders.Toolbox.Lerpers.Movement
{
    public class Vector3Opener : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [SerializeField] private Transform target = null;
        [SerializeField] private Vector3LerperMono lerper = null;
        [SerializeField] private Vector3 closedPosition = Vector2.zero;
        [SerializeField] private Vector3 openPosition = Vector2.zero;
        [SerializeField] private bool startOpen = false;
        #endregion

        #region UNITY_CALLS
        private void Awake()
        {
            if (startOpen)
            {
                UpdateStatus(true, true);
            }
        }

        private void Update()
        {
            if (lerper.On)
            {
                target.position = lerper.CurrentValue;
            }
        }
        #endregion

        #region PUBLIC_METHODS
        public void UpdateStatus(bool status, bool instant = false)
        {
            if (instant)
            {
                lerper.SwitchState(false);
                target.position = status ? openPosition : closedPosition;
            }
            else
            {
                lerper.SetValues(target.position, status ? openPosition : closedPosition, true);
            }
        }
        #endregion
    }
}