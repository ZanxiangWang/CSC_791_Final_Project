using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//simple code for refilling gas
public class refill : MonoBehaviour
{
    //take the player controller script sa variable
    public PlayerController carController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //by making the gas tank a trigger 
        //we can make event such as refilling the gas to full happen
        carController.gas = 100;
        //simply destroy the gas tank object after its triggered 
        //we do not want the game object still visable after triggering it after all
        Destroy(gameObject);
    }

}
