using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class State
{
    public int ID
    {
        get;
        private set;
    }

    public string Name
    {
        get;
        private set;
    }

    public VoiceLineManager.VoiceLinePurpose Purpose
    {
        get;
        private set;
    }

    public List<Edge> Edges
    {
        get;
        private set;
    }



    public State(int ID, string Name, VoiceLineManager.VoiceLinePurpose purpose)
    {
        this.ID = ID;
        this.Name = Name;
        this.Purpose = purpose;

        Edges = new List<Edge>();
    }


    public void AddEdge(Edge edge)
    {
        Edges.Add(edge);
    }

}

