using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCollision : MonoBehaviour
{
    public int damage = 1;
    
    void OnColliderEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>(); //Reference Enemy class and get enemy script component
        if(other.gameObject.CompareTag("Enemy")) //Check to see if we are hitting the enemy
        {
            enemy.TakeDamage(damage); //Run the TakeDamage function and apply damage to the enemy
        }
        Destroy(gameObject);// Destroy the game object
    }
}
