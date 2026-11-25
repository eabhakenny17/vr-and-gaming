using UnityEngine;
using UnityEngine.InputSystem;

public class RunTrigger : MonoBehaviour
{
    public Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("Shift", true);
        }
        else if(!Input.GetKey(KeyCode.LeftShift)){
            animator.SetBool("Shift", false);
        }
    }
}
