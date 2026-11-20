using UnityEngine;
using StarterAssets;

public class RagdollToggle : MonoBehaviour
{
    public KeyCode toggleKey = KeyCode.R;   // test key

    private bool _ragdolled;
    private Animator _animator;
    private CharacterController _cc;
    private ThirdPersonController _tpc;
    private Rigidbody[] _bodies;

    void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _cc = GetComponent<CharacterController>();
        _tpc = GetComponent<ThirdPersonController>();
        _bodies = GetComponentsInChildren<Rigidbody>();
        Apply(false);                        // start in normal mode
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey)) Apply(!_ragdolled);
    }

    void Apply(bool ragdoll)
    {
        _ragdolled = ragdoll;
        if (_animator) _animator.enabled = !ragdoll;
        if (_cc) _cc.enabled = !ragdoll;
        if (_tpc) _tpc.enabled = !ragdoll;

        foreach (var rb in _bodies)
            rb.isKinematic = !ragdoll;        // wizard bones only (non-tagged ones)
    }
}