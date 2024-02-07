using DG.Tweening;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    [SerializeField] public Vector3 moveDistance;
    [SerializeField] float moveTime = 2f;

    void Start()
    {
        transform.DOMove(moveDistance, moveTime)
            .SetRelative(true)
            .SetEase(Ease.Linear)
            .SetLoops(-1, LoopType.Yoyo);   
    }

    public void Pause()
    {
        transform.DOPause();
    }
}

