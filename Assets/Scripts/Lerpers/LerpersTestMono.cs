using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Pathfinders.Toolbox.Lerpers
{
    public class LerpersTestMono : MonoBehaviour
    {
        [Header("v2")]
        private int posIndex = 0;
        [SerializeField] private Vector2[] poss = null;
        [SerializeField] private Vector3LerperMono v2LerperMono = null;

        [Header("v2")]
        private int colorIndex = 0;
        [SerializeField] private Color[] colors = null;
        [SerializeField] private ColorLerperMono colorLerperMono = null;
        [SerializeField] private SpriteRenderer spriteRenderer = null;

        [Header("v2")]
        private int angleIndex = 0;
        [SerializeField] private float[] angles = null;
        [SerializeField] private FloatLerperMono floatLerperMono = null;

        void Start()
        {
            v2LerperMono.SetValues(transform.position, poss[posIndex], true);
            colorLerperMono.SetValues(spriteRenderer.color, colors[colorIndex], true);
            floatLerperMono.SetValues(0, angles[angleIndex], true);
        }

        void Update()
        {
            if (v2LerperMono.On)
            {
                transform.position = v2LerperMono.CurrentValue;
            }

            if (v2LerperMono.Reached)
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

                v2LerperMono.SetValues(transform.position,poss[GetIndex()],true);
            }

            if (colorLerperMono.On)
            {
                spriteRenderer.color = colorLerperMono.CurrentValue;
            }

            if (colorLerperMono.Reached)
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

                colorLerperMono.SetValues(spriteRenderer.color, colors[GetIndex()], true);
            }

            //if (Input.GetKeyDown(KeyCode.A))
            //{
            //    transform.Rotate(Vector3.forward, 90f);

            //}

            if (floatLerperMono.On)
            {
                transform.eulerAngles = new Vector3(0f,0f,floatLerperMono.CurrentValue);
            }

            if (floatLerperMono.Reached)
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

                floatLerperMono.SetValues(floatLerperMono.CurrentValue, angles[GetIndex()], true);
            }
        }
    }
}