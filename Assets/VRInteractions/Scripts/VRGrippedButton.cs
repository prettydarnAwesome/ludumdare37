using UnityEngine;
using System.Collections;

/// <summary>
/// VR gripped button. Requires VR button. This button responds to being "clicked" rather than a physical press.
/// </summary>
public class VRGrippedButton : MonoBehaviour
{

    /// <summary>
    /// Animation that makes the button press down
    /// </summary>
    public Animation ButtonAnim;

    /// <summary>
    /// Button component
    /// </summary>
    VRButton Button;


    void OnEnable()
    {
        Collider collider = GetComponent<Collider>();
        collider.isTrigger = true; // This button should only work as a trigger
    }

    void OnTriggerEnter(Collider _collider)
    {
        Debug.Log("Trigger");
        if (Button.Interactable == true)
            ActivateButton();
    }

    void OnCollisionEnter(Collision _collider)
    {
        Debug.Log("Triggerc");
        if (Button.Interactable == true)
            ActivateButton();
    }

    /// <summary>
    /// Triggers the button if the controllers action key is down
    /// </summary>
    /// <param name="_controllerBody">Controller body.</param>
    public void ActivateButton()
    {
        if (ButtonAnim != null)
            ButtonAnim.Play();
    }

}
