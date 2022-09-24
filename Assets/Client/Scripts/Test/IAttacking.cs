using System.Collections.Generic;
using UnityEngine;

public interface IAttacking
{
    public float Attack(Transform enemy, List<Property> damage, float cooldown, float attackAngle);
}