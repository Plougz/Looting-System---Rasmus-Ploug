using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<string> PlayerBag;
    public Enemies enemies;
    BeastProperties enemy;
    
    void Awake()
    {
        enemy = GameObject.Find("Beast").GetComponent<BeastProperties>();
        enemies = GameObject.Find("GameManager").GetComponent<Enemies>();

    }


    void Update()
    {
        Looting();
    }
    void Looting() {
        if (Distance() <= 5 && enemy.isDead) {
            if (!enemy.isLooted) {
                enemy.lootText.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E)) {

                    if (enemy.avaliableLoot > 0) {
                        enemy.FindLoot();
                    }   
                    enemy.isLooted = true;
                    enemy.lootText.SetActive(false);
                }
            } else if (enemy.isLooted) {
                enemy.lootText.SetActive(false);
            }


        } else {
            enemy.lootText.SetActive(false);
            enemy.prText.SetActive(false);
        }
    }
    public float Distance() {
        float dist;
        dist = Vector3.Distance(GetClosestEnemy().position, transform.position);

        return dist;
    }
    Transform GetClosestEnemy() {
        Transform ClosestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies.ListOfEnemies) {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                ClosestTarget = potentialTarget;
            }
        }
        return ClosestTarget;
    }

}
