using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResolveWar : Action {
    public float n;
    public float chances;
    public War temp;
    public ResolveWar(Country owner) : base(owner)
    {
    }

    public override void DoAction()
    {
        
    }
    public override void DoAction(Country otherCountry)
    {
        base.DoAction(otherCountry);
        Battle action = new Battle();
        n = action.battleResult;
        chances = actionOwner.ArmyStrength/(actionOwner.ArmyStrength + otherCountry.ArmyStrength);
        temp = (War)actionOwner.currentState;
        
        if (n < chances)
        {
            temp.winner = actionOwner;
            temp.loser = otherCountry;
            //OwnerCountry Wins
        }
        else
        {
            temp.winner = otherCountry;
            temp.loser = actionOwner ;
            //otherCountry wins
        }
        Peace newState = new Peace();
        actionOwner.currentState = newState;
        otherCountry.currentState = newState;
    }
}
