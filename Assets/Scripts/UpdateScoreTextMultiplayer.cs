using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreTextMultiplayer : MonoBehaviour
{
    public GameObject GameController;

    private Text text;
    private PlayerControllerMultiplayer pc;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        pc = GameController.GetComponent<GameControllerMultiplayer>().Player.GetComponent<PlayerControllerMultiplayer>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + pc.Score;
    }
}
