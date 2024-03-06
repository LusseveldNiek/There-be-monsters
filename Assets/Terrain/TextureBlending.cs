using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureBlending : MonoBehaviour
{
    public Texture2D positionTexture;
    public Texture2D grassTexture;
    public Texture2D sandTexture;

    void Start()
    {
        // Get the dimensions of the position texture
        int width = positionTexture.width;
        int height = positionTexture.height;

        // Create a new texture to store the blended result
        Texture2D resultTexture = new Texture2D(width, height);

        // Loop through each pixel of the position texture
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Sample the color of the position texture
                Color positionColor = positionTexture.GetPixel(x, y);

                // Determine the texture to blend based on the color of the position texture
                Texture2D textureToBlend = positionColor.r > 0.5f ? grassTexture : sandTexture;

                // Sample the color of the selected texture
                Color textureColor = textureToBlend.GetPixel(x % textureToBlend.width, y % textureToBlend.height);

                // Set the blended color to the result texture
                resultTexture.SetPixel(x, y, textureColor);
            }
        }

        // Apply changes and assign the result texture to the object
        resultTexture.Apply();
        GetComponent<Renderer>().material.mainTexture = resultTexture;
    }
}
