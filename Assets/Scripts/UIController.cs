using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using Pathfinders.Toolbox.Lerpers;
public class UIController : MonoBehaviour
{
    #region EXPOSED_FIELDS
    [SerializeField] private PlayerController player = null;
    [SerializeField] private Image fillImage = null;
    [SerializeField] private float increaseSanitySpeed = 0;
    [SerializeField] private Volume volume = null;
    [SerializeField] private float vignetteIntensity = 0;
    [SerializeField] private float grainIntensity = 0;
    #endregion
    #region PRIVATE_FIELDS
    private bool OnCollidingEnemy = false;
    private ColorLerper colorLerper = null;
    private FloatLerper grainLerper = null;
    private FloatLerper vignetteLerper = null;
    private FilmGrain grain = null;
    private Vignette vignette = null;
    #endregion
    #region UNITY_CALLS
    private void Start()
    {
        player.OnCollidingEnemy += IncreaseSanity;
        volume.profile.TryGet(out grain);
        volume.profile.TryGet(out vignette);
        colorLerper = new ColorLerper(increaseSanitySpeed, AbstractLerper<Color>.SMOOTH_TYPE.STEP_SMOOTHER);
        grainLerper = new FloatLerper(increaseSanitySpeed, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);
        vignetteLerper = new FloatLerper(increaseSanitySpeed, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);
        colorLerper.SetValues(fillImage.color, Color.red, true);
        grainLerper.SetValues(grain.intensity.value, grainIntensity,true);
        vignetteLerper.SetValues(vignette.intensity.value, vignetteIntensity, true);
    }
    private void Update()
    {
        if (OnCollidingEnemy)
        {
            colorLerper.Update();
            grainLerper.Update();
            vignetteLerper.Update();
            fillImage.color = colorLerper.CurrentValue;
            vignette.intensity.value = vignetteLerper.CurrentValue;
            grain.intensity.value = grainLerper.CurrentValue;
        }
    }
    #endregion
    #region PRIVATE_METHODS
    private void IncreaseSanity(bool sanity)
    {
        OnCollidingEnemy = sanity;
    }
    #endregion
}
