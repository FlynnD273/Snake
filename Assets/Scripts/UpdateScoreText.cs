using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScoreText : MonoBehaviour
{
    public GameObject GameController;

    private Text text;
    private PlayerController pc;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
        pc = GameController.GetComponent<GameController>().Player.GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Score: " + pc.Score;
    }
}
