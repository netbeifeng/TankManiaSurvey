using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public PlayerInputActions playerInputActions;
    public GameObject ingameMenu;
    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInputActions.Player.Menu.WasPressedThisFrame())
        {
            ingameMenu.SetActive(true);
        }
    }

    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadSceneByIndex(int sceneIDX)
    {
        SceneManager.LoadScene(sceneIDX);
    }
}
