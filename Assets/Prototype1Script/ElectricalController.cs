using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricalController : MonoBehaviour,IInteractable
{
    //item that can be placed in the electrical
    public ItemController fuseStorage;
    public ItemController boltCutter;
    public ItemController fuseOffice;

    //check if fuse is in the storage
    private bool hasFuseStorage;
    private bool hasFuseOffice;
    
    
    public string GetInteractText()
    {
        if (ItemManager.instance.items.Contains(fuseStorage))
        {
            return "Place " + fuseStorage.name; 
        }
        else if (ItemManager.instance.items.Contains(fuseOffice))
        {
            return "Place " + fuseOffice.name; 
        }
        else if (ItemManager.instance.items.Contains(boltCutter))
        {
            return "Cut chain with " + boltCutter.name; 
        }
        else{
            return "Look For Fuse";
        }
    
    }

    public void Interact()
    {
        if (ItemManager.instance.items.Contains(fuseStorage))
        {
            ItemManager.instance.items.Remove(fuseStorage);
            hasFuseStorage = true;
        }
        else if (ItemManager.instance.items.Contains(fuseOffice))
        {
            ItemManager.instance.items.Remove(fuseOffice);
            hasFuseOffice = true;
        }
        else if (ItemManager.instance.items.Contains(boltCutter))
        {
            ItemManager.instance.items.Remove(boltCutter);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasFuseStorage && hasFuseOffice)
        {
            gameObject.layer = default;

        }
    }
}
