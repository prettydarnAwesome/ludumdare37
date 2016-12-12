﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GrabbableStateMachine : StateMachine
{
    public GrabbableStateMachine(InteractionManager iManager, string name) : base(iManager, name)
    {
        State floorState = CreateState("Floor", "Floor");
        State handState = CreateState("Hand", "Grab");
        State fallingState = CreateState("Falling");
        State juggleState = CreateState("Juggle", "Juggle");
        State wallState = CreateState("Wall", "Wall");

        AttachEdge(floorState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(handState, fallingState, InteractionManager.Interactions.DROP);
        AttachEdge(fallingState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(fallingState, floorState, InteractionManager.Interactions.FLOORCOLLISION);

        AttachEdge(wallState, floorState, InteractionManager.Interactions.FLOORCOLLISION);
        AttachEdge(fallingState, wallState, InteractionManager.Interactions.ENTERWALLCOLLISION);
        AttachEdge(wallState, fallingState, InteractionManager.Interactions.EXITWALLCOLLISION);

        StartState = floorState;
        CurrentState = StartState; 
    }

    public override void Update(GameObject objectObject, GameObject subjectObject, InteractionManager.Interactions interaction)
    {
        if (interaction == InteractionManager.Interactions.GRABBABLECOLLISION)
        {
            //TODO: Should be sending to intermediary the name of both objects being interacted which should then trigger the relevant voice line
            IManager.TriggerSound();//Trigger GrabbableCollision Sound
        }
        else
        {
            base.Update(objectObject, subjectObject, interaction);
        }
    }

}

        

