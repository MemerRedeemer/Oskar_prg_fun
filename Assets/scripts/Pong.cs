using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : ProcessingLite.GP21 {

    Vector2 circPos;
    float rad = 3;
    float devRad;
    float speedX, speedY;

    float playerLineStart;
    float playerLineEnd;

    float inpSpeed = 4;
    float inputPosY;

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
        Debug.Log(speedX + ":" + speedY);
        CPULine();
        PlayerInput();
        Ball();
    }

    void PlayerInput() {
        inputPosY += Input.GetAxis("Vertical") * Time.deltaTime * inpSpeed;
        playerLineStart = inputPosY + (Height / 2) - 3;
        playerLineEnd = inputPosY + (Height / 2) + 3;
        Line(4, playerLineStart, 4, playerLineEnd);
    }

    void CPULine() {
        Line(Width - 4, circPos.y - 3, Width - 4, circPos.y + 3);
    }

    void Ball() {
        //Bounce of CPU
        if((circPos.x + devRad) >= (Width - 4)) {
            speedX += 1;
            speedX = -speedX;
        }

        //Bounce of player
        if((circPos.y + devRad) > playerLineStart && (circPos.y - devRad) < playerLineEnd && (circPos.x - devRad) <= 4) {
            speedX -= 1;
            speedX = -speedX;
        }

        //Bounce of walls
        if((circPos.y + devRad) >= Height || (circPos.y - devRad) <= 0) {
            speedY = -speedY;
        } 
        //Lose
        if((circPos.x - devRad) <= 0) {
            Debug.Log("LOSE!");
        }
        if((circPos.x + devRad) >= Width) {
            Debug.Log("WIN!");
        }
        //Draw circle
        Circle(circPos.x, circPos.y, rad);
    }
}
