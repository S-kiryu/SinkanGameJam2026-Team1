using UnityEngine;
using UnityEngine.UI;

public class ViewCurrentScore : MonoBehaviour
{
    [SerializeField] Text _text;

    void Start()
    {
        _text.text = "Placeholder"; // 後でスコア取ってくる処理追加
    }
}
