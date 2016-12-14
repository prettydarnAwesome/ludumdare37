using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class ComputerStateMachine : StateMachine
{
    public ComputerStateMachine(InteractionManager iManager, string name) : base(iManager, name)
    {
        State beep = CreateState("Beep", VoiceLineManager.VoiceLinePurpose.BEEP);    

        AttachEdge(beep, beep, InteractionManager.Interactions.COMPUTERCOLLISION);

        StartState = beep;
        CurrentState = StartState;
    }
}

