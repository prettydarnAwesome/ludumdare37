using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoCollision : MonoBehaviour {

    private System.Random random = new System.Random();

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
        PlayNote();
    }

    public void PlayNote()
    {
        gameObject.GetComponent<AudioSource>().Stop();
        float pitch = (((float)random.Next(0,100)) / 100) + 0.5f;
        gameObject.GetComponent<AudioSource>().pitch = pitch;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
