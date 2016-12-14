using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GrabbableStateMachine : StateMachine
{
    public GrabbableStateMachine(InteractionManager iManager, string name) : base(iManager, name)
    {
        State floorState = CreateState("Floor", VoiceLineManager.VoiceLinePurpose.FLOOR);
        State handState = CreateState("Hand", VoiceLineManager.VoiceLinePurpose.GRAB);
        State fallingState = CreateState("Falling");
        State juggleState = CreateState("Juggle", VoiceLineManager.VoiceLinePurpose.JUGGLE);
        State wallState = CreateState("Wall", VoiceLineManager.VoiceLinePurpose.WALL);
        State tableState = CreateState("Table", VoiceLineManager.VoiceLinePurpose.TABLE);
        State shelfState = CreateState("Shelf", VoiceLineManager.VoiceLinePurpose.SHELF);
        State terrainState = CreateState("Terrain", VoiceLineManager.VoiceLinePurpose.OUTSIDE);

        AttachEdge(floorState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(handState, fallingState, InteractionManager.Interactions.DROP);
        AttachEdge(fallingState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(fallingState, floorState, InteractionManager.Interactions.FLOORCOLLISION);

        AttachEdge(wallState, floorState, InteractionManager.Interactions.FLOORCOLLISION);
        AttachEdge(fallingState, wallState, InteractionManager.Interactions.ENTERWALLCOLLISION);
        AttachEdge(wallState, fallingState, InteractionManager.Interactions.EXITWALLCOLLISION);

        AttachEdge(fallingState, tableState, InteractionManager.Interactions.ENTERTABLETOPCOLLISION);
        AttachEdge(tableState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(tableState, fallingState, InteractionManager.Interactions.EXITTABLETOPCOLLISION);

        AttachEdge(fallingState, shelfState, InteractionManager.Interactions.ENTERSHELFCOLLISION);
        AttachEdge(shelfState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(shelfState, fallingState, InteractionManager.Interactions.EXITSHELFCOLLISION);

        AttachEdge(fallingState, terrainState, InteractionManager.Interactions.TERRAINCOLLISION);
        AttachEdge(terrainState, handState, InteractionManager.Interactions.GRAB);

        StartState = floorState;
        CurrentState = StartState; 
    }

    public override void Update(GameObject objectObject, GameObject subjectObject, InteractionManager.Interactions interaction)
    {
        if (interaction == InteractionManager.Interactions.GRABBABLECOLLISION)
        {
            //TODO: Should be sending to intermediary the name of both objects being interacted which should then trigger the relevant voice line
            //IManager.TriggerSound();//Trigger GrabbableCollision Sound
        }
        else if(Name == "Radio" && interaction == InteractionManager.Interactions.TERRAINCOLLISION)
        {
            subjectObject.GetComponent<AudioSource>().Stop();
        }
        else
        {
            base.Update(objectObject, subjectObject, interaction);
        }
    }

}

        

