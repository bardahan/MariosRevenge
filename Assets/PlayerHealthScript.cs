using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthScript : MonoBehaviour
{
    public HealthBar playerHealthBar;

    public float health = 100.0f;

    public void TakeDamege(float impact)
    {
        health -= impact;
        playerHealthBar.SetHealth(health);
    }

    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        playerHealthBar.SetHealth(health);
    }
}
