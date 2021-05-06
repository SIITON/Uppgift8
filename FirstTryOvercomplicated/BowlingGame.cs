using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Uppgift8.Bowling
{
    public class BowlingGame : IBowlingGame
    {
        private int _currentFrame;
        public int PinsStanding { get; private set; }
        private List<int[]> _pinsKnockedPerFrame;
        private int[] _score;
        private int _rollIndex;
        private List<Frame> _scorePerFrame;

        public BowlingGame()
        {
            _currentFrame = 1;
            PinsStanding = 10;
            _pinsKnockedPerFrame = new List<int[]>();
            _scorePerFrame = new List<Frame>();
            _rollIndex = 0;
            _score = new int[3] { 0, 0, 0 };
        }
        public void Roll(int pins_knocked_down)
        {
            PinsStanding -= pins_knocked_down;
            _score[_rollIndex] = pins_knocked_down;
            _rollIndex += 1;
            

            // Reset and start new frame
            if ((PinsStanding == 0 || _rollIndex == 2) && _currentFrame != 10)
            {
                var frame = CreateFrameOfCurrentState();
                _scorePerFrame.Add(frame);
                _pinsKnockedPerFrame.Add(_score);
                _score = new int[3] { 0, 0, 0 };
                _currentFrame += 1;
                ResetPins();
            }
            if (_currentFrame >= 10)
            {
                if (PinsStanding > 0 && _rollIndex == 2)
                {
                    var frame = CreateFrameOfCurrentState();
                    _scorePerFrame.Add(frame);
                    _score = new int[3] { 0, 0, 0 };
                    _currentFrame += 1;
                    ResetPins();
                }
                if (PinsStanding == 0)
                {
                    var frame = CreateFrameOfCurrentState();
                    _scorePerFrame.Add(frame);
                    _score = new int[3] { 0, 0, 0 };
                    _currentFrame += 1;
                    ResetPins();
                }
            }

        }
        public int Score()
        {
            var score = 0;
            foreach (var frame in _scorePerFrame.Take(10))
            {
                var sum = 0;
                foreach (var point in frame.Score)
                {
                    sum += point;
                }
                if (frame.Spare)
                {
                    var next_scores = _scorePerFrame.Where(f => f.Id == frame.Id + 1)
                                                    .Select(f => f.Score)
                                                    .ElementAt(0);
                    sum += next_scores[0];
                }
                if (frame.Strike && frame.Id < 12)
                {
                    var next_frame = _scorePerFrame.Where(f => f.Id == frame.Id + 1)
                                                   .Select(f => f)
                                                   .First();
                    var next_score = next_frame.Score;
                    sum += next_score[0];
                    if (next_frame.Strike && next_frame.Id < 12)
                    {
                        var second_frame = _scorePerFrame.Where(f => f.Id == frame.Id + 2)
                                                         .Select(f => f)
                                                         .First();
                        var second_score = second_frame.Score;
                        sum += second_score[0];
                    }
                    else if (next_frame.Strike && next_frame.Id == 12)
                    {
                        sum += 10;
                    }
                    else
                    {
                        sum += next_score[1];
                    }
                }
                score += sum;
            }
            return score;
        }
        private void ResetPins()
        {
            _rollIndex = 0;
            PinsStanding = 10;
        }
        private Frame CreateFrameOfCurrentState()
        {
            return new Frame
            {
                Id = _currentFrame,
                Strike = (_rollIndex == 1) ? true : false,
                Spare = (PinsStanding == 0 && _rollIndex == 2) ? true : false,
                Score = _score
            };
        }
    }
}
