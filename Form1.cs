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


namespace SkeggFallLevelDesigner
{
    public partial class Form1 : Form
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private int mouse_pos_x = 0, mouse_pos_y = 0;
        private cConfig configuration;
        private Bitmap full_sprite;
        private cButtons left_sidebar;
        public Form1()
        {
            InitializeComponent();
            configuration = new cConfig(this.Width, this.Height);
            left_sidebar = new cButtons();
            left_sidebar.add("Erde", 1, "Blöcke", 50, 50, Color.Brown);
            left_sidebar.add("Tunnel", 1, "Blöcke", 50, 50, Color.Brown);
            left_sidebar.add("Sand", 1, "Blöcke", 50, 50, Color.Brown);
            left_sidebar.add("KleineWolke", 1, "Wolken", 50, 50, Color.Cyan);
            left_sidebar.add("GroßeWolke", 1, "Wolken", 50, 50, Color.Cyan);
            left_sidebar.add("SturmWolke", 1, "Wolken", 50, 50, Color.Cyan);
            left_sidebar.add("Heilen", 1, "PowerUps", 50, 50, Color.Gold);
            //full_sprite = new Bitmap("..\\Properties\\SkeggFallSprite.png");
            try
            {
                full_sprite = new Bitmap("SkeggFallSprite.jpg");
            }
            catch (Exception e)
            {
                log.Debug("Fehler: " + e.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (configuration.running)
            {
                try
                {
                    label1.Text = "X: " + Convert.ToString(mouse_pos_x) + " | Y: " + Convert.ToString(mouse_pos_y) + " | run: " + configuration.running;
                    left_sidebar.draw(Main_Panel, 10, 25, 10);
                    left_sidebar.collision_detect(mouse_pos_x, mouse_pos_y);
                    //hover, click, 

                    //configuration.running = false;
                    //  MessageBox.Show(Convert.ToString(configuration.running));
                    //timer1.Stop();
                }
                catch (Exception e2)
                {
                    log.Debug("Fehler: " + e2.Message);
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
            timer1.Interval = Convert.ToInt32(1000/configuration.frames_persec);
            timer1.Start();
            //left_sidebar.draw(Main_Panel, 10, 25, 10);
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
            mouse_pos_x = e.X;
            mouse_pos_y = e.Y;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Login EditorLogin = new Login();
            //EditorLogin.ShowDialog();
        }

        /**
         * Drag & Drop: Used for detection of sidebar-toolbox buttons while dragging
         */
        private void Main_Panel_MouseDown(object sender, MouseEventArgs e)
        {
            log.Debug("Drag starts:" + mouse_pos_x + "," + mouse_pos_y);

            // durchsuche alle gesetzten sidebar-toolbox buttons nach den Koordinaten und prüfe mit collision_detect(), ob Kollisionen stattfinden.
            cButtons c = new cButtons();
            log.Debug(c.collision_detect(mouse_pos_x, mouse_pos_y));
        }

        private void Main_Panel_MouseClick(object sender, MouseEventArgs e)
        {

        }

        /**
         * Drag & Drop: Used for rasterize button an map while dropping
         */
        private void Main_Panel_MouseUp(object sender, MouseEventArgs e)
        {
            log.Debug("Drag stop:" + mouse_pos_x + "+," + mouse_pos_y);

            for (int i = 0; i < cButtons.buttonCats.count(); i++)
            {//Gehe durch alle Button Kategorien
                log.Debug("buttoncats.name(i)" + cButtons.buttonCats.name(i));
///                log.Debug(Convert.ToString(cButtons.button_number));
                log.Debug("button_count_all()" + Convert.ToString(cButtons.button_count_all()));

                for (int j = 0; j < cButtons.button_count_all(); j++)//Richtige Zählung 
                {//Male Buttons
                    log.Debug("buttonCats.name(i) " + cButtons.buttonCats.name(i));
                    //logdebug += "|_name[j]" + _name[j] + "|buttonCats.name(i) " + buttonCats.name(i) + "| ";
                    if (cButtons.bt_cat[j] == cButtons.buttonCats.id(cButtons.buttonCats.name(i)))
                    {
                        log.Debug("|bt_cat[j]" + cButtons.bt_cat[j] + "|buttonCats.id(buttonCats.name(i)) " + Convert.ToString(cButtons.buttonCats.id(cButtons.buttonCats.name(j))) + "| ");
                        log.Debug(Convert.ToString(cButtons.pos_x[j]) + Convert.ToString(cButtons.pos_y[j]) + Convert.ToString(cButtons.width[j]) + Convert.ToString(cButtons.height[j]));

                    }
                }
            }
        }
    }
}
