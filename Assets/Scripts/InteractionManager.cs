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
        foreach (StateMachine SM in StateMachineDict[objectObject.name])
        {
            SM.Update(objectObject, subjectObject, interaction);
            voiceLineManager.RequestVoiceLine(playString);
        }
        foreach (StateMachine SM in StateMachineDict[subjectObject.name])
        {
            SM.Update(objectObject, subjectObject, interaction);
        }
    }

    public void TriggerSound()
    {
        //TODO: Send to intermediary manager
    }
}

