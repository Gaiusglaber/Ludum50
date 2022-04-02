using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinders.Toolbox.Lerpers
{
    public class LerpersTest : MonoBehaviour
    {
        [Header("v2")]
        private int posIndex = 0;
        [SerializeField] private Vector2[] poss = null;
        private Vector3Lerper v3Lerper = new Vector3Lerper(1f,AbstractLerper<Vector3>.SMOOTH_TYPE.STEP_SMOOTHER);
        private Vector2Lerper v2Lerper = new Vector2Lerper(1f,AbstractLerper<Vector2>.SMOOTH_TYPE.STEP_SMOOTHER);

        [Header("v2")]
        private int colorIndex = 0;
        [SerializeField] private Color[] colors = null;
        [SerializeField] private ColorLerper colorLerper = new ColorLerper(1f, AbstractLerper<Color>.SMOOTH_TYPE.STEP_SMOOTHER);
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        [Header("v2")]
        private int angleIndex = 0;
        [SerializeField] private float[] angles = null;
        [SerializeField] private FloatLerper floatLerper = new FloatLerper(1f, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);

        void Start()
        {
            v2Lerper.SetValues(transform.position, poss[posIndex], true);
            colorLerper.SetValues(spriteRenderer.color, colors[colorIndex], true);
            floatLerper.SetValues(0, angles[angleIndex], true);
        }

        void Update()
        {
            if (v2Lerper.On)
            {
                v2Lerper.Update();
                transform.position = v2Lerper.CurrentValue;
            }

            if (v2Lerper.Reached)
            {
                int GetIndex()
                {
                    if (posIndex == 0)
                    {
                        posIndex = 1;
                    }
                    else
                    {
                        posIndex = 0;
                    }

                    return posIndex;

                }

                v2Lerper.SetValues(transform.position,poss[GetIndex()],true);
            }

            if (colorLerper.On)
            {
                colorLerper.Update();
                spriteRenderer.color = colorLerper.CurrentValue;
            }

            if (colorLerper.Reached)
            {
                int GetIndex()
                {
                    if (colorIndex == 0)
                    {
                        colorIndex = 1;
                    }
                    else
                    {
                        colorIndex = 0;
                    }

                    return colorIndex;
                }

                colorLerper.SetValues(spriteRenderer.color, colors[GetIndex()], true);
            }

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    transform.Rotate(Vector3.forward, 90f);

            //}

            if (floatLerper.On)
            {
                floatLerper.Update();
                transform.eulerAngles = new Vector3(0f,0f,floatLerper.CurrentValue);
            }

            if (floatLerper.Reached)
            {
                int GetIndex()
                {
                    if (angleIndex == 0)
                    {
                        angleIndex = 1;
                    }
                    else
                    {
                        angleIndex = 0;
                    }

                    return angleIndex;
                }

                floatLerper.SetValues(floatLerper.CurrentValue, angles[GetIndex()], true);
            }
        }
    }
}