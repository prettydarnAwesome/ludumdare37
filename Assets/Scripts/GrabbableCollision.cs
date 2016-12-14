using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableCollision : MonoBehaviour
{

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
        if(collision.collider.tag == "Grabbable")
            interactionManager.NotifyInteraction(gameObject, collision.collider.gameObject, InteractionManager.Interactions.GRABBABLECOLLISION);
    }

}
