using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameGenerator {

    string[] firstNameParts = new string[]
    {
        "New ",
        "Los ",
        "",
        "",
        "",
        "",
        "Glor ",
        "Klar ",
        "Ka ",
    };

    string[] secondNameParts = new string[]
    {
        "Voo",
        "Ba",
        "Den",
        "Va",
        "Val",
    };
    string[] thirdNameParts = new string[]
    {
        "bis",
        "lia",
        "liks",
        "shire",
        "dam",
        
    };


    public string GenerateName()
    {
        string first = firstNameParts[Random.Range(0, firstNameParts.Length - 1)];
        string second = secondNameParts[Random.Range(0, secondNameParts.Length - 1)];
        string third = thirdNameParts[Random.Range(0, thirdNameParts.Length - 1)];
        return first + second + third;
    }
}
