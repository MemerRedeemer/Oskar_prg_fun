using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21 {

    //background color
    int backgroundRed, backgroundGreen, backgroundBlue;
    
    //circle
    Vector2 pos = new Vector2(16, 10);
    float rad = 4;
    
    //movement
    Vector2 circleToMouse;
    Vector2 velocity;
    float devRad;
    float maxSpeed = 5;

    void Start() {
        devRad = rad / 2;
    }

    void Update() { 
        Background(backgroundRed, backgroundGreen, backgroundBlue);
        Border();

        //Movement code
        if(Input.GetMouseButtonUp(0)) {
            Movement();
        }

        //Teleport code
        if(Input.GetMouseButtonDown(0)) {
            Teleport();
        }

        pos.x += velocity.x * Time.deltaTime;
        pos.y += velocity.y * Time.deltaTime;
        Circle(pos.x, pos.y, rad);

        //Make line
        //Pushed all this code down here so the line would be drawn above the circle (ugly code, works but needs fix)
        if(Input.GetMouseButton(0)) {
            MakeLine();
        }
    }

    void Movement() {
        //creates velocity
        float length = circleToMouse.magnitude;
        if(length >= maxSpeed) {
            length = maxSpeed;
        }
        velocity = new Vector2(-(length * circleToMouse.x), -(length * circleToMouse.y));
    }

    void Teleport() {
        //Changes vector pos to mouse pos.
        pos.x = MouseX;
        pos.y = MouseY;
    }

    void MakeLine() {
        Line(pos.x, pos.y, MouseX, MouseY);
        circleToMouse = new Vector2(pos.x - MouseX, pos.y - MouseY);
    }

    void Border() {
        if((pos.x + devRad) >= Width || (pos.x - devRad) <= 0) {
            backgroundBlue = Random.Range(0, 255);
            backgroundGreen = Random.Range(0, 255);
            backgroundRed = 0;
            Fill(backgroundRed, backgroundBlue, backgroundGreen);
            velocity.x = -velocity.x;
        } else if((pos.y + devRad) >= Height || (pos.y - devRad) <= 0) {
            backgroundRed = Random.Range(0, 255);
            backgroundGreen = Random.Range(0, 255);
            backgroundBlue = 0;
            Fill(backgroundBlue, backgroundGreen, backgroundRed);
            velocity.y = -velocity.y;
        }
    }

}
