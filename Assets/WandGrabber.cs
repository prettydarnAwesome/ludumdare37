using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandGrabber : MonoBehaviour {

    SteamVR_TrackedController trackedController;

	// Use this for initialization
	void Start () {

        trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null)
        {
            trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
        }

        trackedController.TriggerClicked += TrackedController_TriggerClicked;

    }

    private void TrackedController_TriggerClicked(object sender, ClickedEventArgs e)
    {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update () {
		
	}

    void OnTriggerStay(Collider other)
    {
        if (trackedController.triggerPressed)
        {
            if (transform.childCount != 0)
            {
                other.gameObject.transform.parent = transform;
            }
            else
            {
                transform.DetachChildren();
            }        
        }        
    }

    
}
