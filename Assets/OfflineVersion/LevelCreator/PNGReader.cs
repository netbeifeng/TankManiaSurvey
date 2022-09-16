using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PNGReader
{
 
    
    /// <summary>
    /// (Helper function) Creates texture container and tries to load it
    /// </summary>
    /// <param name="pngFilePath"></param>
    /// <returns></returns>
    public static Texture2D LoadTextureFromPNGPath(string pngFilePath)
    {
        Texture2D tex = new Texture2D(2, 2);
        if (LoadPNGFileData(pngFilePath, ref tex)){
            return tex;
        }
        return null;
    }


    /// <summary>
    /// (Helper function)Takes an empty 2x2 Texture2D and fills it with the PNG data from FilePath.
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="textureContainer"></param>
    /// <returns></returns>
    private static bool LoadPNGFileData(string filePath, ref Texture2D textureContainer)
    {

        byte[] fileData;

        if (System.IO.File.Exists(filePath))
        {
            fileData = System.IO.File.ReadAllBytes(filePath);
            textureContainer = new Texture2D(2, 2);
            textureContainer.LoadImage(fileData); //..this will auto-resize the texture dimensions.            
        }
        else
        {
            Debug.LogWarning("Could not load PNG file data. Filepath not found.");
            return false;
        }
        return true;
    }
}
