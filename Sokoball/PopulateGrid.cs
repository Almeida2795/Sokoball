using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Sokoball
{
    class PopulateGrid
    {
        #region Attributes
        private MainAppPage window { get; set; }
        #endregion

        #region Constructor
        public PopulateGrid(MainAppPage Window)
        {
            this.window = Window;
        }
        #endregion

        #region Methods
        //method for placing images in the interface
        public void drawContents(string uriLocation, int row, int column)
        {
            Image img = new Image() { Source = new BitmapImage(new Uri(uriLocation, UriKind.Relative)) };
            window.appGrid.Children.Add(img);
            Grid.SetRow(img, row);
            Grid.SetColumn(img, column);
        }

        //draw grid design for level 1
        public void drawGrid1()
        {
            //fill the grid with blank squares
            for (int x = 0; x < 10; x++)
            {
                for(int y = 0; y < 10; y++)
                {
                    drawContents("Images\\blank.bmp", x, y);
                }
            }
            //fill the grid with the walls
            for (int y = 0; y < 5;y++)
            {
                window.wallsList1.Push(3 + " " + y);
                drawContents("Images\\wall.bmp", 3, y);
            }
            for (int y = 6; y < 10; y++)
            {
                window.wallsList1.Push(3 + " " + y);
                drawContents("Images\\wall.bmp", 3, y);
            }
            for (int x = 2; x < 8; x++)
            {
                window.wallsList1.Push(x + " " + 4);
                drawContents("Images\\wall.bmp", x, 4);
            }
            for (int y = 6; y < 10; y++)
            {
                window.wallsList1.Push(8 + " " + y);
                drawContents("Images\\wall.bmp", 8, y);
            }
            drawContents("Images\\ball.bmp",5, 3);
            drawContents("Images\\player.bmp", 4, 0);
            drawContents("Images\\goal.bmp", 0, 10);
        }

        //draw grid design for level 2
        public void drawGrid2()
        {
            //fill the grid with blank squares
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    drawContents("Images\\blank.bmp", x, y);
                }
            }

            //fill the grid with the walls
            for (int x = 4; x < 7; x++)
            {
                for (int y = 4; y < 7; y++)
                {
                    window.wallsList2.Push(x + " " + y);
                    drawContents("Images\\wall.bmp", x, y);
                }
            }
            for (int y = 0; y < 10; y++)
            {
                window.wallsList2.Push(2 + " " + y);
                drawContents("Images\\wall.bmp", 2, y);
            }
            for (int y = 2; y < 4; y++)
            {
                window.wallsList2.Push(4 + " " + y);
                drawContents("Images\\wall.bmp", 4, y);
            }
           for (int y = 0; y < 4; y++)
            {
                window.wallsList2.Push(8 + " " + y);
                drawContents("Images\\wall.bmp", 8, y);
            }
            drawContents("Images\\ball.bmp", 6, 3);
            drawContents("Images\\player.bmp", 4, 0);
            drawContents("Images\\goal.bmp", 3, 9);

        }
        #endregion
    }
}
