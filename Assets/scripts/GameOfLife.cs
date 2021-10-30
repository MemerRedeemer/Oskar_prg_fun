using UnityEngine;

public class GameOfLife:ProcessingLite.GP21 {
    GameCell[,] cells;
    int numberOfColums;
    int numberOfRows;
    float cellSize = 1;
    int spawnChancePercentage = 15;
    int tempX, tempY;
    int aliveDetect;
    bool pause = true;

    float cameraSizeMax;

    void Start() {
        Fill(255, 255, 255);

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
        cameraSizeMax = Camera.main.orthographicSize;

        //Width
        numberOfRows = (int)Mathf.Ceil(Width);
        //Height
        numberOfColums = (int)Mathf.Ceil(Height);
        //Initialize cell array
        cells = new GameCell[numberOfRows, numberOfColums];
        //Make cells
        for(int y = 0; y < numberOfColums; y++) {
            for(int x = 0; x < numberOfRows; x++) {
                cells[x, y] = new GameCell(x, y, cellSize);
            }
        }
    }

    void Update() {
        Background(0, 0, 0);
        //Rutnät 
        if(pause) {
            Stroke(255, 255, 255, 100);
            for(int y = 0; y < numberOfColums; y++) {
                Line(0, y, numberOfRows, y);
            }
            for(int x = 0; x < numberOfRows; x++) {
                Line(x, 0, x, numberOfColums);
            }
        }

        //Mouse
        if(Input.GetMouseButton(0) && (int)MouseX > 0 && (int)MouseX < numberOfRows && (int)MouseY > 0 && (int)MouseY < numberOfColums) {
            cells[(int)MouseX, (int)MouseY].colorR = 255;
            cells[(int)MouseX, (int)MouseY].colorG = 255;
            cells[(int)MouseX, (int)MouseY].colorB = 255;
            cells[(int)MouseX, (int)MouseY].nextGen = true;
        } else if(Input.GetMouseButton(1) && (int)MouseX > 0 && (int)MouseX < numberOfRows && (int)MouseY > 0 && (int)MouseY < numberOfColums) {
            cells[(int)MouseX, (int)MouseY].nextGen = false;
        }

        //Pause/Play
        if(Input.GetKeyDown(KeyCode.Space)) {
            if(pause) {
                Application.targetFrameRate = 4;
                pause = false;
            } else {
                Application.targetFrameRate = 60;
                pause = true;
            }
        }

        if(Input.GetAxis("Mouse ScrollWheel") < 0 && Camera.main.orthographicSize < cameraSizeMax) {
            Camera.main.orthographicSize += 0.5f;
        } else if(Input.GetAxis("Mouse ScrollWheel") > 0 && Camera.main.orthographicSize > 1) {
            Camera.main.orthographicSize -= 0.5f;
        }

        Stroke(255, 0, 0);
        if(!pause) {
            //Bollchecker
            for(int y = 0; y < numberOfColums; y++) {
                for(int x = 0; x < numberOfRows; x++) {
                    //++Cell alive detection
                    for(int j = -1; j < 2; j++) {
                        if(x + j > 0 && x + j < numberOfRows && y + 1 < numberOfColums) {
                            if(cells[x + j, y + 1].alive) {
                                aliveDetect++;
                            }
                        }
                    }

                    for(int j = -1; j < 2; j++) {
                        if(x + j > 0 && x + j < numberOfRows && y - 1 > 0) {
                            if(cells[x + j, y - 1].alive) {
                                aliveDetect++;
                            }
                        }
                    }

                    if(x - 1 > 0) {
                        if(cells[x - 1, y].alive) {
                            aliveDetect++;
                        }
                    }

                    if(x + 1 < numberOfRows) {
                        if(cells[x + 1, y].alive) {
                            aliveDetect++;
                        }
                    }
                    //--Cell alive detection

                    //Rules
                    if(aliveDetect == 3) {
                        cells[x, y].nextGen = true;
                    } else if(aliveDetect == 2 && cells[x, y].alive == true) {
                        cells[x, y].nextGen = true;
                    } else {
                        cells[x, y].nextGen = false;
                    }
                    aliveDetect = 0;

                    //Generation Color
                    if(cells[x, y].alive == true) {
                        if(cells[x, y].colorB > 0) {
                            cells[x, y].colorB -= 32;
                        } else if(cells[x, y].colorB <= 0 && cells[x, y].colorG > 0) {
                            cells[x, y].colorG -= 32;
                        }
                    } else {
                        cells[x, y].colorR = 255;
                        cells[x, y].colorG = 255;
                        cells[x, y].colorB = 255;
                    }
                }
            }
        }

        //Bollupdate
        for(int y = 0; y < numberOfColums; y++) {
            for(int x = 0; x < numberOfRows; x++) {
                Stroke(Mathf.Clamp(cells[x, y].colorR, 0, 255), Mathf.Clamp(cells[x, y].colorG, 0, 255), Mathf.Clamp(cells[x, y].colorB, 0, 255));
                Fill(Mathf.Clamp(cells[x, y].colorR, 0, 255), Mathf.Clamp(cells[x, y].colorG, 0, 255), Mathf.Clamp(cells[x, y].colorB, 0, 255));
                cells[x, y].alive = cells[x, y].nextGen;
                cells[x, y].Draw();
            }
        }
    }
}

public class GameCell:ProcessingLite.GP21 {
    float size;
    public float x;
    public float y;
    public int colorR = 255, colorG = 255, colorB = 255;

    public bool alive = false;
    public bool nextGen = false;

    public GameCell(float x, float y, float size) {
        this.x = x + size / 2;
        this.y = y + size / 2;
        this.size = size / 2;
    }

    public void Draw() {
        if(alive) {
            Circle(x, y, size);
        }
    }
}