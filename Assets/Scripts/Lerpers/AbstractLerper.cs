using UnityEngine;

namespace Pathfinders.Toolbox.Lerpers
{
    public abstract class AbstractLerper<T>
    {
        #region PROTECTED FIELDS
        protected T start;
        protected T end;

        protected float lerpTime;
        protected float currentLerpTime;
        #endregion

        #region PRIVATE_FIELDS
        private bool initialized = false;
        #endregion

        #region PROPERTIES
        public enum SMOOTH_TYPE { NONE, EASE_IN, EASE_OUT, EXPONENTIAL, STEP_SMOOTH, STEP_SMOOTHER }
        protected SMOOTH_TYPE smoothType;
        #endregion

        #region PROPERTIES
        public T CurrentValue { get; protected set; }
        public bool On { get; private set; }
        public bool Reached { get; private set; }
        public bool Initialized { get => initialized; private set => initialized = value; }
        #endregion

        #region CONSTRUCTORS
        public AbstractLerper(float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE)
        {
            Init(lerpTime, smoothType);
        }

        public AbstractLerper(T start, T end, float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE)
        {
            Init(lerpTime, smoothType);
            this.start = start;
            this.end = end;
        }
        #endregion

        #region PUBLIC METHODS
        public void Init(float lerpTime, SMOOTH_TYPE smoothType)
        {
            this.lerpTime = lerpTime;
            this.smoothType = smoothType;
            Reached = false;
            Initialized = true;
        }

        public void Update()
        {
            if (!On) 
            {
                return;
            }

            currentLerpTime += Time.deltaTime;
            if (currentLerpTime > lerpTime)
            {
                currentLerpTime = lerpTime;
            }

            float perc = currentLerpTime / lerpTime;
            perc = SmoothLerp(perc, smoothType);

            UpdateCurrentPosition(perc);
            if (CheckReached())
            {
                Reached = true;
                SwitchState(false);
            }
        }

        public void SetValues(T start, T end, bool on = false)
        {
            this.start = start;
            this.end = end;
            On = on;
            Reset();
        }

        public void SetLerpTime(float time)
        {
            lerpTime = time;
        }

        public void SwitchState(bool on)
        {
            On = on;
        }
        #endregion

        #region PROTECTED METHODS
        protected abstract void UpdateCurrentPosition(float perc);

        protected abstract bool CheckReached();

        protected void Reset()
        {
            currentLerpTime = 0.0f;
            Reached = false;
            UpdateCurrentPosition(0.0f);
        }

        protected float SmoothLerp(float value, SMOOTH_TYPE mode)
        {
            float smooth = value;

            switch (mode)
            {
                case SMOOTH_TYPE.NONE:
                    break;
                case SMOOTH_TYPE.EASE_IN:
                    smooth = 1f - Mathf.Cos(value * Mathf.PI * 0.5f);
                    break;
                case SMOOTH_TYPE.EASE_OUT:
                    smooth = Mathf.Sin(value * Mathf.PI * 0.5f);
                    break;
                case SMOOTH_TYPE.EXPONENTIAL:
                    smooth = value * value;
                    break;
                case SMOOTH_TYPE.STEP_SMOOTH:
                    smooth = value * value * (3f - 2f * value);
                    break;
                case SMOOTH_TYPE.STEP_SMOOTHER:
                    smooth = value * value * value * (value * (6f * value - 15f) + 10f);
                    break;
            }

            return smooth;
        }
        #endregion
    }

    public class FloatLerper : AbstractLerper<float>
    {
        #region CONSTRUCTORS
        public FloatLerper(float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(lerpTime, smoothType) { }
        public FloatLerper(float start, float end, float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(start, end, lerpTime, smoothType) { }
        #endregion

        #region OVERRIDE
        protected override void UpdateCurrentPosition(float perc)
        {
            CurrentValue = Mathf.Lerp(start, end, perc);
        }

        protected override bool CheckReached()
        {
            if (CurrentValue == end)
                return true;
            else
                return false;
        }
        #endregion
    }

    public class Vector2Lerper : AbstractLerper<Vector2>
    {
        #region CONSTRUCTORS
        public Vector2Lerper(float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(lerpTime, smoothType) { }
        public Vector2Lerper(Vector2 start, Vector2 end, float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(start, end, lerpTime, smoothType) { }
        #endregion

        #region OVERRIDE
        protected override void UpdateCurrentPosition(float perc)
        {
            CurrentValue = Vector2.Lerp(start, end, perc);
        }

        protected override bool CheckReached()
        {
            if (CurrentValue == end)
                return true;
            else
                return false;
        }
        #endregion
    }

    public class Vector3Lerper : AbstractLerper<Vector3>
    {
        #region CONSTRUCTORS
        public Vector3Lerper(float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(lerpTime, smoothType) { }
        public Vector3Lerper(Vector3 start, Vector3 end, float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(start, end, lerpTime, smoothType) { }
        #endregion

        #region OVERRIDE
        protected override void UpdateCurrentPosition(float perc)
        {
            CurrentValue = Vector3.Lerp(start, end, perc);
        }
        protected override bool CheckReached()
        {
            if (CurrentValue == end)
                return true;
            else
                return false;
        }
        #endregion
    }

    public class ColorLerper : AbstractLerper<Color>
    {
        #region CONSTRUCTORS
        public ColorLerper(float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(lerpTime, smoothType) { }
        public ColorLerper(Color start, Color end, float lerpTime, SMOOTH_TYPE smoothType = SMOOTH_TYPE.NONE) : base(start, end, lerpTime, smoothType) { }
        #endregion

        #region OVERRIDE
        protected override void UpdateCurrentPosition(float perc)
        {
            CurrentValue = Color.Lerp(start, end, perc);
        }
        protected override bool CheckReached()
        {
            if (CurrentValue == end)
                return true;
            else
                return false;
        }
        #endregion
    }
}
