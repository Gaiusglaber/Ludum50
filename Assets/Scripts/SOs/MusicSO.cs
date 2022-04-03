using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Music",menuName ="Sound/Music")]
public class MusicSO : ScriptableObject
{
    public string id = string.Empty;
    public AudioClip music = null;
}
