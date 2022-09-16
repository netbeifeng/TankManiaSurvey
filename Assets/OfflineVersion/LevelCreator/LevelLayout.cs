using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
/// <summary>
/// Author: Janosch Landvogt. This class is used to create level layout assets 
/// as png files according to the specified component parameters.
/// </summary>
public class LevelLayout : MonoBehaviour
{
    /// <summary>
    /// Number of level maps to generate.
    /// </summary>
    [Range(1, 100)]
    public int numLevelsGenerate=1;
    /// <summary>
    /// Number of rooms inside a level.
    /// </summary>
    public int numRooms;
    /// <summary>
    /// level with
    /// </summary>
    [Range(3, 100)]
    public int width;
    /// <summary>
    /// level height
    /// </summary>
    [Range (3, 100)]
    public int height;
    /// <summary>
    /// Initial value should be spawn room index
    /// </summary>
    public Vector2 spawnRoom;
    private Vector2 currRoom;

    /// <summary>
    /// Stating room id in level array. 1=Spawn room
    /// </summary>
    int counter = 2;
    int[,] level;


    //Debug levelLayout:
    /*
    int width = 11;
    int height = 11;
    Vector2 currLevel = new Vector2(5, 5);
    int counter = 2;
    public int[,] level = new int[11, 11] {
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
        { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
    };
    */


    void Start()
    {
        
        for (int i = 0; i < numLevelsGenerate; i++)
        {

            Initialize();
            CreatePNGFromLevel();
        }



    }

    void Update()
    {

    }

    private void Initialize()
    {
        //reset currRoom
        currRoom = spawnRoom;
        //set level size
        level = new int[width, height];
        //setup spawn room
        level[(int)spawnRoom.x, (int)spawnRoom.y] = 1;
        //fill rooms
        for (int i = 0; i < numRooms; i++)
        {
            Vector2 newIndex = GetNewIndex();
            if (newIndex.x == 0 && newIndex.y == 0)
            {
                break;
            }
            currRoom += newIndex;
            level[(int)currRoom.x, (int)currRoom.y] = counter;
            counter++;
        }

        //reset counter
        counter = 2;

        PrintLevelToConsole(level);
    }
    

    /// <summary>
    /// Debug tool to visualize levelLayout in console. Same layout like png view.
    /// </summary>
    /// <param name="level"></param>
    public static void PrintLevelToConsole(int[,] level)
    {
        Debug.Log("Level layout:");
        StringBuilder sb = new StringBuilder();
        for (int y = 0; y < level.GetLength(1); y++)
        {
            for (int x = 0; x < level.GetLength(0); x++)
            {
                sb.Append(level[x, y]);
                sb.Append(' ');
            }
            sb.AppendLine();
        }
        Debug.Log(sb.ToString());
    }

    /// <summary>
    /// Tries 20 times to get a new neighbor index from currRoom that is empty.
    /// </summary>
    /// <returns>A vector2 adder that can be added on the current vec2 index denoting the nex room</returns>
    private Vector2 GetNewIndex()
    {
        for (int i = 0; i < 20; i++)
        {


            int number = Random.Range(0, 4);
            Vector2 adder = Vector2.zero;
            switch (number)
            {
                case 0:
                    adder += Vector2.left;
                    break;
                case 1:
                    adder += Vector2.right;
                    break;
                case 2:
                    adder += Vector2.up;
                    break;
                case 3:
                    adder += Vector2.down;
                    break;

                default:
                    break;
            }
            Vector2 newIndex = currRoom + adder;
            if (newIndex.x != 0 && newIndex.x != width - 1 && newIndex.y != 0 && newIndex.y != height - 1)
            {
                if (level[(int)newIndex.x, (int)newIndex.y] == 0)
                {

                    return adder;
                }
            }
        }
        return Vector2.zero;
    }

    /// <summary>
    /// Saves level data into project directory folder as png
    /// </summary>
    private void CreatePNGFromLevel()
    {
        //first Make sure you're using RGB24 as your texture format
        Texture2D texture = new Texture2D(width, height, TextureFormat.RGB24, false);
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (level[x, y] == 0)
                {
                    texture.SetPixel(x, y, new Color(0f, 0f, 0f));

                }
                else
                {
                    texture.SetPixel(x, y, new Color(level[x, y] / 255f, 1f, 0f));

                }
            }
        }
        //then Save To Disk as PNG
        byte[] bytes = texture.EncodeToPNG();
        string dirPath = MapSelector.GetLevelFileDir();
        if (!Directory.Exists(dirPath))
        {
            Directory.CreateDirectory(dirPath);
        }
        int imgNum = 1;
        string pngPath;
        //try creating continous path numbers until next one is empty
        do
        {
            pngPath = dirPath + MapSelector.GetLevelMapName() + imgNum + ".png";
            imgNum++;
        } while (System.IO.File.Exists(pngPath));

        File.WriteAllBytes(pngPath, bytes);
    }
}
