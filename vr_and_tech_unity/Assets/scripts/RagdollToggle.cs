using UnityEngine;
using UnityEngine.InputSystem;
using StarterAssets;

public class RagdollToggle : MonoBehaviour
{
    // Drag the CharacterController here in the Inspector (it's on the character root)
    public CharacterController characterController;

    // We'll fill this with every bone Rigidbody on the character
    private Rigidbody[] boneRigidbodies;

    // Reference to the Animator that's driving the walking/idle animations
    private Animator animator;

    // The ThirdPersonController must be disabled too, otherwise it keeps calling
    // CharacterController.Move() on the disabled capsule every frame
    private ThirdPersonController thirdPersonController;

    private bool ragDolled;

    private void Awake()
    {
        if (characterController == null)
            characterController = GetComponent<CharacterController>();

        // Find all Rigidbodies on the character and its children
        boneRigidbodies = GetComponentsInChildren<Rigidbody>();

        // Grab the Animator
        animator = GetComponentInChildren<Animator>();

        // Grab the ThirdPersonController (it's on this same GameObject)
        thirdPersonController = GetComponent<ThirdPersonController>();

        // Start with ragdoll OFF
        SetRagdollActive(false);
    }

    private void Update()
    {
        if (Keyboard.current.rKey.wasPressedThisFrame)
        {
            Activate();
        }
    }

    public void Activate()
    {
        SetRagdollActive(!ragDolled);
    }

    private void SetRagdollActive(bool isActive)
    {
        ragDolled = isActive;
        
        // Turn off the animator when ragdolling — animation and physics fight otherwise
        if (animator != null) animator.enabled = !isActive;

        // Turn off the ThirdPersonController too — while it's enabled it would keep
        // calling Move() on the disabled capsule, spamming "CharacterController.Move
        // called on inactive controller" every frame
        if (thirdPersonController != null) thirdPersonController.enabled = !isActive;

        // Turn off the CharacterController when ragdolling — its capsule shoves the bones around otherwise
        if (characterController != null) characterController.enabled = !isActive;

        // Flip every bone's kinematic state
        foreach (Rigidbody rb in boneRigidbodies)
        {
            rb.isKinematic = !isActive;
        }
    }
}