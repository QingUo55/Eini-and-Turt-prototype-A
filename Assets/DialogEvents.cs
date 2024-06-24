using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogEvents 
{
    public string LineToTrigger;
    public Action ActionToTrigger;

    public DialogEvents(string lineToTrigger, Action actionToTrigger)
    {
        LineToTrigger = lineToTrigger;
        ActionToTrigger = actionToTrigger;
    }   
}
