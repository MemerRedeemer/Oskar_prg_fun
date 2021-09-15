using UnityEngine;

public class Assignment1 : ProcessingLite.GP21 {
    //Assignment variables
    float Mfloat;
    //P01 float variables
    float P01floatX;
    float P01floatY;
    float P01CircFloatY;

    //P02 float variables
    float P02floatX;
    float P02floatY;

    //Swallow M variables
    int swallowColorShift = 0;
    bool swallowColorStuck = false;

    //Abstract Shapes
    float circPosX = 2;
    float circPosY = 2;
    float circSize = 2;
    int circBlueShift = 0;
        //Circle Bools
        bool circMoveWidth;
        bool circMoveHeight;
        bool circSizeBool;
        bool circBlueBool = false;

    //Platformer variables
    bool platformerActivated = false;
    //Player Pos
    float playerx = 2;
    float playery = 2;
    float diameter = 2;

    bool shootBool = false;
    bool bulletTime = false;
    float tempPlayerPosX;
    float tempPlayerPosY;
    float tempEndPosX;
    float tempEndPosY;

    void FixedUpdate() {

        //Old Stuff
        if(platformerActivated == false) {
            Background(0, 0, 0);
            LetterM();
            Mswallow();
            LetterU();
            LetterP01();
            LetterP02();
            LetterE();
            LetterT();
            AbstractShape01();

            if(Input.GetKey(KeyCode.M)) {
                Mfloat += 0.1f;
                swallowColorShift += 4;
            } else if(Input.GetKey(KeyCode.P) && Input.GetKey(KeyCode.L) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.Y)) {
                platformerActivated = true;
            } else if(Input.GetKey(KeyCode.P)) {
                P01floatX = 2.5f;
                P01CircFloatY = -2;
            }

            if(circBlueShift == 255) {
                circBlueBool = false;
            } else if(circBlueShift == 0) {
                circBlueBool = true;
            }

            if(circSize <= 0) {
                circSizeBool = true;
            } else if(circSize >= 4) {
                circSizeBool = false;
            }

            if(circPosX >= 32) {
                circMoveWidth = false;
            } else if(circPosX <= 3) {
                circMoveWidth = true;
            }

            if(circPosY >= 18) {
                circMoveHeight = false;
            } else if(circPosY <= 2.9) {
                circMoveHeight = true;
            }

            if(Mfloat >= 7f) {
                Mfloat = 25;
                swallowColorStuck = true;
            } else if(Mfloat >= 0.04f) {
                Mfloat -= 0.04f;
            }

            if(swallowColorStuck == false) {
                if(swallowColorShift >= 1) {
                    swallowColorShift -= 2;
                } else if(swallowColorShift <= 2) {
                    swallowColorShift = 2;
                }
            } else if(swallowColorStuck == true) {
                swallowColorShift = 0;
            }
        } else {
            Background(0, 0, 0);
            Line(0, 0.5f, 36, 0.5f);
            Player01();
            if(shootBool == true) {
                tempPlayerPosX = playerx + 2;
                tempPlayerPosY = playery;
                tempEndPosX = tempPlayerPosX + 3; 
            } else {
                shootBool = false;
            }
        }
        
    }

    void Player01() {
        // x, y, diam
        if(Input.GetKey(KeyCode.D)) {
            playerx += 0.2f;
        } else if(Input.GetKey(KeyCode.A)) {
            playerx -= 0.2f;
        } else if(Input.GetKey(KeyCode.W)) {
            if(playery <= 17) {
                playery += 2f;
            }
        } else if(Input.GetKey(KeyCode.Space)) {
            shootBool = true;
        }else {
            if(playery >= 2.1f) {
                playery -= 0.5f;
            }
        }
        
        Circle(playerx, playery, diameter);
    }

    void Bullet() {
        if (bulletTime == true) {
            Line(tempPlayerPosX, tempPlayerPosY, tempEndPosX, tempPlayerPosY);
        }
    }

    void Mswallow() {
        Stroke(swallowColorShift, swallowColorShift, swallowColorShift);
        Rect(1.5f, 10, 6.5f, 14);
        Stroke(0, 0, 0);
        Rect(1.5f, 10.1f, 6.5f, 14);
        Stroke(swallowColorShift, swallowColorShift, swallowColorShift);
        Line(1.5f, 10, 1.5f, 8.95f);
        Line(6.5f, 10, 6.5f, 8.95f);
        Stroke(255, 255, 255);
    }

    void LetterM() {
        //Start(x, y), End(x, y)
        Stroke(swallowColorShift, swallowColorShift, swallowColorShift);
        Line(1.5f, 9, 6.5f, 9);
        Stroke(255, 255, 255);
        Line(2, Mfloat + 7, 2, Mfloat + 3);
        Line(2, Mfloat + 7, 4, Mfloat + 3);
        Line(4, Mfloat + 3, 6, Mfloat + 7);
        Line(6, Mfloat + 7, 6, Mfloat + 3);
    }

    void LetterU() {
        Circle(8, 4.5f, 3);
        Rect(9.5f, 7, 6.5f, 4.5f);
        Stroke(0,0,0);
        Line(6.55f, 7, 9.45f, 7);
        Line(6.55f, 4.5f, 9.45f, 4.5f);
        Stroke(255, 255, 255);
    }

    void LetterP01() {
        Circle(P01floatX + 11, P01CircFloatY + 6, 2);
        Rect(P01floatX + 10, P01CircFloatY + 7, P01floatX + 11, P01CircFloatY + 5);
        Line(P01floatX + 10, 7, P01floatX + 10, 3);
        Stroke(0, 0, 0);
        Line(P01floatX + 11, P01CircFloatY + 6.95f, P01floatX + 11, P01CircFloatY + 5.05f);
        Stroke(255, 255, 255);
    }

    void LetterP02() {
        Circle(13.5f, 6, 2);
        Rect(12.5f, 7, 13.5f, 5);
        Line(12.5f, 7, 12.5f, 3);
        Stroke(0, 0, 0);
        Line(13.5f, 6.95f, 13.5f, 5.05f);
        Stroke(255, 255, 255);
    }

    void LetterE() {
        Rect(15, 7, 17, 3);
        Line(15, 5, 17, 5);
        Stroke(0, 0, 0);
        Line(17, 6.95f, 17, 3.05f);
        Stroke(255, 255, 255);
    }

    void LetterT() {
        Line(19, 7, 19, 3);
        Line(17.5f, 7, 20.5f, 7);
    }

    void AbstractShape01() {
        //Bool for color shift
        if (circBlueBool == true) {
            circBlueShift += 1;
        } else if (circBlueBool == false) {
            circBlueShift -= 1;
        }
        //Bool for circle size
        if (circSizeBool == true) {
            circSize += 0.02f;
        } else if (circSizeBool == false) {
            circSize -= 0.02f;
        }
        //Bool for circle movement Horizontal
        if (circMoveWidth == true) {
            circPosX += 0.1f;
        } else if (circMoveWidth == false) {
            circPosX -= 0.1f;
        }
        //Bool for circle movement Vertical
        if (circMoveHeight == true) {
            circPosY += 0.1f;
        } else if (circMoveHeight == false) {
            circPosY -= 0.1f;
        }
        //Circle
        Stroke(255, -circBlueShift, circBlueShift);
        Fill(0, circBlueShift, -circBlueShift);
        Circle(circPosX, circPosY, circSize);


        Stroke(255, 255, 255);
        Fill(0, 0, 0);
    }
    

}