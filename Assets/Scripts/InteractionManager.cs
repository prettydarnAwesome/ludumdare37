using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionManager : MonoBehaviour
{

    public VoiceLineManager voiceLineManager;
    private Dictionary<string,List<StateMachine>> StateMachineDict;


    public enum Interactions
    {
        GRAB,
        DROP,        
        FLOORCOLLISION,
        ENTERWALLCOLLISION,
        EXITWALLCOLLISION,
        GRABBABLECOLLISION
    }

    // Use this for initialization
    void Start()
    {
        StateMachineDict = new Dictionary<string, List<StateMachine>>();

        foreach (GameObject grabbable in GameObject.FindGameObjectsWithTag("Grabbable"))
        {
            StateMachineDict.Add(grabbable.name, new List<StateMachine>());
            StateMachineDict[grabbable.name].Add(new GrabbableStateMachine(this, grabbable.name));            
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NotifyInteraction(GameObject objectObject, GameObject subjectObject, Interactions interaction)
    {
        if (StateMachineDict.ContainsKey(objectObject.name))
        {
            foreach (StateMachine SM in StateMachineDict[objectObject.name])
            {
                SM.Update(objectObject, subjectObject, interaction);
                //voiceLineManager.RequestVoiceLine(playString);
            }
        }
        if (StateMachineDict.ContainsKey(subjectObject.name))
        {
            foreach (StateMachine SM in StateMachineDict[subjectObject.name])
            {
                SM.Update(objectObject, subjectObject, interaction);
            }
        }
    }

    public void TriggerSound(GameObject obj, VoiceLineManager.VoiceLinePurpose purpose)
    {
        // Do processing of game obj here
        string name = obj.name.ToLower();
        string purp = purpose.ToString().ToLower();
        voiceLineManager.RequestVoiceLine(name + '_' + purp);
    }
}

