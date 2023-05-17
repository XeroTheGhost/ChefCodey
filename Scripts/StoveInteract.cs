using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoveInteract : MonoBehaviour
{

    public string triggerName = "";

    public GameObject stove;



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //if space is pressed
        {
            if (triggerName == "stove 1") //if in stove collider(trigger)
            {
                print("I'm at the stove!");
            }
        }
    }

    private void OnTriggerEnter(Collider other) //if codey is in something else's collider, put the collided name as the string
    {
        triggerName = other.name;
    }

    private void OnTriggerExit(Collider other) //if codey is not touching any colliders, string is empty
    {
        triggerName = "";
    }
}
