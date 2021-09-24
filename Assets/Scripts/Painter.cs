using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Painter : MonoBehaviour
{
    
    public LineRenderer lr;
    public float speed = 1f; 

    void FixedUpdate()
    {
        // Calculate distance and direction from object to mouse
        Vector2 mousePos = new Vector2(Simulation.getMouseCenteredPos().x, Simulation.getMouseCenteredPos().y);
        Vector2 dist = mousePos - new Vector2(gameObject.transform.position.x, gameObject.transform.position.y);
        drawBucketMouseLine();
        // Apply force to object in same direction
        gameObject.GetComponent<Rigidbody2D>().AddForce(dist.normalized*speed*Time.deltaTime);
    }

    // Draw line from center of bucket to mouse pointer
    private void drawBucketMouseLine() {
        // 
        Vector3[] points = new Vector3[] {
            gameObject.transform.position,
            Simulation.getMouseCenteredPos()
        };
        // Debug.Log(points[1] + " : " + gameObject.transform.position);
        lr.positionCount = 2;
        lr.SetPositions(points);
    }

    public Vector3 getPos() {
        return gameObject.transform.position;
    }
}
