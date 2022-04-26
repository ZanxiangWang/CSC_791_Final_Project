using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform Player;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 offset = new Vector3(Player.position.x, Player.position.y, transform.position.z);
        transform.position = offset;
    }
}
