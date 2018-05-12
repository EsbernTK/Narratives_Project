using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class War : WorldState {
    public List<Country> participants = new List<Country>();
    [SerializeField]
    public Country winner;
    [SerializeField]
    public Country loser;


}
