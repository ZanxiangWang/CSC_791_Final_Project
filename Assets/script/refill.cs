using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class refill : MonoBehaviour
{
    public PlayerController carController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        carController.gas = 1;
        Destroy(gameObject);
    }

}
