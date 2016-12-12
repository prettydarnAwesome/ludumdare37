using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class VoiceLineManager : MonoBehaviour
{
    public AudioManager audioManager;
    Dictionary<string, List<string>> voiceLines;
    Dictionary<string, float> categoryTimeouts;

    // ugly hack i think
    List<string> categoriesToRemoveFromTimeouts;

    // time between lines of same category being played, in seconds
    float timeout = 5.0f;

    void Start()
    {
        voiceLines = new Dictionary<string, List<string>>();
        voiceLines.Add("box_grab", new List<string>()
        {
            "Cube"
        });
        voiceLines.Add("box_drop", new List<string>()
        {
            "Juggle"
        });
        voiceLines.Add("box_floor_collide", new List<string>()
        {
            "Floor"
        });

    }

    void Update()
    {
        categoriesToRemoveFromTimeouts.Clear();
        foreach(var kv in categoryTimeouts)
        {
            // kv.Key = category name
            // kv.Value = time until we can play it again
            categoryTimeouts[kv.Key] = kv.Value - Time.deltaTime;
            if(categoryTimeouts[kv.Key] <= 0f)
            {
                categoriesToRemoveFromTimeouts.Add(kv.Key);
            }
        }

        // we can't remove entries from categoryTimeouts during the previous foreach loop, so we do it here. see line 12
        categoriesToRemoveFromTimeouts.ForEach(x =>
        {
            categoryTimeouts.Remove(x);
        });
    }

    public void RequestVoiceLine(string category)
    {
        // check if we have any voice lines of the requested category
        if (!voiceLines.ContainsKey(category))
        {
            Debug.LogError("unknown voice line category requested: " + category);
            return;
        }

        // check if we played a voice line from this category too recently
        if (!categoryTimeouts.ContainsKey(category))
        {
            // we didn't, so let's get a random voice line and play it
            var linesList = voiceLines[category];
            var line = linesList[Mathf.FloorToInt(Random.value * linesList.Count)];
            audioManager.RequestSound(line);

            categoryTimeouts.Add(category, timeout);
        }
    }
}
