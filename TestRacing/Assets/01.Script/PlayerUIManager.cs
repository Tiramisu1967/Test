using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUIManager : BaseManager
{
    public TextMeshProUGUI LabText;
    public TextMeshProUGUI RacingTimeText;
    public RectTransform SpeedMeterneedle;

    public override void init(GameManager gameManager)
    {
        base.init(gameManager);
    }

    private void FixedUpdate()
    {
        LabUpdate();
        RacingTimeUpdate();
        SpeedMeterUpdate();
    }

    public void LabUpdate()
    {
        LabText.text = $"{_gameManager.player.Lab} / <color=#FFFFFF3C>{GameInstance.instance.MaxLabs[GameInstance.instance.Stage - 1]}</color> Lab";
    }

    public void RacingTimeUpdate()
    {
        RacingTimeText.text = $"Time : {GameInstance.instance.RacingTime}";
    }

    public void SpeedMeterUpdate()
    {
        SpeedMeterneedle.rotation = Quaternion.Euler(new Vector3(0, 0, 360 - (_gameManager.player.Speed * 1.4f)));
    }
}
