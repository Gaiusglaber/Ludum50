using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Sound", menuName = "Sound/Sound")]
public class SoundSO : ScriptableObject
{
    public string id = string.Empty;
    public AudioClip sound = null;
}
