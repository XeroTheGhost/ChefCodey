using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stove : MonoBehaviour
{
    public Interact heldItem;

    public GameObject toast;
    public GameObject bread;

    public string triggerName = "";

    // Start is called before the first frame update
    void Start()
    {
        toast.SetActive(false);
    }

    public void Toastbread()
    {
        toast.SetActive(true);
    }
}
