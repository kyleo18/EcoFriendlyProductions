using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scenes : MonoBehaviour
{
    public CursorLockMode lockCursor;
    public void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
    public void menu()
    {
        SceneManager.LoadScene(sceneBuildIndex: 0);
    }
    public void Level1()
    {
        SceneManager.LoadScene(sceneBuildIndex: 8);
    }
    public void Level2()
    {
        SceneManager.LoadScene(sceneBuildIndex: 2);
    }
    public void Select()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    public void tutorial()
    {
        SceneManager.LoadScene(sceneBuildIndex: 4);
    }
    public void win()
    {
        SceneManager.LoadScene(sceneBuildIndex: 5);
    }
    public void die()
    {
        SceneManager.LoadScene(sceneBuildIndex: 6);
    }
    public void story()
    {
        SceneManager.LoadScene(sceneBuildIndex: 7);
    }
    public void Options()
    {
        SceneManager.LoadScene(sceneBuildIndex: 9);
    }
}
