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

    //Abstract Shapes
    float circPosX = 2;
    float circPosY = 8;
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
            Mfloat += 0.06f;
        } else if (Input.GetKey(KeyCode.U)) {

        } else if (Input.GetKey(KeyCode.P)) {
            P01floatX = 2.5f;
            P01CircFloatY = -2;
        }

        if (Mfloat >= 6.5f) {
            Mfloat = 10;
        } else if (Mfloat >= 0.04f) {
            Mfloat -= 0.04f;
        } 
        
    }

    void LetterM() {
        //Start(x, y), End(x, y)
        Line(2, Mfloat + 7, 2, Mfloat + 3);
        Line(2, Mfloat + 7, 4, Mfloat + 3);
        Line(4, Mfloat + 3, 6, Mfloat + 7);
        Line(6, Mfloat + 7, 6, Mfloat + 3);
        Stroke(255, 255, 255);
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
        } else if(circSizeBool == false) {
            circSize -= 0.02f;
        }

        Stroke(255, 0, circBlueShift);
        Circle(circPosX, circPosY, circSize);



        Stroke(255, 255, 255);
    }

}
