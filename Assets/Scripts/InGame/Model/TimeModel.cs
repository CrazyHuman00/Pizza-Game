namespace InGame.Model
{
    public class TimeModel
    {
        private float _time;

        public TimeModel(float time)
        {
            _time = time;
        }

        public float GetTime()
        {
            return _time;
        }

        public void SetTime(float time)
        {
            _time = time;
        }

        public void ResetTime()
        {
            _time = 0;
        }

        public void DecreaseTime()
        {
            _time--;
        }
    }
}