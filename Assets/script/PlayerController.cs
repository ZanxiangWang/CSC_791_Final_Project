using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public UnityEngine.UI.Image image;
    public Rigidbody2D tire1;
    public Rigidbody2D tire2;
    public Rigidbody2D car;
    public float torque = 30;
    public float speed = 150;
    public float gas = 1;
    public float consumRate = 0.1f;

    private float carMovement;

    // Update is called once per frame
    void Update()
    {
        carMovement = Input.GetAxis("Horizontal");
        image.fillAmount = gas;
    }

    void FixedUpdate()
    {
        if (gas > 0)
        {
            car.AddTorque(carMovement * torque * Time.fixedDeltaTime);
            tire1.AddTorque(carMovement * speed * Time.fixedDeltaTime);
            tire2.AddTorque(carMovement * speed * Time.fixedDeltaTime);

        }     

        gas -= consumRate * Mathf.Abs(carMovement) * Time.fixedDeltaTime;

    }
}
