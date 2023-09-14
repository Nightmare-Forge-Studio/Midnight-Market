using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{

    public ObjectiveData[] objectiveDatas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // foreach (ObjectiveData objective in objectiveDatas)
        // {
        //     if (objective.isComplete == true)
        //     {
        //         GameManager.instance.FinishGame();
        //     }
        // }
        if (objectiveDatas[objectiveDatas.Length - 1].isComplete)
        {
            GameManager.instance.FinishGame();
        }
    }
}
