using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreamGameController : MonoBehaviour
{
    public Sprite screamSprite;
    public CanvasGroup smallScream;
    public CanvasGroup loudScream;

    private InflateController _inflateControllerRef;
    private ViolentShakingComponent _violentShakeRef;
    // Start is called before the first frame update
    void Start()
    {
        _inflateControllerRef = GetComponent<InflateController>();
        _violentShakeRef = GetComponent<ViolentShakingComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        _violentShakeRef.shakeMagnitude = (_inflateControllerRef.Scale - 1.0f) / 2.0f;
        if(_violentShakeRef.shakeMagnitude < 0.1f)
        {
            _violentShakeRef.shakeMagnitude = 0.0f;
        }

        if(!_inflateControllerRef.CanContinueToInflate)
        {
            GetComponent<SpriteRenderer>().sprite = screamSprite;
        }

        if(MicrogameController.instance.HasWon())
        {
            loudScream.alpha = 1.0f;
        }
        if(MicrogameController.instance.HasLost())
        {
            smallScream.alpha = 1.0f;
        }
    }
}
