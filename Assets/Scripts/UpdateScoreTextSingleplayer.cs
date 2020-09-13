using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreTextSingleplayer : MonoBehaviour
{
    public GameObject GameController;
    public bool Resize = false;

    private Text text;
    private PlayerControllerSingleplayer pc;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        pc = GameController.GetComponent<GameControllerSingleplayer>().Player.GetComponent<PlayerControllerSingleplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + pc?.Score;

        if (Resize)
            text.fontSize = (int)(Screen.height / 30);
    }
}
