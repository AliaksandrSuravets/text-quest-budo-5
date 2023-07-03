using UnityEngine;

public class Level : MonoBehaviour
{
    #region Variables

    [TextArea(4, 6)]
    public string Answers;
    public bool Death;
    [TextArea(4, 12)]
    public string Description;
    public bool IsWin;
    public Sprite LocationSprite;
    [TextArea(2, 2)]
    public string NameLocation;
    public Level[] NextLevels;

    #endregion
}