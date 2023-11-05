using UnityEngine;

public class AppleWholeState : AppleBaseState
{
    private float rottenCountDown = 10.0f;

    public override void EnterState(AppleStateManager apple)
    {
        apple.GetComponent<Rigidbody>().useGravity = true;
    }

    public override void UpdateState(AppleStateManager apple)
    {
        if (rottenCountDown >= 0)
        {
            rottenCountDown -= Time.deltaTime;
        }
        else
        {
            apple.SwitchState(apple.rottenState);
        }
    }

    public override void OnCollisionEnter(AppleStateManager apple, Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerController>().addHealth();

            apple.SwitchState(apple.chewedState);
        }
    }
}
