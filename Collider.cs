using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace customfinal
{
    public class Collider
    {
        private float _offsetX, _offsetY;
        private float _width, _height;
        private bool _isHitbox;
        public Collider(float offsetX, float offsetY, float width, float height, bool isHitbox)
        {
            OffsetX = offsetX;
            OffsetY = offsetY;
            Width = width;
            Height = height;
            IsHitbox = isHitbox;
        }
        public float OffsetX
        {
            get { return _offsetX; }
            set { _offsetX = value; }
        }
        public float OffsetY
        {
            get { return _offsetY; }
            set { _offsetY = value; }
        }
        public float Width
        {
            get { return _width; }
            set { _width = value; }
        }
        public float Height
        {
            get { return _height; }
            set { _height = value; }
        }
        public bool IsHitbox
        {
            get { return _isHitbox; }
            set { _isHitbox = value; }
        }
    }
}
