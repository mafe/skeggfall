﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.IO;
using System.Xml;

namespace SkeggFallLevelDesigner
{
    class cMapArray
    {
        private int x_pos, y_pos;
        private string name;
        public cMapArray()           //Standart Konstruktor
        {
            x_pos = 0;
            y_pos = 0;
            name = "Himmel";
        }
        public cMapArray(int x, int y, string n)      //Allgemeiner Konstruktor
        {
            x_pos = x;
            y_pos = y;
            name = n;
        }


        public void add(int x, int y, string n)
        {
            x_pos = x;
            y_pos = y;
            name = n;
        }
        public int get_x()
        {
            return x_pos;
        }
        public int get_y()
        {
            return y_pos;
        }
        public string get_n()
        {
            return name;
        }
    }
    class cMap
    {
        private int buttonsquare;
        private int mapwidth;
        private int mapheight;
        private bool changed_map;
        private int margin_left;
        private int margin_top;
        private Pen mapPen;
        private int save_x = 0;
        private int save_y = 0;
        private string save_name;
        //private Bitmap Sky = new Bitmap("himmel.png");
        private bool skyisdrawn;
        int button_id;
        private cMapArray[,] buttons_arr;

        public cMap(int mw, int mh, int bs, int margin_l, int margin_t)
        {
            mapPen = new Pen(Color.Black, 1);
            mapwidth = mw;
            mapheight = mh;
            changed_map = true;
            margin_left = margin_l;
            margin_top = margin_t;
            skyisdrawn = false;
            buttonsquare = bs;
            buttons_arr = new cMapArray[(mapwidth / buttonsquare), (mapheight / buttonsquare)];
            for (int i = 0; i < (mapwidth / buttonsquare); i++)
            {
                for (int j = 0; j < (mapheight / buttonsquare); j++)
                {
                    buttons_arr[i, j] = new cMapArray();
                }
            }
            //MessageBox.Show(buttoncount.ToString());
        }

        public void skydraw(Panel p, int margin_left, int margin_top, Bitmap buttonsprite)
        {
            Bitmap Sky = new Bitmap(50, 50);
            using (Graphics g = Graphics.FromImage(Sky))
            {
                g.DrawImage(buttonsprite,
                        new Rectangle(0, 0, buttonsquare, buttonsquare),//Ziel
                        new Rectangle(450, 0, buttonsquare, buttonsquare),//Source
                        GraphicsUnit.Pixel);
            }

            if (changed_map)
            {
                Graphics g = p.CreateGraphics();
                for (int x = 0; x < mapwidth; x += buttonsquare)
                {
                    for (int y = 0; y < mapheight; y += buttonsquare)
                    {
                        g.DrawImage(Sky, x + margin_left, y + margin_top, buttonsquare, buttonsquare);
                    }
                }
                g.Dispose();
            }
        }

        public void draw(Panel p, cButtons buttons)
        {
            if (changed_map)
            {

                Graphics g = p.CreateGraphics();

                for (int i = 0; i <= mapheight; i += buttonsquare)
                {
                    g.DrawLine(mapPen, margin_left, i + margin_top, mapwidth + margin_left, i + margin_top);
                }
                for (int i = 0; i <= mapwidth; i += buttonsquare)
                {
                    g.DrawLine(mapPen, i + margin_left, margin_top, i + margin_left, mapheight + margin_top);
                }

                for (int i = 0; i < (mapwidth / buttonsquare); i++)
                {
                    for (int j = 0; j < (mapheight / buttonsquare); j++)
                    {
                        if (buttons_arr[i, j].get_n() != "Himmel")
                            buttons.button_draw(buttons_arr[i, j].get_x(), buttons_arr[i, j].get_y(), buttons_arr[i, j].get_n(), p, 1);
                    }
                }
                // MessageBox.Show("hihi");
                g.Dispose();
                changed_map = false;
            }
        }

        public int collision_detect(int mouse_x, int mouse_y, int margin_left, int margin_top)
        {//gibt id des collidierten buttons zurück, wenn nix -1
            //bool helper = false;
            int helper = -1;
            if ((mouse_x <= margin_left + mapwidth) &&
            (mouse_x >= margin_left) &&
            (mouse_y <= margin_top + mapheight) &&
            (mouse_y >= margin_top))
            {
                helper = 1;
            }
            return helper;
        }

        public void hover(int mouse_x, int mouse_y, int margin_left, int margin_top)
        {//ändert Cursor bei Hover
            if (collision_detect(mouse_x, mouse_y, margin_left, margin_top) != -1)
            {//noch nicht fertig, bleibt nicht konstant
                if (Cursor.Current != Cursors.Hand)
                    Cursor.Current = Cursors.Hand;
            }
            else
            {
                Cursor.Current = Cursors.Arrow;
            }
        }
        public void getSave_Name(cButtons buttons)
        {
            button_id = buttons.statefinder(2);
            save_name = buttons.name(button_id);
        }

        public void click(int mouse_x, int mouse_y, Panel p, int bs, cButtons buttons, int margin_top)
        {

            int button_id = -1;

            if (buttons.statefinder(2) != -1)
                button_id = buttons.statefinder(2);
            else if (buttons.statefinder(3) != -1)
                button_id = buttons.statefinder(3);

            if (collision_detect(mouse_x, mouse_y, buttons.buttonWidth, margin_top) != -1 && button_id != -1)
            {
                int count_x = 0;
                int count_y = 0;

                for (int i = 0; i < mouse_x; i += bs)
                {
                    count_x++;
                }
                for (int i = 0; i < mouse_y; i += bs)
                {
                    count_y++;
                }
                save_x = (count_x - 1) * bs;
                save_y = (count_y - 1) * bs;
                save_name = buttons.name(button_id);

                if (save_name != null)
                {
                    //buttons.button_draw(save_x, save_y, save_name, p);//muss in eine eigene Methode map.buttonsdraw ausgelagert werden wenn Array/List fertig damit dies in dem timer_tick laufen kann
                    if (save_name == "Spieler1")
                    {
                        bool p1onmap = false;
                        for (int i = 0; i < (mapwidth / buttonsquare); i++)
                        {
                            for (int j = 0; j < (mapheight / buttonsquare); j++)
                            {
                                if (buttons_arr[i, j].get_n() == "Spieler1")
                                {
                                    MessageBox.Show("Spieler 1 ist schon gesetzt und darf nur einmal gesetzt werden.");
                                    p1onmap = true;
                                }
                            }
                        }
                        if (p1onmap == false)
                        {
                            buttons_arr[((save_x - margin_left) / 50), ((save_y - margin_top)) / 50].add(save_x, save_y, save_name);
                            changed_map = true;
                        }
                    }
                    if (save_name == "Spieler2")
                    {
                        bool p2onmap = false;
                        for (int i = 0; i < (mapwidth / buttonsquare); i++)
                        {
                            for (int j = 0; j < (mapheight / buttonsquare); j++)
                            {
                                if (buttons_arr[i, j].get_n() == "Spieler2")
                                {
                                    MessageBox.Show("Spieler 2 ist schon gesetzt und darf nur einmal gesetzt werden.");
                                    p2onmap = true;
                                }
                            }
                        }
                        if (p2onmap == false)
                        {
                            buttons_arr[((save_x - margin_left) / 50), ((save_y - margin_top)) / 50].add(save_x, save_y, save_name);
                            changed_map = true;
                        }
                    }
                    if (save_name != "Spieler1" && save_name != "Spieler2")
                    {
                        buttons_arr[((save_x - margin_left) / 50), ((save_y - margin_top)) / 50].add(save_x, save_y, save_name);
                        changed_map = true;
                    }
                }
            }
        }
        public void right_click(int mouse_x, int mouse_y, Panel p, int bs, cButtons buttons, int margin_top)
        {
            int count_x = 0;
            int count_y = 0;

            if (collision_detect(mouse_x, mouse_y, buttons.buttonWidth, margin_top) != -1)
            {
                for (int i = 0; i < mouse_x; i += bs)
                {
                    count_x++;
                }
                for (int i = 0; i < mouse_y; i += bs)
                {
                    count_y++;
                }
                save_x = (count_x - 1) * bs;
                save_y = (count_y - 1) * bs;
                Graphics g = p.CreateGraphics();
                MessageBox.Show("Button hier: " + buttons_arr[((save_x - margin_left) / 50), ((save_y - margin_top)) / 50].get_n());
                //TODO - ersetzen durch sprite sofern es in die Datei mit eingebunden wurde
                //g.DrawImage(Sky, save_x, save_y, bs, bs);
                g.Dispose();
                //TODO - Setzten des Arrays bei x,y mit name auf sky und speichern.
                //add_to_array(array);
                changed_map = true;
            }
        }
        public int getX
        {
            get { return save_x; }
        }
        public int getY
        {
            get { return save_y; }
        }
        public string getName(int mouse_x, int mouse_y, cButtons buttons)
        {//liefert button zurück der gerade gedragdropped wird
            int button_id = -1;

            if (buttons.statefinder(2) != -1)
                button_id = buttons.statefinder(2);
            if (button_id != -1)
            {
                save_name = buttons.name(button_id);
            }
            return save_name;
        }
        public void changer()
        {
            changed_map = true;
        }

        public bool load(OpenFileDialog ur)
        {
            bool helper = false;
            if (ur.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
                XmlTextReader textReader = new XmlTextReader(ur.FileName);
                int x = 0, y = 0, count = 3;
                string nam = "Himmel";
                try
                {
                    while (textReader.Read())
                    {
                        switch (textReader.NodeType)
                        {
                            case XmlNodeType.Element:

                                break;
                            case XmlNodeType.Text:
                                break;
                            case XmlNodeType.XmlDeclaration:
                            case XmlNodeType.ProcessingInstruction:
                                if (textReader.Name == "x")
                                    x = Int32.Parse(textReader.Value);
                                if (textReader.Name == "y")
                                    y = Int32.Parse(textReader.Value);
                                if (textReader.Name == "Name")
                                    nam = textReader.Value;
                                break;
                            case XmlNodeType.Comment:
                                //writer.WriteComment(reader.Value);
                                break;
                            case XmlNodeType.EndElement:
                                //writer.WriteFullEndElement();
                                break;
                        }
                        buttons_arr[x, y].add(x * buttonsquare, y * buttonsquare, nam);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show("Fehler in Map Import: " + e.Message);

                }
                textReader.Close();
                helper = true;
                changed_map = true;
            }
            return helper;
        }
        public bool save(SaveFileDialog ur)
        {
            bool helper = false;
            if (ur.ShowDialog() == DialogResult.OK)
            {
                Encoding encoding = Encoding.GetEncoding("ISO-8859-1");
                XmlTextWriter textWriter = new XmlTextWriter(ur.FileName, encoding);
                textWriter.WriteStartDocument();
                textWriter.WriteComment("Skeggfall XML Map v.01");

                textWriter.WriteComment("skeggfall_map.xml");
                textWriter.Formatting = Formatting.Indented;
                textWriter.WriteStartElement("MapItems");
                for (int i = 0; i < (mapwidth / buttonsquare); i++)
                {
                    for (int j = 0; j < (mapheight / buttonsquare); j++)
                    {
                        if (buttons_arr[i, j].get_n() != "Himmel")
                        {

                            textWriter.WriteStartElement(buttons_arr[i, j].get_n());

                            //textWriter.WriteStartElement("Name");
                            textWriter.WriteElementString("Name", buttons_arr[i, j].get_n());
                            //textWriter.WriteEndElement();

                            //textWriter.WriteStartElement("x");
                            textWriter.WriteElementString("x", i.ToString());
                            //textWriter.WriteEndElement();

                            //textWriter.WriteStartElement("y");
                            textWriter.WriteElementString("y", j.ToString());
                            //textWriter.WriteEndElement();
                            textWriter.WriteEndElement();
                        }

                    }
                }
                textWriter.WriteEndElement();
                textWriter.WriteEndDocument();
                textWriter.Close();
                helper = true;
            }
            return helper;
        }

    }

}


