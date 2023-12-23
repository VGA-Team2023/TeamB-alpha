using TeamB_TD.Battle.Unit.Ally;
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
                private Sprite _meleePlaceableUI;
                [SerializeField]
                private Sprite _rangePlaceableUI;
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
                public AllyController PlacedAlly { get; set; }

                public void Initialize(int cellStatus, int yPos, int xPos)
                {
                    _status = (StageCellStatus)cellStatus;
                    _type = (WeaponType)cellStatus;
                    _yPos = yPos; _xPos = xPos;

                    Vector3 position = new Vector3(_xDelta * _xPos, _yDelta * _yPos, 0f);
                    transform.position += position;

                    var spriteRenderer = GetComponent<SpriteRenderer>();
                    spriteRenderer.sprite = _type switch
                    {
                        WeaponType.None => null,
                        WeaponType.Range => _rangePlaceableUI,
                        WeaponType.Melee => _meleePlaceableUI,
                        _ => null
                    };
                }
            }
        }
    }
}