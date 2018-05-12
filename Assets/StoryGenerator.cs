using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGenerator {

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
        string output = "";
        return output;
    }
    
    public string GenerateWarStory(War war)
    {
        string output = "The war was ";
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
        }
        else
        {
            if (endAction.GetType() == typeof(ResolveWar))
                output +=  "short " + GenerateResolveStory((ResolveWar)endAction);
            else if(endAction.GetType() == typeof(Surrender))
            {
                output += "short " + GenerateSurrenderStory((Surrender)endAction);
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
            else if (battle.otherCountryLoses < battle.actionOwnerLoses * 1.5)
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
            else if (battle.otherCountryLoses < battle.actionOwnerLoses * 1.5)
            {
                output += "though " + battle.otherCountry.name + " lost " + battle.otherCountryLoses + " men, when we only lost " + battle.actionOwnerLoses + ". ";
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
            else if (battle.otherCountryLoses < battle.actionOwnerLoses * 1.5)
            {
                output += "though " + battle.otherCountry.name + " lost " + battle.otherCountryLoses + "men, when we only lost " + battle.actionOwnerLoses + ". ";
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
        string output = "resolve";
        return output;
    }
    public string GenerateSurrenderStory(Surrender resolve)
    {
        string output = "surrender";
        return output;
    }
}
