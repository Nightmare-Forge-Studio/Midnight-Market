using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private LayerMask interactLayer;
    public static Interactor instance;
    // Update is called once per frame

    private void Awake() {
        instance = this;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float interactRange = 2f;
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange, interactLayer);
            foreach (Collider collider in colliderArray)
            {
                if (collider.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact();
                }
                Debug.Log(collider);
            }
        }
    }
    public  IInteractable GetInteractableObject(){
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange, interactLayer);
        foreach (Collider collider in colliderArray){
            if (collider.TryGetComponent(out IInteractable interactable)){
                return interactable;
            }
        }
        return null;
    }

}
