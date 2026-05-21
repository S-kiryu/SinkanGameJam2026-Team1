using UnityEngine;

namespace Iwaki.Scripts
{
    public class BGMove : MonoBehaviour
    {
        [SerializeField] private Vector3 _moveDir = Vector2.up;
        [SerializeField] private float _speed;
        [SerializeField] private float _moveDistance;

        private Vector3 _startPos;
        private Vector3 _endPos;
        private float _t;

        private void Start()
        {
            _startPos = transform.position;
        }

        private void Update()
        {
            _endPos = _startPos + _moveDir.normalized * _moveDistance;

            _t += Time.deltaTime * (_speed / _moveDistance);
            _t %= 1f;

            transform.position = Vector3.Lerp(_startPos, _endPos, _t);
        }
    }
}
