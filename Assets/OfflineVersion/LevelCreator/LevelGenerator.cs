using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public int levelGridWidth;
    public int levelGridHeight;
    public int levelGridTileSize;
    public int roomCount;
    public RoomSizes roomSizes;
    private Rooms[] rooms;

    public enum RoomSizes
    {
        small,medium, large, mixed
    }

    struct Rooms
    {
        int size;

    }

    struct LevelGridTile
    {
        string mapFile;
        bool[] borders;

        public LevelGridTile(string mapFile, bool borderTop, bool borderBottom, bool borderLeft, bool borderRight)
        {
            this.mapFile = mapFile;
            this.borders = new bool[4] { borderTop, borderBottom, borderLeft, borderRight };
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void CreateRoomLayout()
    {
        int gridTileCount = levelGridWidth * levelGridHeight;
        int possibleRoomCount = gridTileCount - 1; //-1 for spawning room
        if (possibleRoomCount > roomCount)
        {
            Debug.LogError("Levelsize and room number does not match! Not all rooms fit in the level!");
        }
        int biggestRoomSize = possibleRoomCount / roomCount; //distribute all levelGridTiles to all rooms
        int mediumRoomzize = Mathf.Max(biggestRoomSize - biggestRoomSize / 3, 1); //subtract a third from room size but at least one
        int smallRoomSize = Mathf.Max(biggestRoomSize - (2*biggestRoomSize) / 3, 1); //subtract two third from room size but at least one
    }
}
