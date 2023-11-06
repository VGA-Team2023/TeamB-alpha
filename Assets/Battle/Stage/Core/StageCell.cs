using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            public class StageCell : MonoBehaviour, IStageCell
            {
                [SerializeField]
                private float _yDelta;
                [SerializeField]
                private float _xDelta;

                [SerializeField]
                private Color _multiplePossibleColor = Color.green;
                [SerializeField]
                private Color _movableColor = Color.white;
                [SerializeField]
                private Color _placableColor = Color.yellow;
                [SerializeField]
                private Color _cantDoAnything = Color.black;

                [SerializeField]
                private Color _moveableColor;

                private int _yPos;
                private int _xPos;
                private StageCellStatus _status;

                public float YDelta => _yDelta;
                public float XDelta => _xDelta;
                public StageCell Parent { get; set; } = null;

                public int YPos => _yPos;
                public int XPos => _xPos;
                public StageCellStatus Status => _status;
                public Vector3 WorldPosition => transform.position;

                public void Initialize(int cellStatus, int yPos, int xPos)
                {
                    _status = (StageCellStatus)cellStatus;
                    _yPos = yPos; _xPos = xPos;

                    Vector3 position = new Vector3(_xDelta * _xPos, _yDelta * _yPos, 0f);
                    transform.position += position;

                    var spriteRenderer = GetComponent<SpriteRenderer>();
                    if (_status.HasFlag(StageCellStatus.Movable) &&
                        _status.HasFlag(StageCellStatus.UnitPlacable))
                    {
                        spriteRenderer.color = _multiplePossibleColor;
                    }
                    else if (_status.HasFlag(StageCellStatus.Movable))
                    {
                        spriteRenderer.color = _movableColor;
                    }
                    else if (_status.HasFlag(StageCellStatus.UnitPlacable))
                    {
                        spriteRenderer.color = _placableColor;
                    }
                    else
                    {
                        spriteRenderer.color = _cantDoAnything;
                    }
                }
            }
        }
    }
}