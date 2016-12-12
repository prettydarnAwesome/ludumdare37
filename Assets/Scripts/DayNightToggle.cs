using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNightToggle : MonoBehaviour {

    public Light Sun;
    public Light Lamp;
    public Material DayMat;
    public Material NightMat;
    public Color DayColor;
    public Color NightColor;

    private bool Day;

    // Use this for initialization
    void Start () {
        Day = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Toggle()
    {
        Day = !Day;

        Lamp.enabled = Day;

        if (Day == true) {
            RenderSettings.skybox = DayMat;
            Sun.color = DayColor;
        }
        else
        {
            RenderSettings.skybox = NightMat;
            Sun.color = NightColor;
        }
    }
}
