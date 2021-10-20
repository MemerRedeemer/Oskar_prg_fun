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

	void Start() {
		Fill(255, 255, 255);

		QualitySettings.vSyncCount = 0;
		Application.targetFrameRate = 4;

		//Width
		numberOfRows = (int)Mathf.Ceil(Width);
		//Height
		numberOfColums = (int)Mathf.Ceil(Height);

		cells = new GameCell[numberOfRows, numberOfColums];

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
			Stroke(0, 255, 0);
		} else {
			Stroke(255, 255, 255, 100);
		}


		for(int y = 0; y < numberOfColums; y++) {
			Line(0, y, numberOfRows, y);
		}
		for(int x = 0; x < numberOfRows; x++) {
			Line(x, 0, x, numberOfColums);
		}

		//Mouse
		if(Input.GetMouseButton(0)) {
			if(cells[(int)MouseX, (int)MouseY].nextGen) {
				cells[(int)MouseX, (int)MouseY].nextGen = false;
			} else {
				cells[(int)MouseX, (int)MouseY].nextGen = true;
			}
		}
		
		//Pause/Play
		if(Input.GetKey(KeyCode.Space)) {
			if(pause) {
				pause = false;
			} else {
				pause = true;
			}
		}

		Stroke(255, 0, 0);
		if(!pause) {
			//Bollchecker
			for(int y = 0; y < numberOfColums; y++) {
				for(int x = 0; x < numberOfRows; x++) {

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


					if(aliveDetect == 3) {
						cells[x, y].nextGen = true;
						aliveDetect = 0;
					} else if(aliveDetect == 2 && cells[x, y].alive == true) {
						cells[x, y].nextGen = true;
						aliveDetect = 0;
					} else {
						cells[x, y].nextGen = false;
						aliveDetect = 0;
					}
				}
			}
		}

		Stroke(255, 255, 255);
		//Bollupdate
		for(int y = 0; y < numberOfColums; y++) {
			for(int x = 0; x < numberOfRows; x++) {
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