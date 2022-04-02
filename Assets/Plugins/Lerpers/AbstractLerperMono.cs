using UnityEngine;

namespace Pathfinders.Toolbox.Lerpers
{
    public abstract class AbstractLerperMono<T> : MonoBehaviour
    {
        #region EXPOSED_FIELDS
        [SerializeField] protected float lerpTime = 1.0f;
        [SerializeField] protected AbstractLerper<T>.SMOOTH_TYPE smoothType = AbstractLerper<T>.SMOOTH_TYPE.NONE;
        #endregion

        #region PROPERTIES

        public T CurrentValue { get { return GetValue(); } }
        public bool On { get { return IsOn(); } }
        public bool Reached { get { return HasReached(); } }
        #endregion

        #region UNITY_CALLS
        protected abstract void Update();
        #endregion

        #region ABSTRACT_METHODS
        public abstract void SetValues(T start, T end, bool on = false);
        public abstract void SwitchState(bool status);

        public abstract T GetValue();

        protected abstract bool IsOn();
        public abstract bool HasReached();
        #endregion
    }
}
