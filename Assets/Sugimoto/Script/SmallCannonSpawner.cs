using System.Collections.Generic;
using UnityEngine;

public class SmallCannonSpawner : MonoBehaviour
{
    [SerializeField] private CharacterStatus _characterStatus;
    [SerializeField] private GameObject _smallCannonPrefab;
    [SerializeField] private Transform _spawnRoot;
    [SerializeField] private Vector3 _centerOffset = Vector3.zero;
    [SerializeField] private float _spacing = 1.25f;

    private readonly List<GameObject> _spawnedCannons = new();

    private void Awake()
    {
        if (_characterStatus == null)
        {
            _characterStatus = GetComponent<CharacterStatus>();

        }

        if (_spawnRoot == null)
        {
            _spawnRoot = transform;
        }
    }

    private void OnEnable()
    {
        if (_characterStatus != null)
        {
            _characterStatus.OnSmallcannonChanged += HandleSmallcannonChanged;
        }
    }

    private void OnDisable()
    {
        if (_characterStatus != null)
        {
            _characterStatus.OnSmallcannonChanged -= HandleSmallcannonChanged;
        }
    }

    // ¬–C‘ä‚Ì”‚ª•ÏX‚³‚ê‚½‚Æ‚«‚Ìˆ—
    private void HandleSmallcannonChanged(int count)
    {
        Rebuild(count);
    }

    // ¬–C‘ä‚Ì”‚É‰‚¶‚ÄÄ\’z
    private void Rebuild(int count)
    {
        ClearSpawnedCannons();

        if (_smallCannonPrefab == null || _spawnRoot == null || count <= 0)
        {
            return;
        }

        float totalWidth = _spacing * (count - 1);
        float startX = -totalWidth * 0.5f;

        for (int i = 0; i < count; i++)
        {
            float x = startX + (_spacing * i);
            Vector3 localPosition = _centerOffset + new Vector3(x, 0f, 0f);

            GameObject cannon = Instantiate(_smallCannonPrefab, _spawnRoot);
            cannon.transform.localPosition = localPosition;
            cannon.transform.localRotation = Quaternion.identity;

            _spawnedCannons.Add(cannon);
        }
    }

    // Šù‘¶‚Ì¬–C‘ä‚ğ‚·‚×‚Äíœ
    private void ClearSpawnedCannons()
    {
        for (int i = _spawnedCannons.Count - 1; i >= 0; i--)
        {
            GameObject cannon = _spawnedCannons[i];
            if (cannon == null)
            {
                continue;
            }

            if (Application.isPlaying)
            {
                Destroy(cannon);
            }
            else
            {
                DestroyImmediate(cannon);
            }
        }

        _spawnedCannons.Clear();
    }
}