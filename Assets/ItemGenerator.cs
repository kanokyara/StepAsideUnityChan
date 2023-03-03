using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefab������
    public GameObject carPrefab;

    //coinPrefab������
    public GameObject coinPrefab;

    //cornPrefab������
    public GameObject conePrefab;

    //�X�^�[�g�n�_(���W)
    private int startPos = 80;

    //�S�[���n�_(���W)
    private int goalPos = 360;

    //�A�C�e�����o��x�����͈̔�
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        //���̋������ƂɃA�C�e���𐶐�
        //(�X�^�[�g�ォ��S�[����O�܂�15�����ɐ��������)
        for (int i = startPos; i < goalPos; i += 15)
        {
            //�ǂ̃A�C�e�����o���̂��������_���ɐݒ�(1D10�̊��o)
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //�R�[����x�������Ɉ꒼���ɐ���(20%�̊m��)
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    //Instantiate�̓I�u�W�F�N�g�𐶐�����֐�
                    GameObject cone = Instantiate(conePrefab);
                    //for����float j�̒ʂ�A-1����0.4�������Ă����A1�̎���+= 0.4f���K�p����邽�߁A�v6�񐶐������
                    //0.4f�͈ʒu�̎w��ɂ��g��
                    //j += 0.4f��4�����������ꂼ��̐��l�����Wx�̒l�ƂȂ�A�����ɋϓ��ɔz�u�����
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {

                //���[�����ƂɃA�C�e���𐶐�
                for (int j = -1; j <= 1; j++)
                {
                    //�A�C�e���̎�ނ����߂�(1D10�̊��o)
                    int item = Random.Range(1, 11);
                    //�A�C�e����u��Z���W�̃I�t�Z�b�g�������_���ɐݒ�
                    //���̋����̒��́A-5����6�܂ł̊Ԃ�Z���W�ɃA�C�e�������������
                    int offsetZ = Random.Range(-5, 6);
                    //60%�R�C���z�u
                    if (1 <= item && item <= 6)
                    {
                        //�R�C���𐶐�
                        //posRange�ɑ������Ă���l�A3.4f��-1�A0�A1(for����int j�Q��)�̔{����x���ɃA�C�e�������������
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    //30%�Ԕz�u
                    else if (7 <= item && item <= 9)
                    {
                        //�Ԃ𐶐�
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                    //10%�����Ȃ�
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
