using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21 {

    Vector2 velPos;
    Vector2 acsPos;
    Vector2 acceleration = new Vector2(0, 0);

    float acsDecSpeed = 0.025f;
    float acsIncSpeed = 0.1f;

    float rad = 3;
    float speed = 5;


    void Start() {
        velPos = new Vector2(Width / 2, Height / 2);
        acsPos = new Vector2(Width / 2, Height / 3);
    }

    void Update() {
        Background(0, 0, 0);

        //Velocity Circle
        BallNR1();
        //Acceleration Circle
        BallNR2();
    }

    void BallNR1() {
        velPos.x = velPos.x + Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        velPos.y = velPos.y + Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Stroke(255, 255, 255);
        Circle(velPos.x, velPos.y, rad);
    }

    void BallNR2() {
        if(Input.GetKey(KeyCode.D)) {
            acceleration.x += acsIncSpeed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.A)) {
            acceleration.x -= acsIncSpeed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.S)) {
            acceleration.y -= acsIncSpeed * Time.deltaTime;
        } else if(Input.GetKey(KeyCode.W)) {
            acceleration.y += acsIncSpeed * Time.deltaTime;
        } else {
            if(acceleration.x > 0) {
                acceleration.x -= acsDecSpeed * Time.deltaTime;
            }
            if(acceleration.x < 0) {
                acceleration.x += acsDecSpeed * Time.deltaTime;
            }
            if(acceleration.y > 0) {
                acceleration.y -= acsDecSpeed * Time.deltaTime;
            }
            if(acceleration.y < 0) {
                acceleration.y += acsDecSpeed * Time.deltaTime;
            }
        }
        if(acceleration.x >= 0.2f) {
            acceleration.x = 0.2f;
        }
        if(acceleration.x <= -0.2f) {
            acceleration.x = -0.2f;
        }
        if(acceleration.y >= 0.2f) {
            acceleration.y = 0.2f;
        }
        if(acceleration.y <= -0.2f) {
            acceleration.y = -0.2f;
        }
        acsPos.x += acceleration.x;
        acsPos.y += acceleration.y;
        Stroke(255, 0, 0);
        Circle(acsPos.x, acsPos.y, rad);
    }
}
