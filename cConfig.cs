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
        private int _frames_persec, _display_res_x, _display_res_y, _zoom_val;
        private bool _zoom_switch;
        public cConfig()
        {
            _running = false;
            _sounds_all = true;
            _sounds_player = true;
            _sounds_music = true;
            _sounds_effects = true;
            _frames_persec = 60;
            _display_res_x = 480;
            _display_res_y = 480;
            _zoom_switch = false;
            _zoom_val = 0;
        }
        public cConfig(int width, int height)
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
        public int frames_persec
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
    }
}
        
