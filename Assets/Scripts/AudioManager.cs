using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    private SoundClip nextClip;
    public AudioSource Source;

    // Use this for initialization
    void Start()
    {
        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Source.isPlaying && nextClip != null) // If we arent playing something and there is something to play
        {
            Debug.Log("Playing: " + nextClip.clipName);
            Source.clip = nextClip.audioClip;
            nextClip.Played();
            nextClip = null;
            Source.Play();
        }
    }

    public void RequestSound(SoundClip clipToPlay)
    {
        if (nextClip == null)
        {
            nextClip = clipToPlay;
        } else if (clipToPlay.priority > nextClip.priority)
        {
            PlaySoundImmediately(clipToPlay);
        }
    }

    public void PlaySoundImmediately(SoundClip soundClip)
    {
        nextClip = null;
        Source.Stop();
        Debug.Log("Playing: " + soundClip.clipName);
        Source.clip = soundClip.audioClip;
        soundClip.Played();
        Source.Play();
    }
}
