using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    [Header("Prefabs")]
    public Stove stove;
    public GameObject toast;
    public GameObject breadPrefab;
    public GameObject heldItem;

    [Header("Inventory")]
    public string triggerName = "";
    public string cookedFood = "";
    public string heldItemName;
    public bool isCooking = false;

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //if space is pressed
        {
            if (triggerName == "Bread") //if in bread collider(trigger)
            {
                heldItem = Instantiate(breadPrefab, transform, false); //(create copy of object, game object we want as new object's parent 9in this case, codey's transform/position, does not tell unity how to position in relation to the world
                heldItem.transform.localPosition = new Vector3(0, 2, 2);//position bread at codey, not original's position from codey (YALL ITS PLACED IN XYZ MODE WE FINALLY KNOW-) (and it wont let me do decimals for some reason-)
                heldItemName = "breadSlice";
            }

            if(triggerName == "stove 1")
            {
                print("I'm at the stove!");
                if (heldItemName == "breadSlice")
                {
                    print("Ready to toast!");
                    smoke.Play();
                    isCooking = true;
                    //Destroy(heldItem);
                    toast.SetActive(true);
                    //heldItemName = "";
                    cookedFood = "toast";
                    PlaceHeldItem();
                    Invoke("CompleteCooking", 6f);
                }
                else
                {
                    if(cookedFood == "toast")
                    {
                        if(isCooking == false)
                        {
                            heldItem = Instantiate(breadPrefab, transform, false);
                            heldItem.transform.localPosition = new Vector3(0, 2, 2);
                            heldItemName = "toastSlice";
                            CleanStove();
                        }
                    }
                    else if (isCooking == true)
                    {
                        print("your food is not ready!");
                    }
                }
            }

            if (triggerName == "Receivers")
            {
                if (heldItemName == "toastSlice")
                {
                    //Destroy(heldItem);
                    //heldItemName = "";
                    PlaceHeldItem();
                    GameObject.Find("Receivers/French Toast/toastSlice").SetActive(true);
                    //GameObject.Find("Receivers/French Toast/friedEgg").SetActive(true);
                }
            }
        }
    }

    private void CompleteCooking()
    {
        smoke.Stop();
        complete.Play();
        isCooking = false;
    }

    private void PlaceHeldItem()
    {
        Destroy(heldItem);
        heldItemName = "";
    }

    public void CleanStove()
    {
        toast.SetActive(false);
        cookedFood = "";
        complete.Stop();
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
