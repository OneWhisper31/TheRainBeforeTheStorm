using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    public int widthSize=90;
    public float[] posX;

    Image image;
    RectTransform rectTransform;
    public int currentHealth=4;

    private void Start() {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void DamagedUpdateUIHealth(){
        currentHealth--;
        rectTransform.sizeDelta=new Vector2(widthSize*currentHealth,rectTransform.sizeDelta.y);
        var position = this.transform.localPosition;
        rectTransform.localPosition= new Vector3(posX[currentHealth],position.y,position.z);
    }
    public void HealedUpdateUIHealth(){
        if(currentHealth>=4) return;
        currentHealth++;
        rectTransform.sizeDelta=new Vector2(widthSize*currentHealth,rectTransform.sizeDelta.y);
        var position = this.transform.localPosition;
        rectTransform.localPosition= new Vector3(posX[currentHealth],position.y,position.z);
    }
}
