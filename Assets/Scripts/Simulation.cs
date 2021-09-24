using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation : MonoBehaviour
{
    public Texture2D texture2; // should be a component get
    // public Transform textureTransform;
    public Painter painter;

    private void OnValidate() {
        // Debug.Log("Validating...");
        // Debug.Log(gameObject.transform.GetChild(1).transform.position);
        // textureTransform = gameObject.transform.GetChild(0);
    }

    private void FixedUpdate() {
        if (Input.GetKey(KeyCode.W)){
            // calculate what pixel it is
            drawPixel(getImagePixel(painter.getPos(), texture2), texture2, Color.black);
            // Vector2[] pixels = { Input.mousePosition, new Vector2(Input.mousePosition.x+10, Input.mousePosition.y+10)};
            // drawPixels(pixels, texture2, Color.black);
        }
        else if(Input.GetKey(KeyCode.R)) {
            // Create new texture with specified settings.
            // Or just paint the whole image white.
            clearImage(texture2);
        }
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
        // Check if mouse is currently in the correct space
        // Translate the mouse coord to the appropriate
        // Vector2 scalor = new Vector2(
        //     (Camera.main.orthographicSize*2*Camera.main.aspect)/texture.width,
        //     (Camera.main.orthographicSize*2)/texture.height
        // );
        Vector2 scalor = new Vector2(
            (Camera.main.orthographicSize*2*Camera.main.aspect),
            (Camera.main.orthographicSize*2)
        );
        Debug.Log(scalor);

        Vector3 payload = worldSpacePos;
        payload.x = (payload.x + texture.width/2);
        payload.y = (payload.y + texture.height/2);
        // (0,0) should be (width/2, height/2)
        // Debug.Log(payload);
        return payload;
    }

    public static Vector3 getMouseCenteredPos() {
        // Debug.Log();
        // return new Vector3(Input.mousePosition.x-Screen.width/2, Input.mousePosition.y-Screen.height/2, Input.mousePosition.z);
        Vector3 pz = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pz.z = -1;
        return pz;
    }
}
