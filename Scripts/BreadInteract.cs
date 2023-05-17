using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadInteract : MonoBehaviour
{
    public string triggerName = "";

    public GameObject breadPrefab;

    public GameObject heldItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //if space is pressed
        {
            if(triggerName == "Bread") //if in bread collider(trigger)
            {
                heldItem = Instantiate(breadPrefab, transform, false); //(create copy of object, game object we want as new object's parent 9in this case, codey's transform/position, does not tell unity how to position in relation to the world
                heldItem.transform.localPosition = new Vector3(1, 1, 0); //position bread at codey, not original's position from codey (YALL ITS PLACED IN XYZ MODE WE FINALLY KNOW-) (and it wont let me do decimals for some reason-)
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
