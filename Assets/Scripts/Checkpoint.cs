using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Player_Character player = collision.GetComponent<Player_Character>();
            player.SetCurrentCheckpoint(this);
        }
        else
        {

        }
    }
}
