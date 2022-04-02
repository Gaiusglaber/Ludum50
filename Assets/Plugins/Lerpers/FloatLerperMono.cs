using UnityEngine;

namespace Pathfinders.Toolbox.Lerpers
{
    public class FloatLerperMono : AbstractLerperMono<float>
    {
        #region PRIVATE_FIELDS
        private FloatLerper lerper = null;
        #endregion

        #region PROPERTIES
        private FloatLerper Lerper
        {
            get
            {
                if (lerper == null)
                {
                    lerper = new FloatLerper(lerpTime, smoothType);
                }

                return lerper;
            }
        }
        #endregion

        #region UNITY_CALLS
        protected override void Update()
        {
            Lerper.Update();
        }
        #endregion

        #region OVERRIDE
        public override float GetValue()
        {
            return Lerper.CurrentValue;
        }

        public override bool HasReached()
        {
            return Lerper.Reached;
        }

        protected override bool IsOn()
        {
            return Lerper.On;
        }

        public override void SetValues(float start, float end, bool on = false)
        {
           Lerper.SetValues(start,end,on);
        }

        public override void SwitchState(bool status)
        {
            Lerper.SwitchState(status);
        }
        #endregion
    }
}
