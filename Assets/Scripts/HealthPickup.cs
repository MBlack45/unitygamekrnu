using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HealthPickup : MonoBehaviour
{

    public int healthRestore = 20;

    private Tween rotationTween;

    // Start is called before the first frame update
    void Start()
    {
        rotationTween = transform.DORotate(new Vector3(0, 360, 0), 2f, RotateMode.FastBeyond360).SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();

        if (damageable)
        {
            bool wasHealed = damageable.Heal(healthRestore);

            if (wasHealed)
            {
                if(rotationTween != null && rotationTween.IsActive())
                {
                    rotationTween.Kill();
                }
                Destroy(gameObject);
            }
                
        }
    }
}
