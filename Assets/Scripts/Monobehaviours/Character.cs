using System.Collections;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    public float maxHitPoints;
    [SerializeField] protected float startingHitPoints;

    public virtual void KillCharacter()
    {
        Destroy(gameObject);
    }

    public abstract void ResetCharacter();

    public abstract IEnumerator DamageCharacter(int damage, float interval);

}
