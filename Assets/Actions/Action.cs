using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Action {
    public string name;
    [HideInInspector]
    public Country actionOwner;
    [HideInInspector]
    public List<Country> snapshot;
    //add time-keeping to constructor
    public Action()
    {

    }
    public Action(Country owner)
    {
        actionOwner = owner;
        name = GetType().ToString();
    }
    public virtual void DoAction()
    {
        snapshot = new List<Country>();
        foreach(Country c in GameManagerSimulator.instance.countries)
        {
            snapshot.Add(c.Copy());
        }
    }
    public virtual void DoAction(Country otherCountry)
    {
        snapshot = new List<Country>();
        foreach (Country c in GameManagerSimulator.instance.countries)
        {
            snapshot.Add(c.Copy());
        }
    }
    public virtual void DoAction(Action BelongingAction)
    {
        snapshot = new List<Country>();
        foreach (Country c in GameManagerSimulator.instance.countries)
        {
            snapshot.Add(c.Copy());
        }
    }
}
