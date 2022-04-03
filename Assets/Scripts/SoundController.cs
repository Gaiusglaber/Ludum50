using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private SoundPlayer[] players = null;
    private void Start()
    {
        players = FindObjectsOfType<SoundPlayer>();
    }
}
