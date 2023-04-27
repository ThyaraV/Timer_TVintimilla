using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private string tag;

    [SerializeField]
    private GameObject playerPrefab;
  

    private GameObject player;

    [SerializeField]
    private GameObject[] spawnPoints;

    [SerializeField]
    private GameObject selectedSpawnPoints;

    [SerializeField]
    private GameObject menuCamera;

    [SerializeField]
    private GameObject menuUI;

    [SerializeField]
    private GameObject gameUI;

    private Timer timer;



    // Start is called before the first frame update
    void Start()
    {
        timer=gameObject.GetComponent<Timer>();
        menuCamera.SetActive(true);
        menuUI.SetActive(true);
        gameUI.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            endGame();
        }
    }

    public void starGame()
    {
        timer.startTimer();
        menuCamera.SetActive(false);
        menuUI.SetActive(false);
        gameUI.SetActive(true);

        placePlayerRandomly();
    }

    public void endGame()
    {
        timer.stopTimer();
        menuCamera.SetActive(true);
        menuUI.SetActive(true);
        gameUI.SetActive(false);

        Destroy(player);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }



    private void placePlayerRandomly()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag(tag);
        int rand = Random.Range(0, spawnPoints.Length);
        selectedSpawnPoints = spawnPoints[rand];

        player = Instantiate(playerPrefab, selectedSpawnPoints.transform.position, selectedSpawnPoints.transform.localRotation);

    }
}
