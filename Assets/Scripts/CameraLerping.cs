using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinders.Toolbox.Lerpers;
using UnityEngine.Rendering.Universal;

public class CameraLerping : MonoBehaviour
{
    [SerializeField] private UniversalAdditionalCameraData cameraRenderer = null;
    [SerializeField] private Vector3[] positionsToLerp = null;
    [SerializeField] private Vector3[] positionsToTP = null;
    [SerializeField] private Vector3[] rotationsToTP = null;
    [SerializeField] private float Cameraspeed = 0;
    [SerializeField] private GameObject[] objToRotate = null;
    [SerializeField] private Vector3[] rotToLerp = null;
    private Vector3Lerper posLerper = null;
    void Start()
    {
        posLerper = new Vector3Lerper(Cameraspeed, AbstractLerper<Vector3>.SMOOTH_TYPE.STEP_SMOOTHER);
        ChangeRenderer();
    }

    private IEnumerator LerpCamera()
    {
        for (int i = 0; i < positionsToLerp.Length; i++)
        {
            posLerper.SetValues(transform.position, positionsToLerp[i], true);
            while (posLerper.On)
            {
                posLerper.Update();
                transform.position = posLerper.CurrentValue;
                yield return new WaitForEndOfFrame();
            }
            if (i < positionsToTP.Length)
            {
                transform.position = positionsToTP[i];
                transform.eulerAngles = rotationsToTP[i];
            }
        }
        yield return new WaitForSeconds(2);
        for (int i = 0; i < objToRotate.Length; i++)
        {
            StartCoroutine(LerpObjectsRotations(objToRotate[i],i));
        }
    }
    private IEnumerator LerpObjectsRotations(GameObject obj, int index)
    {
        Vector3Lerper rotLerper = new Vector3Lerper(Cameraspeed, AbstractLerper<Vector3>.SMOOTH_TYPE.STEP_SMOOTHER);
        rotLerper.SetValues(obj.transform.eulerAngles, rotToLerp[index], true);
        while (rotLerper.On)
        {
            rotLerper.Update();
            obj.transform.eulerAngles = rotLerper.CurrentValue;
            yield return new WaitForEndOfFrame();
        }
    }
    public void ChangeRenderer()
    {
        cameraRenderer.SetRenderer(1);
    }
}
