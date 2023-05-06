using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GameEvent
{
    public string EventDescription;
}

public class FetchingGameEvent : GameEvent
{
    public string ItemName;

    public FetchingGameEvent(string name)
    {
        ItemName = name;
    }
}
