using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Edge
{

    public InteractionManager.Interactions EdgeCondition
    {
        get;
        private set;
    }

    public State TargetState
    {
        get;
        private set;
    }

    public Edge(State targetState, InteractionManager.Interactions condition)
    {
        TargetState = targetState;
        EdgeCondition = condition;
    }

}

