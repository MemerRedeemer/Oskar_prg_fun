using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21 {

    public GameObject gameOverText;

    Ball[] balls;
    Player playerConnect;
    Vector2 spawnpoint;

    int ballRender;
    float targetTime = 5;

    void Start() {
        ballRender = 4;
        gameOverText.SetActive(false);
        spawnpoint = new Vector2(Width / 2, Height / 2);
        playerConnect = new Player();
        playerConnect.CreateVector();
        balls = new Ball[100];
        for(int i = 0; i < balls.Length; i++) {
            float randomSize = Random.Range(1, 2.5f);
            Vector2 randomPos = new Vector2(Random.Range(randomSize, Width - randomSize), Random.Range(randomSize, Height - randomSize));
            int randomRed = Random.Range(125, 255);
            balls[i] = new Ball(randomPos.x, randomPos.y, randomSize, randomRed);
        }
    }
    void Update() {
        Background(0, 0, 0);

        if(Input.GetKeyUp(KeyCode.R)) {
            Start();
        }

        playerConnect.PlayerMovement();

        for(int x = 0; x < ballRender; x++) {
            balls[x].UpdatePos();
            balls[x].Draw();

            bool hit = CircleCollision(
                balls[x].position.x, 
                balls[x].position.y, 
                balls[x].diameter, 
                playerConnect.playerBall.x, 
                playerConnect.playerBall.y, 
                playerConnect.playerDiameter);

            if(hit) {
                gameOverText.SetActive(true);
            }
        }

        targetTime -= Time.deltaTime;
        if(targetTime <= 0) {
            ballRender += 1;
            targetTime = 3;
        }

    }

    void SpawnCheck(float x1, float y1, float x2, float y2) {
        


    }

    bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2) {

        float maxDistance = (size1 + size2) / 2;

        if(Mathf.Abs(x1 - x2) > maxDistance || Mathf.Abs(y1 - y2) > maxDistance) {
            return false;
        } else if(Vector2.Distance(new Vector2(x1, y1), new Vector2(x2, y2)) > maxDistance) {
            return false;
        } else {
            return true;
        }
    }
}