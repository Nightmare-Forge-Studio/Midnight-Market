using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportToVent : MonoBehaviour,IInteractable
{
    [SerializeField] private GameObject ventLocation = null;
    [SerializeField] private GameObject player = null;
    
    public string GetInteractText()
    {
        return "Go to Vent";
    }

    public void Interact()
    {
        player.transform.position = ventLocation.transform.position;
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
