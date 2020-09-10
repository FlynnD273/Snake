using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance = null;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance.gameObject);   
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetActiveChildren(bool isActive, string tag)
    {
        foreach (GameObject o in GameObject.FindGameObjectsWithTag(tag))
        {
            for (int i = 0; i < o.transform.childCount; i++)
            {
                o.transform.GetChild(i).gameObject.SetActive(isActive);
            }
        }
    }

    public void LoadSinglePlayer()
    {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("TitleScene", LoadSceneMode.Single);
        Time.timeScale = 1;
    }
}
