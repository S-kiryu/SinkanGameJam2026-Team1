using UnityEngine;
using UnityEngine.UI;
public class HPgauge : MonoBehaviour
{

    [SerializeField] Image _gauge;
    //[SerializeField] float _maxHP = 100f;
    //[SerializeField] float _currentHP = 100f;//デバッグ用後で消す
    //[SerializeField] float _changeValue = 10f;//デバッグ用後で消す
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
    //    _currentHP = _maxHP;
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Q))//デバッグ用後で消す
    //    {
    //        UpdateGauge(_maxHP, _currentHP - _changeValue);
    //    }

    //}
    public void UpdateGauge(float max, float current)
    {
        //_currentHP = Mathf.Max(current, 0f);
        _gauge.fillAmount = current / max;
    }


}
