using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundAudioPlay : MonoBehaviour
{
    [SerializeField] private AudioSource background;
    // Start is called before the first frame update
    private void Awake()
    {
        background.Play();
    }
}
