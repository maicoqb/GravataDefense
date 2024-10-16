using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private Transform healthBarBackground;
    private Transform healthBarFill;

    private float maxLife;
    private float healthPercent = 1f;
    private Transform anchor;
    private Vector3 offset;

    void Awake()
    {
        healthBarBackground = GameObject.Find("HealthBarBackground").transform;
        healthBarFill = GameObject.Find("HealthBarFill").transform;
    }

    void Update()
    {
        healthBarBackground.position = anchor.position + offset;
        healthBarBackground.rotation = Quaternion.identity;
    }

    internal void SetMaxLife(float maxLife)
    {
        this.maxLife = maxLife;
    }

    internal void SetAnchor(Transform anchor)
    {
        this.anchor = anchor;
        offset = transform.position - anchor.position;
    }

    internal void TakeDamage(float damage)
    {
        healthPercent -= damage / maxLife;

        healthBarFill.localScale = new Vector3(healthPercent, healthBarFill.localScale.y, healthBarFill.localScale.z);
    }
}
