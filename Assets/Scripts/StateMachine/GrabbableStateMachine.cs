using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public class GrabbableStateMachine : StateMachine
{
    public GrabbableStateMachine(string name) : base(name)
    {
        State floorState = CreateState("Floor", "TestSound2");
        State handState = CreateState("Hand", "TestSound1");
        State fallingState = CreateState("Falling");
        State juggleState = CreateState("Juggle");

        AttachEdge(floorState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(handState, fallingState, InteractionManager.Interactions.DROP);
        AttachEdge(fallingState, handState, InteractionManager.Interactions.GRAB);
        AttachEdge(fallingState, floorState, InteractionManager.Interactions.FLOORCOLLISION);

        StartState = floorState;
        CurrentState = StartState; 
    }

}

