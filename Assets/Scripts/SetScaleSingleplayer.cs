using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScaleSingleplayer : MonoBehaviour
{
    public int Rows = 50;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SetScale", 0, 0.1f);
    }

    private void SetScale ()
    {
        float h = Camera.main.orthographicSize * 2;

        transform.localScale = new Vector3(h / Rows, h / Rows);
    }
}
