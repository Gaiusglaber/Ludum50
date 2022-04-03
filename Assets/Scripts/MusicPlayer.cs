using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MusicPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip music = null;
    public Action<string> OnPlayMusic = null;
}
