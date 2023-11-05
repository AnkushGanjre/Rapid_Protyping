using UnityEngine;

public class AppleChewedState : AppleBaseState
{
    private float destroyCountdown = 5.0f;

    public override void EnterState(AppleStateManager apple)
    {

    }

    public override void UpdateState(AppleStateManager apple)
    {
        if (destroyCountdown > 0)
        {
            destroyCountdown -= Time.deltaTime;
        }
        else
        {
            //object.Destroy(apple.gameObject);
        }
    }

    public override void OnCollisionEnter(AppleStateManager apple, Collision collision)
    {

    }
}
