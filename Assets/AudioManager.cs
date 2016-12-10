using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    Dictionary<string, AudioClip> Clips;
    Queue<string> SoundQueue;
    AudioSource Source;

	// Use this for initialization
	void Start () {
        SoundQueue = new Queue<string>();
        Clips = new Dictionary<string, AudioClip>();
        var cliparray = Resources.LoadAll<AudioClip>("").ToList();
        cliparray.ForEach(x =>
        {
            Clips.Add(x.name, x);
            Debug.Log("adding " + x.name + " to list of audio clips");
        });

        Source = GetComponent<AudioSource>();

        //test: play a random sound
        /*var source = GetComponent<AudioSource>();
        source.clip = Clips.ElementAt(Mathf.FloorToInt(Random.value * Clips.Count)).Value;
        source.volume = 0.1f;
        source.Play();*/
    }
	
	// Update is called once per frame
	void Update () {
		if(!Source.isPlaying)
        {
            // we can play another sound from the queue if one is available
            if(SoundQueue.Count > 0)
            {
                var clipname = SoundQueue.Dequeue();
                Source.clip = Clips[name];
                Source.Play();
            }
        }
	}

    public void RequestSound(string name)
    {
        if(Clips.ContainsKey(name))
        {
            SoundQueue.Enqueue(name);
        } else
        {
            Debug.LogWarning("Couldn't find a sound clip with name " + name + " !!!");
        }
    }

    public void PlaySoundImmediately(string name)
    {
        if (Clips.ContainsKey(name))
        {
            Source.clip = Clips[name];
            Source.Play();
        }
        else
        {
            Debug.LogWarning("Couldn't find a sound clip with name " + name + " !!!");
        }
    }

    public void RequestSoundNext(string name)
    {
        if (Clips.ContainsKey(name))
        {
            var tempqueue = new Queue<string>();
            tempqueue.Enqueue(name);
            while(SoundQueue.Count > 0)
            {
                tempqueue.Enqueue(SoundQueue.Dequeue());
            }
            SoundQueue = tempqueue;
        }
        else
        {
            Debug.LogWarning("Couldn't find a sound clip with name " + name + " !!!");
        }
    }
}
