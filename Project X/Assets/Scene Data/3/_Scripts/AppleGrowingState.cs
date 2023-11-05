using UnityEngine;

public class AppleGrowingState : AppleBaseState
{
    private Vector3 startingAppleSize = new Vector3(0.1f, 0.1f, 0.1f);
    private Vector3 growingAppleScalar = new Vector3(0.1f, 0.1f, 0.1f);

    public override void EnterState(AppleStateManager apple)
    {
        apple.transform.localScale = startingAppleSize;
    }

    public override void UpdateState(AppleStateManager apple)
    {
        if (apple.transform.localScale.x < 1)
        {
            apple.transform.localScale += growingAppleScalar * Time.deltaTime;
        }
        else
        {
            // immediately switch to the whole state once complete
            apple.SwitchState(apple.wholeState);
        }
    }

    public override void OnCollisionEnter(AppleStateManager apple, Collision collision)
    {

    }
}
