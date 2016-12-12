using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class VoiceLineManager : MonoBehaviour
{
    public AudioManager audioManager;

    public enum VoiceLinePurpose
    {
        NULL,
        GRAB,
        FLOOR,
        WALL,
        JUGGLE
    }

    // TODO: Make a custom clip class, this would contain information such as the last time it was played, its priority and whatever else we want to put in there
    private List<string> Clips;

    void Start()
    {
        Clips = new List<string>();
        var cliparray = Resources.LoadAll<AudioClip>("").ToList();
        cliparray.ForEach(x =>
        {
            Clips.Add(x.name);
        });
    }

    void Update()
    {

    }

    public void RequestVoiceLine(string clipName)
    {
        // check if we have any voice lines of the requested category
        if (!Clips.Contains(clipName))
        {
            Debug.LogError("unknown voice line category requested: " + clipName);
            return;
        }
        else
        {
            // with the custom class we need to find all clips with the name of the clipName and then decide which one to play
            // make sure to check the last played + timeout for unix stuff
            audioManager.RequestSound(clipName);
        }
    }
}
