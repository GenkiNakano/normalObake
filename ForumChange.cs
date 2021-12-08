using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForumChange : MonoBehaviour
{
    private float eyeAlpha; //目だけの状態の透明度
    private float obakeAlpha; //おばけ状態の透明度
    private bool hitFlag; //ライトが当たっているか調べる変数

    public float backFuwaSetx;
    public float backFuwaSety;

    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        obakeAlpha = 0.1f;
        hitFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        eyeAlpha = (Mathf.PerlinNoise(Time.time * 1000, 0)  -0.45f) / 5; //目の透明度をパーリンノイズで変更する。透明度が0の状態が多くなるように-0.45fして、ノイズの中心を0付近にしている。

        //ライトが当たっていて、透明度が最大値以下の時、透明度を徐々に上げてオブジェクトに反映させる。
        if(hitFlag == true && obakeAlpha < 1.0f)
        {
            obakeAlpha += 0.005f;
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, obakeAlpha);
        }
        if(hitFlag == false)
        {
            obakeAlpha = 0.1f;
        }
    }

    //ライトが当たった時にアニメーションを変更
    //ライトが当たったらx方向の動きをなくし、緩やかに上下に浮遊する
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "HandLight")
        {
            this.animator.SetTrigger("hit");
            hitFlag = true;
            this.GetComponent<Fuwafuwa>().fuwaSetX = 0;
            this.GetComponent<Fuwafuwa>().fuwaSetY = 1.5f;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "HandLight")
        {
            this.animator.SetTrigger("out");
            hitFlag = false;
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, eyeAlpha);
            this.GetComponent<Fuwafuwa>().fuwaSetX = backFuwaSetx;
            this.GetComponent<Fuwafuwa>().fuwaSetY = backFuwaSety;
        }
    }
}
