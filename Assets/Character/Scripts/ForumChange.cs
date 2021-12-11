using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForumChange : MonoBehaviour
{
    private float eyeAlpha; //�ڂ����̏�Ԃ̓����x
    private float obakeAlpha; //���΂���Ԃ̓����x
    private bool hitFlag; //���C�g���������Ă��邩���ׂ�ϐ�

    Animator animator;
    
    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
        obakeAlpha = 0.1f;
        eyeAlpha = 0.0f;
        hitFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        //���C�g���������Ă��āA�����x���ő�l�ȉ��̎��A�����x�����X�ɏグ�ăI�u�W�F�N�g�ɔ��f������B
        if(hitFlag == true && obakeAlpha < 1.0f)
        {
            obakeAlpha += 0.005f;
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, obakeAlpha);
        }
        if(hitFlag == false)
        {
            if(obakeAlpha > 0.1f)
            {
                obakeAlpha -= 0.01f;
                eyeAlpha = obakeAlpha;
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, eyeAlpha);
            }
            else
            {
                eyeAlpha = (Mathf.PerlinNoise(Time.time, 0) - 0.45f) / 5; //�ڂ̓����x���p�[�����m�C�Y�ŕύX����B�����x��0�̏�Ԃ������Ȃ�悤��-0.45f���āA�m�C�Y�̒��S��0�t�߂ɂ��Ă���B
                this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, eyeAlpha);
            }
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
            this.GetComponent<Fuwafuwa>().hitCheck = true;
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.name == "HandLight")
        {
            this.animator.SetTrigger("out");
            hitFlag = false;
            this.GetComponent<Fuwafuwa>().outCheck = true;
        }
    }
}
