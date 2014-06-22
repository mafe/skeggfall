using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.Runtime.InteropServices;

namespace SkeggFallLevelDesigner
{
    class cButtons
    {

        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }


        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);



        [StructLayout(LayoutKind.Sequential)]
        struct ICONINFO
        {
            public bool fIcon;         // Specifies whether this structure defines an icon or a cursor. A value of TRUE specifies
            // an icon; FALSE specifies a cursor.
            public Int32 xHotspot;     // Specifies the x-coordinate of a cursor's hot spot. If this structure defines an icon, the hot
            // spot is always in the center of the icon, and this member is ignored.
            public Int32 yHotspot;     // Specifies the y-coordinate of the cursor's hot spot. If this structure defines an icon, the hot
            // spot is always in the center of the icon, and this member is ignored.
            public IntPtr hbmMask;     // (HBITMAP) Specifies the icon bitmask bitmap. If this structure defines a black and white icon,
            // this bitmask is formatted so that the upper half is the icon AND bitmask and the lower half is
            // the icon XOR bitmask. Under this condition, the height should be an even multiple of two. If
            // this structure defines a color icon, this mask only defines the AND bitmask of the icon.
            public IntPtr hbmColor;    // (HBITMAP) Handle to the icon color bitmap. This member can be optional if this
            // structure defines a black and white icon. The AND bitmask of hbmMask is applied with the SRCAND
            // flag to the destination; subsequently, the color bitmap is applied (using XOR) to the
            // destination by using the SRCINVERT flag.
        }

        [DllImport("user32.dll")]
        static extern bool GetIconInfo(IntPtr hIcon, out ICONINFO piconinfo);

        [DllImport("user32.dll")]
        static extern IntPtr CreateIconIndirect([In] ref ICONINFO piconinfo);

        // Create a cursor from a bitmap.
        private Cursor BitmapToCursor(Bitmap bmp,
            int hot_x, int hot_y)
        {
            // Initialize the cursor information.
            ICONINFO icon_info = new ICONINFO();
            IntPtr h_icon = bmp.GetHicon();
            GetIconInfo(h_icon, out icon_info);
            icon_info.xHotspot = hot_x;
            icon_info.yHotspot = hot_y;
            icon_info.fIcon = false;    // Cursor, not icon.

            // Create the cursor.
            IntPtr h_cursor = CreateIconIndirect(ref icon_info);
            return new Cursor(h_cursor);
        }


        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private List<int> pos_x, pos_y, width, height, img_x, img_y, state, bt_cat;
        //state: 0 none, 1 clicked, 2 dragdrop, 3 checked
        private List<string> _name;
        private List<Color> colour;
        private int _buttonWidth;
        private Pen buttonPen;
        private Pen catPen;
        private Color cat_colour;
        private cButtonsCat buttonCats;
        private Bitmap buttonsprite;
        private bool pos_calculated;
        private bool changed_button;
        public cButtons(int all_buttonWidth, Bitmap sprite)
        {
            pos_x = new List<int>();
            pos_y = new List<int>();
            width = new List<int>();
            height = new List<int>();
            img_x = new List<int>();
            img_y = new List<int>();
            state = new List<int>();
            bt_cat = new List<int>();
            _name = new List<string>();
            colour = new List<Color>();
            _buttonWidth = all_buttonWidth;
            buttonsprite = new Bitmap(sprite);
            pos_calculated = false;
            buttonPen = new Pen(Color.Black, 3);
            buttonCats = new cButtonsCat();//Anlegen der Klasse Buttons Kategorie
            buttonCats.add(0, 0, 300, 0, 1, 50, 50, 15, "White", "Boden");//Anlegen einer Kategorie Buttons
            buttonCats.add(0, 50, 300, 0, 1, 50, 50, 15, "White", "Wolken");//Anlegen einer Kategorie Buttons
            buttonCats.add(0, 50, 300, 0, 1, 50, 50, 15, "White", "Sky");//Anlegen einer Kategorie Buttons
            buttonCats.add(0, 50, 300, 0, 1, 50, 50, 15, "White", "Player");//Anlegen einer Kategorie Buttons
            changed_button = true;
            cat_colour = Color.DarkGreen;
            catPen = new Pen(cat_colour, 3);
            //log.Debug("ID: " + Convert.ToString(buttonCats.id("Wolken")));//todo debug
        }
        public void pos_calculation(int margin, int margin_first, int margin_last)
        {
            if (!pos_calculated)
            {
                //Graphics g = p.CreateGraphics();
                int prev = 0, prev_cat = 0, button_number;
                bool first = true, last = false, last_cat = false;


                for (int i = 0; i < buttonCats.count(); i++)
                {//Gehe durch alle Button Kategorien
                    button_number = button_count(buttonCats.name(i));//Zähle Anzahl Buttons in derzeitiger Kategorie
                    int counter_row = 0;
                    for (int j = 0; j < button_count_all(); j++)//weise pos den jeweiligen Buttons zu, es fehlt abprüfen das nur buttons die wirklich in der kategorie sind genommen werden
                    {
                        if (bt_cat[j] == buttonCats.id(buttonCats.name(i)))//Gehe durch alle Buttons der derzeitigen Kategorie
                        {
                            if (counter_row % 2 == 0)//Berechnungen für doppelte Reihen
                            {
                                pos_x[j] = 25;
                            }
                            else
                            {
                                pos_x[j] = 25 + margin + width[j];
                                prev -= margin + height[j];
                            }
                            counter_row++;
                            pos_y[j] = margin + height[j] + prev;

                            prev += margin + height[j];
                        }
                    }
                    prev += 30;
                }
                pos_calculated = true;
            }
        }
        public void draw(Panel p, cMap map)
        {
            if (changed_button)
            {
                p.Refresh();
                for (int i = 0; i < buttonCats.count(); i++)
                {//Gehe durch alle Button Kategorien
                    for (int j = 0; j < button_count_all(); j++)//Richtige Zählung 
                    {//Male Buttons
                        //log.Debug(Convert.ToString(colour[j]) + " " + Convert.ToString(j) + " nam: " + _name[j]);
                        if (bt_cat[j] == buttonCats.id(buttonCats.name(i)))
                        {
                            button_draw(pos_x[j], pos_y[j], _name[j], p, 0);
                        }
                    }
                }
                changed_button = false;
                map.changer();
            }
        }

        public void add(string add_name, int add_state, string cat_name, int add_width, int add_height, Color add_color, int add_img_x, int add_img_y)
        {
            try
            {
                _name.Add(add_name);
                colour.Add(add_color);
                state.Add(add_state);
                pos_x.Add(10);
                pos_y.Add(10);
                img_x.Add(add_img_x);
                img_y.Add(add_img_y);
                bt_cat.Add(buttonCats.id(cat_name));//Erhalt der ID der Buttonkategorie, übergabe von string name, Name muss eindeutig sein.
                width.Add(add_width);
                height.Add(add_height);
                //log.Debug("add: " + Convert.ToString(add_color)+" anz: "+Convert.ToString(colour[(_name.Count()-1)]));
            }
            catch (Exception e)
            {
                //log.Debug("Fehler: " + e.Message);
            }
        }
        public int id(string nam)
        {//gibt ID von Übergebenem Button wieder.
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
        public int collision_detect(int mouse_x, int mouse_y)
        {//gibt id des collidierten buttons zurück, wenn nix -1
            //bool helper = false;
            int helper = -1;
            for (int i = 0; i < _name.Count(); i++)
            {
                if ((mouse_x <= pos_x[i] + width[i]) &&
            (mouse_x >= pos_x[i]) &&
            (mouse_y <= pos_y[i] + height[i]) &&
            (mouse_y >= pos_y[i]))
                {
                    //log.Debug("Hover");
                    helper = i;
                }
            }
            return helper;
        }
        public int button_count(string nam)
        {//Liefer Anzahl der Buttons in einer Kategorie wieder, funktionsfähig
            int helper = 0;
            for (int i = 0; i < _name.Count(); i++)
            {
                if (buttonCats.id(nam) == bt_cat[i])
                {
                    helper++;
                }
            }
            return helper;
        }

        private int button_count_all()
        {//Liefert Anzahl aller Buttons zurück
            return _name.Count();
        }

        public string name(int index)
        {//liefert Name der Kategorie an Position index ind, als string zurück
            string helper = null;
            if (index != -1)
                helper = this._name[index];
            return helper;
        }

        public int buttonWidth
        {
            get { return this._buttonWidth; }
        }

        public void click(int mouse_x, int mouse_y)
        {//noch nicht fertig, state muss wieder zurückgesetzt werden
            int helper = collision_detect(mouse_x, mouse_y);
            if (helper != -1)
            {
                if (state[helper] != 3)
                    state[helper] = 1;
                //MessageBox.Show("clicked" + _name[helper]);
            }
        }

        public void upclick(int mouse_x, int mouse_y)
        {//noch nicht fertig, state muss wieder zurückgesetzt werden
            if (statefinder(1) != -1)
                state[statefinder(1)] = 0;
            if (statefinder(2) != -1)
                state[statefinder(2)] = 0;
        }
        public void hover(int mouse_x, int mouse_y)
        {//ändert Cursor bei Hover
            if (collision_detect(mouse_x, mouse_y) != -1)
            {//noch nicht fertig, bleibt nicht konstant
                if (Cursor.Current != Cursors.Hand)
                    Cursor.Current = Cursors.Hand;
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
        public int _state(int id)
        {//liefert state des buttons der übergebenen ID wieder;
            return state[id];
        }

        public int statefinder(int sta)
        {//liefert ID zurück von Button der übergebenen State hat, setzt am Ende state wieder auf 0
            int helper = -1;
            for (int i = 0; i < _name.Count(); i++)
            {
                if (state[i] == sta)
                {
                    helper = i;
                    //state[i] = -1;
                }
            }
            return helper;
        }
        public void checker(int x, int y)
        {
            int helper = collision_detect(x, y);
            int helper2 = -1;

            if (helper != -1)
            {
                for (int i = 0; i < _name.Count(); i++)
                {
                    if (state[i] == 3)
                    {
                        helper2 = i;
                    }
                }
                if (helper2 != helper && helper2 != -1)
                {
                    state[helper2] = 0;
                    //MessageBox.Show("unchecked old when complete new");
                }

                if (helper2 == helper && helper2 != -1)
                {
                    state[helper2] = 0;
                    //MessageBox.Show("unchecked old");
                }
                else
                {
                    state[helper] = 3;
                    changed_button = true;
                    //MessageBox.Show("check new");
                }
                //MessageBox.Show("clicked" + _name[helper]);
            }
        }

        public void button_draw(int x, int y, string nam, Panel p, int sender)//sender 0 = normal, 1 = map
        {//malt Button, benötigt x und y wo er hingemalt werden soll, Name des Buttons, und Panel auf das er gemalt werden soll.
            Graphics g = p.CreateGraphics();
            Pen checkedPen = new Pen(Color.Green, 4);
            int button_id = id(nam);
            g.DrawImage(buttonsprite,
                        new Rectangle(x, y, 50, 50),/*Ziel*/
                        new Rectangle(img_x[button_id], img_y[button_id], width[button_id], height[button_id]),/*Source*/
                        GraphicsUnit.Pixel);
            if (state[button_id] == 3 && sender == 0)
            {
                g.DrawLine(checkedPen, x, y + height[button_id], x + width[button_id], y + height[button_id]);
            }
            g.Dispose();
        }
        public void drag_drop(int mouse_x, int mouse_y, string nam)
        {
            /*
            if (statefinder(1) != -1)
                state[statefinder(1)] = 2;*/
            if (collision_detect(mouse_x, mouse_y) != -1)
            {
                Bitmap bm = new Bitmap(50, 50);
                int button_id = id(nam);
                using (Graphics g = Graphics.FromImage(bm))
                {
                    g.DrawImage(buttonsprite,
                            new Rectangle(0, 0, 50, 50),//Ziel
                            new Rectangle(img_x[button_id], img_y[button_id], width[button_id], height[button_id]),//Source
                            GraphicsUnit.Pixel);
                }

                //bm.MakeTransparent(bm.GetPixel(0, 0));
                Cursor.Current = BitmapToCursor(bm, 7, 7);
            }
        }
        public void state_set(int id_st, int set_st)
        {//id_st = erwartet den state dessen button gesucht werden soll, set_st erwartet den state wo der jenige button erhalten soll
            do
            {
                if (statefinder(id_st) != -1)
                    state[statefinder(id_st)] = set_st;
            } while (statefinder(id_st) != -1);
        }
        public void clear(Panel p)
        {
            Graphics g = p.CreateGraphics();
            Rectangle rec = new Rectangle(0, 0, 150, 1080);
            Pen clearpen = new Pen(p.BackColor);
            MessageBox.Show(p.BackColor.ToString());
            g.DrawRectangle(clearpen, rec);
            g.Dispose();
        }
        public void changer ()
        {
            changed_button = true;
        }
    }
}
