using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WorldState {
    public List<Action> stateHistory = new List<Action>();
    public int statePeriodLength = 1;
    public string name;
    public WorldState()
    {
        name = GetType().ToString();
    }
}
