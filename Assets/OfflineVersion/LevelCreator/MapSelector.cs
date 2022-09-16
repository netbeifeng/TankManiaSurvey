using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MapSelector 
{
    private static string levelMapDirPath = Application.dataPath + "/Game/Textures/Maps/";
    private static string roomMapDirPath = Application.dataPath + "/Game/Textures/Maps/Rooms/";
    private static string roomIDDirPath = Application.dataPath + "/Game/Textures/Maps/";
    private static string levelMapName = "LevelMap";
    private static string roomMapName = "RoomMap";

    /// <summary>
    /// Counts all level maps starting from levelMapName1 to levelMapNameN and chooses a random one based on the count. (Folder structure dependant)
    /// </summary>
    /// <returns> Full level map file path</returns>
    public static string SelectLevelMap()
    {
        string dirPath = GetLevelFileDir();
        string pngPathLevel;
        int levelMapCount = 1;
        do
        {
            pngPathLevel = dirPath + levelMapName + levelMapCount + ".png";
            levelMapCount++;
        } while (System.IO.File.Exists(pngPathLevel));
        levelMapCount--;
        int selectedLvl = Random.Range(1, levelMapCount);
        return dirPath + levelMapName + selectedLvl + ".png";
    }

    /// <summary>
    /// Counts all room maps and chooses a random one based on the count. (Folder structure dependant)
    /// </summary>
    /// <returns> Full room map file path</returns>
    public static string SelectRoomMap()
    {
        string dirPath = GetRoomFileDir();
        string pngPathLevel;
        int roomMapCount = 1;
        do
        {
            pngPathLevel = dirPath + roomMapName +" ("+ roomMapCount + ").png";
            roomMapCount++;
        } while (System.IO.File.Exists(pngPathLevel));
        roomMapCount--;
        int selectedRoom = Random.Range(1, roomMapCount);
        return dirPath + roomMapName + " (" + selectedRoom + ").png";
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>File path to room maps directory</returns>
    public static string GetRoomFileDir()
    {
        return roomMapDirPath;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns>File path to level map directory</returns>
    public static string GetLevelFileDir()
    {
        return levelMapDirPath;
    }
    
    public static string GetRoomIDFileDir()
    {
        return roomIDDirPath;
    }

    public static string GetLevelMapName()
    {
        return levelMapName;
    }

    public static string GetRoomMapName()
    {
        return roomMapName;
    }

    public static string GetRoomMapAtIdx(int x)
    {
        return roomMapName + " (" + x + ").png";
    }
}
