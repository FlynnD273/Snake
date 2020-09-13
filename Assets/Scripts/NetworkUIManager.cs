using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkUIManager : MonoBehaviour
{
    public GameObject UIManager;
    public GameObject HostButton;
    public GameObject ClientButton;
    public GameObject ReadyButton;

    private NetworkManager manager;
    private Text text;

    // Start is called before the first frame update
    void Start()
    {
        manager = GetComponent<NetworkManager>();
        text = ReadyButton.GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (NetworkServer.active)
        {
            text.text = "Waiting...";

            if (NetworkClient.isConnected)
            {
                UIManager.GetComponent<UIManager>().LoadScene("MultiScene");
            }
        }
    }

    public void ClientClick ()
    {
        HostButton.GetComponent<Button>().interactable = false;
        manager.StartClient();
        ReadyButton.SetActive(true);
    }

    public void HostClick()
    {
        ClientButton.GetComponent<Button>().interactable = false;
        manager.StartHost();
        ReadyButton.SetActive(true);
    }
}
