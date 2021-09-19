using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21 {

    Vector2 velPos;
    Vector2 acsPos;
    Vector2 acceleration = new Vector2(0,0); 
    float rad = 3;
    float speed = 5;


    void Start() {
        velPos = new Vector2(Width / 2, Height / 2);
        acsPos = new Vector2(Width / 2, Height / 3);
    }

    void Update() {
        Background(0, 0, 0);

        //Velocity Circle
        velPos.x = velPos.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        velPos.y = velPos.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Stroke(255, 255, 255);
        Circle(velPos.x, velPos.y, rad);

        //Acceleration Circle
        if(Input.GetKey(KeyCode.D)) {
            acceleration.x += 0.2f * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.A)) {
            acceleration.x -= 0.2f * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.S)) {
            acceleration.y -= 0.2f * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.W)) {
            acceleration.y += 0.2f * Time.deltaTime;
        } else {
            if(acceleration.x >= 0) {
                acceleration.x -= 0.1f * Time.deltaTime;
            }
            if(acceleration.x <= 0) {
                acceleration.x += 0.1f * Time.deltaTime;
            }
            if(acceleration.y >= 0) {
                acceleration.y -= 0.1f * Time.deltaTime;
            }
            if(acceleration.y <= 0) {
                acceleration.y += 0.1f * Time.deltaTime;
            }
        }
        acsPos.x += acceleration.x;
        acsPos.y += acceleration.y;
        Stroke(255, 0, 0);
        Circle(acsPos.x, acsPos.y, rad);
    }
}
