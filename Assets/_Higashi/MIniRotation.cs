using UnityEngine;

public class MIniRotation : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 1f;

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate(0,0,Time.deltaTime * rotationSpeed);
    }
}
