using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//a controller for the car which player controlls
public class PlayerController : MonoBehaviour
{
    //this is for the fillable gas tank
    public UnityEngine.UI.Image image;
    /*ridigbody2D for both of the car tires and the car body
      so it does not fall through*/
    public Rigidbody2D tire1;
    public Rigidbody2D tire2;
    public Rigidbody2D car;
    //the torque of the car when air borne
    public float torque = 30;
    //speed of the car
    public float speed = 150;
    //amount of gas
    public float gas = 100;
    //the rate of consumtion for the car
    public float consumRate = 0.1f;

    //input for car movement going left or right
    private float carMovement;

    // Update is called once per frame
    void Update()
    {
        //assign input for car movement left and right for "A", "D", "Left Arrow Key", and "Right Arrow Key"
        carMovement = Input.GetAxis("Horizontal");
        //fillable object gas tank so the image of the tank will be deplet or replenish base on the gas amount 
        image.fillAmount = gas;
    }

    void FixedUpdate()
    {
        //decrease the gas value base on the consumation rate
        gas -= consumRate * Mathf.Abs(carMovement) * Time.fixedDeltaTime;
        //a if statement making sure the car only has power with gas is not 0
        if (gas > 0)
        {
            car.AddTorque(carMovement * torque * Time.fixedDeltaTime);
            tire1.AddTorque(carMovement * speed * Time.fixedDeltaTime);
            tire2.AddTorque(carMovement * speed * Time.fixedDeltaTime);

        }     
    }
}
