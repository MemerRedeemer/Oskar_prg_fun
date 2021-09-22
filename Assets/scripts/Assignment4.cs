using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment4 : ProcessingLite.GP21 {

    Vector2 velPos;
    Vector2 acsPos;
    Vector2 wrapPos;
    Vector2 acceleration = new Vector2(0, 0);

    float acsDecSpeed = 0.025f;
    float acsIncSpeed = 0.1f;

    float diameter = 3;
    float speed = 10;
    float maxSpeed;
    float radie;

    bool gravitySwitch = false;
    float gravity = 9.82f;

    void Start() {
        velPos = new Vector2(Width / 2, Height / 2);
        acsPos = new Vector2(Width / 2, Height / 3);
        radie = diameter / 2;
    }

    void Update() {
        Background(0, 0, 0);

        //Velocity Circle
        BallNR1();
        //Acceleration Circle
        BallNR2();
        BorderWrap01();
        BorderWrap02();
        Gravity();
    }

    void Gravity() {
        if(Input.GetKeyUp(KeyCode.G)) {
            if(gravitySwitch == false) {
                gravitySwitch = true;
            } else {
                gravitySwitch = false;
            }
        }
        if(gravitySwitch == true) {
            if((velPos.y - radie) >= 0.1f) {
                velPos.y -= gravity * Time.deltaTime;
            } else {
                velPos.y = 0.1f + radie;
            }
            if((acsPos.y - radie) >= 0.1f) {
                acsPos.y -= gravity * Time.deltaTime;
            } else {
                acsPos.y = 0.1f + radie;
            }
        }
    }

    void BorderWrap02() {
        Stroke(255, 0, 0);
        //Left border Temp Circle
        if((acsPos.x - radie) <= 0) {
            wrapPos = new Vector2(Width + acsPos.x, acsPos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
            //Right border Temp Circle
        }
        if((acsPos.x + radie) >= Width) {
            wrapPos = new Vector2(acsPos.x - Width, acsPos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
            //Bottom border temp circle
        }
        if((acsPos.y - radie) <= 0) {
            wrapPos = new Vector2(acsPos.x, Height + acsPos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
            //Top border temp circle
        }
        if((acsPos.y + radie) >= Height) {
            wrapPos = new Vector2(acsPos.x, acsPos.y - Height);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        //Left border switch (telport main circle to temp circle)
        if((acsPos.x + radie) <= 0 || (acsPos.x - radie) >= Width || (acsPos.y + radie) <= 0 || (acsPos.y - radie) >= Height) {
            acsPos.x = wrapPos.x;
            acsPos.y = wrapPos.y;
        }
        Stroke(255, 255, 255);
    }

    void BorderWrap01() {
        //Left border Temp Circle
        if((velPos.x - radie) <= 0) {
            wrapPos = new Vector2(Width + velPos.x, velPos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
            //Right border Temp Circle
        }
        if((velPos.x + radie) >= Width) {
            wrapPos = new Vector2(velPos.x - Width, velPos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
            //Bottom border temp circle
        } 
        if((velPos.y - radie) <= 0) {
            wrapPos = new Vector2(velPos.x, Height + velPos.y);
            Circle(wrapPos.x, wrapPos.y, diameter);
            //Top border temp circle
        } 
        if((velPos.y + radie) >= Height) {
            wrapPos = new Vector2(velPos.x, velPos.y - Height);
            Circle(wrapPos.x, wrapPos.y, diameter);
        }

        //Left border switch (telport main circle to temp circle)
        if((velPos.x + radie) <= 0 || (velPos.x - radie) >= Width || (velPos.y + radie) <= 0 || (velPos.y - radie) >= Height)  {
            velPos.x = wrapPos.x;
            velPos.y = wrapPos.y;
        }
    }

    void BallNR1() {
        velPos.x += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        velPos.y += Input.GetAxis("Vertical") * Time.deltaTime * speed;
        Stroke(255, 255, 255);
        Circle(velPos.x, velPos.y, diameter);
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
            //Decelatrion
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
        if(acceleration.magnitude > 0.2f) {
            acceleration = acceleration.normalized * 0.2f;
        }
        Debug.Log(acceleration);
        acsPos.x += acceleration.x;
        acsPos.y += acceleration.y;
        Stroke(255, 0, 0);
        Circle(acsPos.x, acsPos.y, diameter);
        Stroke(255, 255, 255);
    }
}
