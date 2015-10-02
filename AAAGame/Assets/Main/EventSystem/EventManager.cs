using UnityEngine;
using System.Collections;

public class EventManager : MonoBehaviour {

    private delegate void Handler(Event evt);

    private Queue m_eventsQueue;

    private ArrayList m_eventsHandlerLink;

    public void SendEvent(Event evt)
    {
        m_eventsQueue.Enqueue(evt);
    }

    public void SendEvent(EVT_TYPE t)
    {
        Event evt = new Event(EVT_TYPE.EVT_TYPE_DEFAULT);
        m_eventsQueue.Enqueue(evt);
    }

	// Use this for initialization
	void Start () {
        m_eventsQueue = new Queue(100);
        m_eventsHandlerLink = new ArrayList(200);

        m_eventsHandlerLink.Add(new Handler(DefaultEventHandler.Handle));
	}

	// Update is called once per frame
	void Update () {
	    while(m_eventsQueue.Count != 0)
        {
            Event evt = m_eventsQueue.Dequeue() as Event;
            if (evt.type < EVT_TYPE.EVT_TYPE_MAX)
            {
                Handler hdr = m_eventsHandlerLink[(int)evt.type] as Handler;
                hdr(evt);
            }
            else
            {
                Debug.LogError("Wrong Event Type!");
            }
        }
	}
}
