using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Roguelike/DamageSensitivities")]
public class DamageSensitivities : ScriptableObject
{
    [SerializeField] private List<Damage> resistances;
    [SerializeField] private List<Damage> weaknesses;

    public float CalculateDamage(DamageType type, float amount)
    {
        float actualDamage = 0;
        for (int i = 0; i < resistances.Count; i++)
        for (int j = 0; j < weaknesses.Count; j++)
        {
            if (type == resistances[i].Type)
            {
                actualDamage += amount * (100 / (100 + resistances[i].Amount));
            }
            
            if (type == weaknesses[j].Type)
            {
                actualDamage += amount * (100 / (100 - weaknesses[i].Amount));
            }
        }
        if (actualDamage > 0)
        {
	        return actualDamage;
        }
        return amount;
    }
}
