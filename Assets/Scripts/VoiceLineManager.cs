using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class VoiceLineManager : MonoBehaviour
{
    public AudioManager audioManager;

    private System.Random random = new System.Random();

    public enum VoiceLinePurpose
    {
        NULL,
        GRAB,
        FLOOR,
        WALL,
        JUGGLE,
        TABLE
    }

    // TODO: Make a custom clip class, this would contain information such as the last time it was played, its priority and whatever else we want to put in there
    private List<SoundClip> Clips;

    void Start()
    {
        Clips = new List<SoundClip>();
        var cliparray = Resources.LoadAll<AudioClip>("").ToList();
        cliparray.ForEach(x =>
        {
            Clips.Add(new SoundClip(x, x.name, new TimeSpan(0, 0, 5)));
        });
    }

    void Update()
    {

    }

    public void RequestVoiceLine(string clipTitle)
    {
        List<SoundClip> requestedClips = GetClips(clipTitle);

        // check if we have any voice lines of the requested category
        if (requestedClips.Count == 0)
        {
            Debug.LogWarning("no voice lines found with the given title: " + clipTitle);
            return;
        }
        else
        {
            SoundClip chosenClip = requestedClips[random.Next(requestedClips.Count)];
            audioManager.RequestSound(chosenClip);
        }
    }

    private List<SoundClip> GetClips(string clipTitle)
    {
        List<SoundClip> returnClips = new List<SoundClip>();
        foreach (SoundClip clip in Clips)
        {
            if(clip.clipTitle == clipTitle && clip.Ready()) // Math the given name with the clip titles
            {
                returnClips.Add(clip);
            }
        }

        return returnClips;
    }
}
