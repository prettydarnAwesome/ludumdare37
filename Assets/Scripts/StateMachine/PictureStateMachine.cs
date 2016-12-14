using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class PictureStateMachine : StateMachine
{
    public PictureStateMachine(InteractionManager iManager, string name) : base(iManager, name)
    {
        State onWall = CreateState("onWall", VoiceLineManager.VoiceLinePurpose.NULL);
        State offWall = CreateState("offWall", VoiceLineManager.VoiceLinePurpose.FALL);

        AttachEdge(onWall, offWall, InteractionManager.Interactions.PICTURECOLLISION);

        StartState = onWall;
        CurrentState = StartState;
    }

    public override void Update(GameObject objectObject, GameObject subjectObject, InteractionManager.Interactions interaction)
    {
        if(CurrentState == StartState && interaction == InteractionManager.Interactions.PICTURECOLLISION)
        {
            subjectObject.GetComponent<Rigidbody>().isKinematic = false;
        }

        base.Update(objectObject, subjectObject, interaction);        
    }




}

