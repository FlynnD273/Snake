using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerMultiplayer : MonoBehaviour
{
    public GameObject Player;
    public bool IsPaused = true;

    private PlayerControllerMultiplayer playerController;
    private bool lastFrame = true;
    private bool gameStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        playerController = Player.GetComponent<PlayerControllerMultiplayer>();
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bool frame = Time.timeScale == 0 && !playerController.IsAlive && gameStarted;
        if (frame && !lastFrame)
        {
            UIManager.Instance?.SetActiveChildren(true, "ShowOnGameOver");
            //HideGameElements();
        }
        else if (!frame && lastFrame)
        {
            UIManager.Instance?.SetActiveChildren(false, "ShowOnGameOver");
        }
        lastFrame = frame;
    }
}
