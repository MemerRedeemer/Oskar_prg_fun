using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assignment5 : ProcessingLite.GP21 {

    public GameObject gameOverText;

    int numberOfBalls = 10;
    Ball[] balls;
    Player playerConnect;

    void Start() {
        playerConnect = new Player();
        playerConnect.CreateVector();
        balls = new Ball[numberOfBalls];
        for(int i = 0; i < balls.Length; i++) {
            float randomSize = Random.Range(1, 2.5f);
            Vector2 randomPos = new Vector2(Random.Range(3, 20), Random.Range(4, 16));
            int randomRed = Random.Range(125, 255);
            balls[i] = new Ball(randomPos.x, randomPos.y, randomSize, randomRed);
        }
    }

    void Update() {
        Background(0, 0, 0);

        playerConnect.PlayerMovement();

        for(int i = 0; i < balls.Length; i++) {
            balls[i].UpdatePos();
            balls[i].Draw();

            bool hit = CircleCollision(
                balls[i].position.x, 
                balls[i].position.y, 
                balls[i].diameter, 
                playerConnect.playerBall.x, 
                playerConnect.playerBall.y, 
                playerConnect.playerDiameter);

            if(hit) {
                gameOverText.SetActive(true);
            }
        }



    }
    public bool CircleCollision(float x1, float y1, float size1, float x2, float y2, float size2) {

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

class Player : ProcessingLite.GP21 {

    public Vector2 playerBall;
    public float playerDiameter = 2;
    float playerSpeed = 5;

    public void PlayerMovement() {
        Stroke(0, 0, 255);
        playerBall.x += Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        playerBall.y += Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        Circle(playerBall.x, playerBall.y, playerDiameter);
        Stroke(255, 255, 255);
    }

    public void CreateVector() {
        playerBall = new Vector2((Width / 2), (Height / 2));
    }

}