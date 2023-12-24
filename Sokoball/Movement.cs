using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Windows;

namespace Sokoball
{
    class Movement
    {
        #region Attributes
        private MainAppPage window { get; set; }
        private int targetCellRow, targetCellCol;
        new string targetCords, targetBallCords;
        private int targetBallRow, targetBallCol;
        public int moves; 
        private PopulateGrid populateGrid { get; set; }

        Character player = new Character(4, 0);
        BallObj ball = new BallObj(5, 3);
        GoalObj goal = new GoalObj(0, 9);
        #endregion

        #region Constructors
        public Movement(MainAppPage window)
        {
            this.window = window;
        }
        #endregion

        #region Methods

        //method for storing direction pressed by user
        public void movePlayer(KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Left: move("left"); break;
                case Key.Up: move("up"); break;
                case Key.Right: move("right"); break;
                case Key.Down: move("down"); break;
                default: break;
            }

        }

        //method for storing value of direction pressed by user
        private void move(string direction)
        {
            int i = 0, j = 0;

            switch (direction)
            {
                case "left": i = 0; j = -1; break;
                case "up": i = -1; j = 0; break;
                case "right": i = 0; j = 1; break;
                case "down": i = 1; j = 0; break;

                default: break;
            }

            //checks what level is currently being played
            if (window.levelNo == 0)
            {
                //calculates target cell row and collumn, and checks if target cells are in walls array
                if (((targetCellRow = player.currentRow + i) < 10) && ((targetCellRow = player.currentRow + i) >= 0) && ((targetCellCol = player.currentColumn + j) < 10) && ((targetCellCol = player.currentColumn + j) >= 0))
                {
                    targetCords = targetCellRow.ToString() + " " + targetCellCol.ToString();
                    if (window.wallsList1.Contains(targetCords))
                    {
                        return;
                    }
                    //checks if target cells are in ball cells
                    else if ((targetCellRow == ball.currentRow) && (targetCellCol == ball.currentColumn))
                    {
                        //Calculates if target ball cells are in walls array
                        if (((targetBallRow = ball.currentRow + i) < 10) && ((targetBallRow = ball.currentRow + i) >= 0) && ((targetBallCol = ball.currentColumn + j) < 10) && ((targetBallCol = ball.currentColumn + j) >= 0))
                        {
                            targetBallCords = targetBallRow.ToString() + " " + targetBallCol.ToString();
                            if (window.wallsList1.Contains(targetBallCords))
                            {
                                return;
                            }
                            else
                            {
                                //updates player and balls location in the interface and updates moves counter
                                moves++;
                                populateGrid.drawContents("Images\\blank.bmp", targetCellRow, targetCellCol);
                                populateGrid.drawContents("Images\\player.bmp", targetCellRow, targetCellCol);
                                populateGrid.drawContents("Images\\blank.bmp", player.currentRow, player.currentColumn);
                                populateGrid.drawContents("Images\\ball.bmp", targetBallRow, targetBallCol);
                                //updates ball and player current location values
                                updatePlayerLocation(targetCellCol, targetCellRow);
                                updateBallLocation(targetBallCol, targetBallRow);

                                //checks if ball current cells are in goal cells
                                if (ball.currentRow == goal.currentRow & ball.currentColumn == goal.currentColumn)
                                {
                                    //changes to next level, displays amount of moves played and resets moves counter
                                    MessageBox.Show("Congratulations you won the level with " + moves + " moves");
                                    window.levelNo++;
                                    moves = 0;
                                    if (window.levelNo == 1)
                                    {
                                        //draws interface for level 2 and sets position values for level 2
                                        populateGrid.drawGrid2();
                                        player.currentRow = 4;
                                        player.currentColumn = 0;
                                        ball.currentRow = 6;
                                        ball.currentColumn = 3;
                                        goal.currentRow = 3;
                                        goal.currentColumn = 9;
                                    }

                                }
                            }

                        }
                    }
                    else
                    {
                        //updates player location in the interface and updates moves counter
                        populateGrid = new PopulateGrid(window);                  
                        moves++;
                        populateGrid.drawContents("Images\\player.bmp", targetCellRow, targetCellCol);
                        populateGrid.drawContents("Images\\blank.bmp", player.currentRow, player.currentColumn);
                        //updates player location values
                        updatePlayerLocation(targetCellCol, targetCellRow);
                    }
                }
            }
            //if second level
            else if (window.levelNo == 1)
            {
                //calculates target cell row and collumn, and checks if target cells are in walls array
                if (((targetCellRow = player.currentRow + i) < 10) && ((targetCellRow = player.currentRow + i) >= 0) && ((targetCellCol = player.currentColumn + j) < 10) && ((targetCellCol = player.currentColumn + j) >= 0))
                {
                    targetCords = targetCellRow.ToString() + " " + targetCellCol.ToString();
                    if (window.wallsList2.Contains(targetCords))
                    {
                        return;
                    }
                    //checks if target cells are in ball cells
                    else if ((targetCellRow == ball.currentRow) && (targetCellCol == ball.currentColumn))
                    {
                        //Calculates if target ball cells are in walls array
                        if (((targetBallRow = ball.currentRow + i) < 10) && ((targetBallRow = ball.currentRow + i) >= 0) && ((targetBallCol = ball.currentColumn + j) < 10) && ((targetBallCol = ball.currentColumn + j) >= 0))
                        {
                            targetBallCords = targetBallRow.ToString() + " " + targetBallCol.ToString();
                            if (window.wallsList2.Contains(targetBallCords))
                            {
                                return;
                            }
                            else
                            {
                                //updates player and balls location in the interface and updates moves counter
                                moves++;
                                populateGrid.drawContents("Images\\blank.bmp", targetCellRow, targetCellCol);
                                populateGrid.drawContents("Images\\player.bmp", targetCellRow, targetCellCol);
                                populateGrid.drawContents("Images\\blank.bmp", player.currentRow, player.currentColumn);
                                populateGrid.drawContents("Images\\ball.bmp", targetBallRow, targetBallCol);
                                //updates ball and player current location values
                                updatePlayerLocation(targetCellCol, targetCellRow);
                                updateBallLocation(targetBallCol, targetBallRow);

                                //checks if ball current cells are in goal cells
                                if (ball.currentRow == goal.currentRow && ball.currentColumn == goal.currentColumn)
                                {
                                   // displays amount of moves played and resets moves counter and closes game
                                    MessageBox.Show("Congratulations you won the level with" + moves + "moves");
                                    MainWindow mainWindow = new MainWindow();
                                    window.Close();
                                    mainWindow.Show();

                                }
                            }

                        }
                    }
                    else
                    {
                        //updates player location in the interface and updates moves counter
                        moves++;
                        populateGrid = new PopulateGrid(window);
                        populateGrid.drawContents("Images\\player.bmp", targetCellRow, targetCellCol);
                        populateGrid.drawContents("Images\\blank.bmp", player.currentRow, player.currentColumn);
                        //updates player location values
                        updatePlayerLocation(targetCellCol, targetCellRow);
                    }
                }
            }
        }

        //method to restart initial positions values after restart button is clicked
        //and resets moves counter
        public void restartPositions()
        {
            if (window.levelNo == 0)
            {
                player.currentRow = 4;
                player.currentColumn = 0;
                ball.currentRow = 5;
                ball.currentColumn = 3;
                goal.currentRow = 0;
                goal.currentColumn = 9;
                moves = 0;
            }
            else
            {
                player.currentRow = 4;
                player.currentColumn = 0;
                ball.currentRow = 6;
                ball.currentColumn = 3;
                goal.currentRow = 3;
                goal.currentColumn = 9;
                moves = 0;
            }
        }
        //method for updating player location
        private void updatePlayerLocation(int newCol, int newRow)
        {
            player.currentRow = newRow;
            player.currentColumn = newCol;
        }
        
        //method for updating ball location
        private void updateBallLocation(int newBallCol, int newBallRow)
        {
            ball.currentRow = newBallRow;
            ball.currentColumn = newBallCol;
        }
        #endregion
    }
}
