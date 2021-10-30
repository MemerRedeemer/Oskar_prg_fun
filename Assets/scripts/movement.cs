using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    float speed = 8;
    Rigidbody2D rgbd2D;

    void Start() {
        rgbd2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        
        Vector3 pos = new Vector3(x, y).normalized * speed;

        rgbd2D.velocity = pos;
    }
}
