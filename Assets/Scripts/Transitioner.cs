using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pathfinders.Toolbox.Singletons;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Pathfinders.Toolbox.Lerpers;

public class Transitioner : GenericSingleton<Transitioner>
{
    #region EXPOSED_FIELDS
    [SerializeField] private Canvas canvas = null;
    [SerializeField] private Image image = null;
    [SerializeField] private Volume volume = null;
    [SerializeField] private float lerperSpeed = 0;
    [SerializeField] private float grainToLerp = 0;
    [SerializeField] private float vignetteToLerp = 0;
    #endregion
    #region PRIVATE_FIELDS
    private FilmGrain grain = null;
    private Vignette vignette = null;
    private FloatLerper grainLerper = null;
    private FloatLerper vignetteLerper = null;
    private ColorLerper colorLerper = null;
    #endregion
    #region UNITY_CALLS
    private void Start()
    {
        volume.profile.TryGet(out grain);
        volume.profile.TryGet(out vignette);
        SceneManager.activeSceneChanged += GetCamera;
        grainLerper = new FloatLerper(lerperSpeed, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);
        vignetteLerper = new FloatLerper(lerperSpeed, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);
        colorLerper = new ColorLerper(lerperSpeed, AbstractLerper<Color>.SMOOTH_TYPE.STEP_SMOOTHER);
    }
    #endregion
    #region PUBLIC_METHODS
    public void ChangeScene(string name)
    {
        StartCoroutine(LerpScene(name));
    }
    #endregion
    #region PRIVATE_METHODS
    private void GetCamera(Scene scene1, Scene scene2)
    {
        canvas.worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }
    private void LerpLerpers()
    {
        grainLerper.Update();
        vignetteLerper.Update();
        colorLerper.Update();
        image.color = colorLerper.CurrentValue;
        vignette.intensity.value = vignetteLerper.CurrentValue;
        grain.intensity.value = grainLerper.CurrentValue;
    }
    #endregion
    #region PRIVATE_CORROUTINES
    private IEnumerator LerpScene(string name)
    {
        var scene = SceneManager.LoadSceneAsync(name);
        scene.allowSceneActivation = false;
        grainLerper.SetValues(grain.intensity.value, grainToLerp, true);
        vignetteLerper.SetValues(vignette.intensity.value, vignetteToLerp, true);
        colorLerper.SetValues(image.color, new Color(0.5f, 0.5f, 0.5f, 1), true);
        while (grainLerper.On)
        {
            LerpLerpers();
            yield return new WaitForEndOfFrame();
        }
        scene.allowSceneActivation = true;
        grainLerper.SetValues(grain.intensity.value, 0, true);
        vignetteLerper.SetValues(vignette.intensity.value, 0, true);
        colorLerper.SetValues(image.color, new Color(0.5f, 0.5f, 0.5f, 0),true);
        while (grainLerper.On)
        {
            LerpLerpers();
            yield return new WaitForEndOfFrame();
        }
    } 
    #endregion
}
