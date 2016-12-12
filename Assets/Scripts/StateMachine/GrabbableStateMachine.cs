using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GrabbableStateMachine : StateMachine
{
    public GrabbableStateMachine(string name) : base(name)
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
   

}

