using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProfileMenu : MonoBehaviour
{
    public Sprite bronzeBadge;
    public Sprite silverBadge;
    public Image currentBadge;

    public Text RelationDescription;
    public Text ProgressDescription;

    void Start()
    {
        switch (CL.CurrentLevel)
        {
            case 3:
                currentBadge.sprite = silverBadge;
                break;
            default:
                currentBadge.sprite = bronzeBadge;
                break;
        }

        CalculateRelation();
        CalculateProgress();
    }

    private void CalculateRelation()
    {
        var curRelation = CL.CurrentRelations;
        if (curRelation < 50)
            RelationDescription.text = $"Враждебное ({curRelation}%)";
        else
            RelationDescription.text = $"Дружелюбное ({curRelation}%)";
    }

    private void CalculateProgress()
    {
        var curProgress = Mathf.Round(((CL.CurrentLevel - 1)/(float)CL.TotalChapters)*100);
        ProgressDescription.text = $"{curProgress}%";
    }
}
