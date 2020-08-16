using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    private LevelManager levelManager;

    private void Start()
    {
        levelManager = GameObject.FindObjectOfType<LevelManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        print("Collision");
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        levelManager.LoadSceneAsync("Lose");
        print("Trigger");
    }
}
