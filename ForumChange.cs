using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForumChange : MonoBehaviour
{
    private float eyeAlpha; //�ڂ����̏�Ԃ̓����x
    private float obakeAlpha; //���΂���Ԃ̓����x
    private bool hitFlag; //���C�g���������Ă��邩���ׂ�ϐ�

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
        eyeAlpha = (Mathf.PerlinNoise(Time.time * 1000, 0)  -0.45f) / 5; //�ڂ̓����x���p�[�����m�C�Y�ŕύX����B�����x��0�̏�Ԃ������Ȃ�悤��-0.45f���āA�m�C�Y�̒��S��0�t�߂ɂ��Ă���B

        //���C�g���������Ă��āA�����x���ő�l�ȉ��̎��A�����x�����X�ɏグ�ăI�u�W�F�N�g�ɔ��f������B
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

    //���C�g�������������ɃA�j���[�V������ύX
    //���C�g������������x�����̓������Ȃ����A�ɂ₩�ɏ㉺�ɕ��V����
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
