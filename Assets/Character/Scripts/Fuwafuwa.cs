using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuwafuwa : MonoBehaviour
{ 

    //�o���ʒu�̕ϐ�
    private float rdmX;
    private float rdmY;

    //�m�C�Y�ɕω���^����ϐ�
    private float rdm;

    //���𓖂Ă����ɂ��̏�Ɏc�点�邽�߂̐ݒ�ϐ�
    public float fuwaSetX;
    public float fuwaSetY;

    // Start is called before the first frame update
    void Start()
    {
        //�o���ʒu���m�C�Y�Ŏw��B0�ɂȂ�Ȃ��悤�ɐF�X�������肵�Ă���B
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

        fuwaSetX = 3.1f;
        fuwaSetY = 3.1f;
        rdm = Random.Range(1.0f, 3.0f);
    }

    // Update is called once per frame
    void Update()
    {
        //��O�̈ʒu�Ɣ�ׂĒl���Ⴉ������X�P�[���𔽓]���邱�ƂŁA�i�s�����ɉ摜��������
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
