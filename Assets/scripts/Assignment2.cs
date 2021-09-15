using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment2 : ProcessingLite.GP21 {

    float startPointX = 1;
    float endPointY = 19;

    void Start() {
        Background(0, 0, 0);
    }

    void Update() {
        for(int i = 0; i < endPointY; i++) {
            startPointX += 1;
            endPointY -= 1;
            Line(startPointX, 1, 1, endPointY);
        }
    }
}
