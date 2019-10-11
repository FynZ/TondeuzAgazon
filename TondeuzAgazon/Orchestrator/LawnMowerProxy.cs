using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using TondeuzAgazon.Actors;
using TondeuzAgazon.Parser;

namespace TondeuzAgazon.Orchestrator
{
    public class LawnMowerProxy : IDrawable
    {
        private readonly LawnMower _lawnMower;
        private readonly IList<Rotation> _rotations;

        private int _currentActionIndex;

        public bool HasFinished { get; private set; }

        public LawnMowerProxy(LawnMowerData lawnmowerData)
        {
            HasFinished = _rotations.Count == 0 ;
            _currentActionIndex = 0;

            _lawnMower = new LawnMower(lawnmowerData.X, lawnmowerData.Y, lawnmowerData.Orientation);
            _rotations = lawnmowerData.Moves;
        }

        public (int a, int b) GetPosition()
        {
            return (_lawnMower.X, _lawnMower.Y);
        }

        public void MoveNext(char[,] map)
        {
            if (HasFinished) return;

            if (_currentActionIndex < _rotations.Count)
            {
                if (CanMove(map))
                {
                    MoveForward();
                }
            
                _currentActionIndex++;

                Rotate(_rotations[_currentActionIndex]);
            }
        }

        private void Rotate(Rotation rotation)
        {
            if (rotation == Rotation.L)
            {
                _lawnMower.Orientation = _lawnMower.Orientation.PreviousValue();
            }
            else if (rotation == Rotation.R)
            {
                _lawnMower.Orientation = _lawnMower.Orientation.NextValue();
            }
        }

        public char Draw()
        {
            return 'o';
        }

        private bool CanMove(char[,] map)
        {
            switch (_lawnMower.Orientation)
            {
                case Orientation.N:
                {
                    if (_lawnMower.Y == map.GetLength(1))
                    {
                        return false;
                    }
                    break;
                }
                case Orientation.E:
                {
                    if (_lawnMower.X == map.GetLength(2))
                    {
                        return false;
                    }
                    break;
                }
                case Orientation.S:
                {
                    if (_lawnMower.Y == 0)
                    {
                        return false;
                    }
                    break;
                }
                case Orientation.W:
                    if (_lawnMower.X == 0)
                    {
                        return false;
                    }
                    break;
            }

            return true;
        }

        private void MoveForward()
        {
            switch (_lawnMower.Orientation)
            {
                case Orientation.N:
                    _lawnMower.Y++;
                    break;
                case Orientation.E:
                    _lawnMower.X++;
                    break;
                case Orientation.S:
                    _lawnMower.Y--;
                    break;
                case Orientation.W:
                    _lawnMower.X--;
                    break;
            }
        }
    }
}
