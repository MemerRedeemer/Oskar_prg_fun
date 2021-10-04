using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Player : ProcessingLite.GP21 {

    public Vector2 playerBall;
    public float playerDiameter = 2;
    float playerSpeed = 8;

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
