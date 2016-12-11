using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InteractionManager : MonoBehaviour
{

    public AudioManager audioManager;

    GrabbableStateMachine boxGrabSM;

    public enum Interactions
    {
        GRAB,
        DROP,
        FLOORCOLLISION
    }

    // Use this for initialization
    void Start()
    {
        boxGrabSM = new GrabbableStateMachine("Cube");

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NotifyInteraction(GameObject objectObject, GameObject subjectObject, Interactions interaction)
    {

        string playString = boxGrabSM.Update(objectObject, subjectObject, interaction);
        if (playString != null)
        {
            audioManager.PlaySoundImmediately(playString);
        }


    }
}

