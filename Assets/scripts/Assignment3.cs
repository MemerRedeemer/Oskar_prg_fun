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
    float speed = 0.5f;
    float devRad;

    void Start() {
        devRad = rad / 2;
    }

    void Update() { 
        Background(0, 0, 0);
        //Make line
        if(Input.GetMouseButton(0)) {
            Line(pos.x, pos.y, MouseX, MouseY);
            circleToMouse = new Vector2(pos.x - MouseX, pos.y - MouseY);
        }

        //Movement code
        if(Input.GetMouseButtonUp(0)) {
            //creates velocity
            velocity = new Vector2((speed * circleToMouse.x) * -1, (speed * circleToMouse.y) * -1);
            
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
        Debug.Log(pos.x + " " + pos.y);
    }



}
