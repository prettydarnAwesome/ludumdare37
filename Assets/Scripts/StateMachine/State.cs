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

    public string VoiceString
    {
        get;
        private set;
    }

    public List<Edge> Edges
    {
        get;
        private set;
    }



    public State(int ID, string Name, string voiceString = null)
    {
        this.ID = ID;
        this.Name = Name;
        this.VoiceString = voiceString;

        Edges = new List<Edge>();
    }


    public void AddEdge(Edge edge)
    {
        Edges.Add(edge);
    }

}

