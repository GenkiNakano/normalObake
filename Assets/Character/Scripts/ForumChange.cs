using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForumChange : MonoBehaviour
{
    private float alpha;
    private float alphaB;
    private bool flag;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        alphaB = 0.1f;
        flag = false;
    }

    // Update is called once per frame
    void Update()
    {
        alpha = (Mathf.PerlinNoise(Time.time * 1000, 0)  -0.45f) / 5;

        if(flag == true && alphaB < 1.0f)
        {
            alphaB += 0.005f;
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alphaB);
        }
        if(flag == false)
        {
            alphaB = 0.1f;
        }
    }

    //ライトが当たった時にアニメーションを変更
    private void OnTriggerEnter2D(Collider2D collision)
    {
        this.animator.SetTrigger("hit");
        flag = true;
        this.GetComponent<Fuwafuwa>().fuwaSetX = 0;
        this.GetComponent<Fuwafuwa>().fuwaSetX = 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        this.animator.SetTrigger("out");
        flag = false;
        this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, alpha);
        this.GetComponent<Fuwafuwa>().fuwaSetX = 3.1f;
        this.GetComponent<Fuwafuwa>().fuwaSetX = 3.1f;
    }
}
