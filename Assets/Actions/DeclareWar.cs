using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeclareWar : Action {
    public DeclareWar(Country owner) : base(owner)
    {
    }

    public override void DoAction(Country otherCountry)
    {
        base.DoAction(otherCountry);
        War newState = new War()
        {
            participants = new List<Country>()
            {
                actionOwner,
                otherCountry
            }
        };
        actionOwner.currentState = newState;
        otherCountry.currentState = newState;
        actionOwner.DoAction(actionOwner.AllActions["Battle"], otherCountry);
    }

}
