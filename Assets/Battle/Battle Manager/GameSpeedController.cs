namespace TeamB_TD
{
    namespace Battle
    {
        public static class GameSpeedController
        {
            private static float _currentSpeed = 1f;

            private static bool _isPaused = false;

            public static float CurrentSpeed => _currentSpeed;
            public static bool IsPaused => _isPaused;

            public static float CurretGameSpeed => _isPaused ? 0f : _currentSpeed;

            public static void ChangeGameSpeed(float speed)
            {
                _currentSpeed = speed;
            }

            public static void Pause()
            {
                _isPaused = true;
            }

            public static void Resume()
            {
                _isPaused = false;
            }
        }
    }
}