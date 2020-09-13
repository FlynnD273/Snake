using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerSingleplayer : MonoBehaviour
{
    public GameObject Player;

    private PlayerControllerSingleplayer playerController;
    private bool lastFrame = true;

    // Start is called before the first frame update
    void Start()
    {
        playerController = Player.GetComponent<PlayerControllerSingleplayer>();
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        bool frame = Time.timeScale == 0 && !playerController.IsAlive;
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
