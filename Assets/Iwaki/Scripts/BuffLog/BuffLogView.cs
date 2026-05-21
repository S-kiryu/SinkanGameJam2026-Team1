using UnityEngine;

public class BuffLogView : MonoBehaviour
{
    [SerializeField] private TextMesh _text;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _duration;

    private float _startTime;
    private Color _startColor;
    private Color _endColor;
    private Vector3 _startPosition;

    public void SetBuffInfo(StatModifier modifier)
    {
        _text.text = $"{modifier.StatType.ToString()} Buffed!";
        _startTime = Time.time;
        _startColor = _text.color;
        _endColor = _startColor;
        _endColor.a = 0;
        _startPosition = transform.position;
    }

    private void Update()
    {
        var t = (Time.time - _startTime) / _duration;
        transform.localPosition = _startPosition + _offset * t;
        _text.color = Color.Lerp(_startColor, _endColor, t);

        if (t > 1)
        {
            Destroy(gameObject);
        }
    }
}
