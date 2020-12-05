using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour {
    public List<GameObject> ListOfEnemies;


    private void Awake() {
        foreach (GameObject enemy in GameObject.FindGameObjectsWithTag("Enemy")) {
            ListOfEnemies.Add(enemy);
        }
    }
}
