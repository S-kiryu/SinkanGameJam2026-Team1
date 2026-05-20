using UnityEngine;

public class buffDrop : MonoBehaviour
{
    [SerializeField] public GameObject debugBuffItem;
    private HPgauge bossHP;
    
    //別のスクリプトからいろんなバフが指定されている変数が入っているリスト取得するためのコード
    private 
    void Start()
    {
        //アイテムの呼び出し処理
        GameObject Item = Instantiate(debugBuffItem);

    }

    // Update is called once per frame
    void Update()
    {
        if (bossHP._maxHP <= 10)
        {
            //アイテムの呼び出し処理
            GameObject Item = Instantiate(debugBuffItem);

        }
        else if (bossHP._maxHP <= 50)
        {
            //アイテムの呼び出し処理
            GameObject Item = Instantiate(debugBuffItem);
        }
        else if (bossHP._maxHP <= 80)
        {
            GameObject Item = Instantiate(debugBuffItem);
        }

    }
}
