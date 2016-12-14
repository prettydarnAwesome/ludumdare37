using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestClickScript : MonoBehaviour {

    public AudioManager audioManager;

	// Use this for initialization
	void Start () {
        var trackedController = GetComponent<SteamVR_TrackedController>();
        if (trackedController == null)
        {
            trackedController = gameObject.AddComponent<SteamVR_TrackedController>();
        }

        trackedController.TriggerClicked += TrackedController_TriggerClicked;
        trackedController.PadClicked += TrackedController_PadClicked;
        trackedController.PadUnclicked += TrackedController_PadUnclicked;

        foreach (Transform child in transform)
        {
            if (child.name == "New Game Object")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void TrackedController_PadUnclicked(object sender, ClickedEventArgs e)
    {
        foreach (Transform child in transform)
        {
            if(child.name == "New Game Object")
            {
                child.gameObject.SetActive(false);
            }
        }
    }

    private void TrackedController_PadClicked(object sender, ClickedEventArgs e)
    {
        foreach (Transform child in transform)
        {
            if (child.name == "New Game Object")
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    private void TrackedController_TriggerClicked(object sender, ClickedEventArgs e)
    {
        
    }

    // Update is called once per frame
    void Update () {
		
	}
}
