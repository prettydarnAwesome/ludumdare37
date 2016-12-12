using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallCollision : MonoBehaviour {

    public InteractionManager interactionManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {
        interactionManager.NotifyInteraction(gameObject, collision.collider.gameObject, InteractionManager.Interactions.ENTERWALLCOLLISION);
    }

    public void OnCollisionExit(Collision collision)
    {
        interactionManager.NotifyInteraction(gameObject, collision.collider.gameObject, InteractionManager.Interactions.EXITWALLCOLLISION);
    }
}
