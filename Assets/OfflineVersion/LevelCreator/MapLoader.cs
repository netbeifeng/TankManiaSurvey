using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

public class MapLoader : MonoBehaviour
{
    /// <summary>
    /// Filename "name.png" for room layout
    /// </summary>
    public string roomFileNamePath;
    public bool selectRandomRoom;
    public GameObject[] basicFloorTile;
    public GameObject[] basicWallTile;
    public GameObject spawnPointTile;
    public GameObject[] itemTiles;
    public GameObject playerRef;
    public GameObject enemyPrefab;
   

    public Texture2D[] levelMaps;
    public Texture2D[] roomMaps;


    /// <summary>
    /// Container for temporary map loading
    /// </summary>
    Texture2D map;
    /// <summary>
    /// Room tile size in width and height
    /// </summary>
    int tileSize = 64;
    /// <summary>
    /// World space room parent object
    /// </summary>
    GameObject room;
    /// <summary>
    /// 2D Array that holds level layout from LevelLayout.cs
    /// </summary>
    int[,] levelLayout;


    void Start()
    {
        GenerateLevel();
    }

    /// <summary>
    /// Master function to start level generation
    /// </summary>
    public void GenerateLevel()
    {
        if (selectRandomRoom)
        {
            //random file selector
            roomFileNamePath = MapSelector.SelectRoomMap();
            
        }
        //Load level layout data
        CreateLevel();
        //Create Rooms from level layout data
        CreateRoomsFromLevel();
        Debug.Log("Level creation finished!");
    }


    void Update()
    {

    }


    /// <summary>
    /// Chooses a random level map from project directory and loads it into levelLayout member
    /// </summary>
    private void CreateLevel()
    {
        //string selectedLevel = MapSelector.SelectLevelMap();
        //if (!LoadMap(selectedLevel))
        //{
        //    return;
        //}
        map = levelMaps[0];
        //set levelLayout size from map
        levelLayout = new int[map.width, map.height];

        //iterate over levelmap pixels
        for (int y = 0; y < map.height; y++)
        {
            for (int x = 0; x < map.width; x++)
            {
                //color values are multiplied with 255 and only the red channel is the room id.
                //Green and blue channels are uses for png visualisation.
                //!!!IMPORTANT!!!(not 100% sure though)
                //GetPixel(x,y) gets y-indeces flipped. 
                //PNG visual being:
                //10
                //00
                //is filling 2d array with GetPixel() as:
                //00
                //10
                //to keep everything visually equally oriented we get inverted y
                //levelLayout[x, y] = (int)(map.GetPixel(x, map.height - y - 1).r * 255);
                levelLayout[x, y] = (int)(map.GetPixel(x,y).r * 255);
                //Debug.Log(map.GetPixel(x,y).r);
            }
        }
        //Debug print center block levelLayout
        //print("" +
        //    levelLayout[4, 4] + levelLayout[4, 5] + levelLayout[4, 6] + "\n" +
        //    levelLayout[5, 4] + levelLayout[5, 5] + levelLayout[5, 6] + "\n" +
        //    levelLayout[6, 4] + levelLayout[6, 5] + levelLayout[6, 6] + "\n");

        //Debug print Level layout matrix
        LevelLayout.PrintLevelToConsole(levelLayout);
        Debug.Log("Loading level layout completed.");
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





    /// <summary>
    /// Takes levelLayout and spawns rooms as specified
    /// </summary>
    private void CreateRoomsFromLevel()
    {
        int levelWidth = levelLayout.GetLength(0);
        int levelHeight = levelLayout.GetLength(1);
        //Iterate over room indices and assign borders based on direct neighbours
        for (int y = 0; y < levelHeight; y++)
        {
            for (int x = 0; x < levelWidth; x++)
            {
                int tileId = levelLayout[x, y];
                if (tileId != 0)
                {

                    Vector4 borders = Vector4.zero;
                    if (levelLayout[x, y + 1] == 0)
                    {
                        borders[0] = 1;
                    }
                    if (levelLayout[x, y - 1] == 0)
                    {
                        borders[1] = 1;
                    }
                    if (levelLayout[x - 1, y] == 0)
                    {
                        borders[2] = 1;

                    }
                    if (levelLayout[x + 1, y] == 0)
                    {
                        borders[3] = 1;
                    }
                    //levelLayout png anchored at the top left corner. so x= x and y = -z
                    CreateRoom(roomFileNamePath, new Vector3(x * tileSize, 0, -y * tileSize), borders, tileId);
                }
            }
        }
    }

    //private void AddrCompl(AsyncOperationHandle<IResourceLocator>obj)
    //{
    //    roomMap.LoadAssetAsync<Texture2D>().Completed += (tex) =>
    //    {
    //        map = tex.Result;
    //    };
    //}

    /// <summary>
    /// Instantiates a room at the values specified by the parameters.
    /// <para>Room map data format: Only red channel counts.</para> 
    /// <br>0 = Empty</br>
    /// <br>125 = Wall</br>
    /// <br>255 = Floor</br>
    /// <br>10 = Spawnpoint Player</br>
    /// <br>11 = Spawnpoint Enemy</br>
    /// <br>100 = Random Item</br>
    /// </summary>
    /// <param name="roomFileName">Filename for room layout information</param>
    /// <param name="roomAnchor">Top left corner of the room.</param>
    /// <param name="borders">Specify room borders top,bottom,left,right with wall=1 or no-wall=0</param>
    private void CreateRoom(string roomFileName, Vector3 roomAnchor, Vector4 borders, int roomID)
    {
        //if (!LoadMap(roomFileName))
        //{
        //    return;
        //}

        map = roomMaps[0];
        //Addressables.InitializeAsync().Completed += AddrCompl;


        //map =Addressables.LoadAssetAsync<Texture2D>("Assets/Game/Textures/Maps/Rooms/RoomMap (1).png").Result;
        //roomFileNamePath = Addressables.LoadAsset("Assets/Game/Textures/Maps/Rooms/RoomMap (1).png");

        //mapValues holds room layout data
        int[,] mapValues = new int[map.width, map.height];
        int width = mapValues.GetLength(0);
        int height = mapValues.GetLength(1);
        for (int i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                mapValues[j, i] = (int)(map.GetPixel(j, i).r * 255f);
            }
        }
        //room is used to parent-anchor room
        room = Instantiate(new GameObject("Room_Base"), roomAnchor, Quaternion.identity);
        

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                //walls
                if (mapValues[i, j] == 125)
                {
                    SpawnWallTile(roomAnchor, i, j);

                }
                //floor
                //spawn player, spawn enemy
                else if (mapValues[i, j] == 255 || mapValues[i, j] == 10 || mapValues[i, j] == 11 || mapValues[i, j] == 100)
                {
                    int x = Random.Range(0, basicFloorTile.Length);
                    Instantiate(basicFloorTile[x], new Vector3(
                      roomAnchor.x + i * 1 + basicFloorTile[x].transform.position.x
                    , roomAnchor.y + basicFloorTile[x].transform.position.y
                    , roomAnchor.z + j * 1 + basicFloorTile[x].transform.position.z)
                    , basicFloorTile[x].transform.rotation, room.transform);
                }
                //only in spawn room
                if (roomID == 1)
                {
                    //spawnpoints player
                    if (mapValues[i, j] == 10)
                    {
                        GameObject spawnpoint = Instantiate(spawnPointTile, new Vector3(
                          roomAnchor.x + i * 1 + spawnPointTile.transform.position.x
                        , roomAnchor.y + spawnPointTile.transform.position.y
                        , roomAnchor.z + j * 1 + spawnPointTile.transform.position.z)
                        , spawnPointTile.transform.rotation, room.transform);

                        playerRef.transform.position = new Vector3(spawnpoint.transform.position.x,0, spawnpoint.transform.position.z);


                        //    Instantiate(basicFloorTile, new Vector3(
                        //  roomAnchor.x + i * 1 + basicFloorTile.transform.position.x
                        //, roomAnchor.y + basicFloorTile.transform.position.y
                        //, roomAnchor.z + j * 1 + basicFloorTile.transform.position.z)
                        //, basicFloorTile.transform.rotation, room.transform);

                    }
                }
                //not on spawn room
                if (roomID != 1)
                {
                    //spawnpoints enemy
                    if (mapValues[i, j] == 11)
                    {

                        GameObject spawnpoint = Instantiate(spawnPointTile, new Vector3(
                          roomAnchor.x + i * 1 + spawnPointTile.transform.position.x
                        , roomAnchor.y + spawnPointTile.transform.position.y
                        , roomAnchor.z + j * 1 + spawnPointTile.transform.position.z)
                        , spawnPointTile.transform.rotation, room.transform);

                        Instantiate(enemyPrefab, spawnpoint.transform.position, Quaternion.identity);

                        Debug.Log("Set enemy spawn");

                        //Instantiate(basicFloorTile, new Vector3(
                        //  roomAnchor.x + i * 1 + basicFloorTile.transform.position.x
                        //, roomAnchor.y + basicFloorTile.transform.position.y
                        //, roomAnchor.z + j * 1 + basicFloorTile.transform.position.z)
                        //, basicFloorTile.transform.rotation);


                    }
                    //spawn items
                    else if (mapValues[i, j] == 100)
                    {
                        GameObject randomItem = itemTiles[Random.Range(0, itemTiles.Length)];
                        Instantiate(randomItem, new Vector3(
                          roomAnchor.x + i * 1 + randomItem.transform.position.x
                        , roomAnchor.y + randomItem.transform.position.y
                        , roomAnchor.z + j * 1 + randomItem.transform.position.z)
                        , randomItem.transform.rotation, room.transform);
                    }
                }
            }
        }
        //borders
        CreateRoomBorder(roomAnchor, mapValues, borders);




        //Pathfinding:
        //NavMeshSurface[] rooms = new NavMeshSurface[1];
        //room.AddComponent<NavMeshSurface>();
        //rooms[0] = room.GetComponent<NavMeshSurface>();
        //rooms[0].BuildNavMesh();
        //NavMeshAgent agent;

        //room.GetComponentsInChildren<NavMeshSurface>()
    }



    /// <summary>
    /// Create a room boarder wall around the map where floor tiles are at the edge.
    /// </summary>
    /// <param name="roomAnchor"></param>
    /// <param name="mapValues"></param>
    /// <param name="borders"></param>
    private void CreateRoomBorder(Vector3 roomAnchor, int[,] mapValues, Vector4 borders)
    {
        int width = mapValues.GetLength(0);
        int height = mapValues.GetLength(1);

        //top
        if (ToBoolean((int)borders.x))
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (mapValues[i, j] == 255)
                    {
                        SpawnWallTile(roomAnchor, i, j);

                    }
                }
            }
        }
        //bottom
        if (ToBoolean((int)borders.y))
        {
            for (int i = 0; i < width; i++)
            {
                for (int j = height - 1; j < height; j++)
                {
                    if (mapValues[i, j] == 255)
                    {
                        SpawnWallTile(roomAnchor, i, j);

                    }
                }
            }
        }
        //left
        if (ToBoolean((int)borders.z))
        {
            for (int i = 0; i < 1; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (mapValues[i, j] == 255)
                    {
                        SpawnWallTile(roomAnchor, i, j);

                    }
                }
            }
        }
        //right
        if (ToBoolean((int)borders.w))
        {
            for (int i = height - 1; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (mapValues[i, j] == 255)
                    {
                        SpawnWallTile(roomAnchor, i, j);
                        
                    }
                }
            }
        }
    }

    /// <summary>
    /// 1=true, else false
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    private bool ToBoolean(int i)
    {
        if (i == 1)
        {
            return true;
        }
        return false;
    }


    private void SpawnWallTile(Vector3 roomAnchor, int i, int j)
    {
        int x = Random.Range(0, basicWallTile.Length);
        Instantiate(basicWallTile[x], new Vector3(
                          roomAnchor.x + i * 1 + basicWallTile[x].transform.position.x
                        , roomAnchor.y + basicWallTile[x].transform.position.y
                        , roomAnchor.z + j * 1 + basicWallTile[x].transform.position.z)
                        , basicWallTile[x].transform.rotation, room.transform);
    }


}
