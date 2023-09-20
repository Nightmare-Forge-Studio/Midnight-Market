using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectiveData : MonoBehaviour
{
    
        public int ID;
        public ObjectiveDescription Description;
        public bool IsComplete;
        public bool IsActive;
        public ObjectiveType Type;
        public float Progress;
        public Requirement ObjectiveRequirement;
        public HintData ObjectiveHint;

        public ObjectiveData(int id, ObjectiveDescription description, ObjectiveType type, Requirement requirement, HintData hint)
        {
            ID = id;
            Description = description;
            IsComplete = false;
            IsActive = false;
            Type = type;
            Progress = 0f;
            ObjectiveRequirement = requirement;
            ObjectiveHint = hint;
        }


    public class Requirement
    {
        public string Description;
        public bool IsFulfilled;

        public Requirement(string description)
        {
            Description = description;
            IsFulfilled = false;
        }
    }

    public class HintData
    {
        public string Description;
        public HintType Type;
        public bool IsActive;

        public HintData(string description, HintType type)
        {
            Description = description;
            Type = type;
            IsActive = false;
        }
    }

    public enum ObjectiveType
    {
        Item,
        Trigger,
        Activate
    }

    public enum HintType
    {
        FuseHint,
        VentHint,
        ToolkitHint
    }

    public enum ObjectiveDescription
    {
        EndTheShift,
        InvestigateWhatHappened,
        FixElectricalProblem,
        EscapeTheSupermarket
    }

}
