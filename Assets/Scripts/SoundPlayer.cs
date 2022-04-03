using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundPlayer : MonoBehaviour
{
    [SerializeField] private AudioClip sound = null;
    public UnityEvent<string> OnPlaySound = null;
}
