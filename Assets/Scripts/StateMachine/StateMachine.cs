using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


public class StateMachine
{
    protected State StartState;
    protected State CurrentState;

    private int StateCounter;

    public string Name
    {
        get;
        private set;
    }
    protected InteractionManager IManager;

    public StateMachine(InteractionManager iManager, string name)
    {
        IManager = iManager;
        Name = name;
        StateCounter = 0;
    }

    protected void AttachEdge(State fromState, State toState, InteractionManager.Interactions condition)
    {
        Edge newEdge = new Edge(toState, condition);
        fromState.AddEdge(newEdge);
    }

    protected State CreateState(string name, string soundName = null)
    {
        State state = new State(StateCounter, name, soundName);
        StateCounter += 1;
        return state;
    }

    public virtual void Update(GameObject objectObject, GameObject subjectObject, InteractionManager.Interactions interaction)
    {
            Debug.Log("StateMachine Update");

            foreach (Edge edge in CurrentState.Edges)
            {
                if (edge.EdgeCondition == interaction)
                {
                    CurrentState = edge.TargetState;
                    Debug.Log("Changed State To: " + CurrentState.Name);
                    IManager.TriggerSound(); // TODO: Make this do sound pls
                    break;
                }
            }        
    }



}

