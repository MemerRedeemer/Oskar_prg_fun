using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pong : ProcessingLite.GP21 {

    Vector2 circPos;
    Vector2 speed;
    Vector2 pullToBall;

    float rad = 1;
    float devRad;

    float cpuLineYStart, cpuLineYEnd;
    float playerLineStart, playerLineEnd;
    float lineSpeed = 3.5f;

    float inpSpeed = 4;
    float inputPosY;

    int playerScore, cpuScore;

    void Start() {
        circPos = new Vector2(Width / 2, Height / 2);
        pullToBall = new Vector2(Width - 4, circPos.y);
        float randomStartY = Random.Range(-3, 3);
        speed = new Vector2(6, randomStartY);
        playerScore = 2;
        devRad = rad / 2;
    }

    void Update() {
        Background(0, 0, 0);
        //Top,Bottom border
        Line(0, 0, Width, 0);
        Line(0, Height, Width, Height);

        //Ball movement
        circPos.x += speed.x * Time.deltaTime;
        circPos.y += speed.y * Time.deltaTime;
        
        //CPU Line movement
        if(pullToBall.y < circPos.y) {
            pullToBall.y +=  lineSpeed * Time.deltaTime;
        }
        if(pullToBall.y > circPos.y) {
            pullToBall.y -=  lineSpeed * Time.deltaTime;
        }

        ScoreCPU();
        ScorePlayer();
        MidLine();
        CPULine();
        PlayerInput();
        Ball();
    }

    void ScorePlayer() {
        //Player
        Stroke(0, 0, 255);
        if(playerScore == 1) {
            //1
            Line((Width / 2) - 5, (Height / 2) + 3, (Width / 2) - 5, (Height / 2) + 9);
        } else if (playerScore == 2) {
           //2

        } else if (playerScore == 3) {
            //3
            Line((Width / 2) - 5, (Height / 2) + 3, (Width / 2) - 5, (Height / 2) + 9);
            Line((Width / 4), (Height / 2) + 3, (Width / 2) - 5, (Height / 2) + 3);
            Line((Width / 4), (Height / 2) + 6, (Width / 2) - 5, (Height / 2) + 6);
            Line((Width / 4), (Height / 2) + 9, (Width / 2) - 5, (Height / 2) + 9);
        } else {
            //Zero
            Text("0", Width / 2 - 5, Height / 2 + 5); 
        }
        Stroke(255, 255, 255);
    }

    void ScoreCPU() {
        Stroke(255, 0, 0);
        if(cpuScore == 1) {
            //1
            Line((Width / 2) + 5, (Height / 2) + 3, (Width / 2) + 5, (Height / 2) + 9);
        } else if(cpuScore == 2) {
            //2
        } else if(cpuScore == 3) {
            //3
            Line((Width / 2) + 8.8f, (Height / 2) + 3, (Width / 2) + 8.8f, (Height / 2) + 9);
            Line((Width / 2) + 8.8f, (Height / 2) + 3, (Width / 2) + 5, (Height / 2) + 3);
            Line((Width / 2) + 8.8f, (Height / 2) + 6, (Width / 2) + 5, (Height / 2) + 6);
            Line((Width / 2) + 8.8f, (Height / 2) + 9, (Width / 2) + 5, (Height / 2) + 9);
        } else {
            //Zero
            Line((Width / 2) + 5, (Height / 2) + 3, (Width / 2) + 5, (Height / 2) + 9);
            Line((Width / 2) + 8.8f, (Height / 2) + 3, (Width / 2) + 8.8f, (Height / 2) + 9);
            Line((Width / 2) + 8.8f, (Height / 2) + 3, (Width / 2) + 5, (Height / 2) + 3);
            Line((Width / 2) + 8.8f, (Height / 2) + 9, (Width / 2) + 5, (Height / 2) + 9);
        }
        Stroke(255, 255, 255);
    }

    void MidLine() {
        //Dotted midline
        float middleOfScreen = Width / 2;
        for(int i = 0; i < Height; i++) {
            Line(middleOfScreen, i, middleOfScreen, i + 0.75f);
        }
    }

    void PlayerInput() {
        inputPosY += Input.GetAxis("Vertical") * Time.deltaTime * inpSpeed;
        playerLineStart = inputPosY + (Height / 2) - 3;
        playerLineEnd = inputPosY + (Height / 2) + 3;
        Line(4, playerLineStart, 4, playerLineEnd);
    }

    void CPULine() {
        cpuLineYStart = pullToBall.y - 3;
        cpuLineYEnd = pullToBall.y + 3;
        Line(pullToBall.x, cpuLineYStart , pullToBall.x, cpuLineYEnd);
    }

    void Ball() {
        //Bounce of CPU
        if((circPos.y + devRad) > cpuLineYStart && (circPos.y - devRad) < cpuLineYEnd) {
            if((circPos.x + devRad) >= (Width - 4)) {
                speed.x += 1;
                speed.x = -speed.x;
            }
        }

        //Bounce of player
        if((circPos.y + devRad) > playerLineStart && (circPos.y - devRad) < playerLineEnd) {
            if((circPos.x - devRad) <= 4) {
                speed.x -= 1;
                speed.x = -speed.x;
            }
        }

        //Bounce of walls
        if((circPos.y + devRad) >= Height || (circPos.y - devRad) <= 0) {
            speed.y = -speed.y;
        }
        
        //Win.Lose
        if((circPos.x - devRad) <= 2) {
            Lose();
        }
        if((circPos.x + devRad) >= (Width - 2)) {
            Win();
        }

        //Draw circle
        Fill(255, 255, 255);
        Circle(circPos.x, circPos.y, rad);
        Fill(0, 0, 0);
    }

    void Win() {
        playerScore += 1;
        if(playerScore == 3) {
            //Win text right here
        }
        Start();
    }

    void Lose() {
        cpuScore += 1;
        if(cpuScore == 3) { 
            //Lose text right here
        }
        Start();
    }
}
