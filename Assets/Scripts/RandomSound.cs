using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSound : MonoBehaviour
{
    [SerializeField] AudioClip[] _clips;

    // Update is called once per frame
    void Update()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            var clip = _clips[UnityEngine.Random.Range(0, _clips.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        }
    }
}
