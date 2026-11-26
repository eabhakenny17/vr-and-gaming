using UnityEngine;
using UnityEngine.InputSystem;

public class FlipAudio : MonoBehaviour
{
    public AudioSource flipSoundEffect;
    public Animator anim;
    private bool ramping;

    void Update(){
        //don't flip if you're laready flipping
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("FlipBlendTree"))
        return;

        if(Keyboard.current.fKey.wasPressedThisFrame){
            anim.SetFloat("FlipBlend", 0f); //start blended from idle anim
            anim.SetTrigger("Flip");
            ramping = true;
        }

        if (ramping){
            float v = Mathf.MoveTowards(anim.GetFloat("FlipBlend"), 1f, Time.deltaTime / 0.1f);
            anim.SetFloat("FlipBlend", v);
            if (v >= 1f) ramping = false;
        }
    }

    public void PlayAudio(){
        flipSoundEffect.Play();
    }
}
