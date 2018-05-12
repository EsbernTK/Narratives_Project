using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : Action
{
    public float battleResult;
    public int actionOwnerLoses;
    public int otherCountryLoses;
    public float actionOwnerArmyStrength;
    public float otherCountryArmyStrength;
    public string BattleName;
    public Country otherCountry;
    public Battle()
    {
        
    }
    public Battle(Country owner) : base(owner)
    {
        
    }

    public override void DoAction(Country otherCountry)
    {

        base.DoAction(otherCountry);
        BattleName = GameManagerSimulator.instance.GenerateName();
        battleResult = Random.value;
        this.otherCountry = otherCountry;
        actionOwnerArmyStrength = actionOwner.ArmyStrength;
        otherCountryArmyStrength = otherCountry.ArmyStrength;

        float oldActionOwnerArmyPop = actionOwner.ArmyPopulation;
        float oldOtherCountryArmyPop = otherCountry.ArmyPopulation;
        actionOwnerLoses = (int)((1 - battleResult) * otherCountry.ArmyStrength);
        otherCountryLoses = (int)((battleResult) * actionOwner.ArmyPopulation);

        actionOwner.ArmyPopulation = Mathf.Max(0, actionOwner.ArmyPopulation - actionOwnerLoses);
        otherCountry.ArmyPopulation = Mathf.Max(0, otherCountry.ArmyPopulation - otherCountryLoses);

        actionOwner.Population = Mathf.Max(0, actionOwner.Population - actionOwnerLoses);
        otherCountry.Population = Mathf.Max(0, otherCountry.Population - otherCountryLoses);


        actionOwner.CalculateArmyStrength();
        otherCountry.CalculateArmyStrength();
        actionOwner.pacifistAggressive *= actionOwner.ArmyPopulation/oldActionOwnerArmyPop;
        otherCountry.pacifistAggressive *= otherCountry.ArmyPopulation/oldOtherCountryArmyPop;
    }
}
