﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventInfoS {
    public EventInfoS(IgorEventSystemS _send, IgorEventSystemS _call, int _id)
    {
        eventId = _id;
        sender = _send;
    }
    public IgorEventSystemS sender;
    public IgorEventSystemS caller;
    public int eventId;
}
