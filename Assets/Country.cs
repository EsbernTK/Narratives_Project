using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum Affluence
{
    Destitude,
    Poor,
    Moderate,
    Rich,
    Affluent
}
[System.Serializable]
public class Country{
    public float pacifistAggressive;
    public Affluence money;
    private List<Country> countries = new List<Country>();
    public float ArmyStrength;
    public int ArmyPopulation;
    [HideInInspector]
    public float ArmyPopPercentage;
    public int Population;
    public int TotalPossiblePopulation;
    public float tradeWillingness;
    public string name;
    public Dictionary<string, Action> AllActions = new Dictionary<string, Action>
    {
        {"DeclareWar",new DeclareWar(null) },
        {"ResolveWar",new ResolveWar(null) },
        {"Battle",new Battle(null) },
        {"RecruitSoldiers",new RecruitSoldiers(null) },
        {"GrowPopulation",new GrowPop(null) },
        {"Surrender",new Surrender(null) },
        {"DoNothing",new DoNothing(null) }

    };

    public WorldState currentState;
    public Action currentAction;
    public Country()
    {

    }
    public Country(WorldState initialState)
    {
        currentState = initialState;
        ArmyPopPercentage = 0.1f;
        Population = (int)((Random.value + 0.2f) * 10000);
        TotalPossiblePopulation = (int)(Population * 1.7f);
        ArmyPopulation = (int)(ArmyPopPercentage * Population);
        pacifistAggressive = Random.Range(0f, 100f);
        money = (Affluence)Random.Range(0, 4);
        tradeWillingness = ((4 - (int)money) / 4)*100f;
        CalculateArmyStrength();
        Debug.Log(ArmyStrength);
    }

    public void DecideOnAction()
    {
        float number = Random.value*100f;
        if(currentState.GetType() == typeof(Peace))
        {
            //Debug.Log("Army chance " + (1 - ((float)ArmyPopulation / (float)Population) / ArmyPopPercentage) * 100f);
            //Debug.Log("Pop chance " + (1 - ((float)Population / (float)TotalPossiblePopulation)) * 100f);

            if(number < (1-((float)ArmyPopulation / (float)Population) / ArmyPopPercentage)*100f)
            {
                DoAction(AllActions["RecruitSoldiers"]);
            }
            else if(number < (1-((float)Population / (float)TotalPossiblePopulation)) * 100f)
            {
                DoAction(AllActions["GrowPopulation"]);
            }
            else
            {
                DoAction(AllActions["DoNothing"]);
            }
        }
        if(number < pacifistAggressive && currentState.GetType() != typeof(War) && AllActions.ContainsKey("DeclareWar"))
        {
                DoAction(AllActions["DeclareWar"],countries[0]);
        }
        else if (currentState.GetType() == typeof(War))
        {
            War tempState = (War)currentState;
            Country enemy = null;
            foreach(Country c in tempState.participants)
            {
                if (!c.Equals(this))
                {
                    enemy = c;
                    break;
                }
            }
            if(ArmyStrength* 3 < enemy.ArmyStrength)
            {
                DoAction(AllActions["Surrender"], countries[0]);
            }
            else if(number > pacifistAggressive )
                DoAction(AllActions["ResolveWar"],countries[0]);
            else if (number < pacifistAggressive  && AllActions.ContainsKey("Battle"))
            {
                    DoAction(AllActions["Battle"], countries[0]);
            }
            else
            {
                DoAction(AllActions["DoNothing"]);
            }
        }
        else
        {
            DoAction(AllActions["DoNothing"]);
        }
        if(currentAction.GetType() != typeof(DoNothing))
        {
            currentState.statePeriodLength++;
        }
    }

    public void DoAction(Action action)
    {
        Action copyAction = action;
        currentAction = copyAction;
        if (copyAction.GetType() != typeof(DoNothing))
        {
            copyAction.actionOwner = this;
            currentState.stateHistory.Add(copyAction);
            copyAction.DoAction();
            if (!GameManagerSimulator.instance.WorldEvents.Contains(currentState))
                GameManagerSimulator.instance.WorldEvents.Add(currentState);
            //currentAction = copyAction;
        }
    }
    public void DoAction(Action action, Country otherCountry)
    {
        Action copyAction = action;
        currentAction = copyAction;
        if (copyAction.GetType() != typeof(DoNothing))
        {
            copyAction.actionOwner = this;
            currentState.stateHistory.Add(copyAction);
            copyAction.DoAction(otherCountry);
            if(!GameManagerSimulator.instance.WorldEvents.Contains(currentState))
                GameManagerSimulator.instance.WorldEvents.Add(currentState);
            //currentAction = copyAction;
        }
    }


    

    public void CalculateArmyStrength()
    {
        ArmyStrength = ArmyPopulation *(((int)money) + 1f) / 2f;
    }

    [HideInInspector]
    public List<Country> Countries
    {
        get
        {
            return countries;
        }

        set
        {
            if (!value.Contains(this))
                countries = value;
            else
            {
                countries = new List<Country>(value);

                countries.Remove(this);
            }
        }
    }
    public Country Copy()
    {
        Country output = new Country
        {
            Population = Population,
            money = money,
            pacifistAggressive = pacifistAggressive,
            ArmyStrength = ArmyStrength
        };
        return output;
    }
}
