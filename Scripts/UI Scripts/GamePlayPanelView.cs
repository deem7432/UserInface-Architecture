using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GamePlayPanelView : UIView
{

    [SerializeField] private Button m_pauseButton;
    [SerializeField] private Text m_ScoreText;
    [SerializeField] private Text m_CurrencyText;
    
    public override void Initialize()
    {
        m_pauseButton.onClick.AddListener(OnPauseClick);
        UIEvents.m_gameplayScoreUpdate += ScoreUpdate;
        UIEvents.m_gameplayCurrencyUpdate += CurrencyUpdate;
    }

    private void CurrencyUpdate(int currency)
    {
        m_CurrencyText.text = currency.ToString();
    }

    private void ScoreUpdate(int scoreValue)
    {
        m_ScoreText.text = scoreValue.ToString();
    }

    private void OnPauseClick()
    {
        UIViewManager.Show<PausePanelView>();
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        UIEvents.m_gameplayScoreUpdate -= ScoreUpdate;
        UIEvents.m_gameplayCurrencyUpdate -= CurrencyUpdate;
    }
}
