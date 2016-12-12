using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCollision : MonoBehaviour {

    public InteractionManager interactionManager;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnCollisionEnter(Collision collision)
    {        
        interactionManager.NotifyInteraction(gameObject, collision.collider.gameObject, InteractionManager.Interactions.FLOORCOLLISION);
    }
}
