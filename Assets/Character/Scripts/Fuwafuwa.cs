using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuwafuwa : MonoBehaviour
{ 

    //出現位置の変数
    private float rdmX;
    private float rdmY;

    //ノイズに変化を与える変数
    private float rdm;

    //光を当てた時にその場に残らせるための設定変数
    public float fuwaSetX;
    public float fuwaSetY;

    // Start is called before the first frame update
    void Start()
    {
        //出現位置をノイズで指定。0にならないように色々かけたりしている。
        rdmX = Random.Range(-1.0f, 1.0f) * 10.1f + 0.1f;
        rdmY = Random.Range(-1.0f, 1.0f) * 5.1f + 0.1f;
        while(rdmX == 0)
        {
            rdmX = Random.Range(-1.0f, 1.0f) * 10.1f + 0.1f;
        }
        while (rdmY == 0)
        {
            rdmY = Random.Range(-1.0f, 1.0f) * 5.1f + 0.1f;
        }
        rdm = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //一個前の位置と比べて値が低かったらスケールを反転することで、進行方向に画像を向ける
        Vector3 oldPos = transform.position;
        Vector3 position = transform.position;
        float check = 0.0f;
       
        position.x = rdmX + (Mathf.PerlinNoise(Time.time / rdm , 0) - 0.5f) * fuwaSetX;
        position.y = rdmY + (Mathf.PerlinNoise(0, Time.time / rdm) - 0.5f) * fuwaSetY;

        check = position.x - oldPos.x;

        if (0 <= check)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        transform.position = position;
    }
}
