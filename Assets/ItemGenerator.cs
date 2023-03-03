using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;

    //coinPrefabを入れる
    public GameObject coinPrefab;

    //cornPrefabを入れる
    public GameObject conePrefab;

    //スタート地点(座標)
    private int startPos = 80;

    //ゴール地点(座標)
    private int goalPos = 360;

    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;

    // Start is called before the first frame update
    void Start()
    {
        //一定の距離ごとにアイテムを生成
        //(スタート後からゴール手前まで15おきに生成される)
        for (int i = startPos; i < goalPos; i += 15)
        {
            //どのアイテムを出すのかをランダムに設定(1D10の感覚)
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                //コーンをx軸方向に一直線に生成(20%の確率)
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    //Instantiateはオブジェクトを生成する関数
                    GameObject cone = Instantiate(conePrefab);
                    //for文のfloat jの通り、-1から0.4ずつ足していき、1の時も+= 0.4fが適用されるため、計6回生成される
                    //0.4fは位置の指定にも使う
                    //j += 0.4fに4をかけたそれぞれの数値が座標xの値となり、横一列に均等に配置される
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }
            else
            {

                //レーンごとにアイテムを生成
                for (int j = -1; j <= 1; j++)
                {
                    //アイテムの種類を決める(1D10の感覚)
                    int item = Random.Range(1, 11);
                    //アイテムを置くZ座標のオフセットをランダムに設定
                    //一定の距離の中の、-5から6までの間のZ座標にアイテムが生成される
                    int offsetZ = Random.Range(-5, 6);
                    //60%コイン配置
                    if (1 <= item && item <= 6)
                    {
                        //コインを生成
                        //posRangeに代入されている値、3.4fの-1、0、1(for文のint j参照)の倍数でx軸にアイテムが生成される
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }
                    //30%車配置
                    else if (7 <= item && item <= 9)
                    {
                        //車を生成
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                    //10%何もなし
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
