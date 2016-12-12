﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTopCollision : MonoBehaviour {

    public InteractionManager interactionManager;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnCollisionEnter(Collision collision)
    {
        interactionManager.NotifyInteraction(transform.parent.gameObject, collision.collider.gameObject, InteractionManager.Interactions.ENTERTABLETOPCOLLISION);
    }
    public void OnCollisionExit(Collision collision)
    {
        interactionManager.NotifyInteraction(transform.parent.gameObject, collision.collider.gameObject, InteractionManager.Interactions.EXITTABLETOPCOLLISION);
    }
}