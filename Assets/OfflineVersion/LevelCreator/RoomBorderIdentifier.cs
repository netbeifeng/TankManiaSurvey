using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;

public class RoomBorderIdentifier : MonoBehaviour
{
    public int roomCount;
    RoomData[] roomData;
    Texture2D map;

    //string building
    int counter;
    StringBuilder sb;
    int val;
    int val2;

    void Start()
    {
        counter = 0;
        roomData = new RoomData[roomCount];
        sb = new StringBuilder();
        for (int i = 0; i < roomCount; i++)
        {
            roomData[i] = CalculateBorderID(MapSelector.GetRoomMapAtIdx(i+1));
        }

        sb.Clear();
        sb.Append("[\n");
        for (int i = 0; i < roomData.Length; i++)
        {
            if (i == roomData.Length - 1)
            {

                sb.Append(JsonUtility.ToJson(roomData[i], true) + "\n]");
                break;
            }
            sb.Append(JsonUtility.ToJson(roomData[i], true) + ",\n");
            
        }



        File.WriteAllText(MapSelector.GetRoomIDFileDir() + "/roomIds.json", sb.ToString());

    }

    void Update()
    {

    }

    private void AssignRoomArray()
    {
        int roomMapCount = 1;
        string pngNameRoom = MapSelector.GetRoomMapName() + " (" + roomMapCount + ").png";


        string dirPath = MapSelector.GetRoomFileDir();
        string pngPathLevel;
        do
        {
            pngPathLevel = dirPath + MapSelector.GetRoomMapName() + " (" + roomMapCount + ").png";
            roomMapCount++;
        } while (System.IO.File.Exists(pngPathLevel));
        roomMapCount--;
        int selectedRoom = Random.Range(1, roomMapCount);
        //return dirPath + MapSelector.GetRoomMapName() + selectedRoom + ".png";
    }


    private RoomData CalculateBorderID(string roomFileName)
    {
        if (!LoadMap("" + MapSelector.GetRoomFileDir() + roomFileName))
        {
            return null;
        }
        RoomData roomData = new RoomData();
        roomData.Name = roomFileName;
        //mapValues holds room layout data
        int[,] mapValues = new int[map.width, map.height];
        int width = mapValues.GetLength(0);
        int height = mapValues.GetLength(1);

        //top
        for (int i = 0; i < width; i++)
        {
            sb.Append(PixelToString((int)(map.GetPixel(i, 0).r * 255f)));

        }
        roomData.borderUp = sb.ToString();
        sb.Clear();

        //bottom
        for (int i = 0; i < width; i++)
        {
            sb.Append(PixelToString((int)(map.GetPixel(i, height - 1).r * 255f)));
        }
        roomData.borderDown = sb.ToString();
        sb.Clear();

        //left
        for (int i = 0; i < height; i++)
        {
            sb.Append(PixelToString((int)(map.GetPixel(0, i).r * 255f)));
        }
        roomData.borderLeft = sb.ToString();
        sb.Clear();
        //right
        for (int i = 0; i < height; i++)
        {
            sb.Append(PixelToString((int)(map.GetPixel(height - 1, i).r * 255f)));
        }
        roomData.borderRight = sb.ToString();
        sb.Clear();
        //Debug.Log(roomData.borderUp);
        //Debug.Log(roomData.borderDown);
        //Debug.Log(roomData.borderLeft);
        //Debug.Log(roomData.borderRight);
        roomData.borderUp = CompressString(roomData.borderUp);
        roomData.borderDown = CompressString(roomData.borderDown);
        roomData.borderLeft = CompressString(roomData.borderLeft);
        roomData.borderRight = CompressString(roomData.borderRight);


        //Debug.Log(roomData.borderUp);
        //Debug.Log(roomData.borderDown);
        //Debug.Log(roomData.borderLeft);
        //Debug.Log(roomData.borderRight);


        return roomData;
    }

    private string PixelToString(int val)
    {
        if (val == 0)
        {
            return "e";

        }
        //floor
        if (val == 255)
        {
            return "f";

        }
        //wall
        if (val == 125)
        {
            return "w";

        }
        return "x";
    }

    private string CompressString(string s)
    {
        counter = 1;
        char c = s[0];
        string result = "" + c;
        for (int i = 1; i < s.Length; i++)
        {
            if (i == s.Length - 1)
            {
                if (s[i] == c)
                {

                    counter++;
                    result += "" + counter;
                    break;
                }
                else
                {
                    c = s[i];
                    result += "" + counter + c + "1";
                    break;
                }
            }
            if (s[i] == c)
            {
                counter++;
            }
            else
            {
                c = s[i];
                result += "" + counter + c;
                counter = 1;
            }
        }
        return result;
    }

    /// <summary>
    /// Tries to load texture file into "map" member
    /// </summary>
    /// <param name="PNGPath"></param>
    private bool LoadMap(string PNGPath)
    {

        Debug.Log("Try loading: " + PNGPath);
        map = PNGReader.LoadTextureFromPNGPath(PNGPath);
        if (map == null)
        {
            Debug.LogWarning("Failed to load png file from path " + PNGPath);
            return false;
        }
        else
        {
            return true;
        }
    }
    [System.Serializable]
    private class RoomData
    {
        public string Name;
        public string borderUp;
        public string borderDown;
        public string borderLeft;
        public string borderRight;
    }
}


