using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkeggFallLevelDesigner
{
    class cConfig
    {
        private bool _running;
        private bool _sounds_all, _sounds_player, _sounds_music, _sounds_effects;
        private int _display_res_x, _display_res_y, _zoom_val, _map_width, _map_height, _buttonsquare;
        private double _frames_persec;
        private bool _zoom_switch;
        public cConfig()
        {
            _running = false;
            _sounds_all = true;
            _sounds_player = true;
            _sounds_music = true;
            _sounds_effects = true;
            _frames_persec = 0.1;
            _display_res_x = 480;
            _display_res_y = 480;
            _zoom_switch = false;
            _zoom_val = 0;
            _map_width = 900;
            _map_height = 600;
            _buttonsquare = 50;
        }
        public cConfig(int width, int height, int mw, int mh, int bs)
        {
            _running = false;
            _sounds_all = true;
            _sounds_player = true;
            _sounds_music = true;
            _sounds_effects = true;
            _frames_persec = 60;
            _display_res_x = width;
            _display_res_y = height;
            _zoom_switch = false;
            _zoom_val = 0;
            _map_width = mw;
            _map_height = mh;
            _buttonsquare = bs;
        }

        public bool running
        {
            set { this._running = value; }
            get { return this._running; }
        }
        public bool sounds_all
        {
            set { this._sounds_all = value; }
            get { return this._sounds_all; }
        }
        public bool sounds_player
        {
            set { this._sounds_player = value; }
            get { return this._sounds_player; }
        }
        public bool sounds_music
        {
            set { this._sounds_music = value; }
            get { return this._sounds_music; }
        }
        public bool sounds_effects
        {
            set { this._sounds_effects = value; }
            get { return this._sounds_effects; }
        }
        public double frames_persec
        {
            set { this._frames_persec = value; }
            get { return this._frames_persec; }
        }
        public int display_res_x
        {
            set { this._display_res_x = value; }
            get { return this._display_res_x; }
        }
        public int display_res_y
        {
            set { this._display_res_y = value; }
            get { return this._display_res_y; }
        }
        public int zoom_val
        {
            set { this._zoom_val = value; }
            get { return this._zoom_val; }
        }
        public int map_width
        {
            set { this._map_width = value; }
            get { return this._map_width; }
        }
        public int map_height
        {
            set { this._map_height = value; }
            get { return this._map_height; }
        }
        public int buttonsquare
        {
            set { this._buttonsquare = value; }
            get { return this._buttonsquare; }
        }
    }
}
        
