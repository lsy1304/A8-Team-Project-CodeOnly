using UnityEngine;

public class SpikeTrap : MonoBehaviour, ITrap
{
    Animator animator;
    public bool DefaultState;
    private bool _currentState;
    private readonly int Switch = Animator.StringToHash("Switch");
    private readonly int Reset = Animator.StringToHash("Reset");
    private readonly int OnInDefault = Animator.StringToHash("OnInDefault");

    void Start()
    {
        animator = GetComponent<Animator>();
        if(DefaultState) animator.SetBool(OnInDefault, true);
        _currentState = DefaultState;
        animator.SetBool(OnInDefault, DefaultState);
    }

    public void Toggle()
    {
        _currentState = !_currentState;
        animator.SetTrigger(Switch);
    }

    public void ResetTrap()
    {   
        animator.SetTrigger(Reset);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().Die();
        }
    }
}
