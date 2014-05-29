using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeggFallLevelDesigner
{
    class cButtonsCat
    {
        private List<int> _pos_x, _pos_y, _width, _height, _state, _bt_std_width, _bt_std_height, _margin_left, _id;
        private List<string> _colour, _name;

        public cButtonsCat()
        {
            _pos_x = new List<int>();
            _pos_y = new List<int>();
            _width = new List<int>();
            _height = new List<int>();
            _state = new List<int>();
            _bt_std_width = new List<int>();
            _bt_std_height = new List<int>();
            _margin_left = new List<int>();
            _colour = new List<string>();
            _name = new List<string>();
            _id = new List<int>();
        }

        public void add(int x, int y, int w, int h, int st, int bt_w, int bt_h, int ml, string col, string nam)
        {
            _pos_x.Add(x);
            _pos_y.Add(y);
            _width.Add(w);
            _height.Add(h);
            _state.Add(st);
            _bt_std_width.Add(bt_w);
            _bt_std_height.Add(bt_h);
            _margin_left.Add(ml);
            _colour.Add(col);
            _name.Add(nam);
            _id.Add(_name.Count());
        }

        public int pos_x(int ind)
        {
            return this._pos_x[ind];
        }
        public int pos_y(int ind)
        {
            return this._pos_y[ind];
        }
        public int width(int ind)
        {
            return this._width[ind];
        }
        public int height(int ind)
        {
            return this._height[ind];
        }
        public int state(int ind)
        {
            return this._state[ind];
        }

        public int bt_std_width(int ind)
        {
            return this._bt_std_width[ind];
        }

        public int bt_std_height(int ind)
        {
            return this._bt_std_height[ind];
        }

        public int margin_left(int ind)
        {
            return this._margin_left[ind];
        }

        public string name(int ind)
        {//liefert Name der Kategorie an Position index ind, als string zurück
            return this._name[ind];
        }

        public int id(string nam)
        {//gibt ID von Übergebener Klasse wieder.
            int helper2 = 0;
            for (int i = 0; i < _name.Count(); i++)
            {
                if (_name[i] == nam)
                {
                    helper2 = i;
                }
            }
            return helper2;
        }

        public int count()
        {
            return _id.Count();
        }
    }
}
