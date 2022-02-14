using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EventTriggerSet : MonoBehaviour
{
    public static typeOfTrigger typeOfTriggerEnum;

    public enum typeOfTrigger
    {
        laser,switchButton,
    };

    [Serializable]
   public class eventTrigger : EventArgs
    {
        public EventTriggerSet.typeOfTrigger typeOfEventTrigger;
    }
}
