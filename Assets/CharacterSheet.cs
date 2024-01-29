using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{
    [SerializeField] string characterName = "";
    [SerializeField] int proficiency = 0;
    [SerializeField] bool usingFinesse = false;
    [SerializeField] [Range(-5,5)] int str = 0;
    [SerializeField] [Range(-5, 5)] int dex = 0;

    // Start is called before the first frame update
    void Start()
    {


        Debug.Log(characterName + "\'s modifier is " + CheckPositive(FindModifier()) );

        int enemyAC = UnityEngine.Random.Range(10, 21);
        Debug.Log("Enemy AC is " + enemyAC);
        int roll20 = UnityEngine.Random.Range(1, 21);
        Debug.Log(characterName + " rolled a " + roll20);
        if (FindModifier()+roll20 >= enemyAC)
        {
            Debug.Log(characterName + " hit the enemy!");
        }
        else
        {
            Debug.Log(characterName + " missed!");
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    int FindModifier()
    {
        /**if this was just using if statements then i would need to wrap the "str" output in an else statement,
        but because i'm using return here i can guarantee that there won't be a double output in the first place**/
        if (usingFinesse)
        {
            if (str < dex)
                return dex + proficiency;
        }
        return str + proficiency;

        //yes i know you know this but i wanted to explain that i knew what i was doing since this is slightly more than what was shown in class
    }

    string CheckPositive(int i)
    {
        if (i > 0)
            return "+" + i;
        else return "" + i;
    }
}
