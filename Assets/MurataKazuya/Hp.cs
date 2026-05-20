using UnityEngine;
using UnityEngine.UI;

public class Hp : MonoBehaviour
{
    [SerializeField] Image _image;
    [SerializeField] float _maxHP = 100;
    [SerializeField] float _currentHP = 100;
    [SerializeField] float _changeValue = 20;//喰らうダメージ量
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _currentHP = _maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        Damege();
    }
    void Damege()
    {

        _image.fillAmount = _currentHP / _maxHP;

        Debug.Log($"HPの割合:{_currentHP / _maxHP}");
    }
}
