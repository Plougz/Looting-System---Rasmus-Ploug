using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour {
    Player player;
    UI ui;

    [HideInInspector] public GameObject killText;
    [HideInInspector] public GameObject lootText;
    // Start is called before the first frame update
    void Awake() {
        player = GameObject.Find("Player").GetComponent<Player>();
        ui = GameObject.Find("GameManager").GetComponent<UI>();
        killText = GameObject.Find("Kill");
        lootText = GameObject.Find("Loot");


        killText.SetActive(false);
        lootText.SetActive(false);
    }
    private void Update() {
        ShowLootText();
        ShowKillText();
    }

    void ShowLootText() {
        if (player.DistanceToClosestTarget() <= 5 && player.ClosestEnemy.isDead) {
            if (!player.ClosestEnemy.isLooted) {
                ui.lootText.SetActive(true);
            } else if (player.ClosestEnemy.isLooted) {
                ui.lootText.SetActive(false);
            }
        } else {
            ui.lootText.SetActive(false);

        }
    }
    void ShowKillText() {
        if (player.DistanceToClosestTarget() <= 5 && !player.ClosestEnemy.isDead) {
            ui.killText.SetActive(true);
        } else {
            ui.killText.SetActive(false);
        }
    }
}
