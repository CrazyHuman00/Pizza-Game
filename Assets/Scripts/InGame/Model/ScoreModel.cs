namespace InGame.Model
{
    public class ScoreModel
    {
        private int _score;

        public void AddScore()
        {
            _score++;
        }

        public int GetScore()
        {
            return _score;
        }
    }
}