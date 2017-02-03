using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgorEventSystemS : MonoBehaviour {

    //You want to be careful when passing event name
    //If there is no such a event it will throw 
    //an ArgumentNullException 
    //So be aware of that  

    public string[] eventsList;

    public delegate void eventDelegate(EventInfoS e);
    eventDelegate[] events;

    void Awake()
    {
        events = new eventDelegate[eventsList.Length];
    }

    public bool Subscribe(string eventName, eventDelegate client)
    {
        
        int index = Array.FindIndex(eventsList, s => s == eventName);
        if ( eventsList.Length > index && index >= 0)
        {
            Debug.Log(index);
            events[index] += client;
            return true;
        }
        return false;
    }

    public bool Unsubscribe(string eventName, eventDelegate client)
    {
        int index = Array.FindIndex(eventsList, s => s == eventName);
        if (index >= 0)
        {
            events[index] -= client;
            return true;
        }
        return false;
    }

    public bool Call(string eventName, IgorEventSystemS caller)
    {
        int index = Array.FindIndex(eventsList, s => eventName == s);
        if (index >= 0)
        {
            EventInfoS e = new EventInfoS(this, caller, index);
            if(events[index] != null)
                events[index](e);
            return true;
        }
        return false;
    }

}
