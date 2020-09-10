using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWorldBounds : MonoBehaviour
{
    public GameObject Player;

    private BoxCollider2D b;
    private Camera camera;
    private float w, h;
    // Start is called before the first frame update
    void Start()
    {
        float s = Player.transform.localScale.x;
        camera = GetComponent<Camera>();
        h = camera.orthographicSize * 2;
        h -= h % s;
        w = h * camera.aspect;
        w -= w % s;
        b = GetComponent<BoxCollider2D>();
        b.size = new Vector2(w - s * 2, h - s * 2);

        float m = s;

        Vector3 dl = new Vector3(b.bounds.min.x - m, b.bounds.max.y + m);
        Vector3 ul = new Vector3(b.bounds.min.x - m, b.bounds.min.y - m);
        Vector3 dr = new Vector3(b.bounds.max.x + m, b.bounds.max.y + m);
        Vector3 ur = new Vector3(b.bounds.max.x + m, b.bounds.min.y - m);

        LineRenderer l = GetComponent<LineRenderer>();
        l.positionCount = 5;
        l.SetPositions(new Vector3[] { dl, dr, ur, ul, dl });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
