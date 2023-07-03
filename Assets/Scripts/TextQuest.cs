using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextQuest : MonoBehaviour
{
    #region Variables

    public TMP_Text AnswersLabel;
    public TMP_Text DeathLabel;
    public TMP_Text DescriptionLabel;
    public TMP_Text LacationNameLabel;
    public Image SpriteLevel;
    public Level StartLevel;
    private Level _currentLevel;
    private int _death;

    private readonly KeyCode[] _inputKeys =
    {
        KeyCode.Alpha1, KeyCode.Alpha2, KeyCode.Alpha3,
        KeyCode.Alpha4, KeyCode.Alpha5, KeyCode.Alpha6,
        KeyCode.Alpha7, KeyCode.Alpha8, KeyCode.Alpha9,
    };

    #endregion

    #region Unity lifecycle

    private void Start()
    {
        _currentLevel = StartLevel;
        UpdateUi();
    }

    private void Update()
    {
        for (int i = 0; i < _inputKeys.Length; i++)
        {
            if (IsNextLevelExist(i) && Input.GetKeyDown(_inputKeys[i]))
            {
                _currentLevel = GetNextLevel(i);
                CalculateDeath();
                UpdateUi();
            }
        }

        if (_currentLevel.IsWin && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    #endregion

    #region Private methods

    private void CalculateDeath()
    {
        if (_currentLevel.Death)
        {
            _death++;
        }
    }

    private Level GetNextLevel(int index)
    {
        return _currentLevel.NextLevels[index];
    }

    private bool IsNextLevelExist(int index)
    {
        return _currentLevel.NextLevels.Length > index;
    }

    private void UpdateUi()
    {
        AnswersLabel.text = _currentLevel.Answers;
        DescriptionLabel.text = _currentLevel.Description;
        LacationNameLabel.text = _currentLevel.NameLocation;
        DeathLabel.text = $"Смертей: {_death}";
        SpriteLevel.sprite = _currentLevel.LocationSprite;
    }

    #endregion
}