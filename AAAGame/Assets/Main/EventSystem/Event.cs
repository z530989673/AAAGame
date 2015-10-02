using UnityEngine;
using System.Collections;

public class Event {
    public Event(EVT_TYPE t) { type = t; }

    //public delegate void CallBack(Event evt);
    public object evt_obj;
    public EVT_TYPE type;
    //public event CallBack callBacks;

    //public void HandleCallBacks(Event evt)
    //{
    //    if (callBacks != null)
    //        callBacks.Invoke(evt);
    //}
}
