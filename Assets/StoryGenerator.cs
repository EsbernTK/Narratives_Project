using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGenerator {

    public List<string> eras = new List<string>()
    {
        "first",
        "fifth",
        "31st",
        "long",
        "16th",
        "105th",
        "second",
        "world",
        "false"
    };

	public string GenerateStateStory(WorldState state)
    {
        string output = "";
        switch (state.GetType().ToString())
        {
            case "Peace":
                output = GeneratePeaceStory((Peace)state);
                break;
            case "War":
                output = GenerateWarStory((War)state);
                break;
            default:

                break;
        }
        return output;
        
    }
    public string GeneratePeaceStory(Peace battle)
    {
        string output = "A period of peace that stretched for a long time. ";
        int indexLenght = Mathf.Min(5, battle.stateHistory.Count);
        for (int i = 0; i < indexLenght; i++)
        {
            if(battle.stateHistory[i].GetType() == typeof(GrowPop))
            {
                output += GenerateGrowthStory((GrowPop)battle.stateHistory[i]);
            }
            else if(battle.stateHistory[i].GetType() == typeof(RecruitSoldiers))
            {
                output += GenerateRecruitmentStory((RecruitSoldiers)battle.stateHistory[i]);
            }
        }
        output += "\n However after this time of peace came a war decleration " + GenerateDeclareWarStory((DeclareWar)battle.stateHistory[battle.stateHistory.Count-1]);
        return output;
    }
    public string GenerateDeclareWarStory(DeclareWar battle)
    {
        string output = "";

        return output;
    }
    public string GenerateRecruitmentStory(RecruitSoldiers battle)
    {
        string output = "\n There was a time of recuitment in the country.\n ";
        if(battle.actionHappiness < 0.2)
        {
            output += "Many soldiers were recruited from the population, however many were angry at this as they needed their sons for the harvest";
        }
        else if(battle.actionHappiness >= 0.2 && battle.actionHappiness < 0.7)
        {
            output += "Many soldiers were recruited from the population, most were content but some were unhappy with their new living conditions, though it was not a problem";
        }
        else
        {
            output += "Many soldiers were recruited from the population and they were all happy to be a part of the new army, they wanted to protect the country";
        }
        return output;
    }
    public string GenerateGrowthStory(GrowPop battle)
    {
        string output = "\n The country could support many more people than there were, so the government gave all citizens more food, such that they might be insentivised to have more children";
        return output;
    }
    public string GenerateWarStory(War war)
    {
        int val = Random.Range(0, eras.Count - 1);
        string output = "The " +eras[val] + " war.\n The war was ";
        Action endAction = war.stateHistory[war.stateHistory.Count - 1];
        if (war.statePeriodLength > 2)
        {
            string battleStories = "";
            foreach(Action b in war.stateHistory)
            {
                if(b.GetType() == typeof(Battle))
                    battleStories += GenerateShallowBattleStory((Battle)b);
            }
            output += "relativly long, with " + (war.stateHistory.Count-1) + " battles " + battleStories;
            if (endAction.GetType() == typeof(ResolveWar))
                output += "\n It ultimately ended with a final battle. " + GenerateResolveStory((ResolveWar)endAction);
            else if (endAction.GetType() == typeof(Surrender))
            {
                output += GenerateSurrenderStory((Surrender)endAction);
            }
        }
        else
        {
            output += "short with only two battles, the first being " + GenerateShallowBattleStory((Battle)war.stateHistory[0]);
            if (endAction.GetType() == typeof(ResolveWar))
                output += "\n It ultimately ended with a final battle. " + GenerateResolveStory((ResolveWar)endAction);
            else if(endAction.GetType() == typeof(Surrender))
            {
                output += GenerateSurrenderStory((Surrender)endAction);
            }
        }

        return output;
    }

    

    public string GenerateShallowBattleStory(Battle battle)
    {
        //reformat to match country you are in

        string output = "\n The battle of " + battle.BattleName;
        if(battle.battleResult < 0.25)
        {
            output += " was hard fought by " + battle.otherCountry.name + "'s army, ";
            if (battle.actionOwnerArmyStrength >= battle.otherCountryArmyStrength * 1.5)
            {
                output += "even when outnumbered and outclassed ";
            }
            else if (battle.actionOwnerArmyStrength * 1.5 <= battle.otherCountryArmyStrength)
            {
                output += "because they outnumbered us ";
            }
            else
            {
                output += "even when they were equal in numbers and gear ";
            }
            output += "they ultimately won the battle ";
            if(battle.otherCountryLoses > battle.actionOwnerLoses*1.5)
            {
                output += "but at a much steeper cost than us. They lost " + battle.otherCountryLoses + "men, when we only lost " + battle.actionOwnerLoses + " men. ";
            }
            else if (battle.otherCountryLoses * 1.5  < battle.actionOwnerLoses)
            {
                output += "decisivly, only losing " + battle.otherCountryLoses + "men, when we lost " + battle.actionOwnerLoses + " men. ";
            }
            else
            {
                output += "but not by much, as both countries lost about " + battle.otherCountryLoses + " men. ";
            }
        }
        else if(battle.battleResult >= 0.25 && battle.battleResult < 0.5)
        {
            output += " was a struggle that went back and forth between the two armies, ";
            if (battle.actionOwnerArmyStrength >= battle.otherCountryArmyStrength * 1.5)
            {
                output += "even when " + battle.otherCountry.name +  "'s army was outnumbered and outclassed. ";
            }
            else if (battle.actionOwnerArmyStrength * 1.5 <= battle.otherCountryArmyStrength)
            {
                output += "a major feat considering the disadvantage we were at. ";
            }
            else
            {
                output += "because the two armies were equal in men and experience. ";
            }
            output += "No one decisivly won the battle ";
            if (battle.otherCountryLoses > battle.actionOwnerLoses * 1.5)
            {
                output += "however we lost " + battle.actionOwnerLoses + " men, much fewer than the " + battle.otherCountryLoses + " that " + battle.otherCountry.name + " lost. ";
            }
            else if (battle.otherCountryLoses * 1.5 < battle.actionOwnerLoses)
            {
                output += "though " + battle.otherCountry.name + " only lost " + battle.otherCountryLoses + " men, when we lost " + battle.actionOwnerLoses + ". ";
            }
            else
            {
                output += "and countries lost about " + battle.otherCountryLoses + " men, making neither country gain any ground. ";
            }
        }
        else
        {
            output += " was gloriously fought, and won, by our magnificent army, ";
            if (battle.actionOwnerArmyStrength >= battle.otherCountryArmyStrength * 1.5)
            {
                output += "though not just because" + battle.otherCountry.name + "'s army was outnumbered and weak. ";
            }
            else if (battle.actionOwnerArmyStrength * 1.5 <= battle.otherCountryArmyStrength)
            {
                output += "a major feat considering the disadvantage we were at. ";
            }
            else
            {
                output += "a great deed when knowing how even the armies were. ";
            }
            output += "The battle was won in stride ";
            if (battle.otherCountryLoses > battle.actionOwnerLoses * 1.5)
            {
                output += "however we lost " + battle.actionOwnerLoses + " men, much fewer than the " + battle.otherCountryLoses + " that " + battle.otherCountry.name + " lost. ";
            }
            else if (battle.otherCountryLoses * 1.5 < battle.actionOwnerLoses)
            {
                output += "though " + battle.otherCountry.name + " only lost " + battle.otherCountryLoses + " men, when we lost " + battle.actionOwnerLoses + ". ";
            }
            else
            {
                output += "and both countries lost about " + battle.otherCountryLoses + " men, which didnt make our country gain any ground over the other. ";
            }
        }
        return output;
    }
    public string GenerateDeepBattleStory(Battle battle)
    {
        string output = "";
        return output;
    }
    public string GenerateResolveStory(ResolveWar resolve)
    {
        string output = "\n";
        if(resolve.temp.winner.name.Equals(GameManagerSimulator.instance.countries[0].name))
        {
            output += "The final battle was long and tough, but finally we beat the enemy army and succeded in our conquest";
        }
        else if (resolve.temp.winner.name.Equals(GameManagerSimulator.instance.countries[1].name))
        {
            output += "The final battle was hard fought by us, but also by the enemy, who only just succeeded in besting us";
        }
        return output;
    }
    public string GenerateSurrenderStory(Surrender resolve)
    {
        string output = "\n";
        if (resolve.actionOwner.name.Equals(GameManagerSimulator.instance.countries[0].name))
        {
            output += "The war had been tough and we had lost many men. The enemy was too strong so we had to surrender";
        }
        else if (resolve.actionOwner.name.Equals(GameManagerSimulator.instance.countries[1].name))
        {
            output += "We had beaten the enemy to a pulp and to the point where the cowards no longer had a will to fight.\n Finally they surrendered to our military might";
        }
        return output;
    }
}
