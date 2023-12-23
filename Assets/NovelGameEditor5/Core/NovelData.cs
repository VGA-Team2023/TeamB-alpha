// 日本語対応
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TeamB_TD
{
    namespace NovelGameEditor5
    {
        [DefaultExecutionOrder(-100)]
        public class NovelData : MonoBehaviour
        {
            private static NovelData _current;
            public static NovelData Current => _current;

            private void Awake()
            {
                _current = this;
            }
            private void OnDestroy()
            {
                _current = null;
            }

            [SerializeField]
            private TextMeshProUGUI _text;
            [SerializeField]
            private TextMeshProUGUI _caption;
            [SerializeField]
            private Image _screenImage;
            [SerializeField]
            private Transform _selectViewPrefabParent;
            [SerializeField]
            private SelectView _selectViewPrefab;
            [SerializeField]
            private Image _bgImage;
            [SerializeField, Range(0.8f, 2f)]
            private float _autoDuration = 1f;
            [SerializeField, Header("話しているActorのサイズ")]
            private Vector3 _talkingActorSize = new Vector3(0.5f, 0.5f, 0.5f);
            [SerializeField, Header("話していないActorのサイズ")]
            private Vector3 _notTalkingActorSize = new Vector3(0.45f, 0.45f, 0.45f);
            [SerializeField, Header("話していないActorの暗さ加減")]
            private Color _darkColor = new Color32(144, 144, 144, 246);
            [SerializeField, Header("ActorのImage配列")]
            private Image[] _activeActor = new Image[3];
            [SerializeField, Header("Unit立ち絵の配列")]
            private Sprite[] _allyUnitSprites;
            [SerializeField, Header("背景イラストの配列")]
            private Sprite[] _bgSprites;

            public TextMeshProUGUI Text => _text;
            public TextMeshProUGUI Caption => _caption;
            public Image ScreenImage => _screenImage;
            public Image BG => _bgImage;
            public Transform SelectViewPrefabParent => _selectViewPrefabParent;
            public SelectView SelectViewPrefab => _selectViewPrefab;
            public float AutoDuration => _autoDuration;
            public Vector3 TalkingActorSize => _talkingActorSize;
            public Vector3 NotTalkingActorSize => _notTalkingActorSize;
            public Color DarkColor => _darkColor;
            public Image[] ActiveActor => _activeActor;
            public Sprite[] AllyUnitSprites => _allyUnitSprites;
            public Sprite[] BGSprites => _bgSprites;
        }
    }
}