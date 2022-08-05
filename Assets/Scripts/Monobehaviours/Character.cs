using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected HitPoints hitPoints;
    public float maxHitPoints;
    [SerializeField] protected float startingHitPoints;
}
