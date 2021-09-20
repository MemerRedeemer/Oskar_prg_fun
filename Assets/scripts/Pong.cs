using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : ProcessingLite.GP21 {

    Vector2 circPos;
    float rad = 3;
    float devRad;
    float speedX, speedY;

    void Start() {
        circPos = new Vector2(Width / 2, Height / 2);
        speedX = 5;
        speedY = 3;
        devRad = rad / 2;
    }

    void Update() {
        Background(0, 0, 0);
        circPos.x += speedX * Time.deltaTime;
        circPos.y += speedY * Time.deltaTime;
        CPULine();
        PlayerInput();
        Ball();
    }

    void PlayerInput() {
        Line(4, (Height / 2) - 3, 4, (Height / 2) + 3);
    }

    void CPULine() {
        Line(Width - 4, circPos.y - 3, Width - 4, circPos.y + 3);
    }

    void Ball() {

        Circle(circPos.x, circPos.y, rad);
        if((circPos.x + devRad) >= (Width - 4)) {
            speedX = -speedX;
        }

        if((circPos.y + devRad) >= Height || (circPos.y - devRad) <= 0) {
            speedY = -speedY;
        }
    }
}
