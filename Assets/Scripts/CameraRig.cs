using UnityEngine;

public class CameraRig : MonoBehaviour
{
    [Header("REFERENCES")]
    [SerializeField] private Transform target;

    [Header("RIG SETTINGS")]
    [SerializeField] private Vector3 rigOffset = Vector3.zero;
    [SerializeField] private float rigSmoothness = 1f;

    private void Update()
    {
        Vector3 targetPosition = target.position + rigOffset;
        Vector3 newRigPosition = Vector3.Lerp(transform.position, targetPosition, rigSmoothness);
        //to avoid problems with possibles compenetrations
        transform.position = new Vector3(newRigPosition.x, newRigPosition.y, -1);
    }
}
