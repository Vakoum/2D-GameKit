using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AbilityAmmount")]
public class AbilityAmmount : ScriptableObject
{
    public string AbilityName;
    private int currentAbilitySegments;
    public int maxAbilitySegments;
    public bool isEnabled;

    public int GetCurrentAbilityAmmount()
    {
        return currentAbilitySegments;
    }
    public void ResetAbilityToMax()
    {
        currentAbilitySegments = maxAbilitySegments;
    }
    public void SetAbilityAmmount(int ammount)
    {
        if(currentAbilitySegments > 0)
        {
            currentAbilitySegments -= ammount;
        }
        else
        {
            Debug.Log("ability is already zero. you cant get it lower");
        }
    }
}
