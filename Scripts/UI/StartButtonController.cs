using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonController : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        SoundManager.Instance.PlaySE("Buttonclick");
        animator.Play("OnButtonAnim");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        animator.Play("IDleButton"); 
    }
}
