using UnityEngine;
using System.Collections;

public class AttackerParameters : ScriptableObject
{    
    public int Damage;
    public float Cooldown;
    public float Range;
    public Destroyable Target;
}
