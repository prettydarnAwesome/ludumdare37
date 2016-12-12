using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WandGrabber : MonoBehaviour
{
    private SteamVR_TrackedController trackedController;
    private Queue<Tuple<Vector3, float>> previousPositions;

    public InteractionManager interactionManager;
    public DayNightToggle dayNightToggle;

    // Use this for initialization
    void Start()
    {
        trackedController = GetComponentInParent<SteamVR_TrackedController>();
        previousPositions = new Queue<Tuple<Vector3, float>>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.childCount != 0)
        {
            if (trackedController.triggerPressed)
            {
                if (previousPositions.Count >= 5)
                {
                    previousPositions.Dequeue();
                }
                previousPositions.Enqueue(new Tuple<Vector3, float>(transform.position, Time.deltaTime));
            }
            else
            {
                transform.GetChild(0).GetComponent<Rigidbody>().isKinematic = false;
                List<Vector3> velocities = new List<Vector3>();
                for (var i = 0; i < previousPositions.Count - 1; i++)
                {
                    velocities.Add((previousPositions.ElementAt(i + 1).Item1 - previousPositions.ElementAt(i).Item1) / previousPositions.ElementAt(i + 1).Item2);
                }
                var dx = velocities.Average(v => v.x);
                var dy = velocities.Average(v => v.y);
                var dz = velocities.Average(v => v.z);

                //Debug.Log("Given Velocity:" + dx + "," + dy + "," + dz);

                transform.GetChild(0).GetComponent<Rigidbody>().AddForce(dx, dy, dz, ForceMode.Impulse);

                interactionManager.NotifyInteraction(gameObject, transform.GetChild(0).gameObject, InteractionManager.Interactions.DROP);

                transform.DetachChildren();


            }
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (trackedController.triggerPressed && transform.childCount == 0 && other.gameObject.tag == "Grabbable")
        {
            other.gameObject.transform.parent = transform;
            other.GetComponent<Rigidbody>().isKinematic = true;

            interactionManager.NotifyInteraction(gameObject, other.gameObject, InteractionManager.Interactions.GRAB);
        }    

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Button" && other.gameObject.name == "LightSwitchButton")
        {
            other.gameObject.GetComponent<Animation>().Play();
            dayNightToggle.Toggle();
            interactionManager.NotifyInteraction(gameObject, other.gameObject, InteractionManager.Interactions.SWITCHTOGGLE);
        }
    }



}
