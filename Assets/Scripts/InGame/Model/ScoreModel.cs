namespace InGame.Model
{
    public class ScoreModel
    {
        private int _score;

        public ScoreModel(int score)
        {
            _score = score;
        }

        public void AddScore(int score)
        {
            _score += score;
        }

        public int GetScore()
        {
            return _score;
        }
    }
}