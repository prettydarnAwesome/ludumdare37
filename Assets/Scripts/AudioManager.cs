using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Dictionary<string, AudioClip> Clips;
    public Queue<SoundClip> SoundQueue;
    public AudioSource Source;

    // Use this for initialization
    void Start()
    {
        SoundQueue = new Queue<SoundClip>();

        Source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Source.isPlaying && SoundQueue.Count > 0) // If we arent playing something and there is something to play
        {
            SoundClip soundClip = SoundQueue.Dequeue();
            Debug.Log("Playing: " + soundClip.clipName);
            Source.clip = soundClip.audioClip;
            soundClip.Played();
            Source.Play();
        }
    }

    public void RequestSound(SoundClip clipToPlay)
    {
        SoundQueue.Enqueue(clipToPlay);
    }

    public void PlaySoundImmediately(SoundClip soundClip)
    {
        Debug.Log("Playing: " + soundClip.clipName);
        Source.clip = soundClip.audioClip;
        Source.Play();
    }

    public void RequestSoundNext(SoundClip soundClip)
    {
        var tempqueue = new Queue<SoundClip>();
        tempqueue.Enqueue(soundClip);
        while (SoundQueue.Count > 0)
        {
            tempqueue.Enqueue(SoundQueue.Dequeue());
        }
        SoundQueue = tempqueue;
    }
}
