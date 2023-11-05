using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleStateManager : MonoBehaviour
{
    AppleBaseState currentState;
    public AppleGrowingState growingState = new AppleGrowingState();
    public AppleWholeState wholeState = new AppleWholeState();
    public AppleRottenState rottenState = new AppleRottenState();
    public AppleChewedState chewedState = new AppleChewedState();

    void Start()
    {
        // Start state for the state machine
        currentState = growingState;
        // "this" is a reference to the context (this exact monobehaviour script)
        currentState.EnterState(this);
    }

    void Update()
    {
        // This will call any logic in update state from the current state every frame.
        currentState.UpdateState(this);
    }

    public void SwitchState(AppleBaseState state)
    {
        currentState = state;
        state.EnterState(this);

    }

    private void OnCollisionEnter(Collision collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }
}
