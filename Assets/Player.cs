using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [HideInInspector] public BeastProperties ClosestEnemy;
    
    Enemies enemies;
    Inventory inv;

    void Awake() {
        enemies = GameObject.Find("GameManager").GetComponent<Enemies>();
        inv = GetComponent<Inventory>();
    }
    void Update() {
        ClosestEnemy = GetClosestEnemy().GetComponent<BeastProperties>();
        Looting();
        Kill();
    }

    void Kill() {
        if (DistanceToClosestTarget() <= 5 &&
           !ClosestEnemy.isDead &&
            Input.GetKeyDown(KeyCode.Alpha1)) {
                ClosestEnemy.isDead = true;
                ClosestEnemy.AmountOfLoot();
                ClosestEnemy.avaliableLoot = ClosestEnemy.amountOfLoot;
                if (ClosestEnemy.avaliableLoot == 0f) {
                    ClosestEnemy.isLooted = true;
                } else {
                    ClosestEnemy.FindLoot();
                    ClosestEnemy.isLooted = false;
                }
            }
        }
    void Looting() {
        if (DistanceToClosestTarget() <= 5 && 
            ClosestEnemy.isDead && 
           !ClosestEnemy.isLooted &&
            Input.GetKeyDown(KeyCode.E)) {
                inv.PlayerBag.AddRange(ClosestEnemy.Loot);
                ClosestEnemy.Loot.Clear();
                ClosestEnemy.isLooted = true;
        }
    } 
    

    public float DistanceToClosestTarget() {
        float dist;
        dist = Vector3.Distance(GetClosestEnemy().transform.position, transform.position);

        return dist;
    }
    public GameObject GetClosestEnemy() {
        GameObject ClosestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;

        foreach (GameObject potentialTarget in enemies.ListOfEnemies) {
            Vector3 directionToTarget = potentialTarget.transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                ClosestTarget = potentialTarget;
            }
        }
        return ClosestTarget;
    }
}

