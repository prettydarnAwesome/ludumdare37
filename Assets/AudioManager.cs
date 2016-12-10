using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    Dictionary<string, AudioClip> Clips;
	// Use this for initialization
	void Start () {
        Clips = new Dictionary<string, AudioClip>();
        var cliparray = Resources.LoadAll<AudioClip>("").ToList();
        cliparray.ForEach(x =>
        {
            Clips.Add(x.name, x);
            Debug.Log("adding " + x.name + " to list of audio clips");
        });

        //test: play a random sound
        var source = GetComponent<AudioSource>();
        source.clip = Clips.ElementAt(Mathf.FloorToInt(Random.value * Clips.Count)).Value;
        source.volume = 0.1f;
        source.Play();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
