using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class WaveTrigger : MonoBehaviour
{
    public Animator animator;

    private void Awake()
    {
        // Grab the Animator
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Keyboard.current.qKey.wasPressedThisFrame)
        {
            Activate();
        }
    }

    public void Activate()
    {
        animator.SetTrigger("Wave");
        Debug.Log("wave");
    }
}
