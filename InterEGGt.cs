using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterEGGt : MonoBehaviour
{
    [Header("Prefabs")]
    public Stove stove;
    public GameObject egg;
    public GameObject friedEgg;
    public GameObject heldItem;
    public GameObject eggPrefab;
    public GameObject friedEggPrefab;

    [Header("Inventory")]
    public string triggerName = "";
    public string heldItemName;
    public string cookedFood = "";
    public bool isCooking = false;

    [Header("Particles")]
    public ParticleSystem smoke;
    public ParticleSystem complete;

    // Start is called before the first frame update
    void Start()
    {
        friedEgg.SetActive(false);
        GameObject.Find("Receivers/French Toast/FEgg").SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) //if space is pressed
        {
            if (triggerName == "Oog") //if in bread collider(trigger)
            {
                heldItem = Instantiate(eggPrefab, transform, false); //(create copy of object, game object we want as new object's parent 9in this case, codey's transform/position, does not tell unity how to position in relation to the world
                heldItem.transform.localPosition = new Vector3(0, 2, 2);//position bread at codey, not original's position from codey (YALL ITS PLACED IN XYZ MODE WE FINALLY KNOW-) (and it wont let me do decimals for some reason-)
                heldItemName = "egg";
            }

            if (triggerName == "stove 1")
            {
                print("I'm at the stove!");
                if (heldItemName == "egg")
                {
                    print("Ready to fry!");
                    smoke.Play();
                    isCooking = true;
                    //Destroy(heldItem);
                    friedEgg.SetActive(true);
                    //heldItemName = "";
                    cookedFood = "friedEgg";
                    PlaceHeldItem();
                    Invoke("CompleteCooking", 8f);
                }
                else
                {
                    if (cookedFood == "friedEgg")
                    {
                        if (isCooking == false)
                        {
                            heldItem = Instantiate(friedEggPrefab, transform, false);
                            heldItem.transform.localPosition = new Vector3(0, 2, 2);
                            heldItemName = "friedEgg";
                            CleanStove();
                        }
                        else if (isCooking == true)
                        {
                            print("your food is not ready!");
                        }
                    }
                }
            }

            if (triggerName == "Receivers")
            {
                if (heldItemName == "friedEgg")
                {
                    //Destroy(heldItem);
                    //heldItemName = "";
                    PlaceHeldItem();
                    //GameObject.Find("Receivers/French Toast/toastSlice").SetActive(true);
                    GameObject.Find("Receivers/French Toast/FEgg").SetActive(true);
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
            egg.SetActive(false);
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
