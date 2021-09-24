using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Simulation : MonoBehaviour
{
    public Texture2D texture2; // should be a component get
    public Painter painter;
    public Color colour;

    public Color[] colours;
    

    public static int width = 1;
    public static bool paused = false;

    public GameObject t0;
    public GameObject t00;
    public GameObject t000;

    public Sprite[] numbers;

    private void Start() {
        UpdateWidthDisplay();
        // numbers = Resources.LoadAll<Sprite>("Numbers");
    }

    private void Update() {
        if (!Input.GetKey(KeyCode.W)){
            // drawPixel(getImagePixel(painter.getPos(), texture2), texture2, colour);
            drawPixels(pointsInSquare(painter.getPos(), width, texture2), texture2, colour);
        }
        if(Input.GetKey(KeyCode.R)) {
            clearImage(texture2);
        }
        if(Input.GetKey(KeyCode.Mouse1)) {
            Painter.anchor = getMouseCenteredPos();
        }
    }

    public void UpdateWidthDisplay() {
        int h = (int)Mathf.Floor(width / 100);
        t000.GetComponent<Image>().sprite = numbers[h];
        int t = (int)Mathf.Floor(width%100 / 10);
        t00.GetComponent<Image>().sprite = numbers[t];
        int o = (int)width%100%10;
        t0.GetComponent<Image>().sprite = numbers[o];
    }

    public void setColour(int colID) {
        colour = colours[colID];
    }

    public static bool PauseGame() {
        // Change the sprites here too.
        if (paused) {
            Time.timeScale = 1f;
            paused = false;
        } else {
            Time.timeScale = 0f;
            paused = true;
        }
        return paused;
    }

    // Update a series of pixels
    public void drawPixels(Vector3[] pixels, Texture2D texture, Color colour) {
        foreach (Vector3 pixel in pixels) {
            texture.SetPixel((int)pixel.x, (int)pixel.y, colour);
        }
        texture.Apply();
    }

    // Update a single pixel
    public void drawPixel(Vector3 pixel, Texture2D texture, Color colour) {
        texture.SetPixel((int)pixel.x, (int)pixel.y, colour);
        texture.Apply();
    }

    // Clear the image
    public void clearImage(Texture2D texture) {
        for (int y = 0; y < texture2.height; y++) {
            for (int x = 0; x < texture2.width; x++) {
                texture.SetPixel(x, y, Color.white);
            }
        }
        texture.Apply();
    }

    private Vector3 getImagePixel(Vector3 worldSpacePos, Texture2D texture) {
        Vector3 payload = worldSpacePos;
        payload.x = (payload.x + texture.width/2);
        payload.y = (payload.y + texture.height/2);
        return payload;
    }

    public static Vector3 getMouseCenteredPos() {
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = -1;
        return pz;
    }

    public Vector3[] pointsInSquare(Vector3 p,int radius, Texture2D texture) {
        Vector3[] points = new Vector3[radius*radius];
        for (int y = 0; y < radius; y++) {
            for (int x = 0; x < radius; x++) {
                points[x*y] = getImagePixel((p + new Vector3(x-radius/2,y-radius/2,0)), texture);
            }
        }
        return points;
    }
}
