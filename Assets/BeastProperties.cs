using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastProperties : MonoBehaviour
{
    public List<string> Loot;
    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool isLooted;
    [HideInInspector] public float amountOfLoot;
    [HideInInspector] public float avaliableLoot;

    string item;
    bool doOnce = false;
    float DespawnTimer = 5;

    private void Update() {
        DeathAnimation();
    }

    public float AmountOfLoot() {
        float randomNumber;

        randomNumber = Random.Range(1, 11);

        if (randomNumber == 1) {
            amountOfLoot = 0f;
        }
        if (randomNumber == 2 || randomNumber == 3 || randomNumber == 4 || randomNumber == 5) {
            amountOfLoot = 1f;
        }
        if (randomNumber == 6 || randomNumber == 7 || randomNumber == 8 || randomNumber == 9) {
            amountOfLoot = 2f;
        }
        if (randomNumber == 10) {
            amountOfLoot = 3f;
        }
        return amountOfLoot;
    }
    public List<string> FindLoot() {
        float randomNumber;
        float i = 0;

        while (i < avaliableLoot) {
            randomNumber = Random.Range(1, 10001);
            bool addItem = true;


            if (randomNumber >= 1 && randomNumber <= 500) {
                item = "Small Diamond";
                i++;

            }
            else if (randomNumber >= 501 && randomNumber <= 1500) {
                item = "Intact Hide";
                i++;

            }
            else if (randomNumber >= 1501 && randomNumber <= 3500) {
                item = "Meat";
                i++;

            }
            else if (randomNumber >= 3501 && randomNumber <= 7500) {
                item = "Big Bone";
                i++;

            }
            else {
                addItem = false;
            }

            if (addItem) {
                Loot.Add(item);
            }


        }
        return Loot;
    }


    void DeathAnimation() {
        if (isDead && !doOnce) {
            transform.eulerAngles = new Vector3(
                transform.eulerAngles.x,
                transform.eulerAngles.y,
                transform.eulerAngles.z - 90);
            doOnce = true;
        }
        if (isDead && isLooted) {
            Invoke("Despawn", DespawnTimer);
        }
    }
    void Despawn() {
        gameObject.SetActive(false);
    }
}
