using UnityEngine;

public class Assignment1 : ProcessingLite.GP21
{
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


    void FixedUpdate() {
        Background(0, 0, 0);
        AbstractShape();
        LetterM();
        Mswallow();
        LetterU();
        LetterP01();
        LetterP02();
        LetterE();
        LetterT();

        if (circBlueShift == 255) {
            circBlueBool = false;
        } else if (circBlueShift == 0) {
            circBlueBool = true;
        } 

        if (circSize <= 1) {
            circSizeBool = true;
        } else if (circSize >= 3) {
            circSizeBool = false;
        }

        if (Input.GetKey(KeyCode.M)) {
            Mfloat += 0.1f;
            swallowColorShift += 4;
        } else if (Input.GetKey(KeyCode.U)) {

        } else if (Input.GetKey(KeyCode.P)) {
            P01floatX = 2.5f;
            P01CircFloatY = -2;
        }

        if (Mfloat >= 7f) {
            Mfloat = 25;
            swallowColorStuck = true;
        } else if (Mfloat >= 0.04f) {
            Mfloat -= 0.04f;
        }

        if (circPosX >= 32) {
            circMoveWidth = false;
        } else if (circPosX <= 3) {
            circMoveWidth = true;
        }

        if (circPosY >= 18) {
            circMoveHeight = false;
        } else if (circPosY <= 2.9) {
            circMoveHeight = true;
        }

        if(swallowColorStuck == false) {
            if(swallowColorShift >= 1) {
                swallowColorShift -= 2;
            } else if(swallowColorShift <= 2) {
                swallowColorShift = 2;
            }
        } else if (swallowColorStuck == true) {
            swallowColorShift = 0;
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

    void AbstractShape() {
        if (circBlueBool == true) {
            circBlueShift += 1;
        } else if (circBlueBool == false) {
            circBlueShift -= 1;
        }

        if (circSizeBool == true) {
            circSize += 0.02f;
        } else if (circSizeBool == false) {
            circSize -= 0.02f;
        }

        if (circMoveWidth == true) {
            circPosX += 0.1f;
        } else if (circMoveWidth == false) {
            circPosX -= 0.1f;
        }

        if (circMoveHeight == true) {
            circPosY += 0.1f;
        } else if (circMoveHeight == false) {
            circPosY -= 0.1f;
        }

        Stroke(255, 0, circBlueShift);
        Circle(circPosX, circPosY, circSize);



        Stroke(255, 255, 255);
    }

}