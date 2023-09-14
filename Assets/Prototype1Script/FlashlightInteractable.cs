using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightInteractable : MonoBehaviour, IInteractable{

    public GameObject flashlight;

    public string GetInteractText()
    {
        return "Pick Up";
    }

    public void Interact()
    {
        flashlight.SetActive(true);
        Destroy(gameObject, 0.1f);

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
