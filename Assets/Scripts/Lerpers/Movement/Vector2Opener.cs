using UnityEngine;

namespace Pathfinders.Toolbox.Lerpers.Movement
{
    public class Vector2Opener : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [SerializeField] private RectTransform rectTransform = null;
        [SerializeField] private Vector2LerperMono lerper = null;
        [SerializeField] private Vector2 closedPosition = Vector2.zero;
        [SerializeField] private Vector2 openPosition = Vector2.zero;
        [SerializeField] private bool startOpen = false;
        #endregion

        #region UNITY_CALLS
        private void Awake()
        {
            UpdateStatus(startOpen, true);
        }

        private void Update()
        {
            if (lerper.On)
            {
                rectTransform.anchoredPosition = lerper.CurrentValue;
            }
        }
        #endregion

        #region PUBLIC_METHODS
        public void UpdateStatus(bool status, bool instant = false)
        {
            if (instant)
            {
                lerper.SwitchState(false);
                rectTransform.anchoredPosition = status ? openPosition : closedPosition;
            }
            else
            {
                lerper.SetValues(rectTransform.anchoredPosition, status ? openPosition : closedPosition, true);
            }
        }
        #endregion
    }
}