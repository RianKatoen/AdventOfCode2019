using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace AOC2019.Modules.SpaceImageFormate
{
    public class SpaceImage : IEnumerable<int[]>
    {
        private readonly (int x, int y) _size;
        private readonly int _layerSize;
        private readonly int _nLayers;
        private readonly int[] _data;

        public SpaceImage((int x, int y) size, string data)
        {
            _size = size;
            _data = data
                .ToCharArray()
                .Select(p => int.Parse(p.ToString()))
                .ToArray();

            _layerSize = _size.x * _size.y;
            _nLayers = _data.Length / _layerSize;

            if (_layerSize * _nLayers != _data.Length)
            {
                throw new ArgumentException("Size and data do not correspond which each other. Number of pixels does not correspond to a whole number of layers.");
            }
        }

        public int this[int index] => _data[index];

        public int[] Layer(int index)
        {
            if (index < 0 || index >= _nLayers)
            {
                throw new ArgumentException("Invalid layer.");
            }
            else
            {
                return _data.Skip(_layerSize * index).Take(_layerSize).ToArray();
            }
        }

        public IEnumerable<int[]> Layers()
        {
            for (var i = 0; i < _nLayers; i++)
            {
                yield return Layer(i);
            }
        }

        public SpacePixel[,] Render()
        {
            var imageLayer = Layer(0);
            foreach (var layer in this.Skip(1))
            {
                for (var pixelIndex = 0; pixelIndex < _layerSize; pixelIndex++)
                {
                    if (imageLayer[pixelIndex] == (int)SpacePixel.Transparent)
                    {
                        imageLayer[pixelIndex] = layer[pixelIndex];
                    }
                }
            }

            var image = new SpacePixel[_size.y, _size.x];
            for (var pixelIndex = 0; pixelIndex < _layerSize; pixelIndex++)
            {
                var row = pixelIndex / _size.x;
                var col = pixelIndex - _size.x * row;
                image[row, col] = (SpacePixel)imageLayer[pixelIndex];
            }

            return image;
        }

        public string[,] RenderToText()
        {
            var renderedImage = Render();
            var renderedTextImage = new string[_size.y, _size.x];
            for (var y = 0; y < _size.y; y++)
            {
                for (var x = 0; x < _size.x; x++)
                {
                    switch (renderedImage[y, x])
                    {
                        case SpacePixel.Black: renderedTextImage[y, x] = "-"; break;
                        case SpacePixel.White: renderedTextImage[y, x] = "*"; break;
                        case SpacePixel.Transparent: renderedTextImage[y, x] = " "; break;
                        default: throw new ArgumentException("Unknown SpacePixel");
                    }
                }
            }

            return renderedTextImage;
        }

        public IEnumerator<int[]> GetEnumerator() => Layers().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => Layers().GetEnumerator();
    }
}
