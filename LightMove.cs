using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMove : MonoBehaviour
{
    public float speed;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 position = transform.position;
        //position.x = (Mathf.PerlinNoise(Time.time / 2, 0) - 0.5f) * 5.1f;
        //position.y = (Mathf.PerlinNoise(0, Time.time) - 0.5f) * 5.1f;
        //transform.position = position;

        //ƒ‰ƒCƒg‚Ì–îˆóˆÚ“®
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed, 0);
        }
    }
}
