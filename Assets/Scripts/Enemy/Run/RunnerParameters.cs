using UnityEngine;
using System.Collections;

public class RunnerParameters : ScriptableObject {

    public float MinSpeed;
    public float MaxSpeed;    

    public float GetSpeedValue()
    {
        return Random.Range(MinSpeed, MaxSpeed);
    }
}
