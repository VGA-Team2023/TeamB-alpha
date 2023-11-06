namespace TeamB_TD
{
    namespace Battle
    {
        public static class GameSpeedController
        {
            private static float _currentSpeed = 1f;

            public static float CurretGameSpeed => _currentSpeed;

            public static void ChangeGameSpeed(float speed)
            {
                _currentSpeed = speed;
            }
        }
    }
}