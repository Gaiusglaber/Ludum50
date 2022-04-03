using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinders.Toolbox.Lerpers;

public class SoundController : MonoBehaviour
{
    [SerializeField] private AudioSource musicSource = null;
    [SerializeField] private AudioSource soundSource = null;
    [SerializeField] private float fadeTime = 0;
    [SerializeField] private SoundSO[] sounds = null;
    [SerializeField] private MusicSO[] musics = null;

    private SoundPlayer[] soundPlayers = null;
    private MusicPlayer[] musicPlayers = null;
    private void Start()
    {
        soundPlayers = FindObjectsOfType<SoundPlayer>();
        musicPlayers = FindObjectsOfType<MusicPlayer>();
        InitMusicPlayers();
        InitSoundPlayers();
    }
    private void PlayMusic(string id)
    {
        StartCoroutine(LerpMusic(id));
    }
    private void PlaySound(string id)
    {
        foreach (var sound in sounds)
        {
            if (sound.id == id)
            {
                soundSource.PlayOneShot(sound.sound);
            }
        }
    }
    private void InitSoundPlayers()
    {
        for (int i = 0; i < soundPlayers.Length; i++)
        {
            soundPlayers[i].OnPlaySound = PlaySound;
        }
    }
    private void InitMusicPlayers()
    {
        for (int i = 0; i < musicPlayers.Length; i++)
        {
            musicPlayers[i].OnPlayMusic = PlayMusic;
        }
    }
    private IEnumerator LerpMusic(string id)
    {
        FloatLerper lerper = new FloatLerper(fadeTime, AbstractLerper<float>.SMOOTH_TYPE.STEP_SMOOTHER);
        lerper.SetValues(musicSource.volume, 0, true);
        while (lerper.On)
        {
            lerper.Update();
            musicSource.volume = lerper.CurrentValue;
            yield return new WaitForEndOfFrame();
        }
        foreach (var music in musics)
        {
            if (music.id == id)
            {
                musicSource.clip = music.music;
                soundSource.Play();
            }
        }
        lerper.SetValues(musicSource.volume, 0.1f, true);
        while (lerper.On)
        {
            lerper.Update();
            musicSource.volume = lerper.CurrentValue;
            yield return new WaitForEndOfFrame();
        }
    }
}
