using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class DayNightStateMachine : StateMachine
{
    public DayNightStateMachine(InteractionManager iManager, string name) : base(iManager, name)
    {
        State dayState = CreateState("Day", VoiceLineManager.VoiceLinePurpose.DAY);
        State nightState = CreateState("Night", VoiceLineManager.VoiceLinePurpose.NIGHT);

        AttachEdge(dayState, nightState, InteractionManager.Interactions.SWITCHTOGGLE);
        AttachEdge(nightState, dayState, InteractionManager.Interactions.SWITCHTOGGLE);

        StartState = dayState;
        CurrentState = StartState;
    }
}


