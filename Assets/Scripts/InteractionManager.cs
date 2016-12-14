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
        ENTERTABLETOPCOLLISION,
        EXITTABLETOPCOLLISION,
        ENTERWALLCOLLISION,
        EXITWALLCOLLISION,
        GRABBABLECOLLISION,
        SWITCHTOGGLE,
        ENTERSHELFCOLLISION,
        EXITSHELFCOLLISION,
        PICTURECOLLISION,
        TERRAINCOLLISION,
        COMPUTERCOLLISION
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

        // Light Switch
        StateMachineDict.Add("LightSwitchButton", new List<StateMachine>());
        StateMachineDict["LightSwitchButton"].Add(new DayNightStateMachine(this, "LightSwitchButton"));

        // Picture
        StateMachineDict["Picture"].Add(new PictureStateMachine(this, "Picture"));

        // Computer
        StateMachineDict.Add("Computer", new List<StateMachine>());
        StateMachineDict["Computer"].Add(new ComputerStateMachine(this, "Computer"));
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

