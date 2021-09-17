using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment3 : ProcessingLite.GP21 {

    //circle
    Vector2 pos = new Vector2(16, 10);
    float rad = 4;
    
    //movement
    Vector2 circleToMouse;
    Vector2 velocity;
    float devRad;

    void Start() {
        devRad = rad / 2;
    }

    void Update() { 
        Background(0, 0, 0);

        //Movement code
        if(Input.GetMouseButtonUp(0)) {
            //creates velocity
            float sqrtLength = (circleToMouse.x * circleToMouse.x) + (circleToMouse.y * circleToMouse.y);
            float length = Mathf.Sqrt(sqrtLength);
            if(length >= 5) {
                length = 5;
            }
            velocity = new Vector2(-(length * circleToMouse.x), -(length * circleToMouse.y));
        }


        //Teleport code
        if(Input.GetMouseButtonDown(0)) {
            //Changes vector pos to mouse pos.
            pos.x = MouseX;
            pos.y = MouseY;
        }


        if((pos.x + devRad) >= Width || (pos.x - devRad) <= 0) {
            velocity.x = -velocity.x;
        } else if((pos.y + devRad) >= Height || (pos.y - devRad) <= 0) {
            velocity.y = -velocity.y;
        }

        pos.x += velocity.x * Time.deltaTime;
        pos.y += velocity.y * Time.deltaTime;
        Circle(pos.x, pos.y, rad);

        //Make line
        //Pushed all this code down here so the line would be drawn above the circle (ugly code, works but needs fix)
        if(Input.GetMouseButton(0)) {
            Line(pos.x, pos.y, MouseX, MouseY);
            circleToMouse = new Vector2(pos.x - MouseX, pos.y - MouseY);
        }
    }



}
