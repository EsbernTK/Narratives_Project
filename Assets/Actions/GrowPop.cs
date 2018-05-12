using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowPop : Action {
    public GrowPop(Country owner) : base(owner)
    {
    }

    public override void DoAction()
    {
        //Debug.Log("Calling Grow on: " + actionOwner.name);
        actionOwner.Population += (int)(actionOwner.Population * 0.001f);
    }
}
