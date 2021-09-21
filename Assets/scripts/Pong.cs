using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : ProcessingLite.GP21 {

    Vector2 circPos;
    Vector2 speed;

    float rad = 2;
    float devRad;
    float cpuLineYStart, cpuLineYEnd;
    float playerLineStart, playerLineEnd;
    float pullToBall;

    float inpSpeed = 4;
    float inputPosY;

    void Start() {
        circPos = new Vector2(Width / 2, Height / 2);
        speed = new Vector2(6, 3);
        devRad = rad / 2;
    }

    void Update() {
        Background(0, 0, 0);
        //Top,Bottom border
        Line(0, 0, Width, 0);
        Line(0, Height, Width, Height);

        circPos.x += speed.x * Time.deltaTime;
        circPos.y += speed.y * Time.deltaTime;

        Score();
        MidLine();
        CPULine();
        PlayerInput();
        Ball();
    }

    void Score() {
        //fix this later,
        //Gonna be lots of code :c
    }

    void MidLine() {
        float middleOfScreen = Width / 2;
        for(int i = 0; i < Height; i++) {
            Line(middleOfScreen, i, middleOfScreen, i + 0.5f);
        }
    }

    void PlayerInput() {
        inputPosY += Input.GetAxis("Vertical") * Time.deltaTime * inpSpeed;
        playerLineStart = inputPosY + (Height / 2) - 3;
        playerLineEnd = inputPosY + (Height / 2) + 3;
        Line(4, playerLineStart, 4, playerLineEnd);
    }

    void CPULine() {
        cpuLineYStart = circPos.y - 3;
        cpuLineYEnd = circPos.y + 3;
        Line(Width - 4, cpuLineYStart , Width - 4, cpuLineYEnd);
    }

    void Ball() {
        //Bounce of CPU
        if((circPos.y + devRad) > cpuLineYStart && (circPos.y - devRad) < cpuLineYEnd && (circPos.x + devRad) >= (Width - 4)) { 
            speed.x += 1;
            speed.x = -speed.x;
            speed.y += Random.Range(-5, 5);
        }

        //Bounce of player
        if((circPos.y + devRad) > playerLineStart && (circPos.y - devRad) < playerLineEnd && (circPos.x - devRad) <= 4) {
            speed.x -= 1;
            speed.x = -speed.x;
            speed.y += Random.Range(-5, 5);
        }

        //Bounce of walls
        if((circPos.y + devRad) >= Height || (circPos.y - devRad) <= 0) {
            speed.y = -speed.y;
        } 
        //Lose
        if((circPos.x - devRad) <= 0) {
            Lose();
        }
        if((circPos.x + devRad) >= Width) {
            Win();
        }
        //Draw circle
        Circle(circPos.x, circPos.y, rad);
    }

    void Win() {
        Debug.Log("Win!");
    }

    void Lose() {
        Debug.Log("Lose!");
    }
}
