using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, Random.Range(-1f, 7f), transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement player = collision.GetComponent<PlayerMovement>();
        if(player != null)
        {
            player.PickCoin();
            Destroy(gameObject);
        }
    }
}
