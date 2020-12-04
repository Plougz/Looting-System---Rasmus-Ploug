using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeastProperties : MonoBehaviour
{
    public GameObject killText;
    public GameObject lootText;
    public GameObject prText;
    GameObject player;
    public Inventory inventory;


    public List<string> Loot;
    public bool isDead = false;
    public bool isLooted = false;
    float DespawnTimer = 5;
    bool doOnce = false;

    float amountOfLoot;
    public float avaliableLoot;
    bool PaidRespects = false;

    string item;

    private void Awake() {
        killText = GameObject.Find("Kill");
        lootText = GameObject.Find("Loot");
        prText = GameObject.Find("PayRespects");
        player = GameObject.Find("Player");
        inventory = GameObject.Find("Player").GetComponent<Inventory>();
    }
    private void Update() {
        Kill();
        DeathAnimation();
    }
    void Kill() {

        if (inventory.Distance() <= 5 && !isDead) {
            killText.SetActive(true);

            if (Input.GetKeyDown(KeyCode.Alpha1)) {
                isDead = true;
                AmountOfLoot();
                avaliableLoot = amountOfLoot;
                if (avaliableLoot == 0f) {
                    isLooted = true;
                } else {
                    FindLoot();
                    isLooted = false;
                }
            }
        } else {
            killText.SetActive(false);
        }


        if (!PaidRespects) {
            prText.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F)) {
            prText.SetActive(false);
            PaidRespects = true;
        }
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
        Debug.Log(randomNumber);
        return amountOfLoot;
    }
    public List<string> FindLoot() {
        float randomNumber;
        float i = 0;


        while (i < avaliableLoot) {
            randomNumber = Random.Range(1, 10001);
            bool addItem = true;
            Debug.Log(randomNumber);


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

        Destroy(gameObject);
    }
}
