using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UIDragJumpButton : MonoBehaviour, IDragHandler
{
    Vector2 currentPos;
    Vector3 newPos;
    RectTransform tr;

    // Start is called before the first frame update
    void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        tr.sizeDelta = new Vector2(PlayerPrefsManager.instance.GetButtonSize(), PlayerPrefsManager.instance.GetButtonSize());

        currentPos = RectTransformUtility.WorldToScreenPoint(new Camera(), transform.position);
        currentPos.x = Mathf.Clamp(currentPos.x, tr.sizeDelta.x / 4f, Screen.width - tr.sizeDelta.x / 4f);
        currentPos.y = Mathf.Clamp(currentPos.y, tr.sizeDelta.y / 4f, Screen.height - tr.sizeDelta.y / 4f);
        RectTransformUtility.ScreenPointToWorldPointInRectangle(tr, currentPos, new Camera(), out newPos);
        transform.position = newPos;
    
    }
    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
        PlayerPrefsManager.instance.SetJumpButtonPositionX(transform.position.x - 75f);
        PlayerPrefsManager.instance.SetJumpButtonPositionY(transform.position.y + 75f);
    }
}
