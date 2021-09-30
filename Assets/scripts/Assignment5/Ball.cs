using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Ball : ProcessingLite.GP21 {
    //Our class variables
    public Vector2 position; //Ball position
    Vector2 velocity; //Ball direction
    public float diameter;
    int Red;

    //Ball Constructor, called when we type new Ball(x, y);
    public Ball(float x, float y, float size, int randomR) {
        //Set our position when we create the code.
        position = new Vector2(x, y);
        diameter = size;
        Red = randomR;

        //Create the velocity vector and give it a random direction.
        velocity = new Vector2();
        velocity.x = Random.Range(-10f, 10f);
        velocity.y = Random.Range(-10f, 10f);
    }

    //Draw our ball
    public void Draw() {
        Fill(Red, 0, 0);
        Circle(position.x, position.y, diameter);
        Fill(0, 0, 0);
    }

    //Update our ball
    //adding bounce
    public void UpdatePos() {
        if((position.x + (diameter / 2)) >= Width || (position.x - (diameter / 2) <= 0)) {
            velocity.x = -velocity.x;
        } else if((position.y + (diameter / 2)) >= Height || (position.y - (diameter / 2)) <= 0) {
            velocity.y = -velocity.y;
        }
        position += velocity * Time.deltaTime;
    }
}
