using UnityEngine;

namespace TeamB_TD
{
    namespace Battle
    {
        namespace StageManagement
        {
            public class StageCell : MonoBehaviour, IStageCell, IWeaponType
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
                private Color _placeableColor = Color.yellow;
                [SerializeField]
                private Color _cantDoAnything = Color.black;

                [SerializeField]
                private Color _moveableColor;
                [SerializeField]
                private SpriteRenderer _selectedUI = null;
                [SerializeField]
                private int _orderInLayer = 100;

                private int _yPos;
                private int _xPos;
                private StageCellStatus _status;
                private WeaponType _type;

                public float YDelta => _yDelta;
                public float XDelta => _xDelta;

                public int YPos => _yPos;
                public int XPos => _xPos;
                public StageCellStatus Status => _status;
                public WeaponType WeaponType => _type;
                public Vector3 WorldPosition => transform.position;
                public GameObject GameObject => gameObject;
                public IStageCell Parent { get; set; }

                public void Initialize(int cellStatus, int yPos, int xPos)
                {
                    _status = (StageCellStatus)cellStatus;
                    _type = (WeaponType)cellStatus;
                    _yPos = yPos; _xPos = xPos;

                    Vector3 position = new Vector3(_xDelta * _xPos, _yDelta * _yPos, 0f);
                    transform.position += position;

                    var spriteRenderer = GetComponent<SpriteRenderer>();
                    if (_status.HasFlag(StageCellStatus.Movable) &&
                        _status.HasFlag(StageCellStatus.UnitPlaceable))
                    {
                        spriteRenderer.color = _multiplePossibleColor;
                        _selectedUI.color = _multiplePossibleColor;
                    }
                    else if (_status.HasFlag(StageCellStatus.Movable))
                    {
                        spriteRenderer.color = _movableColor;
                    }
                    else if (_status.HasFlag(StageCellStatus.UnitPlaceable))
                    {
                        spriteRenderer.color = _placeableColor;
                        _selectedUI.color = _placeableColor;
                    }
                    else
                    {
                        spriteRenderer.color = _cantDoAnything;
                    }

                    if (_status.HasFlag(StageCellStatus.UnitPlaceable))
                    {
                        _selectedUI.sortingOrder = _orderInLayer;
                    }
                    else
                    {
                        _selectedUI.enabled = false;
                    }
                }
            }
        }
    }
}