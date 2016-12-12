using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;


public class SoundClip
{
    public AudioClip audioClip
    {
        get;
        private set;
    }
    public string clipName
    {
        get;
        private set;
    }

    // The name of the clip without integer at end. So we can tell which group of sound clips it belongs to
    public string clipTitle
    {
        get;
        private set;
    }

    //TODO: :c
    public int priority
    {
        get;
        private set;
    }

    // This consists of the unix time that this clip was last played plus the given timeout for the clip
    // Clip should only be played after the above combined unix time has been passed
    public DateTime playAfterTime
    {
        get;
        private set;
    }

    public TimeSpan timeoutDuration
    {
        get;
        private set;
    }

    public SoundClip(AudioClip audioClip, string clipName, TimeSpan timeoutDuration, int priority)
    {
        this.audioClip = audioClip;
        this.clipName = clipName;
        this.timeoutDuration = timeoutDuration;

        clipTitle = Regex.Replace(clipName, "[0-9]", "");
    }

    public void Played()
    {        
        playAfterTime = DateTime.Now.Add(timeoutDuration);
    }

    public bool Ready()
    {
        return playAfterTime < DateTime.Now ? true : false;
    }

}

