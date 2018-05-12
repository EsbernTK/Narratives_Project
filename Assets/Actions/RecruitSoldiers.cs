using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecruitSoldiers : Action {
    public RecruitSoldiers(Country owner) : base(owner)
    {
    }

    public override void DoAction()
    {
        actionOwner.ArmyPopulation += (int)(actionOwner.Population * 0.01f);
        actionOwner.CalculateArmyStrength();
        actionOwner.pacifistAggressive += 1f;
    }
}
