using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] AudioClip _music = null;
    [SerializeField] SceneLoader _sceneLoader = null;

    void Start()
    {
        AudioHelper.PlayClip2D(_music, 1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Exit the program
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            _sceneLoader.ReloadLevel();
        }
    }
}
