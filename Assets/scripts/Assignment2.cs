using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21 {

    float startPointX = 0;
    float endPointY = 22;

    bool assignment = true;
    float spaceBetweenLines = 0.2f;
    float extaMathY;

    void Start() {
        Background(0, 0, 0);
    }

    void Update() {
        if(assignment == true) {
            if(Input.GetKey(KeyCode.C)) {
                assignment = false;
            }
            for(int i = 0; i < endPointY; i++) {
                startPointX += 2;
                endPointY -= 0.25f;
                if(startPointX % 3 == 1) {
                    Stroke(255, 0, 0);
                } else {
                    Stroke(0, 0, 255);
                }
                Line(startPointX, 0, 0, endPointY);
            }
        } else { 
            for(int i = 0; i < Height / spaceBetweenLines; i++) {
                Background(0, 0, 0);
                if (Input.GetKey(KeyCode.W)) {
                    float y = i * spaceBetweenLines;
                    extaMathY = y + Time.time;
                } else {
                    float y = i * spaceBetweenLines;
                    extaMathY = y - Time.time;
                }
                Line(0, extaMathY % Height, Width, extaMathY % Height);
            }
        }
    }
}
