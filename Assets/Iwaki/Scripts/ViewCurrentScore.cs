using UnityEngine;
using UnityEngine.UI;

public class ViewCurrentScore : MonoBehaviour
{
    [SerializeField] Text _text;

    void Start()
    {
        int score = ScoreManager.LastScore;
        _text.text = $"{score}";
    }
}
