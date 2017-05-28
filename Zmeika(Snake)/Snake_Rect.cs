using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Zmeika_Snake_
{
    class Snake_Rect
    {
        static private List<Rectangle> full_snake = new List<Rectangle>();
        public enum Direct
        {
            right,up,left,down
        }
        static private int fru_x;
        static private int fru_y;
        static public Rectangle fruit = new Rectangle(fru_x, fru_y, 10, 10);
        static private int eaten = 0;

        static public void plu_eat()
        {
            eaten++;
        }

        static public int get_fru_eat()
        {
            return eaten;
        }

        static public void fru_gen_loc()
        {
            int temp;
            Random rand = new Random();
            temp = rand.Next(0, 770);
            fru_x = (temp / 10) * 10;
            temp = rand.Next(0, 350);
            fru_y = (temp / 10) * 10;
            fruit.X = fru_x;
            fruit.Y = fru_y;
        }

        static public Direct direction = Direct.right;

        static public int Get_snake_count()
        {
            return full_snake.Count;
        }

        static public void Snake_add()
        {
            full_snake.Add(full_snake[full_snake.Count - 1]);
        }

        static public Rectangle Get_Snake(int index)
        {
            return full_snake[index];
        }

        static public void Snake_inic()
        {
            for (int i = 0; i < 5; i++)
            {
                Snake_Rect.full_snake.Add(new Rectangle(400 - i * 10, 200, 10, 10));
            }
        }

        static public void Snake_move()
        {
            if (direction == Direct.right)
            {
                for (int i = full_snake.Count-1; i > 0; i--) 
                {
                    Rectangle pis = full_snake[i - 1];
                    full_snake[i] = pis;
                }
                Rectangle pls = full_snake[0];
                pls.Offset(10, 0);
                full_snake[0] = pls;
            }
            else if(direction == Direct.up)
            {
                for (int i = full_snake.Count-1; i > 0; i--)
                {
                    Rectangle pis = full_snake[i - 1];
                    full_snake[i] = pis;
                }
                Rectangle pls = full_snake[0];
                pls.Offset(0, -10);
                full_snake[0] = pls;
            }
            else if(direction == Direct.left)
            {
                for (int i = full_snake.Count-1; i > 0; i--)
                {
                    Rectangle pis = full_snake[i - 1];
                    full_snake[i] = pis;
                }
                Rectangle pls = full_snake[0];
                pls.Offset(-10, 0);
                full_snake[0] = pls;
            }
            else if(direction == Direct.down)
            {
                for (int i = full_snake.Count-1; i > 0; i--)
                {
                    Rectangle pis = full_snake[i - 1];
                    full_snake[i] = pis;
                }
                Rectangle pls = full_snake[0];
                pls.Offset(0, 10);
                full_snake[0] = pls;
            }

            if(full_snake[0].IntersectsWith(fruit))
            {
                fru_gen_loc();
                Snake_add();
                plu_eat();
            }
            
        }
    }
}
