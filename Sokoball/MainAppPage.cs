using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Sokoball
{
    class MainAppPage : Window
    {
        #region attributes
        private Canvas windowCanvas { get; set; } //automatic properties
        private Button returnButton { get; set; }
        private Button restartButton { get; set; }
        private TextBlock instructionBlock { get; set; }
        private Border gridBorder { get; set; }
        public Grid appGrid { get; set; }
        public Stack<string> wallsList1 = new Stack<string>();
        public Stack<string> wallsList2 = new Stack<string>();
        
        public int levelNo = 0;
        private Movement mover { get; set; }
        private PopulateGrid populateGrid { get; set; }
        #endregion

        #region Constructor   
        public MainAppPage(string windowName)
        {
            this.Title = windowName;
            initializeWindow(); 
        }
        #endregion

        #region Methods

        private void initializeWindow()
        {
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;  //sets the window start up location to the center of the screen
            windowCanvas = new Canvas();  //creates a new canvas object
            createGrid(); //calls method to create grid
            createSidePanel(); //calls method to create side panel
            appGrid.Focus(); //Highlights the grid for the user
            setupPageEvents();

            populateGrid = new PopulateGrid(this);
            populateGrid.drawGrid1();
            mover = new Movement(this);

            this.Content = this.windowCanvas;
        }

        private void createGrid()
        {
            gridBorder = new Border();                              //sets borders thickness and color
            gridBorder.BorderThickness = new Thickness(11.00);
            gridBorder.BorderBrush = Brushes.Black;

            appGrid = new Grid();                                     //sets the height and width of the grid and it's placement on the window
            appGrid.Width = appGrid.Height = 400;
            appGrid.HorizontalAlignment = HorizontalAlignment.Left;
            appGrid.VerticalAlignment = VerticalAlignment.Top;
            appGrid.Focusable = true;
            gridBorder.Child = appGrid;                              //sets the gridBorder to be child of the appGrid which means it will inherit all it's properties

            for (int i = 0; i < 10; i++)
                appGrid.ColumnDefinitions.Add(new ColumnDefinition());
            for (int i = 0; i < 10; i++)
                appGrid.RowDefinitions.Add(new RowDefinition());
        }

        private void createSidePanel()
        {

        //creates instructions textblock
            instructionBlock = new TextBlock();
            instructionBlock.FontSize = 25;
            instructionBlock.Text = "Use arrows to move around the screen";

            //creates return button
            returnButton = new Button();
            returnButton.Height = 30;
            returnButton.Width = 245;
            returnButton.FontSize = 15;
            returnButton.Focusable = false;
            returnButton.Content = "Return to start page";

            //creates restart button
            restartButton = new Button();
            restartButton.Height = 30;
            restartButton.Width = 245;
            restartButton.FontSize = 15;
            restartButton.Focusable = false;
            restartButton.Content = "Restart game";

            arrangeOnCanvas(); //calls method to arrange items on windows canvas
        }

        //method for arranging ui elements position in the interface
        private void arrangeOnCanvas()
        {
               windowCanvas.Children.Add(instructionBlock);
               windowCanvas.Children.Add(returnButton);
               windowCanvas.Children.Add(gridBorder);
               windowCanvas.Children.Add(restartButton);

               Canvas.SetLeft(instructionBlock, 490);
               Canvas.SetTop(instructionBlock, 100);

               Canvas.SetLeft(restartButton, 490);
               Canvas.SetTop(restartButton, 430);

               Canvas.SetLeft(returnButton, 490);
               Canvas.SetTop(returnButton, 380);
            
        }

        public void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public void restartButton_Click(object sender, RoutedEventArgs e)
        {
            if (levelNo == 0)
            {
                populateGrid.drawGrid1();
                mover.restartPositions();
            }
            else
            {
                populateGrid.drawGrid2();
                mover.restartPositions();
            }
        }
        public void setupPageEvents() //method to setup events
        {
            restartButton.Click += restartButton_Click;
            returnButton.Click += returnButton_Click; //event for returning to main page
            appGrid.KeyDown += appGrid_KeyDown;
        }

        public void appGrid_KeyDown(object sender, KeyEventArgs e)
        {
            mover.movePlayer(e);
        }
        #endregion
    }
}
