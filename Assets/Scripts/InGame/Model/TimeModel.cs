namespace InGame.Model
{
    public class TimeModel
    {
        private int _time;

        public TimeModel(int time)
        {
            _time = time;
        }

        public int GetTime()
        {
            return _time;
        }

        public void SetTime(int time)
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