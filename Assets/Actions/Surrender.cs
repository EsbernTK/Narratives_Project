using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Surrender : Action {
    public Surrender()
    {
    }

    public Surrender(Country owner) : base(owner)
    {
    }

    public override void DoAction()
    {
        
        actionOwner.money = (Affluence)Mathf.Max(0, (int)actionOwner.money - 1);
    }
    public override void DoAction(Country otherCountry)
    {
        base.DoAction(otherCountry);
        actionOwner.money = (Affluence)Mathf.Max(0, (int)actionOwner.money - 1);
        otherCountry.money = (Affluence)Mathf.Min(System.Enum.GetNames(typeof(Affluence)).Length-1, (int)actionOwner.money + 1);
        War temp = (War)actionOwner.currentState;
        temp.winner = otherCountry;
        temp.loser = actionOwner;
        Peace newState = new Peace();
        actionOwner.currentState = newState;
        otherCountry.currentState = newState;
    }
}
