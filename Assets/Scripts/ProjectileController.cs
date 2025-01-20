using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    private Transform target;
    private float projectileSpeed;


    private void Update()
    {
        if (target != null)
        {
            Vector2 direction = (transform.position - target.position).normalized;
            transform.position -= (Vector3)direction * projectileSpeed * Time.deltaTime;
        }
    }


    public void Init(Transform _target, float _projectileSpeed)
    {
        target = _target;
        projectileSpeed = _projectileSpeed;
    }
}
