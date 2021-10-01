using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    
    public LineRenderer lr;
    public float speed = 1f;
    public static Vector3 anchor;

    void FixedUpdate()
    {
        // Calculate distance and direction from object to mouse
        Vector2 mousePos = new Vector2(anchor.x, anchor.y);
        Vector2 dist = mousePos - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        // Vector2 dist = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y) - mousePos;
        // Apply force to object in same direction
        gameObject.GetComponent<Rigidbody2D>().AddForce(dist.normalized*speed*Time.deltaTime);
        // Vector2 frictionForce = dist.normalized*-1;
        // if (frictionForce.x < 0) {
        //     frictionForce.x = -1;
        // } else if (frictionForce.x > 0) {
        //     frictionForce.x = 1;
        // }
        // if (frictionForce.y < 0) {
        //     frictionForce.y = -1;
        // } else if (frictionForce.y > 0) {
        //     frictionForce.y = 1;
        // }
        // if (frictionForce != new Vector2(0,0)) {
        //     gameObject.GetComponent<Rigidbody2D>().AddForce(frictionForce*speed*Time.deltaTime*gameObject.GetComponent<Rigidbody2D>().velocity/50);
        // }
    }

    void Update() {
        drawBucketMouseLine();
    }

    // Draw line from center of bucket to mouse pointer
    private void drawBucketMouseLine() {
        // 
        Vector3[] points = new Vector3[] {
            gameObject.transform.position,
            anchor
        };
        lr.positionCount = 2;
        lr.SetPositions(points);
    }

    public Vector3 getPos() {
        return gameObject.transform.position;
    }

    public void resetVelocity() {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
        gameObject.transform.position = new Vector3(0,0,0);
    }
}
