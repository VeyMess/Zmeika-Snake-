using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zmeika_Snake_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            Snake_Rect.fru_gen_loc();
            Snake_Rect.Snake_inic();
            InitializeComponent();
        }

        public void Snake_draw()
        {
            Graphics snake = this.CreateGraphics();
            Rectangle bot = new Rectangle(-10, 360, 800, 30);
            snake.Clear(Color.DarkOrange);
            snake.DrawRectangle(new Pen(Color.Black), Snake_Rect.Get_Snake(0));
            for(int i=1;i<Snake_Rect.Get_snake_count();i++)
            {
                snake.DrawRectangle(new Pen(Color.DarkGreen), Snake_Rect.Get_Snake(i));
            }
            snake.FillRectangle(new SolidBrush(Color.DarkRed), Snake_Rect.fruit);

            snake.FillRectangle(new SolidBrush(Color.White), bot);
            snake.DrawRectangle(new Pen(Color.Black), bot);
            label1.Text = "Фруктов:" + Snake_Rect.get_fru_eat();
        }

        public void Game_end()
        {
            if (MessageBox.Show("Фруктов съедено:" + Snake_Rect.get_fru_eat(),
                "Конец!", MessageBoxButtons.OK) == DialogResult.OK)
                Application.Exit();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Snake_draw();
        }

        public void check_state()
        {
            for (int i = 1; i < Snake_Rect.Get_snake_count(); i++)
            {
                if (Snake_Rect.Get_Snake(0).IntersectsWith(Snake_Rect.Get_Snake(i)))
                {
                    timer1.Stop();
                    Game_end();
                }
            }
            if (Snake_Rect.Get_Snake(0).X < 0 ||
                Snake_Rect.Get_Snake(0).X > 770 ||
                Snake_Rect.Get_Snake(0).Y < 0 ||
                Snake_Rect.Get_Snake(0).Y > 350)
            {
                timer1.Stop();
                Game_end();
            }
        }

        public void move_draw()
        {
            Graphics snake = this.CreateGraphics();

            snake.DrawRectangle(new Pen(Color.DarkGreen), Snake_Rect.Get_Snake(Snake_Rect.Get_snake_count() - 1));
            snake.DrawRectangle(new Pen(Color.Black), Snake_Rect.Get_Snake(0));

            snake.FillRectangle(new SolidBrush(Color.DarkRed), Snake_Rect.fruit);

            label1.Text = "Фрукты:" + Snake_Rect.get_fru_eat();
        }

        public void draw_last()
        {
            Graphics snake = this.CreateGraphics();
            snake.DrawRectangle(new Pen(Color.DarkOrange), Snake_Rect.Get_Snake(Snake_Rect.Get_snake_count() - 1));
            snake.DrawRectangle(new Pen(Color.DarkGreen), Snake_Rect.Get_Snake(0));

            snake.FillRectangle(new SolidBrush(Color.DarkOrange), Snake_Rect.fruit);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            draw_last();
            Snake_Rect.Snake_move();
            move_draw();
            check_state();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Up && Snake_Rect.direction != Snake_Rect.Direct.down)
            {
                draw_last();
                Snake_Rect.direction = Snake_Rect.Direct.up;
                Snake_Rect.Snake_move();
                move_draw();
                check_state();
                timer1.Stop();
                timer1.Start();
            }
            if (e.KeyData == Keys.Left && Snake_Rect.direction != Snake_Rect.Direct.right)
            {
                draw_last();
                Snake_Rect.direction = Snake_Rect.Direct.left;
                Snake_Rect.Snake_move();
                move_draw();
                check_state();
                timer1.Stop();
                timer1.Start();
            }
            if (e.KeyData == Keys.Down && Snake_Rect.direction != Snake_Rect.Direct.up)
            {
                draw_last();
                Snake_Rect.direction = Snake_Rect.Direct.down;
                Snake_Rect.Snake_move();
                move_draw();
                check_state();
                timer1.Stop();
                timer1.Start();
            }
            if (e.KeyData == Keys.Right && Snake_Rect.direction != Snake_Rect.Direct.left)
            {
                draw_last();
                Snake_Rect.direction = Snake_Rect.Direct.right;
                Snake_Rect.Snake_move();
                move_draw();
                check_state();
                timer1.Stop();
                timer1.Start();
            }
        }
    }
}
