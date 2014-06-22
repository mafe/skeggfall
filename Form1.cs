using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
/* Orginal */
namespace SkeggFallLevelDesigner
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /* runtime Maus Variablen */
        private int mouse_pos_x, mouse_pos_y;
        private bool mouse_down, mouse_up;
        private bool drag_drop;
        /* end */
        private cConfig configuration;
        private Bitmap full_sprite;
        private cButtons left_sidebar;
        private cMap map;
        public Form1()
        {
            /* runtime Maus Variablen */
            mouse_pos_x = 0;
            mouse_pos_y = 0;
            mouse_down = false;
            mouse_up = false;
            drag_drop = false;
            /* end */
            InitializeComponent();
            try
            {
                full_sprite = new Bitmap("fullsprite.png");
            }
            catch (Exception e)
            {
                MessageBox.Show("Fehler: " + e.Message);
            }
            configuration = new cConfig(this.Width, this.Height, 900, 600, 50);
            left_sidebar = new cButtons(150, full_sprite);
            left_sidebar.add("Wasserlinks", -1, "Boden", 50, 50, Color.Brown, 0, 0);
            left_sidebar.add("Wasser", -1, "Boden", 50, 50, Color.Brown, 50, 0);
            left_sidebar.add("Wasserrechts", -1, "Boden", 50, 50, Color.Brown, 100, 0);
            left_sidebar.add("Erde", -1, "Boden", 50, 50, Color.Brown, 150, 0);
            left_sidebar.add("Wolke", -1, "Wolken", 50, 50, Color.Cyan, 200, 0);
            left_sidebar.add("Sturmwolke", -1, "Wolken", 50, 50, Color.Cyan, 250, 0);
            left_sidebar.add("Großewolke", -1, "Wolken", 50, 50, Color.Cyan, 300, 0);
            //left_sidebar.add("Heilen", -1, "PowerUps", 50, 50, Color.Black, 0, 0);
            left_sidebar.add("Spieler1", -1, "Player", 50, 50, Color.Cyan, 350, 0);
            left_sidebar.add("Spieler2", -1, "Player", 50, 50, Color.Red, 400, 0);
            left_sidebar.add("Himmel", -1, "Sky", 50, 50, Color.Cyan, 450, 0);
            map = new cMap(configuration.map_width, configuration.map_height, configuration.buttonsquare, left_sidebar.buttonWidth, 50);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (configuration.running)
            {
                try
                {
                    label1.Text = "X: " + Convert.ToString(mouse_pos_x) + " | Y: " + Convert.ToString(mouse_pos_y) + " | run: " + configuration.running;
                    
                    left_sidebar.draw(Main_Panel,map);
                    map.skydraw(Main_Panel, left_sidebar.buttonWidth, 50, full_sprite);
                    map.draw(Main_Panel, left_sidebar);
                    if (drag_drop == true)
                    {
                        //left_sidebar.button_draw(mouse_pos_x, mouse_pos_y, map.getName,Main_Panel);
                        left_sidebar.state_set(1, 2);
                        left_sidebar.drag_drop(mouse_pos_x, mouse_pos_y, map.getName(mouse_pos_x,mouse_pos_y,left_sidebar));
                    }
                    //Main_Panel.Invalidate();
                    //hover, click, 

                    //configuration.running = false;
                    //  MessageBox.Show(Convert.ToString(configuration.running));
                    //timer1.Stop();
                }
                catch (Exception e2)
                {
                    MessageBox.Show("Fehler: " + e2.Message);
                }
            }
            else
            {
                /*MessageBox.Show(Convert.ToString(configuration.running)); todo debug
                MessageBox.Show("ELSEEE");*/
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /*// Create pen.
            Pen blackPen = new Pen(Color.Black, 3);

            // Create rectangle.
            Rectangle rect = new Rectangle(0, 0, 200, 200);

            // Draw rectangle to screen.
            e.Graphics.DrawRectangle(blackPen, rect);*/
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            configuration.running = true;
            left_sidebar.pos_calculation(10, 25, 10);
            timer1.Interval = Convert.ToInt32(1000 / configuration.frames_persec);
            timer1.Start();
        }

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Main_Panel_Move(object sender, EventArgs e)
        {

        }

        private void Main_Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down) { drag_drop = true; }

            mouse_pos_x = e.X;
            mouse_pos_y = e.Y;

            if (drag_drop == false)
            {
                left_sidebar.hover(mouse_pos_x, mouse_pos_y);
            }
            else
            {
                // left_sidebar.drag_drop_draw(mouse_pos_x, mouse_pos_y, Main_Panel);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Login EditorLogin = new Login();
            //EditorLogin.ShowDialog();
        }

        private void Main_Panel_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                mouse_down = true;
                mouse_up = false;
            }

            left_sidebar.click(mouse_pos_x, mouse_pos_y);

            if (e.Button == MouseButtons.Right)
            {
                map.right_click(mouse_pos_x, mouse_pos_y, Main_Panel, configuration.buttonsquare, left_sidebar, 50);
            }

        }

        private void Main_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // map.click(mouse_pos_x, mouse_pos_y, Main_Panel, configuration.buttonsquare, left_sidebar, 50);
            }
            mouse_down = false;
            mouse_up = true;
            drag_drop = false;

            if (!drag_drop)
            {
                left_sidebar.checker(mouse_pos_x, mouse_pos_y);
            }
            map.click(mouse_pos_x, mouse_pos_y, Main_Panel, configuration.buttonsquare, left_sidebar, 50);
            left_sidebar.upclick(mouse_pos_x, mouse_pos_y);
        }

        private void invalidateclearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Main_Panel.Invalidate();
        }

        private void Main_Panel_Paint(object sender, PaintEventArgs e)
        {
            //left_sidebar.changer();
            //map.changer();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.save(saveFileDialog1);
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            map.load(openFileDialog1);
        }
    }
}
