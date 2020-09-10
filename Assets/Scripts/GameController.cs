using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject Player;

    private PlayerController playerController;
    private bool lastFrame = true;

    // Start is called before the first frame update
    void Start()
    {
        playerController = Player.GetComponent<PlayerController>();
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
