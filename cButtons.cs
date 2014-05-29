using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkeggFallLevelDesigner
{
    class cButtons
    {
        private List<int> pos_x, pos_y, width, height, state, bt_cat;
        private List<string> _name;
        private List<Color> colour;
        private Pen buttonPen;
        private Pen catPen;
        private Color cat_colour;
        private cButtonsCat buttonCats;
        public cButtons()
        {
            pos_x = new List<int>();
            pos_y = new List<int>();
            width = new List<int>();
            height = new List<int>();
            state = new List<int>();
            bt_cat = new List<int>();
            buttonPen = new Pen(Color.Black, 3);
            buttonCats = new cButtonsCat();//Anlegen der Klasse Buttons Kategorie
            buttonCats.add(0, 0, 300, 0, 1, 50, 50, 15, "White", "Blöcke");//Anlegen einer Kategorie Buttons
            buttonCats.add(0, 50, 300, 0, 1, 50, 50, 15, "White", "Wolken");//Anlegen einer Kategorie Buttons
            buttonCats.add(0, 50, 300, 0, 1, 50, 50, 15, "White", "PowerUps");//Anlegen einer Kategorie Buttons
            _name = new List<string>();
            colour = new List<Color>();
            cat_colour = Color.DarkGreen;
            catPen = new Pen(cat_colour, 3);
            //MessageBox.Show("ID: " + Convert.ToString(buttonCats.id("Wolken")));//todo debug
        }

        public void draw(Panel p, int margin, int margin_first, int margin_last)
        {
            Graphics g = p.CreateGraphics();
            int prev = 0, prev_cat = 0, button_number;
            bool first = true, last = false, last_cat = false;
            string debug = "";

            //MessageBox.Show(Convert.ToString(buttonCats.count()));


            for (int i = 0; i < buttonCats.count(); i++)
            {//Gehe durch alle Button Kategorien
                button_number = button_count(buttonCats.name(i));//Zähle Anzahl Buttons in derzeitiger Kategorie
                //debug += Convert.ToString(" |first "+first)+"|j "+Convert.ToString(i)+"| buttonCats.count()"+Convert.ToString(buttonCats.count());
                if (first)
                {//Gehe hierrein um den Buttons jeweils in die pos den zugehörigen abstand zu schreiben, dann nochmal (gesteuert über first)
                   
                    for (int j = 0; j < button_number; j++)//Unfertig, weiße pos den jeweiligen Buttons zu, es fehlt abprüfen das nur buttons die wirklich in der kategorie sind genommen werden
                    {
                      /*  prev = prev_cat;
                        prev_cat += prev;//Setze Abstand y, zähle alle Bisherigen mit(alles untereinander(eig))
                        prev = prev_cat + 25;*/
                        debug +=Convert.ToString( (bt_cat[j] == buttonCats.id(buttonCats.name(i))));
                        if (bt_cat[j] == buttonCats.id(buttonCats.name(i)))
                        {
                            pos_x[j] = 25;
                            pos_y[j] = margin + height[j] + prev;

                            prev += pos_y[j];
                            debug += "cat: "+buttonCats.name(i)+"j:  "+Convert.ToString(j)+" posx. " + Convert.ToString(pos_x[j]) + " posy. " + Convert.ToString(pos_y[j])+"\n";
                
                        }
                        //debug += " posx. " + Convert.ToString(pos_x[j]) + " posy. " + Convert.ToString(pos_y[j]);
                    }
                    //MessageBox.Show(Convert.ToString(i >= buttonCats.count() - 1));
                    if (i >= buttonCats.count() - 1)//funktioniert
                    {
                        //gehe bei letzter Kategorie hier rein
                        first = false;
                        i = -1;
                        //MessageBox.Show("hi");
                    }
                }
                else
                {
                    /* if (i == buttonCats.count() - 1)
                         last_cat = true;
                     Rectangle rect_cat = new Rectangle(pos_x[i], prev_cat, width[i], height[i]);
                     g.DrawRectangle(catPen, rect_cat);

                     prev_cat += prev;
                     prev = prev_cat + 25;*/

                    //MessageBox.Show("buttoncats.name(i)" + buttonCats.name(i));
                    /*MessageBox.Show(Convert.ToString(button_number));*/
                    //MessageBox.Show("button_count_all()" + Convert.ToString(button_count_all()));
                    for (int j = 0; j < button_count_all(); j++)//Richtige Zählung 
                    {//Male Buttons
                        //MessageBox.Show("buttonCats.name(i) "+buttonCats.name(i));
                        //debug += "|_name[j]" + _name[j] + "|buttonCats.name(i) " + buttonCats.name(i) + "| ";
                        if (bt_cat[j] == buttonCats.id(buttonCats.name(i)))
                        {
                            debug += "|bt_cat[j]" + bt_cat[j] + "|buttonCats.id(buttonCats.name(i)) " + Convert.ToString(buttonCats.id(buttonCats.name(i))) + "| ";
                            buttonPen = new Pen(colour[j], 3);
                            Rectangle rect = new Rectangle(pos_x[j], pos_y[j], width[j], height[j]);
                         //   MessageBox.Show(Convert.ToString(pos_x[j]) + Convert.ToString(pos_y[j]) + Convert.ToString(width[j]) + Convert.ToString(height[j]));
                            g.DrawRectangle(buttonPen, rect);
                        }
                    }
                }
            }
            MessageBox.Show("DEBUG: " + debug);
        }

        public void add(string add_name, int add_state, string cat_name, int add_width, int add_height, Color add_color)
        {
            try
            {
                //MessageBox.Show(add_name); todo debug
                _name.Add(add_name);
                colour.Add(add_color);
                state.Add(add_state);
                pos_x.Add(10);
                pos_y.Add(10);
                bt_cat.Add(buttonCats.id(cat_name));//Erhalt der ID der Buttonkategorie, übergabe von string name, Name muss eindeutig sein.
                //MessageBox.Show(Convert.ToString(this.id("add_name"))); todo debug
                width.Add(add_width);
                height.Add(add_height);
                colour.Add(add_color);
            }
            catch (Exception e)
            {
                MessageBox.Show("Fehler: " + e.Message);
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
        public bool collision_detect(int mouse_x, int mouse_y)
        {
            for (int i = 0; i < _name.Count(); i++)
            {
                if ((mouse_x <= pos_x[i] + width[i]) &&
            (mouse_x >= pos_x[i]) &&
            (mouse_y <= pos_y[i] + height[i]) &&
            (mouse_y <= pos_y[i]))
                {
                    MessageBox.Show("Hover");
                    return true;
                }
            }
            return false;
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

        public string name(int ind)
        {//liefert Name der Kategorie an Position index ind, als string zurück
            return this._name[ind];
        }
    }
}
