using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Pathfinders.Toolbox.Lerpers;

public class Presentation : MonoBehaviour
{
    [SerializeField] private float secondsToStart = 0;
    [SerializeField] private Transitioner transitioner = null;
    [SerializeField] private GameObject imageImage = null;
    [SerializeField] private Image image = null;
    private FloatLerper imageLerper = null;
    void Start()
    {
        StartCoroutine(StartApp()); 

    }

    private IEnumerator StartApp()
    {
        imageLerper = new FloatLerper(2, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);
        imageLerper.SetValues(1, 0, true);
        while (imageLerper.On)
        {
            imageLerper.Update();
            image.color = new Color(0, 0, 0, imageLerper.CurrentValue);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(secondsToStart);
        imageImage.SetActive(true);
        transitioner.ChangeScene("Menu");
        gameObject.SetActive(false);
    }
}
