using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGGameManager : MonoBehaviour
{
    public static RPGGameManager instance = null;

    public RPGCameraManager cameraManager;

    public SpawnPoint playerSpawnPoint;

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        SetupScene();
    }

    void SetupScene()
    {
        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        if(playerSpawnPoint != null)
        {
            GameObject player = playerSpawnPoint.SpawnObject();

            cameraManager.virtualCamera.Follow = player.transform;
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
