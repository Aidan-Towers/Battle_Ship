using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship
{
    public partial class Form1 : Form
    {

        int placedCount, shipSpaces, shipsPlaced, firstPlacedInt, currentPlacedInt, directionCheck, computerLastHit, computerCurentShot, directionPick, enemyPicker;
        bool patrolBoatPlaced = false, submarinePlaced = false, destroyerPlaced = false, battleshipPlaced = false, carrierPlaced = false, allShipsPlaced = false, firstPlaced = false, secondPlaced = false, vertical = false, horizontal = false, computerHit = false, playerHit = false;
        List<int> activeSpaces = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100};
        List<int> freshBoard = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };
        List<int> emptyList = new List<int> { };
        List<int> playerShips = new List<int> { };
        List<int> enemyShips = new List<int> { };
        List<int> enemySaved1 = new List<int> {6,12,16,22,26,29,39,49,59,62,63,64,69,95,96,97,98};
        List<int> enemySaved2 = new List<int> {2,3,4,22,23,24,25,26,39,43,49,53,55,59,65,75,85};
        List<int> enemySaved3 = new List<int> {2,9,12,19,22,36,46,56,66,74,75,76,77,78,96,97,98};
        List<int> enemySaved4 = new List<int> {6,16,18,22,26,28,32,42,44,52,54,64,67,68,69,74,84};
        List<int> enemySaved5 = new List<int> {5,6,7,8,9,46,56,61,71,77,78,79,81,84,85,86,91};
        List<int> enemySaved6 = new List<int> {13,23,33,35,36,37,43,53,57,58,67,68,77,78,83,84,87};
        List<int> enemySaved7 = new List<int> {9,10,16,19,20,26,30,36,46,56,64,65,66,67,87,88,89};
        List<int> enemySaved8 = new List<int> {1,11,16,17,18,23,33,43,53,56,57,58,59,60,75,85,95};
        List<int> enemySaved9 = new List<int> {10,20,30,37,38,39,40,42,43,44,50,54,55,56,57,96,97};
        List<int> enemySaved10 = new List<int> {11,12,13,25,28,29,35,45,55,65,69,72,73,74,79,89,99};
        List<int> computerAlreadyShot = new List<int> { };
        List<bool> shipCheck = new List<bool> { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

        Random rnd = new Random();

        //goes when the program starts up 
        public Form1()
        {
            InitializeComponent();

            
            //sets all the buttons to be disabled
            foreach (Button button in this.Controls.OfType<Button>())
                button.Enabled = false;
            //sets all the buttons to be dark blue
            foreach (Button button in this.Controls.OfType<Button>())
                button.BackColor = Color.DarkBlue;
            //sets all the buttons to have a 28pt font
            foreach (Button button in this.Controls.OfType<Button>())
                button.Font = new Font(button.Font.FontFamily, 28);

            //sets all boat buttons and reset button back to a regular colour
            patrolBoatButton.BackColor = Color.LightGray;
            submarineButton.BackColor = Color.LightGray;
            destroyerButton.BackColor = Color.LightGray;
            battleshipButton.BackColor = Color.LightGray;
            carrierButton.BackColor = Color.LightGray;
            resetButton.BackColor = Color.LightGray;

            //sets all boat buttons and reset button back to a regular font size
            patrolBoatButton.Font = new Font(patrolBoatButton.Font.FontFamily, 14);
            submarineButton.Font = new Font(submarineButton.Font.FontFamily, 14);
            destroyerButton.Font = new Font(destroyerButton.Font.FontFamily, 14);
            battleshipButton.Font = new Font(battleshipButton.Font.FontFamily, 14);
            carrierButton.Font = new Font(carrierButton.Font.FontFamily, 14);
            resetButton.Font = new Font(resetButton.Font.FontFamily, 14);

            //sets all boat buttons and reset button back to be enabled
            patrolBoatButton.Enabled = true;
            submarineButton.Enabled = true;
            destroyerButton.Enabled = true;
            battleshipButton.Enabled = true;
            carrierButton.Enabled = true;
            resetButton.Enabled = true;

            //picks a random number then chooses the enemies ships position based off that number
            enemyPicker = rnd.Next(1, 10);
            if (enemyPicker == 1)
            {
                enemyShips = enemySaved1;
            }
            else if (enemyPicker == 2)
            {
                enemyShips = enemySaved2;
            }
            else if (enemyPicker == 3)
            {
                enemyShips = enemySaved3;
            }
            else if (enemyPicker == 4)
            {
                enemyShips = enemySaved4;
            }
            else if (enemyPicker == 5)
            {
                enemyShips = enemySaved5;
            }
            else if (enemyPicker == 6)
            {
                enemyShips = enemySaved6;
            }
            else if (enemyPicker == 7)
            {
                enemyShips = enemySaved7;
            }
            else if (enemyPicker == 8)
            {
                enemyShips = enemySaved8;
            }
            else if (enemyPicker == 9)
            {
                enemyShips = enemySaved9;
            }
            else if (enemyPicker == 10)
            {
                enemyShips = enemySaved10;
            }
        }
        
        //reset button to reset any value that needs to be reset 
        private void resetButton_Click(object sender, EventArgs e)
        {
            //disables all the buttons
            foreach (Button button in this.Controls.OfType<Button>())
                button.Enabled = false;
            //changes all the buttons to dark blue
            foreach (Button button in this.Controls.OfType<Button>())
                button.BackColor = Color.DarkBlue;

            //sets all boat buttons and reset button back to a regular colour
            patrolBoatButton.BackColor = Color.LightGray;
            submarineButton.BackColor = Color.LightGray;
            destroyerButton.BackColor = Color.LightGray;
            battleshipButton.BackColor = Color.LightGray;
            carrierButton.BackColor = Color.LightGray;
            resetButton.BackColor = Color.LightGray;

            //sets all boat buttons and reset button back to be enabled
            patrolBoatButton.Enabled = true;
            submarineButton.Enabled = true;
            destroyerButton.Enabled = true;
            battleshipButton.Enabled = true;
            carrierButton.Enabled = true;
            resetButton.Enabled = true;

            //resets all the shi placed bools to false
            patrolBoatPlaced = false;
            submarinePlaced = false;
            destroyerPlaced = false;
            battleshipPlaced = false;
            carrierPlaced = false;
            allShipsPlaced = false;
            //restes the ships placed int
            shipsPlaced = 0;
            //resets the spaces active on your side of the board for the computer
            activeSpaces = freshBoard;
            //clears the list of where your ships are placed
            playerShips = emptyList;
            //resets which way it think the current ship is being placed
            horizontal = false;
            vertical = false;
            //hides the dislay label that shows if you won or not
            displayLabel.Visible = false;

            //resets the ship check list
            shipCheck = new List<bool> { true, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false, false };

            //picks a random number then chooses the enemies ships position based off that number
            enemyPicker = rnd.Next(1, 10);
            if(enemyPicker == 1)
            {
                enemyShips = enemySaved1;
            }
            else if(enemyPicker == 2)
            {
                enemyShips = enemySaved2;
            }
            else if(enemyPicker == 3)
            {
                enemyShips = enemySaved3;
            }
            else if(enemyPicker == 4)
            {
                enemyShips = enemySaved4;
            }
            else if(enemyPicker == 5)
            {
                enemyShips = enemySaved5;
            }
            else if(enemyPicker == 6)
            {
                enemyShips = enemySaved6;
            }
            else if(enemyPicker == 7)
            {
                enemyShips = enemySaved7;
            }
            else if(enemyPicker == 8)
            {
                enemyShips = enemySaved8;
            }
            else if(enemyPicker == 9)
            {
                enemyShips = enemySaved9;
            }
            else if(enemyPicker == 10)
            {
                enemyShips = enemySaved10;
            }
        }

        //runs the computers move
        private void computerMove_Click(object sender, EventArgs e)
        {
            //checks if the player still has ships left before running the next command otherwise it will crash
            if (playerShips.Count != 0)
            {
                //writes in the console where your remaining ships are
                Console.WriteLine("Player: " + String.Join("; ", playerShips));
            }
            //checks if the computer still has ships left before running the next command otherwise it will crash
            if (enemyShips.Count != 0)
            {
                //writes in the console where the computers remaining ships are
                Console.WriteLine("Computer: " + String.Join("; ", enemyShips));
            }
            
            //generates a random number to shoot at that space
            computerCurentShot = rnd.Next(1, 100);
            //checks if the computer has already shot that space
            if (computerAlreadyShot.Contains(computerCurentShot))
            {
                //runs this button click again if the space has already been shot
                computerMove_Click(sender, e);
            }
            //runs this if it's a number that hasn't been shot yet
            else
            {
                //add the current shot to a list of numbers already shot
                computerAlreadyShot.Add(computerCurentShot);

                //checks if you hit a ship
                if (shipCheck[computerCurentShot] == true)
                    {
                        //removes the ship block that was hit from the players list
                        playerShips.Remove(computerCurentShot);

                        //chnages the appropiate button to red to represent a hit
                        if (computerCurentShot == 1)
                        {
                            player1Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 2)
                        {
                            player2Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 3)
                        {
                            player3Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 4)
                        {
                            player4Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 5)
                        {
                            player5Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 6)
                        {
                            player6Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 7)
                        {
                            player7Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 8)
                        {
                            player8Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 9)
                        {
                            player9Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 10)
                        {
                            player10Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 11)
                        {
                            player11Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 12)
                        {
                            player12Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 13)
                        {
                            player13Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 14)
                        {
                            player14Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 15)
                        {
                            player15Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 16)
                        {
                            player16Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 17)
                        {
                            player17Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 18)
                        {
                            player18Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 19)
                        {
                            player19Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 20)
                        {
                            player20Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 21)
                        {
                            player21Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 22)
                        {
                            player22Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 23)
                        {
                            player23Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 24)
                        {
                            player24Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 25)
                        {
                            player25Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 26)
                        {
                            player26Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 27)
                        {
                            player27Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 28)
                        {
                            player28Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 29)
                        {
                            player29Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 30)
                        {
                            player30Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 31)
                        {
                            player31Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 32)
                        {
                            player32Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 33)
                        {
                            player33Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 34)
                        {
                            player34Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 35)
                        {
                            player35Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 36)
                        {
                            player36Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 37)
                        {
                            player37Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 38)
                        {
                            player38Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 39)
                        {
                            player39Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 40)
                        {
                            player40Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 41)
                        {
                            player41Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 42)
                        {
                            player42Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 43)
                        {
                            player43Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 44)
                        {
                            player44Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 45)
                        {
                            player45Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 46)
                        {
                            player46Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 47)
                        {
                            player47Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 48)
                        {
                            player48Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 49)
                        {
                            player49Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 50)
                        {
                            player50Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 51)
                        {
                            player51Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 52)
                        {
                            player52Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 53)
                        {
                            player53Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 54)
                        {
                            player54Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 55)
                        {
                            player55Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 56)
                        {
                            player56Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 57)
                        {
                            player57Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 58)
                        {
                            player58Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 59)
                        {
                            player59Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 60)
                        {
                            player60Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 61)
                        {
                            player61Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 62)
                        {
                            player62Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 63)
                        {
                            player63Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 64)
                        {
                            player64Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 65)
                        {
                            player65Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 66)
                        {
                            player66Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 67)
                        {
                            player67Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 68)
                        {
                            player68Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 69)
                        {
                            player69Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 70)
                        {
                            player70Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 71)
                        {
                            player71Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 72)
                        {
                            player72Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 73)
                        {
                            player73Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 74)
                        {
                            player74Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 75)
                        {
                            player75Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 76)
                        {
                            player76Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 77)
                        {
                            player77Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 78)
                        {
                            player78Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 79)
                        {
                            player79Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 80)
                        {
                            player80Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 81)
                        {
                            player81Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 82)
                        {
                            player82Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 83)
                        {
                            player83Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 84)
                        {
                            player84Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 85)
                        {
                            player85Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 86)
                        {
                            player86Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 87)
                        {
                            player87Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 88)
                        {
                            player88Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 89)
                        {
                            player89Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 90)
                        {
                            player90Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 91)
                        {
                            player91Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 92)
                        {
                            player92Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 93)
                        {
                            player93Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 94)
                        {
                            player94Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 95)
                        {
                            player95Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 96)
                        {
                            player96Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 97)
                        {
                            player97Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 98)
                        {
                            player98Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 99)
                        {
                            player99Button.BackColor = Color.Red;
                        }
                        if (computerCurentShot == 100)
                        {
                            player100Button.BackColor = Color.Red;
                        }

                        //lets the computer go again since it hit you
                        computerMove_Click(sender, e);
                    }
                //runs if the computer missed it shot
                else
                {
                    //chnages the appropiate button to white to represent a miss
                    if (computerCurentShot == 1)
                        {
                            player1Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 2)
                        {
                            player2Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 3)
                        {
                            player3Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 4)
                        {
                            player4Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 5)
                        {
                            player5Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 6)
                        {
                            player6Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 7)
                        {
                            player7Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 8)
                        {
                            player8Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 9)
                        {
                            player9Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 10)
                        {
                            player10Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 11)
                        {
                            player11Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 12)
                        {
                            player12Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 13)
                        {
                            player13Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 14)
                        {
                            player14Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 15)
                        {
                            player15Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 16)
                        {
                            player16Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 17)
                        {
                            player17Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 18)
                        {
                            player18Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 19)
                        {
                            player19Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 20)
                        {
                            player20Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 21)
                        {
                            player21Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 22)
                        {
                            player22Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 23)
                        {
                            player23Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 24)
                        {
                            player24Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 25)
                        {
                            player25Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 26)
                        {
                            player26Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 27)
                        {
                            player27Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 28)
                        {
                            player28Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 29)
                        {
                            player29Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 30)
                        {
                            player30Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 31)
                        {
                            player31Button.BackColor = Color.White;
                        }                        
                    if (computerCurentShot == 32)
                        {
                            player32Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 33)
                        {
                            player33Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 34)
                        {
                            player34Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 35)
                        {
                            player35Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 36)
                        {
                            player36Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 37)
                        {
                            player37Button.BackColor = Color.White;
                        }                        
                    if (computerCurentShot == 38)
                        {
                            player38Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 39)
                        {
                            player39Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 40)
                        {
                            player40Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 41)
                        {
                            player41Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 42)
                        {
                            player42Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 43)
                        {
                            player43Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 44)
                        {
                            player44Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 45)
                        {
                            player45Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 46)
                        {
                            player46Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 47)
                        {
                            player47Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 48)
                        {
                            player48Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 49)
                        {
                            player49Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 50)
                        {
                            player50Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 51)
                        {
                            player51Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 52)
                        {
                            player52Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 53)
                        {
                            player53Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 54)
                        {
                            player54Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 55)
                        {
                            player55Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 56)
                        {
                            player56Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 57)
                        {
                            player57Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 58)
                        {
                            player58Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 59)
                        {
                            player59Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 60)
                        {
                            player60Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 61)
                        {
                            player61Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 62)
                        {
                            player62Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 63)
                        {
                            player63Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 64)
                        {
                            player64Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 65)
                        {
                            player65Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 66)
                        {
                            player66Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 67)
                        {
                            player67Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 68)
                        {
                            player68Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 69)
                        {
                            player69Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 70)
                        {
                            player70Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 71)
                        {
                            player71Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 72)
                        {
                            player72Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 73)
                        {
                            player73Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 74)
                        {
                            player74Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 75)
                        {
                            player75Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 76)
                        {
                            player76Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 77)
                        {
                            player77Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 78)
                        {
                            player78Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 79)
                        {
                            player79Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 80)
                        {
                            player80Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 81)
                        {
                            player81Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 82)
                        {
                            player82Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 83)
                        {
                            player83Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 84)
                        {
                            player84Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 85)
                        {
                            player85Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 86)
                        {
                            player86Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 87)
                        {
                            player87Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 88)
                        {
                            player88Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 89)
                        {
                            player89Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 90)
                        {
                            player90Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 91)
                        {
                            player91Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 92)
                        {
                            player92Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 93)
                        {
                            player93Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 94)
                        {
                            player94Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 95)
                        {
                            player95Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 97)
                        {
                            player97Button.BackColor = Color.White;
                        }
                    if (computerCurentShot == 98)
                        {
                            player98Button.BackColor = Color.White;
                        }                       
                    if (computerCurentShot == 99)
                        {
                            player99Button.BackColor = Color.White;
                        }                       
                    if (computerCurentShot == 100)
                        {
                            player100Button.BackColor = Color.White;
                        }
                }                
             }
        }

        //enables all the player buttons that don't have a ship on them
        private void playerButtonsEnabled_Click(object sender, EventArgs e)
        {
            if (player1Button.BackColor != Color.Gray)
            {
                player1Button.Enabled = true;
                player1Button.BackColor = Color.DarkBlue;
            }
            if (player2Button.BackColor != Color.Gray)
            {
                player2Button.Enabled = true;
                player2Button.BackColor = Color.DarkBlue;
            }
            if (player3Button.BackColor != Color.Gray)
            {
                player3Button.Enabled = true;
                player3Button.BackColor = Color.DarkBlue;
            }
            if (player4Button.BackColor != Color.Gray)
            {
                player4Button.Enabled = true;
                player4Button.BackColor = Color.DarkBlue;
            }
            if (player5Button.BackColor != Color.Gray)
            {
                player5Button.Enabled = true;
                player5Button.BackColor = Color.DarkBlue;
            }
            if (player6Button.BackColor != Color.Gray)
            {
                player6Button.Enabled = true;
                player6Button.BackColor = Color.DarkBlue;
            }
            if (player7Button.BackColor != Color.Gray)
            {
                player7Button.Enabled = true;
                player7Button.BackColor = Color.DarkBlue;
            }
            if (player8Button.BackColor != Color.Gray)
            {
                player8Button.Enabled = true;
                player8Button.BackColor = Color.DarkBlue;
            }
            if (player9Button.BackColor != Color.Gray)
            {
                player9Button.Enabled = true;
                player9Button.BackColor = Color.DarkBlue;
            }
            if (player10Button.BackColor != Color.Gray)
            {
                player10Button.Enabled = true;
                player10Button.BackColor = Color.DarkBlue;
            }
            if (player11Button.BackColor != Color.Gray)
            {
                player11Button.Enabled = true;
                player11Button.BackColor = Color.DarkBlue;
            }
            if (player12Button.BackColor != Color.Gray)
            {
                player12Button.Enabled = true;
                player12Button.BackColor = Color.DarkBlue;
            }
            if (player13Button.BackColor != Color.Gray)
            {
                player13Button.Enabled = true;
                player13Button.BackColor = Color.DarkBlue;
            }
            if (player14Button.BackColor != Color.Gray)
            {
                player14Button.Enabled = true;
                player14Button.BackColor = Color.DarkBlue;
            }
            if (player15Button.BackColor != Color.Gray)
            {
                player15Button.Enabled = true;
                player15Button.BackColor = Color.DarkBlue;
            }
            if (player16Button.BackColor != Color.Gray)
            {
                player16Button.Enabled = true;
                player16Button.BackColor = Color.DarkBlue;
            }
            if (player17Button.BackColor != Color.Gray)
            {
                player17Button.Enabled = true;
                player17Button.BackColor = Color.DarkBlue;
            }
            if (player18Button.BackColor != Color.Gray)
            {
                player18Button.Enabled = true;
                player18Button.BackColor = Color.DarkBlue;
            }
            if (player19Button.BackColor != Color.Gray)
            {
                player19Button.Enabled = true;
                player19Button.BackColor = Color.DarkBlue;
            }
            if (player20Button.BackColor != Color.Gray)
            {
                player20Button.Enabled = true;
                player20Button.BackColor = Color.DarkBlue;
            }
            if (player21Button.BackColor != Color.Gray)
            {
                player21Button.Enabled = true;
                player21Button.BackColor = Color.DarkBlue;
            }
            if (player22Button.BackColor != Color.Gray)
            {
                player22Button.Enabled = true;
                player22Button.BackColor = Color.DarkBlue;
            }
            if (player23Button.BackColor != Color.Gray)
            {
                player23Button.Enabled = true;
                player23Button.BackColor = Color.DarkBlue;
            }
            if (player24Button.BackColor != Color.Gray)
            {
                player24Button.Enabled = true;
                player24Button.BackColor = Color.DarkBlue;
            }
            if (player25Button.BackColor != Color.Gray)
            {
                player25Button.Enabled = true;
                player25Button.BackColor = Color.DarkBlue;
            }
            if (player26Button.BackColor != Color.Gray)
            {
                player26Button.Enabled = true;
                player26Button.BackColor = Color.DarkBlue;
            }
            if (player27Button.BackColor != Color.Gray)
            {
                player27Button.Enabled = true;
                player27Button.BackColor = Color.DarkBlue;
            }
            if (player28Button.BackColor != Color.Gray)
            {
                player28Button.Enabled = true;
                player28Button.BackColor = Color.DarkBlue;
            }
            if (player29Button.BackColor != Color.Gray)
            {
                player29Button.Enabled = true;
                player29Button.BackColor = Color.DarkBlue;
            }
            if (player30Button.BackColor != Color.Gray)
            {
                player30Button.Enabled = true;
                player30Button.BackColor = Color.DarkBlue;
            }
            if (player31Button.BackColor != Color.Gray)
            {
                player31Button.Enabled = true;
                player31Button.BackColor = Color.DarkBlue;
            }
            if (player32Button.BackColor != Color.Gray)
            {
                player32Button.Enabled = true;
                player32Button.BackColor = Color.DarkBlue;
            }
            if (player33Button.BackColor != Color.Gray)
            {
                player33Button.Enabled = true;
                player33Button.BackColor = Color.DarkBlue;
            }
            if (player34Button.BackColor != Color.Gray)
            {
                player34Button.Enabled = true;
                player34Button.BackColor = Color.DarkBlue;
            }
            if (player35Button.BackColor != Color.Gray)
            {
                player35Button.Enabled = true;
                player35Button.BackColor = Color.DarkBlue;
            }
            if (player36Button.BackColor != Color.Gray)
            {
                player36Button.Enabled = true;
                player36Button.BackColor = Color.DarkBlue;
            }
            if (player37Button.BackColor != Color.Gray)
            {
                player37Button.Enabled = true;
                player37Button.BackColor = Color.DarkBlue;
            }
            if (player38Button.BackColor != Color.Gray)
            {
                player38Button.Enabled = true;
                player38Button.BackColor = Color.DarkBlue;
            }
            if (player39Button.BackColor != Color.Gray)
            {
                player39Button.Enabled = true;
                player39Button.BackColor = Color.DarkBlue;
            }
            if (player40Button.BackColor != Color.Gray)
            {
                player40Button.Enabled = true;
                player40Button.BackColor = Color.DarkBlue;
            }
            if (player41Button.BackColor != Color.Gray)
            {
                player41Button.Enabled = true;
                player41Button.BackColor = Color.DarkBlue;
            }
            if (player42Button.BackColor != Color.Gray)
            {
                player42Button.Enabled = true;
                player42Button.BackColor = Color.DarkBlue;
            }
            if (player43Button.BackColor != Color.Gray)
            {
                player43Button.Enabled = true;
                player43Button.BackColor = Color.DarkBlue;
            }
            if (player44Button.BackColor != Color.Gray)
            {
                player44Button.Enabled = true;
                player44Button.BackColor = Color.DarkBlue;
            }
            if (player45Button.BackColor != Color.Gray)
            {
                player45Button.Enabled = true;
                player45Button.BackColor = Color.DarkBlue;
            }
            if (player46Button.BackColor != Color.Gray)
            {
                player46Button.Enabled = true;
                player46Button.BackColor = Color.DarkBlue;
            }
            if (player47Button.BackColor != Color.Gray)
            {
                player47Button.Enabled = true;
                player47Button.BackColor = Color.DarkBlue;
            }
            if (player48Button.BackColor != Color.Gray)
            {
                player48Button.Enabled = true;
                player48Button.BackColor = Color.DarkBlue;
            }
            if (player49Button.BackColor != Color.Gray)
            {
                player49Button.Enabled = true;
                player49Button.BackColor = Color.DarkBlue;
            }
            if (player50Button.BackColor != Color.Gray)
            {
                player50Button.Enabled = true;
                player50Button.BackColor = Color.DarkBlue;
            }
            if (player51Button.BackColor != Color.Gray)
            {
                player51Button.Enabled = true;
                player51Button.BackColor = Color.DarkBlue;
            }
            if (player52Button.BackColor != Color.Gray)
            {
                player52Button.Enabled = true;
                player52Button.BackColor = Color.DarkBlue;
            }
            if (player53Button.BackColor != Color.Gray)
            {
                player53Button.Enabled = true;
                player53Button.BackColor = Color.DarkBlue;
            }
            if (player54Button.BackColor != Color.Gray)
            {
                player54Button.Enabled = true;
                player54Button.BackColor = Color.DarkBlue;
            }
            if (player55Button.BackColor != Color.Gray)
            {
                player55Button.Enabled = true;
                player55Button.BackColor = Color.DarkBlue;
            }
            if (player56Button.BackColor != Color.Gray)
            {
                player56Button.Enabled = true;
                player56Button.BackColor = Color.DarkBlue;
            }
            if (player57Button.BackColor != Color.Gray)
            {
                player57Button.Enabled = true;
                player57Button.BackColor = Color.DarkBlue;
            }
            if (player58Button.BackColor != Color.Gray)
            {
                player58Button.Enabled = true;
                player58Button.BackColor = Color.DarkBlue;
            }
            if (player59Button.BackColor != Color.Gray)
            {
                player59Button.Enabled = true;
                player59Button.BackColor = Color.DarkBlue;
            }
            if (player60Button.BackColor != Color.Gray)
            {
                player60Button.Enabled = true;
                player60Button.BackColor = Color.DarkBlue;
            }
            if (player61Button.BackColor != Color.Gray)
            {
                player61Button.Enabled = true;
                player61Button.BackColor = Color.DarkBlue;
            }
            if (player62Button.BackColor != Color.Gray)
            {
                player62Button.Enabled = true;
                player62Button.BackColor = Color.DarkBlue;
            }
            if (player63Button.BackColor != Color.Gray)
            {
                player63Button.Enabled = true;
                player63Button.BackColor = Color.DarkBlue;
            }
            if (player64Button.BackColor != Color.Gray)
            {
                player64Button.Enabled = true;
                player64Button.BackColor = Color.DarkBlue;
            }
            if (player65Button.BackColor != Color.Gray)
            {
                player65Button.Enabled = true;
                player65Button.BackColor = Color.DarkBlue;
            }
            if (player66Button.BackColor != Color.Gray)
            {
                player66Button.Enabled = true;
                player66Button.BackColor = Color.DarkBlue;
            }
            if (player67Button.BackColor != Color.Gray)
            {
                player67Button.Enabled = true;
                player67Button.BackColor = Color.DarkBlue;
            }
            if (player68Button.BackColor != Color.Gray)
            {
                player68Button.Enabled = true;
                player68Button.BackColor = Color.DarkBlue;
            }
            if (player69Button.BackColor != Color.Gray)
            {
                player69Button.Enabled = true;
                player69Button.BackColor = Color.DarkBlue;
            }
            if (player70Button.BackColor != Color.Gray)
            {
                player70Button.Enabled = true;
                player70Button.BackColor = Color.DarkBlue;
            }
            if (player71Button.BackColor != Color.Gray)
            {
                player71Button.Enabled = true;
                player71Button.BackColor = Color.DarkBlue;
            }
            if (player72Button.BackColor != Color.Gray)
            {
                player72Button.Enabled = true;
                player72Button.BackColor = Color.DarkBlue;
            }
            if (player73Button.BackColor != Color.Gray)
            {
                player73Button.Enabled = true;
                player73Button.BackColor = Color.DarkBlue;
            }
            if (player74Button.BackColor != Color.Gray)
            {
                player74Button.Enabled = true;
                player74Button.BackColor = Color.DarkBlue;
            }
            if (player75Button.BackColor != Color.Gray)
            {
                player75Button.Enabled = true;
                player75Button.BackColor = Color.DarkBlue;
            }
            if (player76Button.BackColor != Color.Gray)
            {
                player76Button.Enabled = true;
                player76Button.BackColor = Color.DarkBlue;
            }
            if (player77Button.BackColor != Color.Gray)
            {
                player77Button.Enabled = true;
                player77Button.BackColor = Color.DarkBlue;
            }
            if (player78Button.BackColor != Color.Gray)
            {
                player78Button.Enabled = true;
                player78Button.BackColor = Color.DarkBlue;
            }
            if (player79Button.BackColor != Color.Gray)
            {
                player79Button.Enabled = true;
                player79Button.BackColor = Color.DarkBlue;
            }
            if (player80Button.BackColor != Color.Gray)
            {
                player80Button.Enabled = true;
                player80Button.BackColor = Color.DarkBlue;
            }
            if (player81Button.BackColor != Color.Gray)
            {
                player81Button.Enabled = true;
                player81Button.BackColor = Color.DarkBlue;
            }
            if (player82Button.BackColor != Color.Gray)
            {
                player82Button.Enabled = true;
                player82Button.BackColor = Color.DarkBlue;
            }
            if (player83Button.BackColor != Color.Gray)
            {
                player83Button.Enabled = true;
                player83Button.BackColor = Color.DarkBlue;
            }
            if (player84Button.BackColor != Color.Gray)
            {
                player84Button.Enabled = true;
                player84Button.BackColor = Color.DarkBlue;
            }
            if (player85Button.BackColor != Color.Gray)
            {
                player85Button.Enabled = true;
                player85Button.BackColor = Color.DarkBlue;
            }
            if (player86Button.BackColor != Color.Gray)
            {
                player86Button.Enabled = true;
                player86Button.BackColor = Color.DarkBlue;
            }
            if (player87Button.BackColor != Color.Gray)
            {
                player87Button.Enabled = true;
                player87Button.BackColor = Color.DarkBlue;
            }
            if (player88Button.BackColor != Color.Gray)
            {
                player88Button.Enabled = true;
                player88Button.BackColor = Color.DarkBlue;
            }
            if (player89Button.BackColor != Color.Gray)
            {
                player89Button.Enabled = true;
                player89Button.BackColor = Color.DarkBlue;
            }
            if (player90Button.BackColor != Color.Gray)
            {
                player90Button.Enabled = true;
                player90Button.BackColor = Color.DarkBlue;
            }
            if (player91Button.BackColor != Color.Gray)
            {
                player91Button.Enabled = true;
                player91Button.BackColor = Color.DarkBlue;
            }
            if (player92Button.BackColor != Color.Gray)
            {
                player92Button.Enabled = true;
                player92Button.BackColor = Color.DarkBlue;
            }
            if (player93Button.BackColor != Color.Gray)
            {
                player93Button.Enabled = true;
                player93Button.BackColor = Color.DarkBlue;
            }
            if (player94Button.BackColor != Color.Gray)
            {
                player94Button.Enabled = true;
                player94Button.BackColor = Color.DarkBlue;
            }
            if (player95Button.BackColor != Color.Gray)
            {
                player95Button.Enabled = true;
                player95Button.BackColor = Color.DarkBlue;
            }
            if (player96Button.BackColor != Color.Gray)
            {
                player96Button.Enabled = true;
                player96Button.BackColor = Color.DarkBlue;
            }
            if (player97Button.BackColor != Color.Gray)
            {
                player97Button.Enabled = true;
                player97Button.BackColor = Color.DarkBlue;
            }
            if (player98Button.BackColor != Color.Gray)
            {
                player98Button.Enabled = true;
                player98Button.BackColor = Color.DarkBlue;
            }
            if (player99Button.BackColor != Color.Gray)
            {
                player99Button.Enabled = true;
                player99Button.BackColor = Color.DarkBlue;
            }
            if (player100Button.BackColor != Color.Gray)
            {
                player100Button.Enabled = true;
                player100Button.BackColor = Color.DarkBlue;
            }
        }

        //enables all the computer side buttons when all the boats are placed
       private void computerButtonsEnabled_Click(object sender, EventArgs e)
        {
            computer1Button.Enabled = true;
            computer2Button.Enabled = true;
            computer3Button.Enabled = true;
            computer4Button.Enabled = true;
            computer5Button.Enabled = true;
            computer6Button.Enabled = true;
            computer7Button.Enabled = true;
            computer8Button.Enabled = true;
            computer9Button.Enabled = true;
            computer10Button.Enabled = true;
            computer11Button.Enabled = true; 
            computer12Button.Enabled = true;
            computer13Button.Enabled = true;
            computer14Button.Enabled = true;
            computer15Button.Enabled = true;
            computer16Button.Enabled = true;
            computer17Button.Enabled = true;
            computer18Button.Enabled = true;
            computer19Button.Enabled = true;
            computer20Button.Enabled = true;
            computer21Button.Enabled = true;
            computer22Button.Enabled = true;
            computer23Button.Enabled = true;
            computer24Button.Enabled = true;
            computer25Button.Enabled = true;
            computer26Button.Enabled = true;
            computer27Button.Enabled = true;
            computer28Button.Enabled = true;
            computer29Button.Enabled = true;
            computer30Button.Enabled = true;
            computer31Button.Enabled = true;
            computer32Button.Enabled = true;
            computer33Button.Enabled = true;
            computer34Button.Enabled = true;
            computer35Button.Enabled = true;
            computer36Button.Enabled = true;
            computer37Button.Enabled = true;
            computer38Button.Enabled = true;
            computer39Button.Enabled = true;
            computer40Button.Enabled = true;
            computer41Button.Enabled = true;
            computer42Button.Enabled = true;
            computer43Button.Enabled = true;
            computer44Button.Enabled = true;
            computer45Button.Enabled = true;
            computer46Button.Enabled = true;
            computer47Button.Enabled = true;
            computer48Button.Enabled = true;
            computer49Button.Enabled = true;
            computer50Button.Enabled = true;
            computer51Button.Enabled = true;
            computer52Button.Enabled = true;
            computer53Button.Enabled = true;
            computer54Button.Enabled = true;
            computer55Button.Enabled = true;
            computer56Button.Enabled = true;
            computer57Button.Enabled = true;
            computer58Button.Enabled = true;
            computer59Button.Enabled = true;
            computer60Button.Enabled = true;
            computer61Button.Enabled = true;
            computer62Button.Enabled = true;
            computer63Button.Enabled = true;
            computer64Button.Enabled = true;
            computer65Button.Enabled = true;
            computer66Button.Enabled = true;
            computer67Button.Enabled = true;
            computer68Button.Enabled = true;
            computer69Button.Enabled = true;
            computer70Button.Enabled = true;
            computer71Button.Enabled = true;
            computer72Button.Enabled = true;
            computer73Button.Enabled = true;
            computer74Button.Enabled = true;
            computer75Button.Enabled = true;
            computer76Button.Enabled = true;
            computer77Button.Enabled = true;
            computer78Button.Enabled = true;
            computer79Button.Enabled = true;
            computer80Button.Enabled = true;
            computer81Button.Enabled = true;
            computer82Button.Enabled = true;
            computer83Button.Enabled = true;
            computer84Button.Enabled = true;
            computer85Button.Enabled = true;
            computer86Button.Enabled = true;
            computer87Button.Enabled = true;
            computer88Button.Enabled = true;
            computer89Button.Enabled = true;
            computer90Button.Enabled = true;
            computer91Button.Enabled = true;
            computer92Button.Enabled = true;
            computer93Button.Enabled = true;
            computer94Button.Enabled = true;
            computer95Button.Enabled = true;
            computer96Button.Enabled = true;
            computer97Button.Enabled = true;
            computer98Button.Enabled = true;
            computer99Button.Enabled = true;
            computer100Button.Enabled = true;
        }

        //All the boat buttons are about the same just sets a different amount of spaces required but check this out for more ↓.
        private void patrolBoatButton_Click(object sender, EventArgs e)
        {
            //runs a hidden button that enables all of the buttons on the board that aren't ship blocks
            playerButtonsEnabled_Click(sender, e);
            //resets the amount of spaces that you've placed
            placedCount = 0;
            //sets the amount of spaces the current ship should take up
            shipSpaces = 2;
            //sets the current boat bool to be true so you can't set it again later
            patrolBoatPlaced = true;
            //sets the first placed space bool to true so it knows that the next button you hit is your first space placed
            firstPlaced = true;
            //resets the bools for which way the ship is going
            horizontal = false;
            vertical = false;
            //resets directionCheck int 
            directionCheck = -100;

            //turns off all the ship buttons till you've placed your current ship
            patrolBoatButton.Enabled = false;
            submarineButton.Enabled = false;
            destroyerButton.Enabled = false;
            battleshipButton.Enabled = false;
            carrierButton.Enabled = false;

        }

        private void submarineButton_Click(object sender, EventArgs e)
        {
            playerButtonsEnabled_Click(sender, e);
            placedCount = 0;
            shipSpaces = 3;
            submarinePlaced = true;
            firstPlaced = true;
            horizontal = false;
            vertical = false;
            directionCheck = -100;

            patrolBoatButton.Enabled = false;
            submarineButton.Enabled = false;
            destroyerButton.Enabled = false;
            battleshipButton.Enabled = false;
            carrierButton.Enabled = false;
        }

        private void destroyerButton_Click(object sender, EventArgs e)
        {
            playerButtonsEnabled_Click(sender, e);
            placedCount = 0;
            shipSpaces = 3;
            destroyerPlaced = true;
            firstPlaced = true;
            horizontal = false;
            vertical = false;
            directionCheck = -100;

            patrolBoatButton.Enabled = false;
            submarineButton.Enabled = false;
            destroyerButton.Enabled = false;
            battleshipButton.Enabled = false;
            carrierButton.Enabled = false;
        }

        private void battleshipButton_Click(object sender, EventArgs e)
        {
            playerButtonsEnabled_Click(sender, e);
            placedCount = 0;
            shipSpaces = 4;
            battleshipPlaced = true;
            firstPlaced = true;
            horizontal = false;
            vertical = false;
            directionCheck = -100;

            patrolBoatButton.Enabled = false;
            submarineButton.Enabled = false;
            destroyerButton.Enabled = false;
            battleshipButton.Enabled = false;
            carrierButton.Enabled = false;
        }

        private void carrierButton_Click(object sender, EventArgs e)
        {
            playerButtonsEnabled_Click(sender, e);
            placedCount = 0;
            shipSpaces = 5;
            carrierPlaced = true;
            firstPlaced = true;
            horizontal = false;
            vertical = false;
            directionCheck = -100;

            patrolBoatButton.Enabled = false;
            submarineButton.Enabled = false;
            destroyerButton.Enabled = false;
            battleshipButton.Enabled = false;
            carrierButton.Enabled = false;
        }

        private void player1Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(1);
            placedCount++;
            player1Button.BackColor = Color.Gray;
            player1Button.Enabled = false;
            shipCheck[1] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 1;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.BackColor = Color.DarkBlue;
                    player12Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player2Button.BackColor != Color.Gray)
                {
                    player2Button.Enabled = true;
                    player2Button.BackColor = Color.Aqua;
                }
                if (player11Button.BackColor != Color.Gray)
                { 
                    player11Button.Enabled = true;
                    player11Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 1;
                secondPlaced = true;
            }
                                
            resetButton.Enabled = true;
            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                { 
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        //Looking for an explanation? look here ↓.
        private void player2Button_Click(object sender, EventArgs e)
        {
            //Adds the value of the button to the Player's list
            playerShips.Add(2);
            //Counts up by one to check later if you placed all the blocks for a ship
            placedCount++;
            //Changes the buttons colour to gray to symbolize a ship and is used to limit the features of the button
            player2Button.BackColor = Color.Gray;
            //Disables you from being able to press this button again
            player2Button.Enabled = false;
            //changes a bool that the space represnts in a list of bools
            shipCheck[2] = true;

            //Checks if it's the second block placed for a boat
            if (secondPlaced == true)
            {
                //sets the int to represent the spaces numerical value
                currentPlacedInt = 2;
                //sets the bool so it won't trigger again to you're placing a second block for another ship
                secondPlaced = false;
                //runs a while statement to help check what direction a ship is going
                while (directionCheck < 100)
                {
                    //adds 10 to itself 
                    directionCheck = directionCheck + 10;
                    //checks if the ship is going verticaly using the spaces numerical values
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        //sets the bool to true so the rest of the blocks placed already know which way the ship is going
                        vertical = true;
                    }
                }
                //determines if the ship isn't going vertically it must be horizontal
                if (vertical != true)
                {
                    //sets the bool to true so the rest of the blocks placed already know which way the ship is going
                    horizontal = true;
                }
                //checks if the blocks diagonal have ships and if not changes them back to regular water tiles
                if (player11Button.BackColor != Color.Gray)
                {
                    //makes sure to change blocks diagonal to it so they can't be pressed and changes the color back dark blue
                    player11Button.BackColor = Color.DarkBlue;
                    player11Button.Enabled = false;
                }
                //does the same as the last if statement just for a different diagonal block
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.BackColor = Color.DarkBlue;
                    player13Button.Enabled = false;
                }

            }
            //checks if it's the first block placed for a boat
            else if (firstPlaced == true)
            {
                //disables all the buttons on the board
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                //checks if there's a ship block on the block next to it
                if (player1Button.BackColor != Color.Gray)
                {
                    //makes the block next to it clickable
                    player1Button.Enabled = true;
                    //makes the block next to it change colour to represent that it can be clicked
                    player1Button.BackColor = Color.Aqua;
                }
                //does the same as the last if statement just for another block next to it
                if (player3Button.BackColor != Color.Gray)
                {
                    player3Button.Enabled = true;
                    player3Button.BackColor = Color.Aqua;
                }
                //does the same as the last if statement just for another block next to it
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.Enabled = true;
                    player12Button.BackColor = Color.Aqua;
                }
                //turns the bool to false so it won't run any first placed code till the next ship
                firstPlaced = false;
                //sets the first place int to help determine later which way the ship is going
                firstPlacedInt = 2;
                //sets the second place bool to true so the next block you click will run the second place code
                secondPlaced = true;
            }

            //checks if either of the directions for the boat has been chosen
            if (vertical == true || horizontal == true)
            {
                //checks if the ship is horizontal
                if (horizontal == true)
                {
                    //checks if there's not a ship block next to this space
                    if (player1Button.BackColor != Color.Gray)
                    {
                        //enables you to click the space next to this one as long as there wasn't a ship block there
                        player1Button.Enabled = true;
                        //changes the spaces colour as long as there wasn't a ship there
                        player1Button.BackColor = Color.Aqua;
                    }
                    //does the same thing as the last if statement just for a different block next to the current one
                    if (player3Button.BackColor != Color.Gray)
                    {
                        player3Button.Enabled = true;
                        player3Button.BackColor = Color.Aqua;
                    }
                }
                //for apropiate spaces there is a vertical checker here as well that does the same as the horizontal just vertically
            }

            //enables the reset button
            resetButton.Enabled = true;

            //checks if the amount of blocks you've placed for a ship equals the amount you need to place for it
            if (placedCount == shipSpaces)
            {
                //adds a ship placed to the total count
                shipsPlaced++;
                //disables all buttons
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                //checks if you've already placed this boat
                if (patrolBoatPlaced == false)
                {
                    //stops you from placing the boat again if you already have
                    patrolBoatButton.Enabled = true;
                }
                //checks if you've already placed this boat
                if (submarinePlaced == false)
                {
                    //stops you from placing the boat again if you already have
                    submarineButton.Enabled = true;
                }
                //checks if you've already placed this boat
                if (destroyerPlaced == false)
                {
                    //stops you from placing the boat again if you already have
                    destroyerButton.Enabled = true;
                }
                //checks if you've already placed this boat
                if (battleshipPlaced == false)
                {
                    //stops you from placing the boat again if you already have
                    battleshipButton.Enabled = true;
                }
                //checks if you've already placed this boat
                if (carrierPlaced == false)
                {
                    //stops you from placing the boat again if you already have
                    carrierButton.Enabled = true;
                }
                //checks if you've placed all your ships
                if (shipsPlaced == 5)
                {
                    //sets the all placed ships bool to true
                    allShipsPlaced = true;
                    //enables all the computers buttons to be clicked
                    computerButtonsEnabled_Click(sender, e);
                }
                //makes it so you can click the reset button
                resetButton.Enabled = true;
            }
        }

        private void player3Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(3);
            placedCount++;
            player3Button.BackColor = Color.Gray;
            player3Button.Enabled = false;
            shipCheck[3] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 3;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.BackColor = Color.DarkBlue;
                    player12Button.Enabled = false;
                }
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.BackColor = Color.DarkBlue;
                    player14Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player2Button.BackColor != Color.Gray)
                {
                    player2Button.Enabled = true;
                    player2Button.BackColor = Color.Aqua;
                }
                if (player4Button.BackColor != Color.Gray)
                {
                    player4Button.Enabled = true;
                    player4Button.BackColor = Color.Aqua;
                }
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.Enabled = true;
                    player13Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 3;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player2Button.BackColor != Color.Gray)
                    {
                        player2Button.Enabled = true;
                        player2Button.BackColor = Color.Aqua;
                    }
                    if (player4Button.BackColor != Color.Gray)
                    {
                        player4Button.Enabled = true;
                        player4Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player4Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(4);
            placedCount++;
            player4Button.BackColor = Color.Gray;
            player4Button.Enabled = false;
            shipCheck[4] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 4;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.BackColor = Color.DarkBlue;
                    player13Button.Enabled = false;
                }
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.BackColor = Color.DarkBlue;
                    player15Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player3Button.BackColor != Color.Gray)
                {
                    player3Button.Enabled = true;
                    player3Button.BackColor = Color.Aqua;
                }
                if (player5Button.BackColor != Color.Gray)
                {
                    player5Button.Enabled = true;
                    player5Button.BackColor = Color.Aqua;
                }
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.Enabled = true;
                    player14Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 4;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player3Button.BackColor != Color.Gray)
                    {
                        player3Button.Enabled = true;
                        player3Button.BackColor = Color.Aqua;
                    }
                    if (player5Button.BackColor != Color.Gray)
                    {
                        player5Button.Enabled = true;
                        player5Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player5Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(5);
            placedCount++;
            player5Button.BackColor = Color.Gray;
            player5Button.Enabled = false;
            shipCheck[5] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 5;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.BackColor = Color.DarkBlue;
                    player14Button.Enabled = false;
                }
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.BackColor = Color.DarkBlue;
                    player16Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player4Button.BackColor != Color.Gray)
                {
                    player4Button.Enabled = true;
                    player4Button.BackColor = Color.Aqua;
                }
                if (player6Button.BackColor != Color.Gray)
                {
                    player6Button.Enabled = true;
                    player6Button.BackColor = Color.Aqua;
                }
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.Enabled = true;
                    player15Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 5;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player4Button.BackColor != Color.Gray)
                    {
                        player4Button.Enabled = true;
                        player4Button.BackColor = Color.Aqua;
                    }
                    if (player6Button.BackColor != Color.Gray)
                    {
                        player6Button.Enabled = true;
                        player6Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player6Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(6);
            placedCount++;
            player6Button.BackColor = Color.Gray;
            player6Button.Enabled = false;
            shipCheck[6] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 6;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.BackColor = Color.DarkBlue;
                    player15Button.Enabled = false;
                }
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.BackColor = Color.DarkBlue;
                    player17Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player5Button.BackColor != Color.Gray)
                {
                    player5Button.Enabled = true;
                    player5Button.BackColor = Color.Aqua;
                }
                if (player7Button.BackColor != Color.Gray)
                {
                    player7Button.Enabled = true;
                    player7Button.BackColor = Color.Aqua;
                }
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.Enabled = true;
                    player16Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 6;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player5Button.BackColor != Color.Gray)
                    {
                        player5Button.Enabled = true;
                        player5Button.BackColor = Color.Aqua;
                    }
                    if (player7Button.BackColor != Color.Gray)
                    {
                        player7Button.Enabled = true;
                        player7Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player7Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(7);
            placedCount++;
            player7Button.BackColor = Color.Gray;
            player7Button.Enabled = false;
            shipCheck[7] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 7;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.BackColor = Color.DarkBlue;
                    player16Button.Enabled = false;
                }
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.BackColor = Color.DarkBlue;
                    player18Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player6Button.BackColor != Color.Gray)
                {
                    player6Button.Enabled = true;
                    player6Button.BackColor = Color.Aqua;
                }
                if (player8Button.BackColor != Color.Gray)
                {
                    player8Button.Enabled = true;
                    player8Button.BackColor = Color.Aqua;
                }
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.Enabled = true;
                    player17Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 7;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player6Button.BackColor != Color.Gray)
                    {
                        player6Button.Enabled = true;
                        player6Button.BackColor = Color.Aqua;
                    }
                    if (player8Button.BackColor != Color.Gray)
                    {
                        player8Button.Enabled = true;
                        player8Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player8Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(8);
            placedCount++;
            player8Button.BackColor = Color.Gray;
            player8Button.Enabled = false;
            shipCheck[8] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 8;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.BackColor = Color.DarkBlue;
                    player17Button.Enabled = false;
                }
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.BackColor = Color.DarkBlue;
                    player19Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player7Button.BackColor != Color.Gray)
                {
                    player7Button.Enabled = true;
                    player7Button.BackColor = Color.Aqua;
                }
                if (player9Button.BackColor != Color.Gray)
                {
                    player9Button.Enabled = true;
                    player9Button.BackColor = Color.Aqua;
                }
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.Enabled = true;
                    player18Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 8;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player7Button.BackColor != Color.Gray)
                    {
                        player7Button.Enabled = true;
                        player7Button.BackColor = Color.Aqua;
                    }
                    if (player9Button.BackColor != Color.Gray)
                    {
                        player9Button.Enabled = true;
                        player9Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player9Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(9);
            placedCount++;
            player9Button.BackColor = Color.Gray;
            player9Button.Enabled = false;
            shipCheck[9] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 9;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.BackColor = Color.DarkBlue;
                    player18Button.Enabled = false;
                }
                if (player20Button.BackColor != Color.Gray)
                {
                    player20Button.BackColor = Color.DarkBlue;
                    player20Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player8Button.BackColor != Color.Gray)
                {
                    player8Button.Enabled = true;
                    player8Button.BackColor = Color.Aqua;
                }
                if (player10Button.BackColor != Color.Gray)
                {
                    player10Button.Enabled = true;
                    player10Button.BackColor = Color.Aqua;
                }
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.Enabled = true;
                    player19Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 9;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player8Button.BackColor != Color.Gray)
                    {
                        player8Button.Enabled = true;
                        player8Button.BackColor = Color.Aqua;
                    }
                    if (player10Button.BackColor != Color.Gray)
                    {
                        player10Button.Enabled = true;
                        player10Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player10Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(10);
            placedCount++;
            player10Button.BackColor = Color.Gray;
            player10Button.Enabled = false;
            shipCheck[10] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 10;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.BackColor = Color.DarkBlue;
                    player19Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player9Button.BackColor != Color.Gray)
                {
                    player9Button.Enabled = true;
                    player9Button.BackColor = Color.Aqua;
                }
                if (player20Button.BackColor != Color.Gray)
                {
                    player20Button.Enabled = true;
                    player20Button.BackColor = Color.Aqua;
                }
                
                firstPlaced = false;
                firstPlacedInt = 10;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {

            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player11Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(11);
            placedCount++;
            player11Button.BackColor = Color.Gray;
            player11Button.Enabled = false;
            shipCheck[11] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 11;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player2Button.BackColor != Color.Gray)
                {
                    player2Button.BackColor = Color.DarkBlue;
                    player2Button.Enabled = false;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.BackColor = Color.DarkBlue;
                    player22Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player1Button.BackColor != Color.Gray)
                {
                    player1Button.Enabled = true;
                    player1Button.BackColor = Color.Aqua;
                }
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.Enabled = true;
                    player12Button.BackColor = Color.Aqua;
                }
                if (player21Button.BackColor != Color.Gray)
                {
                    player21Button.Enabled = true;
                    player21Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 11;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player1Button.BackColor != Color.Gray)
                    {
                        player1Button.Enabled = true;
                        player1Button.BackColor = Color.Aqua;
                    }
                    if (player21Button.BackColor != Color.Gray)
                    {
                        player21Button.Enabled = true;
                        player21Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player12Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(12);
            placedCount++;
            player12Button.BackColor = Color.Gray;
            player12Button.Enabled = false;
            shipCheck[12] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 12;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player1Button.BackColor != Color.Gray)
                {
                    player1Button.BackColor = Color.DarkBlue;
                    player1Button.Enabled = false;
                }
                if (player3Button.BackColor != Color.Gray)
                {
                    player3Button.BackColor = Color.DarkBlue;
                    player3Button.Enabled = false;
                }
                if (player21Button.BackColor != Color.Gray)
                {
                    player21Button.BackColor = Color.DarkBlue;
                    player21Button.Enabled = false;
                }
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.BackColor = Color.DarkBlue;
                    player23Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player2Button.BackColor != Color.Gray)
                {
                    player2Button.Enabled = true;
                    player2Button.BackColor = Color.Aqua;
                }
                if (player11Button.BackColor != Color.Gray)
                {
                    player11Button.Enabled = true;
                    player11Button.BackColor = Color.Aqua;
                }
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.Enabled = true;
                    player13Button.BackColor = Color.Aqua;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.Enabled = true;
                    player22Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 12;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player11Button.BackColor != Color.Gray)
                    {
                        player11Button.Enabled = true;
                        player11Button.BackColor = Color.Aqua;
                    }
                    if (player13Button.BackColor != Color.Gray)
                    {
                        player13Button.Enabled = true;
                        player13Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player2Button.BackColor != Color.Gray)
                    {
                        player2Button.Enabled = true;
                        player2Button.BackColor = Color.Aqua;
                    }
                    if (player22Button.BackColor != Color.Gray)
                    {
                        player22Button.Enabled = true;
                        player22Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player13Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(13);
            placedCount++;
            player13Button.BackColor = Color.Gray;
            player13Button.Enabled = false;
            shipCheck[13] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 13;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player2Button.BackColor != Color.Gray)
                {
                    player2Button.BackColor = Color.DarkBlue;
                    player2Button.Enabled = false;
                }
                if (player4Button.BackColor != Color.Gray)
                {
                    player4Button.BackColor = Color.DarkBlue;
                    player4Button.Enabled = false;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.BackColor = Color.DarkBlue;
                    player22Button.Enabled = false;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player24Button.BackColor = Color.DarkBlue;
                    player24Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player3Button.BackColor != Color.Gray)
                {
                    player3Button.Enabled = true;
                    player3Button.BackColor = Color.Aqua;
                }
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.Enabled = true;
                    player12Button.BackColor = Color.Aqua;
                }
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.Enabled = true;
                    player14Button.BackColor = Color.Aqua;
                }
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.Enabled = true;
                    player23Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 13;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player12Button.BackColor != Color.Gray)
                    {
                        player12Button.Enabled = true;
                        player12Button.BackColor = Color.Aqua;
                    }
                    if (player14Button.BackColor != Color.Gray)
                    {
                        player14Button.Enabled = true;
                        player14Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player3Button.BackColor != Color.Gray)
                    {
                        player3Button.Enabled = true;
                        player3Button.BackColor = Color.Aqua;
                    }
                    if (player23Button.BackColor != Color.Gray)
                    {
                        player23Button.Enabled = true;
                        player23Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player14Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(14);
            placedCount++;
            player14Button.BackColor = Color.Gray;
            player14Button.Enabled = false;
            shipCheck[14] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 14;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player3Button.BackColor != Color.Gray)
                {
                    player3Button.BackColor = Color.DarkBlue;
                    player3Button.Enabled = false;
                }
                if (player5Button.BackColor != Color.Gray)
                {
                    player5Button.BackColor = Color.DarkBlue;
                    player5Button.Enabled = false;
                }
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.BackColor = Color.DarkBlue;
                    player23Button.Enabled = false;
                }
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.BackColor = Color.DarkBlue;
                    player25Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player4Button.BackColor != Color.Gray)
                {
                    player4Button.Enabled = true;
                    player4Button.BackColor = Color.Aqua;
                }
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.Enabled = true;
                    player13Button.BackColor = Color.Aqua;
                }
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.Enabled = true;
                    player15Button.BackColor = Color.Aqua;
                }
                if (player24Button.BackColor != Color.Gray)
                {
                    player24Button.Enabled = true;
                    player24Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 14;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player13Button.BackColor != Color.Gray)
                    {
                        player13Button.Enabled = true;
                        player13Button.BackColor = Color.Aqua;
                    }
                    if (player15Button.BackColor != Color.Gray)
                    {
                        player15Button.Enabled = true;
                        player15Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player4Button.BackColor != Color.Gray)
                    {
                        player4Button.Enabled = true;
                        player4Button.BackColor = Color.Aqua;
                    }
                    if (player24Button.BackColor != Color.Gray)
                    {
                        player24Button.Enabled = true;
                        player24Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player15Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(15);
            placedCount++;
            player15Button.BackColor = Color.Gray;
            player15Button.Enabled = false;
            shipCheck[15] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 15;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player4Button.BackColor != Color.Gray)
                {
                    player4Button.BackColor = Color.DarkBlue;
                    player4Button.Enabled = false;
                }
                if (player6Button.BackColor != Color.Gray)
                {
                    player6Button.BackColor = Color.DarkBlue;
                    player6Button.Enabled = false;
                }
                if (player24Button.BackColor != Color.Gray)
                {
                    player24Button.BackColor = Color.DarkBlue;
                    player24Button.Enabled = false;
                }
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.BackColor = Color.DarkBlue;
                    player26Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player5Button.BackColor != Color.Gray)
                {
                    player5Button.Enabled = true;
                    player5Button.BackColor = Color.Aqua;
                }
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.Enabled = true;
                    player14Button.BackColor = Color.Aqua;
                }
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.Enabled = true;
                    player16Button.BackColor = Color.Aqua;
                }
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.Enabled = true;
                    player25Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 15;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player14Button.BackColor != Color.Gray)
                    {
                        player14Button.Enabled = true;
                        player14Button.BackColor = Color.Aqua;
                    }
                    if (player16Button.BackColor != Color.Gray)
                    {
                        player16Button.Enabled = true;
                        player16Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player5Button.BackColor != Color.Gray)
                    {
                        player5Button.Enabled = true;
                        player5Button.BackColor = Color.Aqua;
                    }
                    if (player25Button.BackColor != Color.Gray)
                    {
                        player25Button.Enabled = true;
                        player25Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player16Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(16);
            placedCount++;
            player16Button.BackColor = Color.Gray;
            player16Button.Enabled = false;
            shipCheck[16] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 16;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player5Button.BackColor != Color.Gray)
                {
                    player5Button.BackColor = Color.DarkBlue;
                    player5Button.Enabled = false;
                }
                if (player7Button.BackColor != Color.Gray)
                {
                    player7Button.BackColor = Color.DarkBlue;
                    player7Button.Enabled = false;
                }
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.BackColor = Color.DarkBlue;
                    player25Button.Enabled = false;
                }
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.BackColor = Color.DarkBlue;
                    player27Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player6Button.BackColor != Color.Gray)
                {
                    player6Button.Enabled = true;
                    player6Button.BackColor = Color.Aqua;
                }
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.Enabled = true;
                    player15Button.BackColor = Color.Aqua;
                }
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.Enabled = true;
                    player17Button.BackColor = Color.Aqua;
                }
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.Enabled = true;
                    player26Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 16;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player15Button.BackColor != Color.Gray)
                    {
                        player15Button.Enabled = true;
                        player15Button.BackColor = Color.Aqua;
                    }
                    if (player17Button.BackColor != Color.Gray)
                    {
                        player17Button.Enabled = true;
                        player17Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player6Button.BackColor != Color.Gray)
                    {
                        player6Button.Enabled = true;
                        player6Button.BackColor = Color.Aqua;
                    }
                    if (player26Button.BackColor != Color.Gray)
                    {
                        player26Button.Enabled = true;
                        player26Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player17Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(17);
            placedCount++;
            player17Button.BackColor = Color.Gray;
            player17Button.Enabled = false;
            shipCheck[17] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 17;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player6Button.BackColor != Color.Gray)
                {
                    player6Button.BackColor = Color.DarkBlue;
                    player6Button.Enabled = false;
                }
                if (player8Button.BackColor != Color.Gray)
                {
                    player8Button.BackColor = Color.DarkBlue;
                    player8Button.Enabled = false;
                }
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.BackColor = Color.DarkBlue;
                    player26Button.Enabled = false;
                }
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.BackColor = Color.DarkBlue;
                    player28Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player7Button.BackColor != Color.Gray)
                {
                    player7Button.Enabled = true;
                    player7Button.BackColor = Color.Aqua;
                }
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.Enabled = true;
                    player16Button.BackColor = Color.Aqua;
                }
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.Enabled = true;
                    player18Button.BackColor = Color.Aqua;
                }
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.Enabled = true;
                    player27Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 17;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player16Button.BackColor != Color.Gray)
                    {
                        player16Button.Enabled = true;
                        player16Button.BackColor = Color.Aqua;
                    }
                    if (player18Button.BackColor != Color.Gray)
                    {
                        player18Button.Enabled = true;
                        player18Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player7Button.BackColor != Color.Gray)
                    {
                        player7Button.Enabled = true;
                        player7Button.BackColor = Color.Aqua;
                    }
                    if (player27Button.BackColor != Color.Gray)
                    {
                        player27Button.Enabled = true;
                        player27Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player18Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(18);
            placedCount++;
            player18Button.BackColor = Color.Gray;
            player18Button.Enabled = false;
            shipCheck[18] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 18;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player7Button.BackColor != Color.Gray)
                {
                    player7Button.BackColor = Color.DarkBlue;
                    player7Button.Enabled = false;
                }
                if (player9Button.BackColor != Color.Gray)
                {
                    player9Button.BackColor = Color.DarkBlue;
                    player9Button.Enabled = false;
                }
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.BackColor = Color.DarkBlue;
                    player27Button.Enabled = false;
                }
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.BackColor = Color.DarkBlue;
                    player29Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player8Button.BackColor != Color.Gray)
                {
                    player8Button.Enabled = true;
                    player8Button.BackColor = Color.Aqua;
                }
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.Enabled = true;
                    player17Button.BackColor = Color.Aqua;
                }
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.Enabled = true;
                    player19Button.BackColor = Color.Aqua;
                }
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.Enabled = true;
                    player28Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 18;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player17Button.BackColor != Color.Gray)
                    {
                        player17Button.Enabled = true;
                        player17Button.BackColor = Color.Aqua;
                    }
                    if (player19Button.BackColor != Color.Gray)
                    {
                        player19Button.Enabled = true;
                        player19Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player8Button.BackColor != Color.Gray)
                    {
                        player8Button.Enabled = true;
                        player8Button.BackColor = Color.Aqua;
                    }
                    if (player28Button.BackColor != Color.Gray)
                    {
                        player28Button.Enabled = true;
                        player28Button.BackColor = Color.Aqua;
                    }

                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player19Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(19);
            placedCount++;
            player19Button.BackColor = Color.Gray;
            player19Button.Enabled = false;
            shipCheck[19] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 19;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player8Button.BackColor != Color.Gray)
                {
                    player8Button.BackColor = Color.DarkBlue;
                    player8Button.Enabled = false;
                }
                if (player10Button.BackColor != Color.Gray)
                {
                    player10Button.BackColor = Color.DarkBlue;
                    player10Button.Enabled = false;
                }
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.BackColor = Color.DarkBlue;
                    player28Button.Enabled = false;
                }
                if (player30Button.BackColor != Color.Gray)
                {
                    player30Button.BackColor = Color.DarkBlue;
                    player30Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player9Button.BackColor != Color.Gray)
                {
                    player9Button.Enabled = true;
                    player9Button.BackColor = Color.Aqua;
                }
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.Enabled = true;
                    player18Button.BackColor = Color.Aqua;
                }
                if (player20Button.BackColor != Color.Gray)
                {
                    player20Button.Enabled = true;
                    player20Button.BackColor = Color.Aqua;
                }
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.Enabled = true;
                    player29Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 19;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player18Button.BackColor != Color.Gray)
                    {
                        player18Button.Enabled = true;
                        player18Button.BackColor = Color.Aqua;
                    }
                    if (player20Button.BackColor != Color.Gray)
                    {
                        player20Button.Enabled = true;
                        player20Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player9Button.BackColor != Color.Gray)
                    {
                        player9Button.Enabled = true;
                        player9Button.BackColor = Color.Aqua;
                    }
                    if (player29Button.BackColor != Color.Gray)
                    {
                        player29Button.Enabled = true;
                        player29Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player20Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(20);
            placedCount++;
            player20Button.BackColor = Color.Gray;
            player20Button.Enabled = false;
            shipCheck[20] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 20;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player9Button.BackColor != Color.Gray)
                {
                    player9Button.BackColor = Color.DarkBlue;
                    player9Button.Enabled = false;
                }
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.BackColor = Color.DarkBlue;
                    player29Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player10Button.BackColor != Color.Gray)
                {
                    player10Button.Enabled = true;
                    player10Button.BackColor = Color.Aqua;
                }
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.Enabled = true;
                    player19Button.BackColor = Color.Aqua;
                }
                if (player30Button.BackColor != Color.Gray)
                {
                    player30Button.Enabled = true;
                    player30Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 20;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player10Button.BackColor != Color.Gray)
                    {
                        player10Button.Enabled = true;
                        player10Button.BackColor = Color.Aqua;
                    }
                    if (player30Button.BackColor != Color.Gray)
                    {
                        player30Button.Enabled = true;
                        player30Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player21Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(21);
            placedCount++;
            player21Button.BackColor = Color.Gray;
            player21Button.Enabled = false;
            shipCheck[21] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 21;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.BackColor = Color.DarkBlue;
                    player12Button.Enabled = false;
                }
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.BackColor = Color.DarkBlue;
                    player32Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player11Button.BackColor != Color.Gray)
                {
                    player11Button.Enabled = true;
                    player11Button.BackColor = Color.Aqua;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.Enabled = true;
                    player22Button.BackColor = Color.Aqua;
                }
                if (player31Button.BackColor != Color.Gray)
                {
                    player31Button.Enabled = true;
                    player31Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 21;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player11Button.BackColor != Color.Gray)
                    {
                        player11Button.Enabled = true;
                        player11Button.BackColor = Color.Aqua;
                    }
                    if (player31Button.BackColor != Color.Gray)
                    {
                        player31Button.Enabled = true;
                        player31Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player22Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(22);
            placedCount++;
            player22Button.BackColor = Color.Gray;
            player22Button.Enabled = false;
            shipCheck[22] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 22;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player11Button.BackColor != Color.Gray)
                {
                    player11Button.BackColor = Color.DarkBlue;
                    player11Button.Enabled = false;
                }
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.BackColor = Color.DarkBlue;
                    player13Button.Enabled = false;
                }
                if (player31Button.BackColor != Color.Gray)
                {
                    player31Button.BackColor = Color.DarkBlue;
                    player31Button.Enabled = false;
                }
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.BackColor = Color.DarkBlue;
                    player33Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.Enabled = true;
                    player12Button.BackColor = Color.Aqua;
                }
                if (player21Button.BackColor != Color.Gray)
                {
                    player21Button.Enabled = true;
                    player21Button.BackColor = Color.Aqua;
                }
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.Enabled = true;
                    player23Button.BackColor = Color.Aqua;
                }
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.Enabled = true;
                    player32Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 22;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player21Button.BackColor != Color.Gray)
                    {
                        player21Button.Enabled = true;
                        player21Button.BackColor = Color.Aqua;
                    }
                    if (player23Button.BackColor != Color.Gray)
                    {
                        player23Button.Enabled = true;
                        player23Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player12Button.BackColor != Color.Gray)
                    {
                        player12Button.Enabled = true;
                        player12Button.BackColor = Color.Aqua;
                    }
                    if (player32Button.BackColor != Color.Gray)
                    {
                        player32Button.Enabled = true;
                        player32Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player23Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(23);
            placedCount++;
            player23Button.BackColor = Color.Gray;
            player23Button.Enabled = false;
            shipCheck[23] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 23;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player12Button.BackColor != Color.Gray)
                {
                    player12Button.BackColor = Color.DarkBlue;
                    player12Button.Enabled = false;
                }
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.BackColor = Color.DarkBlue;
                    player14Button.Enabled = false;
                }
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.BackColor = Color.DarkBlue;
                    player32Button.Enabled = false;
                }
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.BackColor = Color.DarkBlue;
                    player34Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.Enabled = true;
                    player13Button.BackColor = Color.Aqua;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.Enabled = true;
                    player22Button.BackColor = Color.Aqua;
                }
                if (player24Button.BackColor != Color.Gray)
                {
                    player24Button.Enabled = true;
                    player24Button.BackColor = Color.Aqua;
                }
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.Enabled = true;
                    player33Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 23;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player22Button.BackColor != Color.Gray)
                    {
                        player22Button.Enabled = true;
                        player22Button.BackColor = Color.Aqua;
                    }
                    if (player24Button.BackColor != Color.Gray)
                    {
                        player24Button.Enabled = true;
                        player24Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player13Button.BackColor != Color.Gray)
                    {
                        player13Button.Enabled = true;
                        player13Button.BackColor = Color.Aqua;
                    }
                    if (player33Button.BackColor != Color.Gray)
                    {
                        player33Button.Enabled = true;
                        player33Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player24Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(24);
            placedCount++;
            player24Button.BackColor = Color.Gray;
            player24Button.Enabled = false;
            shipCheck[24] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 24;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player13Button.BackColor != Color.Gray)
                {
                    player13Button.BackColor = Color.DarkBlue;
                    player13Button.Enabled = false;
                }
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.BackColor = Color.DarkBlue;
                    player15Button.Enabled = false;
                }
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.BackColor = Color.DarkBlue;
                    player33Button.Enabled = false;
                }
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.BackColor = Color.DarkBlue;
                    player35Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.Enabled = true;
                    player14Button.BackColor = Color.Aqua;
                }
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.Enabled = true;
                    player23Button.BackColor = Color.Aqua;
                }
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.Enabled = true;
                    player25Button.BackColor = Color.Aqua;
                }
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.Enabled = true;
                    player34Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 24;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player23Button.BackColor != Color.Gray)
                    {
                        player23Button.Enabled = true;
                        player23Button.BackColor = Color.Aqua;
                    }
                    if (player25Button.BackColor != Color.Gray)
                    {
                        player25Button.Enabled = true;
                        player25Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player14Button.BackColor != Color.Gray)
                    {
                        player14Button.Enabled = true;
                        player14Button.BackColor = Color.Aqua;
                    }
                    if (player34Button.BackColor != Color.Gray)
                    {
                        player34Button.Enabled = true;
                        player34Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player25Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(25);
            placedCount++;
            player25Button.BackColor = Color.Gray;
            player25Button.Enabled = false;
            shipCheck[25] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 25;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player14Button.BackColor != Color.Gray)
                {
                    player14Button.BackColor = Color.DarkBlue;
                    player14Button.Enabled = false;
                }
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.BackColor = Color.DarkBlue;
                    player16Button.Enabled = false;
                }
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.BackColor = Color.DarkBlue;
                    player34Button.Enabled = false;
                }
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.BackColor = Color.DarkBlue;
                    player36Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.Enabled = true;
                    player15Button.BackColor = Color.Aqua;
                }
                if (player24Button.BackColor != Color.Gray)
                {
                    player24Button.Enabled = true;
                    player24Button.BackColor = Color.Aqua;
                }
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.Enabled = true;
                    player26Button.BackColor = Color.Aqua;
                }
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.Enabled = true;
                    player35Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 25;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player24Button.BackColor != Color.Gray)
                    {
                        player24Button.Enabled = true;
                        player24Button.BackColor = Color.Aqua;
                    }
                    if (player26Button.BackColor != Color.Gray)
                    {
                        player26Button.Enabled = true;
                        player26Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player15Button.BackColor != Color.Gray)
                    {
                        player15Button.Enabled = true;
                        player15Button.BackColor = Color.Aqua;
                    }
                    if (player35Button.BackColor != Color.Gray)
                    {
                        player35Button.Enabled = true;
                        player35Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;          

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player26Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(26);
            placedCount++;
            player26Button.BackColor = Color.Gray;
            player26Button.Enabled = false;
            shipCheck[26] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 26;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player15Button.BackColor != Color.Gray)
                {
                    player15Button.BackColor = Color.DarkBlue;
                    player15Button.Enabled = false;
                }
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.BackColor = Color.DarkBlue;
                    player17Button.Enabled = false;
                }
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.BackColor = Color.DarkBlue;
                    player35Button.Enabled = false;
                }
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.BackColor = Color.DarkBlue;
                    player37Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.Enabled = true;
                    player16Button.BackColor = Color.Aqua;
                }
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.Enabled = true;
                    player25Button.BackColor = Color.Aqua;
                }
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.Enabled = true;
                    player27Button.BackColor = Color.Aqua;
                }
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.Enabled = true;
                    player36Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 26;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player25Button.BackColor != Color.Gray)
                    {
                        player25Button.Enabled = true;
                        player25Button.BackColor = Color.Aqua;
                    }
                    if (player27Button.BackColor != Color.Gray)
                    {
                        player27Button.Enabled = true;
                        player27Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player16Button.BackColor != Color.Gray)
                    {
                        player16Button.Enabled = true;
                        player16Button.BackColor = Color.Aqua;
                    }
                    if (player36Button.BackColor != Color.Gray)
                    {
                        player36Button.Enabled = true;
                        player36Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player27Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(27);
            placedCount++;
            player27Button.BackColor = Color.Gray;
            player27Button.Enabled = false;
            shipCheck[27] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 27;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player16Button.BackColor != Color.Gray)
                {
                    player16Button.BackColor = Color.DarkBlue;
                    player16Button.Enabled = false;
                }
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.BackColor = Color.DarkBlue;
                    player18Button.Enabled = false;
                }
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.BackColor = Color.DarkBlue;
                    player36Button.Enabled = false;
                }
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.BackColor = Color.DarkBlue;
                    player38Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.Enabled = true;
                    player17Button.BackColor = Color.Aqua;
                }
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.Enabled = true;
                    player26Button.BackColor = Color.Aqua;
                }
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.Enabled = true;
                    player28Button.BackColor = Color.Aqua;
                }
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.Enabled = true;
                    player37Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 27;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player26Button.BackColor != Color.Gray)
                    {
                        player26Button.Enabled = true;
                        player26Button.BackColor = Color.Aqua;
                    }
                    if (player28Button.BackColor != Color.Gray)
                    {
                        player28Button.Enabled = true;
                        player28Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player17Button.BackColor != Color.Gray)
                    {
                        player17Button.Enabled = true;
                        player17Button.BackColor = Color.Aqua;
                    }
                    if (player37Button.BackColor != Color.Gray)
                    {
                        player37Button.Enabled = true;
                        player37Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player28Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(28);
            placedCount++;
            player28Button.BackColor = Color.Gray;
            player28Button.Enabled = false;
            shipCheck[28] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 28;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player17Button.BackColor != Color.Gray)
                {
                    player17Button.BackColor = Color.DarkBlue;
                    player17Button.Enabled = false;
                }
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.BackColor = Color.DarkBlue;
                    player19Button.Enabled = false;
                }
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.BackColor = Color.DarkBlue;
                    player37Button.Enabled = false;
                }
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.BackColor = Color.DarkBlue;
                    player39Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.Enabled = true;
                    player18Button.BackColor = Color.Aqua;
                }
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.Enabled = true;
                    player27Button.BackColor = Color.Aqua;
                }
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.Enabled = true;
                    player29Button.BackColor = Color.Aqua;
                }
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.Enabled = true;
                    player38Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 28;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player27Button.BackColor != Color.Gray)
                    {
                        player27Button.Enabled = true;
                        player27Button.BackColor = Color.Aqua;
                    }
                    if (player29Button.BackColor != Color.Gray)
                    {
                        player29Button.Enabled = true;
                        player29Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    {
                        player18Button.Enabled = true;
                        player18Button.BackColor = Color.Aqua;
                    }
                    if (player38Button.BackColor != Color.Gray)
                    {
                        player38Button.Enabled = true;
                        player38Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player29Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(29);
            placedCount++;
            player29Button.BackColor = Color.Gray;
            player29Button.Enabled = false;
            shipCheck[29] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 29;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player18Button.BackColor != Color.Gray)
                {
                    player18Button.BackColor = Color.DarkBlue;
                    player18Button.Enabled = false;
                }
                if (player20Button.BackColor != Color.Gray)
                {
                    player20Button.BackColor = Color.DarkBlue;
                    player20Button.Enabled = false;
                }
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.BackColor = Color.DarkBlue;
                    player38Button.Enabled = false;
                }
                if (player40Button.BackColor != Color.Gray)
                {
                    player40Button.BackColor = Color.DarkBlue;
                    player40Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.Enabled = true;
                    player19Button.BackColor = Color.Aqua;
                }
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.Enabled = true;
                    player28Button.BackColor = Color.Aqua;
                }
                if (player30Button.BackColor != Color.Gray)
                {
                    player30Button.Enabled = true;
                    player30Button.BackColor = Color.Aqua;
                }
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.Enabled = true;
                    player39Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 29;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player28Button.BackColor != Color.Gray)
                    {
                        player28Button.Enabled = true;
                        player28Button.BackColor = Color.Aqua;
                    }
                    if (player30Button.BackColor != Color.Gray)
                    {
                        player30Button.Enabled = true;
                        player30Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player19Button.BackColor != Color.Gray)
                    {
                        player19Button.Enabled = true;
                        player19Button.BackColor = Color.Aqua;
                    }
                    if (player39Button.BackColor != Color.Gray)
                    {
                        player39Button.Enabled = true;
                        player39Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player30Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(30);
            placedCount++;
            player30Button.BackColor = Color.Gray;
            player30Button.Enabled = false;
            shipCheck[30] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 30;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player19Button.BackColor != Color.Gray)
                {
                    player19Button.BackColor = Color.DarkBlue;
                    player19Button.Enabled = false;
                }
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.BackColor = Color.DarkBlue;
                    player39Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player20Button.BackColor != Color.Gray)
                {
                    player20Button.Enabled = true;
                    player20Button.BackColor = Color.Aqua;
                }
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.Enabled = true;
                    player29Button.BackColor = Color.Aqua;
                }
                if (player40Button.BackColor != Color.Gray)
                {
                    player40Button.Enabled = true;
                    player40Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 30;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player20Button.BackColor != Color.Gray)
                    {
                        player20Button.Enabled = true;
                        player20Button.BackColor = Color.Aqua;
                    }
                    if (player40Button.BackColor != Color.Gray)
                    {
                        player40Button.Enabled = true;
                        player40Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player31Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(31);
            placedCount++;
            player31Button.BackColor = Color.Gray;
            player31Button.Enabled = false;
            shipCheck[31] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 31;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.BackColor = Color.DarkBlue;
                    player22Button.Enabled = false;
                }
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.BackColor = Color.DarkBlue;
                    player42Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player21Button.BackColor != Color.Gray)
                {
                    player21Button.Enabled = true;
                    player21Button.BackColor = Color.Aqua;
                }
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.Enabled = true;
                    player32Button.BackColor = Color.Aqua;
                }
                if (player41Button.BackColor != Color.Gray)
                {
                    player41Button.Enabled = true;
                    player41Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 31;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player21Button.BackColor != Color.Gray)
                    {
                        player21Button.Enabled = true;
                        player21Button.BackColor = Color.Aqua;
                    }
                    if (player41Button.BackColor != Color.Gray)
                    {
                        player41Button.Enabled = true;
                        player41Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player32Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(32);
            placedCount++;
            player32Button.BackColor = Color.Gray;
            player32Button.Enabled = false;
            shipCheck[32] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 32;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player21Button.BackColor != Color.Gray)
                {
                    player21Button.BackColor = Color.DarkBlue;
                    player21Button.Enabled = false;
                }
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.BackColor = Color.DarkBlue;
                    player23Button.Enabled = false;
                }
                if (player41Button.BackColor != Color.Gray)
                {
                    player41Button.BackColor = Color.DarkBlue;
                    player41Button.Enabled = false;
                }
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.BackColor = Color.DarkBlue;
                    player43Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.Enabled = true;
                    player22Button.BackColor = Color.Aqua;
                }
                if (player31Button.BackColor != Color.Gray)
                {
                    player31Button.Enabled = true;
                    player31Button.BackColor = Color.Aqua;
                }
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.Enabled = true;
                    player33Button.BackColor = Color.Aqua;
                }
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.Enabled = true;
                    player42Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 32;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player31Button.BackColor != Color.Gray)
                    {
                        player31Button.Enabled = true;
                        player31Button.BackColor = Color.Aqua;
                    }
                    if (player33Button.BackColor != Color.Gray)
                    {
                        player33Button.Enabled = true;
                        player33Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player22Button.BackColor != Color.Gray)
                    {
                        player22Button.Enabled = true;
                        player22Button.BackColor = Color.Aqua;
                    }
                    if (player42Button.BackColor != Color.Gray)
                    {
                        player42Button.Enabled = true;
                        player42Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player33Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(33);
            placedCount++;
            player33Button.BackColor = Color.Gray;
            player33Button.Enabled = false;
            shipCheck[33] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 33;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player22Button.BackColor != Color.Gray)
                {
                    player22Button.BackColor = Color.DarkBlue;
                    player22Button.Enabled = false;
                }
                if (player24Button.BackColor != Color.Gray)
                {
                    player24Button.BackColor = Color.DarkBlue;
                    player24Button.Enabled = false;
                }
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.BackColor = Color.DarkBlue;
                    player42Button.Enabled = false;
                }
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.BackColor = Color.DarkBlue;
                    player44Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.Enabled = true;
                    player23Button.BackColor = Color.Aqua;
                }
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.Enabled = true;
                    player32Button.BackColor = Color.Aqua;
                }
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.Enabled = true;
                    player34Button.BackColor = Color.Aqua;
                }
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.Enabled = true;
                    player43Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 33;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player32Button.BackColor != Color.Gray)
                    {
                        player32Button.Enabled = true;
                        player32Button.BackColor = Color.Aqua;
                    }
                    if (player34Button.BackColor != Color.Gray)
                    {
                        player34Button.Enabled = true;
                        player34Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player23Button.BackColor != Color.Gray)
                    {
                        player23Button.Enabled = true;
                        player23Button.BackColor = Color.Aqua;
                    }
                    if (player43Button.BackColor != Color.Gray)
                    {
                        player43Button.Enabled = true;
                        player43Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player34Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(34);
            placedCount++;
            player34Button.BackColor = Color.Gray;
            player34Button.Enabled = false;
            shipCheck[34] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 34;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player23Button.BackColor != Color.Gray)
                {
                    player23Button.BackColor = Color.DarkBlue;
                    player23Button.Enabled = false;
                }
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.BackColor = Color.DarkBlue;
                    player25Button.Enabled = false;
                }
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.BackColor = Color.DarkBlue;
                    player43Button.Enabled = false;
                }
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.BackColor = Color.DarkBlue;
                    player45Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player24Button.BackColor != Color.Gray)
                {
                    player24Button.Enabled = true;
                    player24Button.BackColor = Color.Aqua;
                }
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.Enabled = true;
                    player33Button.BackColor = Color.Aqua;
                }
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.Enabled = true;
                    player35Button.BackColor = Color.Aqua;
                }
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.Enabled = true;
                    player44Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 34;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player33Button.BackColor != Color.Gray)
                    {
                        player33Button.Enabled = true;
                        player33Button.BackColor = Color.Aqua;
                    }
                    if (player35Button.BackColor != Color.Gray)
                    {
                        player35Button.Enabled = true;
                        player35Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player24Button.BackColor != Color.Gray)
                    {
                        player24Button.Enabled = true;
                        player24Button.BackColor = Color.Aqua;
                    }
                    if (player44Button.BackColor != Color.Gray)
                    {
                        player44Button.Enabled = true;
                        player44Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player35Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(35);
            placedCount++;
            player35Button.BackColor = Color.Gray;
            player35Button.Enabled = false;
            shipCheck[35] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 35;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player24Button.BackColor != Color.Gray)
                {
                    player24Button.BackColor = Color.DarkBlue;
                    player24Button.Enabled = false;
                }
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.BackColor = Color.DarkBlue;
                    player26Button.Enabled = false;
                }
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.BackColor = Color.DarkBlue;
                    player44Button.Enabled = false;
                }
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.BackColor = Color.DarkBlue;
                    player46Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.Enabled = true;
                    player25Button.BackColor = Color.Aqua;
                }
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.Enabled = true;
                    player34Button.BackColor = Color.Aqua;
                }
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.Enabled = true;
                    player36Button.BackColor = Color.Aqua;
                }
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.Enabled = true;
                    player45Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 35;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player34Button.BackColor != Color.Gray)
                    {
                        player34Button.Enabled = true;
                        player34Button.BackColor = Color.Aqua;
                    }
                    if (player36Button.BackColor != Color.Gray)
                    {
                        player36Button.Enabled = true;
                        player36Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player25Button.BackColor != Color.Gray)
                    {
                        player25Button.Enabled = true;
                        player25Button.BackColor = Color.Aqua;
                    }
                    if (player45Button.BackColor != Color.Gray)
                    {
                        player45Button.Enabled = true;
                        player45Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player36Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(36);
            placedCount++;
            player36Button.BackColor = Color.Gray;
            player36Button.Enabled = false;
            shipCheck[36] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 36;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player25Button.BackColor != Color.Gray)
                {
                    player25Button.BackColor = Color.DarkBlue;
                    player25Button.Enabled = false;
                }
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.BackColor = Color.DarkBlue;
                    player27Button.Enabled = false;
                }
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.BackColor = Color.DarkBlue;
                    player45Button.Enabled = false;
                }
                if (player47Button.BackColor != Color.Gray)
                {
                    player47Button.BackColor = Color.DarkBlue;
                    player47Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.Enabled = true;
                    player26Button.BackColor = Color.Aqua;
                }
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.Enabled = true;
                    player35Button.BackColor = Color.Aqua;
                }
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.Enabled = true;
                    player37Button.BackColor = Color.Aqua;
                }
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.Enabled = true;
                    player46Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 36;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player35Button.BackColor != Color.Gray)
                    {
                        player35Button.Enabled = true;
                        player35Button.BackColor = Color.Aqua;
                    }
                    if (player37Button.BackColor != Color.Gray)
                    {
                        player37Button.Enabled = true;
                        player37Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player26Button.BackColor != Color.Gray)
                    {
                        player26Button.Enabled = true;
                        player26Button.BackColor = Color.Aqua;
                    }
                    if (player46Button.BackColor != Color.Gray)
                    {
                        player46Button.Enabled = true;
                        player46Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player37Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(37);
            placedCount++;
            player37Button.BackColor = Color.Gray;
            player37Button.Enabled = false;
            shipCheck[37] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 37;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player26Button.BackColor != Color.Gray)
                {
                    player26Button.BackColor = Color.DarkBlue;
                    player26Button.Enabled = false;
                }
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.BackColor = Color.DarkBlue;
                    player28Button.Enabled = false;
                }
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.BackColor = Color.DarkBlue;
                    player46Button.Enabled = false;
                }
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.BackColor = Color.DarkBlue;
                    player48Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.Enabled = true;
                    player27Button.BackColor = Color.Aqua;
                }
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.Enabled = true;
                    player36Button.BackColor = Color.Aqua;
                }
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.Enabled = true;
                    player38Button.BackColor = Color.Aqua;
                }
                if (player47Button.BackColor != Color.Gray)
                {
                    player47Button.Enabled = true;
                    player47Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 37;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player36Button.BackColor != Color.Gray)
                    {
                        player36Button.Enabled = true;
                        player36Button.BackColor = Color.Aqua;
                    }
                    if (player38Button.BackColor != Color.Gray)
                    {
                        player38Button.Enabled = true;
                        player38Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player27Button.BackColor != Color.Gray)
                    {
                        player27Button.Enabled = true;
                        player27Button.BackColor = Color.Aqua;
                    }
                    if (player47Button.BackColor != Color.Gray)
                    {
                        player47Button.Enabled = true;
                        player47Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player38Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(38);
            placedCount++;
            player38Button.BackColor = Color.Gray;
            player38Button.Enabled = false;
            shipCheck[38] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 38;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player27Button.BackColor != Color.Gray)
                {
                    player27Button.BackColor = Color.DarkBlue;
                    player27Button.Enabled = false;
                }
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.BackColor = Color.DarkBlue;
                    player29Button.Enabled = false;
                }
                if (player47Button.BackColor != Color.Gray)
                {
                    player47Button.BackColor = Color.DarkBlue;
                    player47Button.Enabled = false;
                }
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.BackColor = Color.DarkBlue;
                    player49Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.Enabled = true;
                    player28Button.BackColor = Color.Aqua;
                }
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.Enabled = true;
                    player37Button.BackColor = Color.Aqua;
                }
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.Enabled = true;
                    player39Button.BackColor = Color.Aqua;
                }
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.Enabled = true;
                    player48Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 38;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player37Button.BackColor != Color.Gray)
                    {
                        player37Button.Enabled = true;
                        player37Button.BackColor = Color.Aqua;
                    }
                    if (player39Button.BackColor != Color.Gray)
                    {
                        player39Button.Enabled = true;
                        player39Button.BackColor = Color.Aqua;

                    }
                }
                if (vertical == true)
                {
                    if (player28Button.BackColor != Color.Gray)
                    {
                            player28Button.Enabled = true;
                            player28Button.BackColor = Color.Aqua;
                    }
                    if (player48Button.BackColor != Color.Gray)
                    {
                            player48Button.Enabled = true;
                            player48Button.BackColor = Color.Aqua;
                    }      
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player39Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(39);
            placedCount++;
            player39Button.BackColor = Color.Gray;
            player39Button.Enabled = false;
            shipCheck[39] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 39;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player28Button.BackColor != Color.Gray)
                {
                    player28Button.BackColor = Color.DarkBlue;
                    player28Button.Enabled = false;
                }
                if (player30Button.BackColor != Color.Gray)
                {
                    player30Button.BackColor = Color.DarkBlue;
                    player30Button.Enabled = false;
                }
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.BackColor = Color.DarkBlue;
                    player48Button.Enabled = false;
                }
                if (player50Button.BackColor != Color.Gray)
                {
                    player50Button.BackColor = Color.DarkBlue;
                    player50Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.Enabled = true;
                    player29Button.BackColor = Color.Aqua;
                }
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.Enabled = true;
                    player38Button.BackColor = Color.Aqua;
                }
                if (player40Button.BackColor != Color.Gray)
                {
                    player40Button.Enabled = true;
                    player40Button.BackColor = Color.Aqua;
                }
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.Enabled = true;
                    player49Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 39;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player38Button.BackColor != Color.Gray)
                    {
                        player38Button.Enabled = true;
                        player38Button.BackColor = Color.Aqua;
                    }
                    if (player40Button.BackColor != Color.Gray)
                    {
                        player40Button.Enabled = true;
                        player40Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player29Button.BackColor != Color.Gray)
                    {
                        player29Button.Enabled = true;
                        player29Button.BackColor = Color.Aqua;
                    }
                    if (player49Button.BackColor != Color.Gray)
                    {
                        player49Button.Enabled = true;
                        player49Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player40Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(40);
            placedCount++;
            player40Button.BackColor = Color.Gray;
            player40Button.Enabled = false;
            shipCheck[40] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 40;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player29Button.BackColor != Color.Gray)
                {
                    player29Button.BackColor = Color.DarkBlue;
                    player29Button.Enabled = false;
                }
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.BackColor = Color.DarkBlue;
                    player49Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player30Button.BackColor != Color.Gray)
                {
                    player30Button.Enabled = true;
                    player30Button.BackColor = Color.Aqua;
                }
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.Enabled = true;
                    player39Button.BackColor = Color.Aqua;
                }
                if (player50Button.BackColor != Color.Gray)
                {
                    player50Button.Enabled = true;
                    player50Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 40;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player30Button.BackColor != Color.Gray)
                    {
                        player30Button.Enabled = true;
                        player30Button.BackColor = Color.Aqua;
                    }
                    if (player50Button.BackColor != Color.Gray)
                    {
                        player50Button.Enabled = true;
                        player50Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player41Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(41);
            placedCount++;
            player41Button.BackColor = Color.Gray;
            player41Button.Enabled = false;
            shipCheck[41] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 41;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.BackColor = Color.DarkBlue;
                    player32Button.Enabled = false;
                }
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.BackColor = Color.DarkBlue;
                    player52Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player31Button.BackColor != Color.Gray)
                {
                    player31Button.Enabled = true;
                    player31Button.BackColor = Color.Aqua;
                }
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.Enabled = true;
                    player42Button.BackColor = Color.Aqua;
                }
                if (player51Button.BackColor != Color.Gray)
                {
                    player51Button.Enabled = true;
                    player51Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 41;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player31Button.BackColor != Color.Gray)
                    {
                        player31Button.Enabled = true;
                        player31Button.BackColor = Color.Aqua;
                    }
                    if (player51Button.BackColor != Color.Gray)
                    {
                        player51Button.Enabled = true;
                        player51Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player42Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(42);
            placedCount++;
            player42Button.BackColor = Color.Gray;
            player42Button.Enabled = false;
            shipCheck[42] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 42;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player31Button.BackColor != Color.Gray)
                {
                    player31Button.BackColor = Color.DarkBlue;
                    player31Button.Enabled = false;
                }
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.BackColor = Color.DarkBlue;
                    player33Button.Enabled = false;
                }
                if (player51Button.BackColor != Color.Gray)
                {
                    player51Button.BackColor = Color.DarkBlue;
                    player51Button.Enabled = false;
                }
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.BackColor = Color.DarkBlue;
                    player53Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.Enabled = true;
                    player32Button.BackColor = Color.Aqua;
                }
                if (player41Button.BackColor != Color.Gray)
                {
                    player41Button.Enabled = true;
                    player41Button.BackColor = Color.Aqua;
                }
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.Enabled = true;
                    player43Button.BackColor = Color.Aqua;
                }
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.Enabled = true;
                    player52Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 42;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player41Button.BackColor != Color.Gray)
                    {
                        player41Button.Enabled = true;
                        player41Button.BackColor = Color.Aqua;
                    }
                    if (player43Button.BackColor != Color.Gray)
                    {
                        player43Button.Enabled = true;
                        player43Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player32Button.BackColor != Color.Gray)
                    {
                        player32Button.Enabled = true;
                        player32Button.BackColor = Color.Aqua;
                    }
                    if (player52Button.BackColor != Color.Gray)
                    {
                        player52Button.Enabled = true;
                        player52Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player43Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(43);
            placedCount++;
            player43Button.BackColor = Color.Gray;
            player43Button.Enabled = false;
            shipCheck[43] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 43;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player32Button.BackColor != Color.Gray)
                {
                    player32Button.BackColor = Color.DarkBlue;
                    player32Button.Enabled = false;
                }
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.BackColor = Color.DarkBlue;
                    player34Button.Enabled = false;
                }
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.BackColor = Color.DarkBlue;
                    player52Button.Enabled = false;
                }
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.BackColor = Color.DarkBlue;
                    player54Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.Enabled = true;
                    player33Button.BackColor = Color.Aqua;
                }
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.Enabled = true;
                    player42Button.BackColor = Color.Aqua;
                }
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.Enabled = true;
                    player44Button.BackColor = Color.Aqua;
                }
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.Enabled = true;
                    player53Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 43;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player42Button.BackColor != Color.Gray)
                    {
                        player42Button.Enabled = true;
                        player42Button.BackColor = Color.Aqua;
                    }
                    if (player44Button.BackColor != Color.Gray)
                    {
                        player44Button.Enabled = true;
                        player44Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player33Button.BackColor != Color.Gray)
                    {
                        player33Button.Enabled = true;
                        player33Button.BackColor = Color.Aqua;
                    }
                    if (player53Button.BackColor != Color.Gray)
                    {
                        player53Button.Enabled = true;
                        player53Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player44Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(44);
            placedCount++;
            player44Button.BackColor = Color.Gray;
            player44Button.Enabled = false;
            shipCheck[44] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 44;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player33Button.BackColor != Color.Gray)
                {
                    player33Button.BackColor = Color.DarkBlue;
                    player33Button.Enabled = false;
                }
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.BackColor = Color.DarkBlue;
                    player35Button.Enabled = false;
                }
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.BackColor = Color.DarkBlue;
                    player53Button.Enabled = false;
                }
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.BackColor = Color.DarkBlue;
                    player55Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.Enabled = true;
                    player34Button.BackColor = Color.Aqua;
                }
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.Enabled = true;
                    player43Button.BackColor = Color.Aqua;
                }
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.Enabled = true;
                    player45Button.BackColor = Color.Aqua;
                }
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.Enabled = true;
                    player54Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 44;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player43Button.BackColor != Color.Gray)
                    {
                        player43Button.Enabled = true;
                        player43Button.BackColor = Color.Aqua;
                    }
                    if (player45Button.BackColor != Color.Gray)
                    {
                        player45Button.Enabled = true;
                        player45Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player34Button.BackColor != Color.Gray)
                    {
                        player34Button.Enabled = true;
                        player34Button.BackColor = Color.Aqua;
                    }
                    if (player54Button.BackColor != Color.Gray)
                    {
                        player54Button.Enabled = true;
                        player54Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player45Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(45);
            placedCount++;
            player45Button.BackColor = Color.Gray;
            player45Button.Enabled = false;
            shipCheck[45] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 45;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player34Button.BackColor != Color.Gray)
                {
                    player34Button.BackColor = Color.DarkBlue;
                    player34Button.Enabled = false;
                }
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.BackColor = Color.DarkBlue;
                    player36Button.Enabled = false;
                }
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.BackColor = Color.DarkBlue;
                    player54Button.Enabled = false;
                }
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.BackColor = Color.DarkBlue;
                    player56Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.Enabled = true;
                    player35Button.BackColor = Color.Aqua;
                }
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.Enabled = true;
                    player44Button.BackColor = Color.Aqua;
                }
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.Enabled = true;
                    player46Button.BackColor = Color.Aqua;
                }
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.Enabled = true;
                    player55Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 45;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player44Button.BackColor != Color.Gray)
                    {
                        player44Button.Enabled = true;
                        player44Button.BackColor = Color.Aqua;
                    }
                    if (player46Button.BackColor != Color.Gray)
                    {
                        player46Button.Enabled = true;
                        player46Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player35Button.BackColor != Color.Gray)
                    {
                        player35Button.Enabled = true;
                        player35Button.BackColor = Color.Aqua;
                    }
                    if (player55Button.BackColor != Color.Gray)
                    {
                        player55Button.Enabled = true;
                        player55Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player46Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(46);
            placedCount++;
            player46Button.BackColor = Color.Gray;
            player46Button.Enabled = false;
            shipCheck[46] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 46;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player35Button.BackColor != Color.Gray)
                {
                    player35Button.BackColor = Color.DarkBlue;
                    player35Button.Enabled = false;
                }
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.BackColor = Color.DarkBlue;
                    player37Button.Enabled = false;
                }
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.BackColor = Color.DarkBlue;
                    player55Button.Enabled = false;
                }
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.BackColor = Color.DarkBlue;
                    player57Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.Enabled = true;
                    player36Button.BackColor = Color.Aqua;
                }
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.Enabled = true;
                    player45Button.BackColor = Color.Aqua;
                }
                if (player47Button.BackColor != Color.Gray)
                { 
                    player47Button.Enabled = true;
                    player47Button.BackColor = Color.Aqua;
                }
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.Enabled = true;
                    player56Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 46;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player45Button.BackColor != Color.Gray)
                    {
                        player45Button.Enabled = true;
                        player45Button.BackColor = Color.Aqua;
                    }
                    if (player47Button.BackColor != Color.Gray)
                    {
                        player47Button.Enabled = true;
                        player47Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player36Button.BackColor != Color.Gray)
                    {
                        player36Button.Enabled = true;
                        player36Button.BackColor = Color.Aqua;
                    }
                    if (player56Button.BackColor != Color.Gray)
                    {
                        player56Button.Enabled = true;
                        player56Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player47Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(47);
            placedCount++;
            player47Button.BackColor = Color.Gray;
            player47Button.Enabled = false;
            shipCheck[47] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 47;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player36Button.BackColor != Color.Gray)
                {
                    player36Button.BackColor = Color.DarkBlue;
                    player36Button.Enabled = false;
                }
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.BackColor = Color.DarkBlue;
                    player38Button.Enabled = false;
                }
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.BackColor = Color.DarkBlue;
                    player56Button.Enabled = false;
                }
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.BackColor = Color.DarkBlue;
                    player58Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.Enabled = true;
                    player37Button.BackColor = Color.Aqua;
                }
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.Enabled = true;
                    player46Button.BackColor = Color.Aqua;
                }
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.Enabled = true;
                    player48Button.BackColor = Color.Aqua;
                }
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.Enabled = true;
                    player57Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 47;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player46Button.BackColor != Color.Gray)
                    {
                        player46Button.Enabled = true;
                        player46Button.BackColor = Color.Aqua;
                    }
                    if (player48Button.BackColor != Color.Gray)
                    {
                        player48Button.Enabled = true;
                        player48Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player37Button.BackColor != Color.Gray)
                    {
                        player37Button.Enabled = true;
                        player37Button.BackColor = Color.Aqua;
                    }
                    if (player57Button.BackColor != Color.Gray)
                    {
                        player57Button.Enabled = true;
                        player57Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player48Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(48);
            placedCount++;
            player48Button.BackColor = Color.Gray;
            player48Button.Enabled = false;
            shipCheck[48] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 48;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player37Button.BackColor != Color.Gray)
                {
                    player37Button.BackColor = Color.DarkBlue;
                    player37Button.Enabled = false;
                }
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.BackColor = Color.DarkBlue;
                    player39Button.Enabled = false;
                }
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.BackColor = Color.DarkBlue;
                    player57Button.Enabled = false;
                }
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.BackColor = Color.DarkBlue;
                    player59Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.Enabled = true;
                    player38Button.BackColor = Color.Aqua;
                }
                if (player47Button.BackColor != Color.Gray)
                {
                    player47Button.Enabled = true;
                    player47Button.BackColor = Color.Aqua;
                }
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.Enabled = true;
                    player49Button.BackColor = Color.Aqua;
                }
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.Enabled = true;
                    player58Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 48;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player47Button.BackColor != Color.Gray)
                    {
                        player47Button.Enabled = true;
                        player47Button.BackColor = Color.Aqua;
                    }
                    if (player49Button.BackColor != Color.Gray)
                    {
                        player49Button.Enabled = true;
                        player49Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player38Button.BackColor != Color.Gray)
                    {
                        player38Button.Enabled = true;
                        player38Button.BackColor = Color.Aqua;
                    }
                    if (player58Button.BackColor != Color.Gray)
                    {
                        player58Button.Enabled = true;
                        player58Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player49Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(49);
            placedCount++;
            player49Button.BackColor = Color.Gray;
            player49Button.Enabled = false;
            shipCheck[49] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 49;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player38Button.BackColor != Color.Gray)
                {
                    player38Button.BackColor = Color.DarkBlue;
                    player38Button.Enabled = false;
                }
                if (player40Button.BackColor != Color.Gray)
                {
                    player40Button.BackColor = Color.DarkBlue;
                    player40Button.Enabled = false;
                }
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.BackColor = Color.DarkBlue;
                    player58Button.Enabled = false;
                }
                if (player60Button.BackColor != Color.Gray)
                {
                    player60Button.BackColor = Color.DarkBlue;
                    player60Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.Enabled = true;
                    player39Button.BackColor = Color.Aqua;
                }
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.Enabled = true;
                    player48Button.BackColor = Color.Aqua;
                }
                if (player50Button.BackColor != Color.Gray)
                {
                    player50Button.Enabled = true;
                    player50Button.BackColor = Color.Aqua;
                }
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.Enabled = true;
                    player59Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 49;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player48Button.BackColor != Color.Gray)
                    {
                        player48Button.Enabled = true;
                        player48Button.BackColor = Color.Aqua;
                    }
                    if (player50Button.BackColor != Color.Gray)
                    {
                        player50Button.Enabled = true;
                        player50Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player39Button.BackColor != Color.Gray)
                    {
                        player39Button.Enabled = true;
                        player39Button.BackColor = Color.Aqua;
                    }
                    if (player59Button.BackColor != Color.Gray)
                    {
                        player59Button.Enabled = true;
                        player59Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player50Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(50);
            placedCount++;
            player50Button.BackColor = Color.Gray;
            player50Button.Enabled = false;
            shipCheck[50] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 50;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player39Button.BackColor != Color.Gray)
                {
                    player39Button.BackColor = Color.DarkBlue;
                    player39Button.Enabled = false;
                }
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.BackColor = Color.DarkBlue;
                    player59Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player40Button.BackColor != Color.Gray)
                {
                    player40Button.Enabled = true;
                    player40Button.BackColor = Color.Aqua;
                }
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.Enabled = true;
                    player49Button.BackColor = Color.Aqua;
                }
                if (player60Button.BackColor != Color.Gray)
                {
                    player60Button.Enabled = true;
                    player60Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 50;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player40Button.BackColor != Color.Gray)
                    {
                        player40Button.Enabled = true;
                        player40Button.BackColor = Color.Aqua;
                    }
                    if (player60Button.BackColor != Color.Gray)
                    {
                        player60Button.Enabled = true;
                        player60Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player51Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(51);
            placedCount++;
            player51Button.BackColor = Color.Gray;
            player51Button.Enabled = false;
            shipCheck[51] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 51;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.BackColor = Color.DarkBlue;
                    player42Button.Enabled = false;
                }
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.BackColor = Color.DarkBlue;
                    player62Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player41Button.BackColor != Color.Gray)
                {
                    player41Button.Enabled = true;
                    player41Button.BackColor = Color.Aqua;
                }
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.Enabled = true;
                    player52Button.BackColor = Color.Aqua;
                }
                if (player61Button.BackColor != Color.Gray)
                {
                    player61Button.Enabled = true;
                    player61Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 51;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player41Button.BackColor != Color.Gray)
                    {
                        player41Button.Enabled = true;
                        player41Button.BackColor = Color.Aqua;
                    }
                    if (player61Button.BackColor != Color.Gray)
                    {
                        player61Button.Enabled = true;
                        player61Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player52Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(52);
            placedCount++;
            player52Button.BackColor = Color.Gray;
            player52Button.Enabled = false;
            shipCheck[53] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 52;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player41Button.BackColor != Color.Gray)
                {
                    player41Button.BackColor = Color.DarkBlue;
                    player41Button.Enabled = false;
                }
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.BackColor = Color.DarkBlue;
                    player43Button.Enabled = false;
                }
                if (player61Button.BackColor != Color.Gray)
                {
                    player61Button.BackColor = Color.DarkBlue;
                    player61Button.Enabled = false;
                }
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.BackColor = Color.DarkBlue;
                    player63Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.Enabled = true;
                    player42Button.BackColor = Color.Aqua;
                }
                if (player51Button.BackColor != Color.Gray)
                {
                    player51Button.Enabled = true;
                    player51Button.BackColor = Color.Aqua;
                }
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.Enabled = true;
                    player53Button.BackColor = Color.Aqua;
                }
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.Enabled = true;
                    player62Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 52;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player51Button.BackColor != Color.Gray)
                    {
                        player51Button.Enabled = true;
                        player51Button.BackColor = Color.Aqua;
                    }
                    if (player53Button.BackColor != Color.Gray)
                    {
                        player53Button.Enabled = true;
                        player53Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player42Button.BackColor != Color.Gray)
                    {
                        player42Button.Enabled = true;
                        player42Button.BackColor = Color.Aqua;
                    }
                    if (player62Button.BackColor != Color.Gray)
                    {
                        player62Button.Enabled = true;

                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player53Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(53);
            placedCount++;
            player53Button.BackColor = Color.Gray;
            player53Button.Enabled = false;
            shipCheck[53] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 53;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player42Button.BackColor != Color.Gray)
                {
                    player42Button.BackColor = Color.DarkBlue;
                    player42Button.Enabled = false;
                }
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.BackColor = Color.DarkBlue;
                    player44Button.Enabled = false;
                }
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.BackColor = Color.DarkBlue;
                    player62Button.Enabled = false;
                }
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.BackColor = Color.DarkBlue;
                    player64Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.Enabled = true;
                    player43Button.BackColor = Color.Aqua;
                }
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.Enabled = true;
                    player52Button.BackColor = Color.Aqua;
                }
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.Enabled = true;
                    player54Button.BackColor = Color.Aqua;
                }
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.Enabled = true;
                    player63Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 53;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player52Button.BackColor != Color.Gray)
                    {
                        player52Button.Enabled = true;
                        player52Button.BackColor = Color.Aqua;
                    }
                    if (player54Button.BackColor != Color.Gray)
                    {
                        player54Button.Enabled = true;
                        player54Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player43Button.BackColor != Color.Gray)
                    {
                        player43Button.Enabled = true;
                        player43Button.BackColor = Color.Aqua;
                    }
                    if (player63Button.BackColor != Color.Gray)
                    {
                        player63Button.Enabled = true;
                        player63Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player54Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(54);
            placedCount++;
            player54Button.BackColor = Color.Gray;
            player54Button.Enabled = false;
            shipCheck[54] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 54;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player43Button.BackColor != Color.Gray)
                {
                    player43Button.BackColor = Color.DarkBlue;
                    player43Button.Enabled = false;
                }
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.BackColor = Color.DarkBlue;
                    player45Button.Enabled = false;
                }
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.BackColor = Color.DarkBlue;
                    player63Button.Enabled = false;
                }
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.BackColor = Color.DarkBlue;
                    player56Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.Enabled = true;
                    player44Button.BackColor = Color.Aqua;
                }
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.Enabled = true;
                    player53Button.BackColor = Color.Aqua;
                }
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.Enabled = true;
                    player55Button.BackColor = Color.Aqua;
                }
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.Enabled = true;
                    player64Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 54;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player53Button.BackColor != Color.Gray)
                    {
                        player53Button.Enabled = true;
                        player53Button.BackColor = Color.Aqua;
                    }
                    if (player55Button.BackColor != Color.Gray)
                    {
                        player55Button.Enabled = true;
                        player55Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player44Button.BackColor != Color.Gray)
                    {
                        player44Button.Enabled = true;
                        player44Button.BackColor = Color.Aqua;
                    }
                    if (player64Button.BackColor != Color.Gray)
                    {
                        player64Button.Enabled = true;
                        player64Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player55Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(55);
            placedCount++;
            player55Button.BackColor = Color.Gray;
            player55Button.Enabled = false;
            shipCheck[55] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 55;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player44Button.BackColor != Color.Gray)
                {
                    player44Button.BackColor = Color.DarkBlue;
                    player44Button.Enabled = false;
                }
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.BackColor = Color.DarkBlue;
                    player46Button.Enabled = false;
                }
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.BackColor = Color.DarkBlue;
                    player64Button.Enabled = false;
                }
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.BackColor = Color.DarkBlue;
                    player66Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.Enabled = true;
                    player45Button.BackColor = Color.Aqua;
                }
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.Enabled = true;
                    player54Button.BackColor = Color.Aqua;
                }
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.Enabled = true;
                    player56Button.BackColor = Color.Aqua;
                }
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.Enabled = true;
                    player65Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 55;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player54Button.BackColor != Color.Gray)
                    {
                        player54Button.Enabled = true;
                        player54Button.BackColor = Color.Aqua;
                    }
                    if (player56Button.BackColor != Color.Gray)
                    {
                        player56Button.Enabled = true;
                        player56Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player45Button.BackColor != Color.Gray)
                    {
                        player45Button.Enabled = true;
                        player45Button.BackColor = Color.Aqua;
                    }
                    if (player65Button.BackColor != Color.Gray)
                    {
                        player65Button.Enabled = true;
                        player65Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player56Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(56);
            placedCount++;
            player56Button.BackColor = Color.Gray;
            player56Button.Enabled = false;
            shipCheck[56] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 56;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player45Button.BackColor != Color.Gray)
                {
                    player45Button.BackColor = Color.DarkBlue;
                    player45Button.Enabled = false;
                }
                if (player47Button.BackColor != Color.Gray)
                {
                    player47Button.BackColor = Color.DarkBlue;
                    player47Button.Enabled = false;
                }
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.BackColor = Color.DarkBlue;
                    player65Button.Enabled = false;
                }
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.BackColor = Color.DarkBlue;
                    player67Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.Enabled = true;
                    player46Button.BackColor = Color.Aqua;
                }
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.Enabled = true;
                    player55Button.BackColor = Color.Aqua;
                }
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.Enabled = true;
                    player57Button.BackColor = Color.Aqua;
                }
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.Enabled = true;
                    player66Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 56;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player55Button.BackColor != Color.Gray)
                    {
                        player55Button.Enabled = true;
                        player55Button.BackColor = Color.Aqua;
                    }
                    if (player57Button.BackColor != Color.Gray)
                    {
                        player57Button.Enabled = true;
                        player57Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player46Button.BackColor != Color.Gray)
                    {
                        player46Button.Enabled = true;
                        player46Button.BackColor = Color.Aqua;
                    }
                    if (player66Button.BackColor != Color.Gray)
                    {
                        player66Button.Enabled = true;

                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player57Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(57);
            placedCount++;
            player57Button.BackColor = Color.Gray;
            player57Button.Enabled = false;
            shipCheck[57] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 57;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player46Button.BackColor != Color.Gray)
                {
                    player46Button.BackColor = Color.DarkBlue;
                    player46Button.Enabled = false;
                }
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.BackColor = Color.DarkBlue;
                    player48Button.Enabled = false;
                }
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.BackColor = Color.DarkBlue;
                    player66Button.Enabled = false;
                }
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.BackColor = Color.DarkBlue;
                    player68Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player47Button.BackColor != Color.Gray)
                {
                    player47Button.Enabled = true;
                    player47Button.BackColor = Color.Aqua;
                }
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.Enabled = true;
                    player56Button.BackColor = Color.Aqua;
                }
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.Enabled = true;
                    player58Button.BackColor = Color.Aqua;
                }
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.Enabled = true;
                    player67Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 57;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player56Button.BackColor != Color.Gray)
                    {
                        player56Button.Enabled = true;
                        player56Button.BackColor = Color.Aqua;
                    }
                    if (player58Button.BackColor != Color.Gray)
                    {
                        player58Button.Enabled = true;
                        player58Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player47Button.BackColor != Color.Gray)
                    {
                        player47Button.Enabled = true;
                        player47Button.BackColor = Color.Aqua;
                    }
                    if (player67Button.BackColor != Color.Gray)
                    {
                        player67Button.Enabled = true;
                        player67Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player58Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(58);
            placedCount++;
            player58Button.BackColor = Color.Gray;
            player58Button.Enabled = false;
            shipCheck[58] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 58;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player47Button.BackColor != Color.Gray)
                {
                    player47Button.BackColor = Color.DarkBlue;
                    player47Button.Enabled = false;
                }
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.BackColor = Color.DarkBlue;
                    player49Button.Enabled = false;
                }
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.BackColor = Color.DarkBlue;
                    player67Button.Enabled = false;
                }
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.BackColor = Color.DarkBlue;
                    player69Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.Enabled = true;
                    player48Button.BackColor = Color.Aqua;
                }
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.Enabled = true;
                    player57Button.BackColor = Color.Aqua;
                }
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.Enabled = true;
                    player59Button.BackColor = Color.Aqua;
                }
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.Enabled = true;
                    player68Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 58;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player57Button.BackColor != Color.Gray)
                    {
                        player57Button.Enabled = true;
                        player57Button.BackColor = Color.Aqua;
                    }
                    if (player59Button.BackColor != Color.Gray)
                    {
                        player59Button.Enabled = true;
                        player59Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player48Button.BackColor != Color.Gray)
                    {
                        player48Button.Enabled = true;
                        player48Button.BackColor = Color.Aqua;
                    }
                    if (player68Button.BackColor != Color.Gray)
                    {
                        player68Button.Enabled = true;
                        player68Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player59Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(59);
            placedCount++;
            player59Button.BackColor = Color.Gray;
            player59Button.Enabled = false;
            shipCheck[59] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 59;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player48Button.BackColor != Color.Gray)
                {
                    player48Button.BackColor = Color.DarkBlue;
                    player48Button.Enabled = false;
                }
                if (player50Button.BackColor != Color.Gray)
                {
                    player50Button.BackColor = Color.DarkBlue;
                    player50Button.Enabled = false;
                }
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.BackColor = Color.DarkBlue;
                    player68Button.Enabled = false;
                }
                if (player70Button.BackColor != Color.Gray)
                {
                    player70Button.BackColor = Color.DarkBlue;
                    player70Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.Enabled = true;
                    player49Button.BackColor = Color.Aqua;
                }
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.Enabled = true;
                    player58Button.BackColor = Color.Aqua;
                }
                if (player60Button.BackColor != Color.Gray)
                {
                    player60Button.Enabled = true;
                    player60Button.BackColor = Color.Aqua;
                }
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.Enabled = true;
                    player69Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 59;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player58Button.BackColor != Color.Gray)
                    {
                        player58Button.Enabled = true;
                        player58Button.BackColor = Color.Aqua;
                    }
                    if (player60Button.BackColor != Color.Gray)
                    {
                        player60Button.Enabled = true;
                        player60Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player49Button.BackColor != Color.Gray)
                    {
                        player49Button.Enabled = true;
                        player49Button.BackColor = Color.Aqua;
                    }
                    if (player69Button.BackColor != Color.Gray)
                    {
                        player69Button.Enabled = true;
                        player69Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player60Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(60);
            placedCount++;
            player60Button.BackColor = Color.Gray;
            player60Button.Enabled = false;
            shipCheck[60] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 60;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player49Button.BackColor != Color.Gray)
                {
                    player49Button.BackColor = Color.DarkBlue;
                    player49Button.Enabled = false;
                }
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.BackColor = Color.DarkBlue;
                    player69Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player50Button.BackColor != Color.Gray)
                {
                    player50Button.Enabled = true;
                    player50Button.BackColor = Color.Aqua;
                }
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.Enabled = true;
                    player59Button.BackColor = Color.Aqua;
                }
                if (player70Button.BackColor != Color.Gray)
                {
                    player70Button.Enabled = true;
                    player70Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 60;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player50Button.BackColor != Color.Gray)
                    {
                        player50Button.Enabled = true;
                        player50Button.BackColor = Color.Aqua;
                    }
                    if (player70Button.BackColor != Color.Gray)
                    {
                        player70Button.Enabled = true;
                        player70Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player61Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(61);
            placedCount++;
            player61Button.BackColor = Color.Gray;
            player61Button.Enabled = false;
            shipCheck[61] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 61;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.BackColor = Color.DarkBlue;
                    player52Button.Enabled = false;
                }
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.BackColor = Color.DarkBlue;
                    player72Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player51Button.BackColor != Color.Gray)
                {
                    player51Button.Enabled = true;
                    player51Button.BackColor = Color.Aqua;
                }
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.Enabled = true;
                    player62Button.BackColor = Color.Aqua;
                }
                if (player71Button.BackColor != Color.Gray)
                {
                    player71Button.Enabled = true;
                    player71Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 61;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player51Button.BackColor != Color.Gray)
                    {
                        player51Button.Enabled = true;
                        player51Button.BackColor = Color.Aqua;
                    }
                    if (player71Button.BackColor != Color.Gray)
                    {
                        player71Button.Enabled = true;
                        player71Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player62Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(62);
            placedCount++;
            player62Button.BackColor = Color.Gray;
            player62Button.Enabled = false;
            shipCheck[62] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 62;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player51Button.BackColor != Color.Gray)
                {
                    player51Button.BackColor = Color.DarkBlue;
                    player51Button.Enabled = false;
                }
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.BackColor = Color.DarkBlue;
                    player53Button.Enabled = false;
                }
                if (player71Button.BackColor != Color.Gray)
                {
                    player71Button.BackColor = Color.DarkBlue;
                    player71Button.Enabled = false;
                }
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.BackColor = Color.DarkBlue;
                    player73Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.Enabled = true;
                    player52Button.BackColor = Color.Aqua;
                }
                if (player61Button.BackColor != Color.Gray)
                {
                    player61Button.Enabled = true;
                    player61Button.BackColor = Color.Aqua;
                }
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.Enabled = true;
                    player63Button.BackColor = Color.Aqua;
                }
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.Enabled = true;
                    player72Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 62;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player61Button.BackColor != Color.Gray)
                    {
                        player61Button.Enabled = true;
                        player61Button.BackColor = Color.Aqua;
                    }
                    if (player63Button.BackColor != Color.Gray)
                    {
                        player63Button.Enabled = true;
                        player63Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player52Button.BackColor != Color.Gray)
                    {
                        player52Button.Enabled = true;
                        player52Button.BackColor = Color.Aqua;
                    }
                    if (player72Button.BackColor != Color.Gray)
                    {
                        player72Button.Enabled = true;
                        player72Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player63Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(63);
            placedCount++;
            player63Button.BackColor = Color.Gray;
            player63Button.Enabled = false;
            shipCheck[63] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 63;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player52Button.BackColor != Color.Gray)
                {
                    player52Button.BackColor = Color.DarkBlue;
                    player52Button.Enabled = false;
                }
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.BackColor = Color.DarkBlue;
                    player54Button.Enabled = false;
                }
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.BackColor = Color.DarkBlue;
                    player72Button.Enabled = false;
                }
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.BackColor = Color.DarkBlue;
                    player74Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.Enabled = true;
                    player53Button.BackColor = Color.Aqua;
                }
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.Enabled = true;
                    player62Button.BackColor = Color.Aqua;
                }
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.Enabled = true;
                    player64Button.BackColor = Color.Aqua;
                }
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.Enabled = true;
                    player73Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 63;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player62Button.BackColor != Color.Gray)
                    {
                        player62Button.Enabled = true;
                        player62Button.BackColor = Color.Aqua;
                    }
                    if (player64Button.BackColor != Color.Gray)
                    {
                        player64Button.Enabled = true;
                        player64Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player53Button.BackColor != Color.Gray)
                    {
                        player53Button.Enabled = true;
                        player53Button.BackColor = Color.Aqua;
                    }
                    if (player73Button.BackColor != Color.Gray)
                    {
                        player73Button.Enabled = true;
                        player73Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player64Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(64);
            placedCount++;
            player64Button.BackColor = Color.Gray;
            player64Button.Enabled = false;
            shipCheck[64] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 64;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player53Button.BackColor != Color.Gray)
                {
                    player53Button.BackColor = Color.DarkBlue;
                    player53Button.Enabled = false;
                }
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.BackColor = Color.DarkBlue;
                    player55Button.Enabled = false;
                }
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.BackColor = Color.DarkBlue;
                    player73Button.Enabled = false;
                }
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.BackColor = Color.DarkBlue;
                    player75Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.Enabled = true;
                    player54Button.BackColor = Color.Aqua;
                }
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.Enabled = true;
                    player63Button.BackColor = Color.Aqua;
                }
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.Enabled = true;
                    player65Button.BackColor = Color.Aqua;
                }
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.Enabled = true;
                    player74Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 64;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player63Button.BackColor != Color.Gray)
                    {
                        player63Button.Enabled = true;
                        player63Button.BackColor = Color.Aqua;
                    }
                    if (player65Button.BackColor != Color.Gray)
                    {
                        player65Button.Enabled = true;
                        player65Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player54Button.BackColor != Color.Gray)
                    {
                        player54Button.Enabled = true;
                        player54Button.BackColor = Color.Aqua;
                    }
                    if (player74Button.BackColor != Color.Gray)
                    {
                        player74Button.Enabled = true;
                        player74Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player65Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(65);
            placedCount++;
            player65Button.BackColor = Color.Gray;
            player65Button.Enabled = false;
            shipCheck[65] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 65;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player54Button.BackColor != Color.Gray)
                {
                    player54Button.BackColor = Color.DarkBlue;
                    player54Button.Enabled = false;
                }
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.BackColor = Color.DarkBlue;
                    player56Button.Enabled = false;
                }
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.BackColor = Color.DarkBlue;
                    player74Button.Enabled = false;
                }
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.BackColor = Color.DarkBlue;
                    player76Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.Enabled = true;
                    player55Button.BackColor = Color.Aqua;
                }
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.Enabled = true;
                    player64Button.BackColor = Color.Aqua;
                }
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.Enabled = true;
                    player66Button.BackColor = Color.Aqua;
                }
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.Enabled = true;
                    player75Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 65;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player64Button.BackColor != Color.Gray)
                    {
                        player64Button.Enabled = true;
                        player64Button.BackColor = Color.Aqua;
                    }
                    if (player66Button.BackColor != Color.Gray)
                    {
                        player66Button.Enabled = true;
                        player66Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player55Button.BackColor != Color.Gray)
                    {
                        player55Button.Enabled = true;
                        player55Button.BackColor = Color.Aqua;
                    }
                    if (player75Button.BackColor != Color.Gray)
                    {
                        player75Button.Enabled = true;
                        player75Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player66Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(66);
            placedCount++;
            player66Button.BackColor = Color.Gray;
            player66Button.Enabled = false;
            shipCheck[66] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 66;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player55Button.BackColor != Color.Gray)
                {
                    player55Button.BackColor = Color.DarkBlue;
                    player55Button.Enabled = false;
                }
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.BackColor = Color.DarkBlue;
                    player57Button.Enabled = false;
                }
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.BackColor = Color.DarkBlue;
                    player75Button.Enabled = false;
                }
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.BackColor = Color.DarkBlue;
                    player77Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.Enabled = true;
                    player56Button.BackColor = Color.Aqua;
                }
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.Enabled = true;
                    player65Button.BackColor = Color.Aqua;
                }
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.Enabled = true;
                    player67Button.BackColor = Color.Aqua;
                }
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.Enabled = true;
                    player76Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 66;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player65Button.BackColor != Color.Gray)
                    {
                        player65Button.Enabled = true;
                        player65Button.BackColor = Color.Aqua;
                    }
                    if (player67Button.BackColor != Color.Gray)
                    {
                        player67Button.Enabled = true;
                        player67Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player56Button.BackColor != Color.Gray)
                    {
                        player56Button.Enabled = true;
                        player56Button.BackColor = Color.Aqua;
                    }
                    if (player76Button.BackColor != Color.Gray)
                    {
                        player76Button.Enabled = true;
                        player76Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player67Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(67);
            placedCount++;
            player67Button.BackColor = Color.Gray;
            player67Button.Enabled = false;
            shipCheck[67] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 67;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player56Button.BackColor != Color.Gray)
                {
                    player56Button.BackColor = Color.DarkBlue;
                    player56Button.Enabled = false;
                }
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.BackColor = Color.DarkBlue;
                    player58Button.Enabled = false;
                }
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.BackColor = Color.DarkBlue;
                    player76Button.Enabled = false;
                }
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.BackColor = Color.DarkBlue;
                    player78Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.Enabled = true;
                    player57Button.BackColor = Color.Aqua;
                }
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.Enabled = true;
                    player66Button.BackColor = Color.Aqua;
                }
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.Enabled = true;
                    player68Button.BackColor = Color.Aqua;
                }
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.Enabled = true;
                    player77Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 67;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player66Button.BackColor != Color.Gray)
                    {
                        player66Button.Enabled = true;
                        player66Button.BackColor = Color.Aqua;
                    }
                    if (player68Button.BackColor != Color.Gray)
                    {
                        player68Button.Enabled = true;
                        player68Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player57Button.BackColor != Color.Gray)
                    {
                        player57Button.Enabled = true;
                        player57Button.BackColor = Color.Aqua;
                    }
                    if (player77Button.BackColor != Color.Gray)
                    {
                        player77Button.Enabled = true;
                        player77Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player68Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(68);
            placedCount++;
            player68Button.BackColor = Color.Gray;
            player68Button.Enabled = false;
            shipCheck[68] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 68;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player57Button.BackColor != Color.Gray)
                {
                    player57Button.BackColor = Color.DarkBlue;
                    player57Button.Enabled = false;
                }
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.BackColor = Color.DarkBlue;
                    player59Button.Enabled = false;
                }
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.BackColor = Color.DarkBlue;
                    player77Button.Enabled = false;
                }
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.BackColor = Color.DarkBlue;
                    player79Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.Enabled = true;
                    player58Button.BackColor = Color.Aqua;
                }
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.Enabled = true;
                    player67Button.BackColor = Color.Aqua;
                }
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.Enabled = true;
                    player69Button.BackColor = Color.Aqua;
                }
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.Enabled = true;
                    player78Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 68;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player67Button.BackColor != Color.Gray)
                    {
                        player67Button.Enabled = true;
                        player67Button.BackColor = Color.Aqua;
                    }
                    if (player69Button.BackColor != Color.Gray)
                    {
                        player69Button.Enabled = true;
                        player69Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player58Button.BackColor != Color.Gray)
                    {
                        player58Button.Enabled = true;
                        player58Button.BackColor = Color.Aqua;
                    }
                    if (player78Button.BackColor != Color.Gray)
                    {
                        player78Button.Enabled = true;
                        player78Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player69Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(69);
            placedCount++;
            player69Button.BackColor = Color.Gray;
            player69Button.Enabled = false;
            shipCheck[69] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 69;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player58Button.BackColor != Color.Gray)
                {
                    player58Button.BackColor = Color.DarkBlue;
                    player58Button.Enabled = false;
                }
                if (player60Button.BackColor != Color.Gray)
                {
                    player60Button.BackColor = Color.DarkBlue;
                    player60Button.Enabled = false;
                }
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.BackColor = Color.DarkBlue;
                    player78Button.Enabled = false;
                }
                if (player80Button.BackColor != Color.Gray)
                {
                    player80Button.BackColor = Color.DarkBlue;
                    player80Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.Enabled = true;
                    player59Button.BackColor = Color.Aqua;
                }
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.Enabled = true;
                    player68Button.BackColor = Color.Aqua;
                }
                if (player70Button.BackColor != Color.Gray)
                {
                    player70Button.Enabled = true;
                    player70Button.BackColor = Color.Aqua;
                }
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.Enabled = true;
                    player79Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 69;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player68Button.BackColor != Color.Gray)
                    {
                        player68Button.Enabled = true;
                        player68Button.BackColor = Color.Aqua;
                    }
                    if (player70Button.BackColor != Color.Gray)
                    {
                        player70Button.Enabled = true;
                        player70Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player59Button.BackColor != Color.Gray)
                    {
                        player59Button.Enabled = true;
                        player59Button.BackColor = Color.Aqua;
                    }
                    if (player79Button.BackColor != Color.Gray)
                    {
                        player79Button.Enabled = true;
                        player79Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player70Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(70);
            placedCount++;
            player70Button.BackColor = Color.Gray;
            player70Button.Enabled = false;
            shipCheck[70] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 70;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player59Button.BackColor != Color.Gray)
                {
                    player59Button.BackColor = Color.DarkBlue;
                    player59Button.Enabled = false;
                }
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.BackColor = Color.DarkBlue;
                    player79Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player60Button.BackColor != Color.Gray)
                {
                    player60Button.Enabled = true;
                    player60Button.BackColor = Color.Aqua;
                }
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.Enabled = true;
                    player69Button.BackColor = Color.Aqua;
                }
                if (player80Button.BackColor != Color.Gray)
                {
                    player80Button.Enabled = true;
                    player80Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 70;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player60Button.BackColor != Color.Gray)
                    {
                        player60Button.Enabled = true;
                        player60Button.BackColor = Color.Aqua;
                    }
                    if (player80Button.BackColor != Color.Gray)
                    {
                        player80Button.Enabled = true;
                        player80Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player71Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(71);
            placedCount++;
            player71Button.BackColor = Color.Gray;
            player71Button.Enabled = false;
            shipCheck[71] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 71;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.BackColor = Color.DarkBlue;
                    player62Button.Enabled = false;
                }
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.BackColor = Color.DarkBlue;
                    player82Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player61Button.BackColor != Color.Gray)
                {
                    player61Button.Enabled = true;
                    player61Button.BackColor = Color.Aqua;
                }
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.Enabled = true;
                    player72Button.BackColor = Color.Aqua;
                }
                if (player81Button.BackColor != Color.Gray)
                {
                    player81Button.Enabled = true;
                    player81Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 71;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player61Button.BackColor != Color.Gray)
                    {
                        player61Button.Enabled = true;
                        player61Button.BackColor = Color.Aqua;
                    }
                    if (player81Button.BackColor != Color.Gray)
                    {
                        player81Button.Enabled = true;
                        player81Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player72Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(72);
            placedCount++;
            player72Button.BackColor = Color.Gray;
            player72Button.Enabled = false;
            shipCheck[72] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 72;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player61Button.BackColor != Color.Gray)
                {
                    player61Button.BackColor = Color.DarkBlue;
                    player61Button.Enabled = false;
                }
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.BackColor = Color.DarkBlue;
                    player63Button.Enabled = false;
                }
                if (player81Button.BackColor != Color.Gray)
                {
                    player81Button.BackColor = Color.DarkBlue;
                    player81Button.Enabled = false;
                }
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.BackColor = Color.DarkBlue;
                    player83Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.Enabled = true;
                    player62Button.BackColor = Color.Aqua;
                }
                if (player71Button.BackColor != Color.Gray)
                {
                    player71Button.Enabled = true;
                    player71Button.BackColor = Color.Aqua;
                }
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.Enabled = true;
                    player73Button.BackColor = Color.Aqua;
                }
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.Enabled = true;
                    player82Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 72;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player71Button.BackColor != Color.Gray)
                    {
                        player71Button.Enabled = true;
                        player71Button.BackColor = Color.Aqua;
                    }
                    if (player73Button.BackColor != Color.Gray)
                    {
                        player73Button.Enabled = true;
                        player73Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player62Button.BackColor != Color.Gray)
                    {
                        player62Button.Enabled = true;
                        player62Button.BackColor = Color.Aqua;
                    }
                    if (player82Button.BackColor != Color.Gray)
                    {
                        player82Button.Enabled = true;
                        player82Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player73Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(73);
            placedCount++;
            player73Button.BackColor = Color.Gray;
            player73Button.Enabled = false;
            shipCheck[73] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 73;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player62Button.BackColor != Color.Gray)
                {
                    player62Button.BackColor = Color.DarkBlue;
                    player62Button.Enabled = false;
                }
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.BackColor = Color.DarkBlue;
                    player64Button.Enabled = false;
                }
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.BackColor = Color.DarkBlue;
                    player82Button.Enabled = false;
                }
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.BackColor = Color.DarkBlue;
                    player84Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.Enabled = true;
                    player63Button.BackColor = Color.Aqua;
                }
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.Enabled = true;
                    player72Button.BackColor = Color.Aqua;
                }
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.Enabled = true;
                    player74Button.BackColor = Color.Aqua;
                }
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.Enabled = true;
                    player83Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 73;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player72Button.BackColor != Color.Gray)
                    {
                        player72Button.Enabled = true;
                        player72Button.BackColor = Color.Aqua;
                    }
                    if (player74Button.BackColor != Color.Gray)
                    {
                        player74Button.Enabled = true;
                        player74Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player63Button.BackColor != Color.Gray)
                    {
                        player63Button.Enabled = true;
                        player63Button.BackColor = Color.Aqua;
                    }
                    if (player83Button.BackColor != Color.Gray)
                    {
                        player83Button.Enabled = true;
                        player83Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player74Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(74);
            placedCount++;
            player74Button.BackColor = Color.Gray;
            player74Button.Enabled = false;
            shipCheck[74] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 74;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player63Button.BackColor != Color.Gray)
                {
                    player63Button.BackColor = Color.DarkBlue;
                    player63Button.Enabled = false;
                }
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.BackColor = Color.DarkBlue;
                    player65Button.Enabled = false;
                }
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.BackColor = Color.DarkBlue;
                    player83Button.Enabled = false;
                }
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.BackColor = Color.DarkBlue;
                    player85Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.Enabled = true;
                    player64Button.BackColor = Color.Aqua;
                }
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.Enabled = true;
                    player73Button.BackColor = Color.Aqua;
                }
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.Enabled = true;
                    player75Button.BackColor = Color.Aqua;
                }
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.Enabled = true;
                    player84Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 74;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player73Button.BackColor != Color.Gray)
                    {
                        player73Button.Enabled = true;
                        player73Button.BackColor = Color.Aqua;
                    }
                    if (player75Button.BackColor != Color.Gray)
                    {
                        player75Button.Enabled = true;
                        player75Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player64Button.BackColor != Color.Gray)
                    {
                        player64Button.Enabled = true;
                        player64Button.BackColor = Color.Aqua;
                    }
                    if (player84Button.BackColor != Color.Gray)
                    {
                        player84Button.Enabled = true;
                        player84Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player75Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(75);
            placedCount++;
            player75Button.BackColor = Color.Gray;
            player75Button.Enabled = false;
            shipCheck[75] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 75;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player64Button.BackColor != Color.Gray)
                {
                    player64Button.BackColor = Color.DarkBlue;
                    player64Button.Enabled = false;
                }
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.BackColor = Color.DarkBlue;
                    player66Button.Enabled = false;
                }
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.BackColor = Color.DarkBlue;
                    player84Button.Enabled = false;
                }
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.BackColor = Color.DarkBlue;
                    player86Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.Enabled = true;
                    player65Button.BackColor = Color.Aqua;
                }
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.Enabled = true;
                    player74Button.BackColor = Color.Aqua;
                }
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.Enabled = true;
                    player76Button.BackColor = Color.Aqua;
                }
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.Enabled = true;
                    player85Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 75;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player74Button.BackColor != Color.Gray)
                    {
                        player74Button.Enabled = true;
                        player74Button.BackColor = Color.Aqua;
                    }
                    if (player76Button.BackColor != Color.Gray)
                    {
                        player76Button.Enabled = true;
                        player76Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player65Button.BackColor != Color.Gray)
                    {
                        player65Button.Enabled = true;
                        player65Button.BackColor = Color.Aqua;
                    }
                    if (player85Button.BackColor != Color.Gray)
                    {
                        player85Button.Enabled = true;
                        player85Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player76Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(76);
            placedCount++;
            player76Button.BackColor = Color.Gray;
            player76Button.Enabled = false;
            shipCheck[76] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 76;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player65Button.BackColor != Color.Gray)
                {
                    player65Button.BackColor = Color.DarkBlue;
                    player65Button.Enabled = false;
                }
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.BackColor = Color.DarkBlue;
                    player67Button.Enabled = false;
                }
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.BackColor = Color.DarkBlue;
                    player85Button.Enabled = false;
                }
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.BackColor = Color.DarkBlue;
                    player87Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.Enabled = true;
                    player66Button.BackColor = Color.Aqua;
                }
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.Enabled = true;
                    player75Button.BackColor = Color.Aqua;
                }
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.Enabled = true;
                    player77Button.BackColor = Color.Aqua;
                }
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.Enabled = true;
                    player86Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 76;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player75Button.BackColor != Color.Gray)
                    {
                        player75Button.Enabled = true;
                        player75Button.BackColor = Color.Aqua;
                    }
                    if (player77Button.BackColor != Color.Gray)
                    {
                        player77Button.Enabled = true;
                        player77Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player66Button.BackColor != Color.Gray)
                    {
                        player66Button.Enabled = true;
                        player66Button.BackColor = Color.Aqua;
                    }
                    if (player86Button.BackColor != Color.Gray)
                    {
                        player86Button.Enabled = true;
                        player86Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player77Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(77);
            placedCount++;
            player77Button.BackColor = Color.Gray;
            player77Button.Enabled = false;
            shipCheck[77] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 77;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player66Button.BackColor != Color.Gray)
                {
                    player66Button.BackColor = Color.DarkBlue;
                    player66Button.Enabled = false;
                }
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.BackColor = Color.DarkBlue;
                    player68Button.Enabled = false;
                }
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.BackColor = Color.DarkBlue;
                    player86Button.Enabled = false;
                }
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.BackColor = Color.DarkBlue;
                    player88Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.Enabled = true;
                    player67Button.BackColor = Color.Aqua;
                }
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.Enabled = true;
                    player76Button.BackColor = Color.Aqua;
                }
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.Enabled = true;
                    player78Button.BackColor = Color.Aqua;
                }
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.Enabled = true;
                    player87Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 77;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player76Button.BackColor != Color.Gray)
                    {
                        player76Button.Enabled = true;
                        player76Button.BackColor = Color.Aqua;
                    }
                    if (player78Button.BackColor != Color.Gray)
                    {
                        player78Button.Enabled = true;
                        player78Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player67Button.BackColor != Color.Gray)
                    {
                        player67Button.Enabled = true;
                        player67Button.BackColor = Color.Aqua;
                    }
                    if (player87Button.BackColor != Color.Gray)
                    {
                        player87Button.Enabled = true;
                        player87Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player78Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(78);
            placedCount++;
            player78Button.BackColor = Color.Gray;
            player78Button.Enabled = false;
            shipCheck[78] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 78;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player67Button.BackColor != Color.Gray)
                {
                    player67Button.BackColor = Color.DarkBlue;
                    player67Button.Enabled = false;
                }
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.BackColor = Color.DarkBlue;
                    player69Button.Enabled = false;
                }
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.BackColor = Color.DarkBlue;
                    player87Button.Enabled = false;
                }
                if (player89Button.BackColor != Color.Gray)
                {
                    player89Button.BackColor = Color.DarkBlue;
                    player89Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.Enabled = true;
                    player68Button.BackColor = Color.Aqua;
                }
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.Enabled = true;
                    player77Button.BackColor = Color.Aqua;
                }
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.Enabled = true;
                    player79Button.BackColor = Color.Aqua;
                }
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.Enabled = true;
                    player88Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 78;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player77Button.BackColor != Color.Gray)
                    {
                        player77Button.Enabled = true;
                        player77Button.BackColor = Color.Aqua;
                    }
                    if (player79Button.BackColor != Color.Gray)
                    {
                        player79Button.Enabled = true;
                        player79Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player68Button.BackColor != Color.Gray)
                    {
                        player68Button.Enabled = true;
                        player68Button.BackColor = Color.Aqua;
                    }
                    if (player88Button.BackColor != Color.Gray)
                    {
                        player88Button.Enabled = true;
                        player88Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player79Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(79);
            placedCount++;
            player79Button.BackColor = Color.Gray;
            player79Button.Enabled = false;
            shipCheck[79] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 79;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player68Button.BackColor != Color.Gray)
                {
                    player68Button.BackColor = Color.DarkBlue;
                    player68Button.Enabled = false;
                }
                if (player70Button.BackColor != Color.Gray)
                {
                    player70Button.BackColor = Color.DarkBlue;
                    player70Button.Enabled = false;
                }
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.BackColor = Color.DarkBlue;
                    player88Button.Enabled = false;
                }
                if (player90Button.BackColor != Color.Gray)
                {
                    player90Button.BackColor = Color.DarkBlue;
                    player90Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.Enabled = true;
                    player69Button.BackColor = Color.Aqua;
                }
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.Enabled = true;
                    player78Button.BackColor = Color.Aqua;
                }
                if (player80Button.BackColor != Color.Gray)
                {
                    player80Button.Enabled = true;
                    player80Button.BackColor = Color.Aqua;
                }
                if (player89Button.BackColor != Color.Gray)
                {
                    player89Button.Enabled = true;
                    player89Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 79;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player78Button.BackColor != Color.Gray)
                    {
                        player78Button.Enabled = true;
                        player78Button.BackColor = Color.Aqua;
                    }
                    if (player80Button.BackColor != Color.Gray)
                    {
                        player80Button.Enabled = true;
                        player80Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player69Button.BackColor != Color.Gray)
                    {
                        player69Button.Enabled = true;
                        player69Button.BackColor = Color.Aqua;
                    }
                    if (player89Button.BackColor != Color.Gray)
                    {
                        player89Button.Enabled = true;
                        player89Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player80Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(80);
            placedCount++;
            player80Button.BackColor = Color.Gray;
            player80Button.Enabled = false;
            shipCheck[80] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 80;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player69Button.BackColor != Color.Gray)
                {
                    player69Button.BackColor = Color.DarkBlue;
                    player69Button.Enabled = false;
                }
                if (player89Button.BackColor != Color.Gray)
                {
                    player89Button.BackColor = Color.DarkBlue;
                    player89Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player70Button.BackColor != Color.Gray)
                {
                    player70Button.Enabled = true;
                    player70Button.BackColor = Color.Aqua;
                }
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.Enabled = true;
                    player79Button.BackColor = Color.Aqua;
                }
                if (player90Button.BackColor != Color.Gray)
                {
                    player90Button.Enabled = true;
                    player90Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 80;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player70Button.BackColor != Color.Gray)
                    {
                        player70Button.Enabled = true;
                        player70Button.BackColor = Color.Aqua;
                    }
                    if (player90Button.BackColor != Color.Gray)
                    {
                        player90Button.Enabled = true;
                        player90Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player81Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(81);
            placedCount++;
            player81Button.BackColor = Color.Gray;
            player81Button.Enabled = false;
            shipCheck[81] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 81;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.BackColor = Color.DarkBlue;
                    player72Button.Enabled = false;
                }
                if (player92Button.BackColor != Color.Gray)
                {
                    player92Button.BackColor = Color.DarkBlue;
                    player92Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player71Button.BackColor != Color.Gray)
                {
                    player71Button.Enabled = true;
                    player71Button.BackColor = Color.Aqua;
                }
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.Enabled = true;
                    player82Button.BackColor = Color.Aqua;
                }
                if (player91Button.BackColor != Color.Gray)
                {
                    player91Button.Enabled = true;
                    player91Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 81;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player71Button.BackColor != Color.Gray)
                    {
                        player71Button.Enabled = true;
                        player71Button.BackColor = Color.Aqua;
                    }
                    if (player91Button.BackColor != Color.Gray)
                    {
                        player91Button.Enabled = true;
                        player91Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player82Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(82);
            placedCount++;
            player82Button.BackColor = Color.Gray;
            player82Button.Enabled = false;
            shipCheck[82] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 82;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player71Button.BackColor != Color.Gray)
                {
                    player71Button.BackColor = Color.DarkBlue;
                    player71Button.Enabled = false;
                }
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.BackColor = Color.DarkBlue;
                    player73Button.Enabled = false;
                }
                if (player91Button.BackColor != Color.Gray)
                {
                    player91Button.BackColor = Color.DarkBlue;
                    player91Button.Enabled = false;
                }
                if (player93Button.BackColor != Color.Gray)
                {
                    player93Button.BackColor = Color.DarkBlue;
                    player93Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.Enabled = true;
                    player72Button.BackColor = Color.Aqua;
                }
                if (player81Button.BackColor != Color.Gray)
                {
                    player81Button.Enabled = true;
                    player81Button.BackColor = Color.Aqua;
                }
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.Enabled = true;
                    player83Button.BackColor = Color.Aqua;
                }
                if (player92Button.BackColor != Color.Gray)
                {
                    player92Button.Enabled = true;
                    player92Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 82;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player81Button.BackColor != Color.Gray)
                    {
                        player81Button.Enabled = true;
                        player81Button.BackColor = Color.Aqua;
                    }
                    if (player83Button.BackColor != Color.Gray)
                    {
                        player83Button.Enabled = true;
                        player83Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player72Button.BackColor != Color.Gray)
                    {
                        player72Button.Enabled = true;
                        player72Button.BackColor = Color.Aqua;
                    }
                    if (player92Button.BackColor != Color.Gray)
                    {
                        player92Button.Enabled = true;
                        player92Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player83Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(83);
            placedCount++;
            player83Button.BackColor = Color.Gray;
            player83Button.Enabled = false;
            shipCheck[83] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 83;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player72Button.BackColor != Color.Gray)
                {
                    player72Button.BackColor = Color.DarkBlue;
                    player72Button.Enabled = false;
                }
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.BackColor = Color.DarkBlue;
                    player74Button.Enabled = false;
                }
                if (player92Button.BackColor != Color.Gray)
                {
                    player92Button.BackColor = Color.DarkBlue;
                    player92Button.Enabled = false;
                }
                if (player94Button.BackColor != Color.Gray)
                {
                    player94Button.BackColor = Color.DarkBlue;
                    player94Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.Enabled = true;
                    player73Button.BackColor = Color.Aqua;
                }
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.Enabled = true;
                    player82Button.BackColor = Color.Aqua;
                }
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.Enabled = true;
                    player84Button.BackColor = Color.Aqua;
                }
                if (player93Button.BackColor != Color.Gray)
                {
                    player93Button.Enabled = true;
                    player93Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 83;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player82Button.BackColor != Color.Gray)
                    {
                        player82Button.Enabled = true;
                        player82Button.BackColor = Color.Aqua;
                    }
                    if (player84Button.BackColor != Color.Gray)
                    {
                        player84Button.Enabled = true;
                        player84Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player73Button.BackColor != Color.Gray)
                    {
                        player73Button.Enabled = true;
                        player73Button.BackColor = Color.Aqua;
                    }
                    if (player93Button.BackColor != Color.Gray)
                    {
                        player93Button.Enabled = true;
                        player93Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player84Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(84);
            placedCount++;
            player84Button.BackColor = Color.Gray;
            player84Button.Enabled = false;
            shipCheck[84] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 84;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player73Button.BackColor != Color.Gray)
                {
                    player73Button.BackColor = Color.DarkBlue;
                    player73Button.Enabled = false;
                }
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.BackColor = Color.DarkBlue;
                    player75Button.Enabled = false;
                }
                if (player93Button.BackColor != Color.Gray)
                {
                    player93Button.BackColor = Color.DarkBlue;
                    player93Button.Enabled = false;
                }
                if (player95Button.BackColor != Color.Gray)
                {
                    player95Button.BackColor = Color.DarkBlue;
                    player95Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.Enabled = true;
                    player74Button.BackColor = Color.Aqua;
                }
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.Enabled = true;
                    player83Button.BackColor = Color.Aqua;
                }
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.Enabled = true;
                    player85Button.BackColor = Color.Aqua;
                }
                if (player94Button.BackColor != Color.Gray)
                {
                    player94Button.Enabled = true;
                    player94Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 84;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player83Button.BackColor != Color.Gray)
                    {
                        player83Button.Enabled = true;
                        player83Button.BackColor = Color.Aqua;
                    }
                    if (player85Button.BackColor != Color.Gray)
                    {
                        player85Button.Enabled = true;
                        player85Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player74Button.BackColor != Color.Gray)
                    {
                        player74Button.Enabled = true;
                        player74Button.BackColor = Color.Aqua;
                    }
                    if (player94Button.BackColor != Color.Gray)
                    {
                        player94Button.Enabled = true;
                        player94Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player85Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(85);
            placedCount++;
            player85Button.BackColor = Color.Gray;
            player85Button.Enabled = false;
            shipCheck[85] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 85;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player74Button.BackColor != Color.Gray)
                {
                    player74Button.BackColor = Color.DarkBlue;
                    player74Button.Enabled = false;
                }
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.BackColor = Color.DarkBlue;
                    player76Button.Enabled = false;
                }
                if (player94Button.BackColor != Color.Gray)
                {
                    player94Button.BackColor = Color.DarkBlue;
                    player94Button.Enabled = false;
                }
                if (player96Button.BackColor != Color.Gray)
                {
                    player96Button.BackColor = Color.DarkBlue;
                    player96Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.Enabled = true;
                    player75Button.BackColor = Color.Aqua;
                }
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.Enabled = true;
                    player84Button.BackColor = Color.Aqua;
                }
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.Enabled = true;
                    player86Button.BackColor = Color.Aqua;
                }
                if (player95Button.BackColor != Color.Gray)
                {
                    player95Button.Enabled = true;
                    player95Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 85;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player84Button.BackColor != Color.Gray)
                    {
                        player84Button.Enabled = true;
                        player84Button.BackColor = Color.Aqua;
                    }
                    if (player86Button.BackColor != Color.Gray)
                    {
                        player86Button.Enabled = true;
                        player86Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player75Button.BackColor != Color.Gray)
                    {
                        player75Button.Enabled = true;
                        player75Button.BackColor = Color.Aqua;
                    }
                    if (player95Button.BackColor != Color.Gray)
                    {
                        player95Button.Enabled = true;
                        player95Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player86Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(86);
            placedCount++;
            player86Button.BackColor = Color.Gray;
            player86Button.Enabled = false;
            shipCheck[86] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 86;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player75Button.BackColor != Color.Gray)
                {
                    player75Button.BackColor = Color.DarkBlue;
                    player75Button.Enabled = false;
                }
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.BackColor = Color.DarkBlue;
                    player77Button.Enabled = false;
                }
                if (player95Button.BackColor != Color.Gray)
                {
                    player95Button.BackColor = Color.DarkBlue;
                    player95Button.Enabled = false;
                }
                if (player97Button.BackColor != Color.Gray)
                {
                    player97Button.BackColor = Color.DarkBlue;
                    player97Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.Enabled = true;
                    player76Button.BackColor = Color.Aqua;
                }
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.Enabled = true;
                    player85Button.BackColor = Color.Aqua;
                }
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.Enabled = true;
                    player87Button.BackColor = Color.Aqua;
                }
                if (player96Button.BackColor != Color.Gray)
                {
                    player96Button.Enabled = true;
                    player96Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 86;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player85Button.BackColor != Color.Gray)
                    {
                        player85Button.Enabled = true;
                        player85Button.BackColor = Color.Aqua;
                    }
                    if (player87Button.BackColor != Color.Gray)
                    {
                        player87Button.Enabled = true;
                        player87Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player76Button.BackColor != Color.Gray)
                    {
                        player76Button.Enabled = true;
                        player76Button.BackColor = Color.Aqua;
                    }
                    if (player96Button.BackColor != Color.Gray)
                    {
                        player96Button.Enabled = true;
                        player96Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player87Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(87);
            placedCount++;
            player87Button.BackColor = Color.Gray;
            player87Button.Enabled = false;
            shipCheck[87] = true;


            if (secondPlaced == true)
            {
                currentPlacedInt = 87;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player76Button.BackColor != Color.Gray)
                {
                    player76Button.BackColor = Color.DarkBlue;
                    player76Button.Enabled = false;
                }
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.BackColor = Color.DarkBlue;
                    player78Button.Enabled = false;
                }
                if (player96Button.BackColor != Color.Gray)
                {
                    player96Button.BackColor = Color.DarkBlue;
                    player96Button.Enabled = false;
                }
                if (player98Button.BackColor != Color.Gray)
                {
                    player98Button.BackColor = Color.DarkBlue;
                    player98Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.Enabled = true;
                    player77Button.BackColor = Color.Aqua;
                }
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.Enabled = true;
                    player86Button.BackColor = Color.Aqua;
                }
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.Enabled = true;
                    player88Button.BackColor = Color.Aqua;
                }
                if (player97Button.BackColor != Color.Gray)
                {
                    player97Button.Enabled = true;
                    player97Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 87;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player86Button.BackColor != Color.Gray)
                    {
                        player86Button.Enabled = true;
                        player86Button.BackColor = Color.Aqua;
                    }
                    if (player88Button.BackColor != Color.Gray)
                    {
                        player88Button.Enabled = true;
                        player88Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player77Button.BackColor != Color.Gray)
                    {
                        player77Button.Enabled = true;
                        player77Button.BackColor = Color.Aqua;
                    }
                    if (player97Button.BackColor != Color.Gray)
                    {
                        player97Button.Enabled = true;
                        player97Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player88Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(88);
            placedCount++;
            player88Button.BackColor = Color.Gray;
            player88Button.Enabled = false;
            shipCheck[88] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 88;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player77Button.BackColor != Color.Gray)
                {
                    player77Button.BackColor = Color.DarkBlue;
                    player77Button.Enabled = false;
                }
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.BackColor = Color.DarkBlue;
                    player79Button.Enabled = false;
                }
                if (player97Button.BackColor != Color.Gray)
                {
                    player97Button.BackColor = Color.DarkBlue;
                    player97Button.Enabled = false;
                }
                if (player99Button.BackColor != Color.Gray)
                {
                    player99Button.BackColor = Color.DarkBlue;
                    player99Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.Enabled = true;
                    player78Button.BackColor = Color.Aqua;
                }
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.Enabled = true;
                    player87Button.BackColor = Color.Aqua;
                }
                if (player89Button.BackColor != Color.Gray)
                {
                    player89Button.Enabled = true;
                    player89Button.BackColor = Color.Aqua;
                }
                if (player98Button.BackColor != Color.Gray)
                {
                    player98Button.Enabled = true;
                    player98Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 88;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player87Button.BackColor != Color.Gray)
                    {
                        player87Button.Enabled = true;
                        player87Button.BackColor = Color.Aqua;
                    }
                    if (player89Button.BackColor != Color.Gray)
                    {
                        player89Button.Enabled = true;
                        player89Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player78Button.BackColor != Color.Gray)
                    {
                        player78Button.Enabled = true;
                        player78Button.BackColor = Color.Aqua;
                    }
                    if (player98Button.BackColor != Color.Gray)
                    {
                        player98Button.Enabled = true;
                        player98Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player89Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(89);
            placedCount++;
            player89Button.BackColor = Color.Gray;
            player89Button.Enabled = false;
            shipCheck[89] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 89;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player78Button.BackColor != Color.Gray)
                {
                    player78Button.BackColor = Color.DarkBlue;
                    player78Button.Enabled = false;
                }
                if (player80Button.BackColor != Color.Gray)
                {
                    player80Button.BackColor = Color.DarkBlue;
                    player80Button.Enabled = false;
                }
                if (player98Button.BackColor != Color.Gray)
                {
                    player98Button.BackColor = Color.DarkBlue;
                    player98Button.Enabled = false;
                }
                if (player100Button.BackColor != Color.Gray)
                {
                    player100Button.BackColor = Color.DarkBlue;
                    player100Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.Enabled = true;
                    player79Button.BackColor = Color.Aqua;
                }
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.Enabled = true;
                    player88Button.BackColor = Color.Aqua;
                }
                if (player90Button.BackColor != Color.Gray)
                {
                    player90Button.Enabled = true;
                    player90Button.BackColor = Color.Aqua;
                }
                if (player99Button.BackColor != Color.Gray)
                {
                    player99Button.Enabled = true;
                    player99Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 89;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player88Button.BackColor != Color.Gray)
                    {
                        player88Button.Enabled = true;
                        player88Button.BackColor = Color.Aqua;
                    }
                    if (player90Button.BackColor != Color.Gray)
                    {
                        player90Button.Enabled = true;
                        player90Button.BackColor = Color.Aqua;
                    }
                }
                if (vertical == true)
                {
                    if (player79Button.BackColor != Color.Gray)
                    {
                        player79Button.Enabled = true;
                        player79Button.BackColor = Color.Aqua;
                    }
                    if (player99Button.BackColor != Color.Gray)
                    {
                        player99Button.Enabled = true;
                        player99Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player90Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(90);
            placedCount++;
            player90Button.BackColor = Color.Gray;
            player90Button.Enabled = false;
            shipCheck[90] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 90;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player79Button.BackColor != Color.Gray)
                {
                    player79Button.BackColor = Color.DarkBlue;
                    player79Button.Enabled = false;
                }
                if (player99Button.BackColor != Color.Gray)
                {
                    player99Button.BackColor = Color.DarkBlue;
                    player99Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player80Button.BackColor != Color.Gray)
                {
                    player80Button.Enabled = true;
                    player80Button.BackColor = Color.Aqua;
                }
                if (player89Button.BackColor != Color.Gray)
                {
                    player89Button.Enabled = true;
                    player89Button.BackColor = Color.Aqua;
                }
                if (player100Button.BackColor != Color.Gray)
                {
                    player100Button.Enabled = true;
                    player100Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 90;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (vertical == true)
                {
                    if (player80Button.BackColor != Color.Gray)
                    {
                        player80Button.Enabled = true;
                        player80Button.BackColor = Color.Aqua;
                    }
                    if (player100Button.BackColor != Color.Gray)
                    {
                        player100Button.Enabled = true;
                        player100Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player91Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(91);
            placedCount++;
            player91Button.BackColor = Color.Gray;
            player91Button.Enabled = false;
            shipCheck[91] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 91;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.BackColor = Color.DarkBlue;
                    player82Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player81Button.BackColor != Color.Gray)
                {
                    player81Button.Enabled = true;
                    player81Button.BackColor = Color.Aqua;
                }
                if (player92Button.BackColor != Color.Gray)
                {
                    player92Button.Enabled = true;
                    player92Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 91;
                secondPlaced = true;
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player92Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(92);
            placedCount++;
            player92Button.BackColor = Color.Gray;
            player92Button.Enabled = false;
            shipCheck[92] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 92;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player81Button.BackColor != Color.Gray)
                {
                    player81Button.BackColor = Color.DarkBlue;
                    player81Button.Enabled = false;
                }
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.BackColor = Color.DarkBlue;
                    player83Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.Enabled = true;
                    player82Button.BackColor = Color.Aqua;
                }
                if (player91Button.BackColor != Color.Gray)
                {
                    player91Button.Enabled = true;
                    player91Button.BackColor = Color.Aqua;
                }
                if (player93Button.BackColor != Color.Gray)
                {
                    player93Button.Enabled = true;
                    player93Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 92;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player91Button.BackColor != Color.Gray)
                    {
                        player91Button.Enabled = true;
                        player91Button.BackColor = Color.Aqua;
                    }
                    if (player93Button.BackColor != Color.Gray)
                    {
                        player93Button.Enabled = true;
                        player93Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player93Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(93);
            placedCount++;
            player93Button.BackColor = Color.Gray;
            player93Button.Enabled = false;
            shipCheck[93] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 93;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player82Button.BackColor != Color.Gray)
                {
                    player82Button.BackColor = Color.DarkBlue;
                    player82Button.Enabled = false;
                }
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.BackColor = Color.DarkBlue;
                    player84Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.Enabled = true;
                    player83Button.BackColor = Color.Aqua;
                }
                if (player92Button.BackColor != Color.Gray)
                {
                    player92Button.Enabled = true;
                    player92Button.BackColor = Color.Aqua;
                }
                if (player94Button.BackColor != Color.Gray)
                {
                    player94Button.Enabled = true;
                    player94Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 93;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player92Button.BackColor != Color.Gray)
                    {
                        player92Button.Enabled = true;
                        player92Button.BackColor = Color.Aqua;
                    }
                    if (player94Button.BackColor != Color.Gray)
                    {
                        player94Button.Enabled = true;
                        player94Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player94Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(94);
            placedCount++;
            player94Button.BackColor = Color.Gray;
            player94Button.Enabled = false;
            shipCheck[94] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 94;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player83Button.BackColor != Color.Gray)
                {
                    player83Button.BackColor = Color.DarkBlue;
                    player83Button.Enabled = false;
                }
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.BackColor = Color.DarkBlue;
                    player85Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.Enabled = true;
                    player84Button.BackColor = Color.Aqua;
                }
                if (player93Button.BackColor != Color.Gray)
                {
                    player93Button.Enabled = true;
                    player93Button.BackColor = Color.Aqua;
                }
                if (player95Button.BackColor != Color.Gray)
                {
                    player95Button.Enabled = true;
                    player95Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 94;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player93Button.BackColor != Color.Gray)
                    {
                        player93Button.Enabled = true;
                        player93Button.BackColor = Color.Aqua;
                    }
                    if (player95Button.BackColor != Color.Gray)
                    {
                        player95Button.Enabled = true;
                        player95Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player95Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(95);
            placedCount++;
            player95Button.BackColor = Color.Gray;
            player95Button.Enabled = false;
            shipCheck[95] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 95;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player84Button.BackColor != Color.Gray)
                {
                    player84Button.BackColor = Color.DarkBlue;
                    player84Button.Enabled = false;
                }
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.BackColor = Color.DarkBlue;
                    player86Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.Enabled = true;
                    player85Button.BackColor = Color.Aqua;
                }
                if (player94Button.BackColor != Color.Gray)
                {
                    player94Button.Enabled = true;
                    player94Button.BackColor = Color.Aqua;
                }
                if (player96Button.BackColor != Color.Gray)
                {
                    player96Button.Enabled = true;
                    player96Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 95;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player94Button.BackColor != Color.Gray)
                    {
                        player94Button.Enabled = true;
                        player94Button.BackColor = Color.Aqua;
                    }
                    if (player96Button.BackColor != Color.Gray)
                    {
                        player96Button.Enabled = true;
                        player96Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player96Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(96);
            placedCount++;
            player96Button.BackColor = Color.Gray;
            player96Button.Enabled = false;
            shipCheck[96] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 96;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player85Button.BackColor != Color.Gray)
                {
                    player85Button.BackColor = Color.DarkBlue;
                    player85Button.Enabled = false;
                }
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.BackColor = Color.DarkBlue;
                    player87Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.Enabled = true;
                    player86Button.BackColor = Color.Aqua;
                }
                if (player95Button.BackColor != Color.Gray)
                {
                    player95Button.Enabled = true;
                    player95Button.BackColor = Color.Aqua;
                }
                if (player97Button.BackColor != Color.Gray)
                {
                    player97Button.Enabled = true;
                    player97Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 96;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player95Button.BackColor != Color.Gray)
                    {
                        player95Button.Enabled = true;
                        player95Button.BackColor = Color.Aqua;
                    }
                    if (player97Button.BackColor != Color.Gray)
                    {
                        player97Button.Enabled = true;
                        player97Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player97Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(97);
            placedCount++;
            player97Button.BackColor = Color.Gray;
            player97Button.Enabled = false;
            shipCheck[97] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 97;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player86Button.BackColor != Color.Gray)
                {
                    player86Button.BackColor = Color.DarkBlue;
                    player86Button.Enabled = false;
                }
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.BackColor = Color.DarkBlue;
                    player88Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.Enabled = true;
                    player87Button.BackColor = Color.Aqua;
                }
                if (player96Button.BackColor != Color.Gray)
                {
                    player96Button.Enabled = true;
                    player96Button.BackColor = Color.Aqua;
                }
                if (player98Button.BackColor != Color.Gray)
                {
                    player98Button.Enabled = true;
                    player98Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 97;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player96Button.BackColor != Color.Gray)
                    {
                        player96Button.Enabled = true;
                        player96Button.BackColor = Color.Aqua;
                    }
                    if (player98Button.BackColor != Color.Gray)
                    {
                        player98Button.Enabled = true;
                        player98Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player98Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(98);
            placedCount++;
            player98Button.BackColor = Color.Gray;
            player98Button.Enabled = false;
            shipCheck[98] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 98;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player87Button.BackColor != Color.Gray)
                {
                    player87Button.BackColor = Color.DarkBlue;
                    player87Button.Enabled = false;
                }
                if (player89Button.BackColor != Color.Gray)
                {
                    player89Button.BackColor = Color.DarkBlue;
                    player89Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.Enabled = true;
                    player88Button.BackColor = Color.Aqua;
                }
                if (player97Button.BackColor != Color.Gray)
                {
                    player97Button.Enabled = true;
                    player97Button.BackColor = Color.Aqua;
                }
                if (player99Button.BackColor != Color.Gray)
                {
                    player99Button.Enabled = true;
                    player99Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 98;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player97Button.BackColor != Color.Gray)
                    {
                        player97Button.Enabled = true;
                        player97Button.BackColor = Color.Aqua;
                    }
                    if (player99Button.BackColor != Color.Gray)
                    {
                        player99Button.Enabled = true;
                        player99Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player99Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(99);
            placedCount++;
            player99Button.BackColor = Color.Gray;
            player99Button.Enabled = false;
            shipCheck[99] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 99;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player88Button.BackColor != Color.Gray)
                {
                    player88Button.BackColor = Color.DarkBlue;
                    player88Button.Enabled = false;
                }
                if (player90Button.BackColor != Color.Gray)
                {
                    player90Button.BackColor = Color.DarkBlue;
                    player90Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player80Button.BackColor != Color.Gray)
                {
                    player89Button.Enabled = true;
                    player89Button.BackColor = Color.Aqua;
                }
                if (player98Button.BackColor != Color.Gray)
                {
                    player98Button.Enabled = true;
                    player98Button.BackColor = Color.Aqua;
                }
                if (player100Button.BackColor != Color.Gray)
                {
                    player100Button.Enabled = true;
                    player100Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 99;
                secondPlaced = true;
            }

            if (vertical == true || horizontal == true)
            {
                if (horizontal == true)
                {
                    if (player98Button.BackColor != Color.Gray)
                    {
                        player98Button.Enabled = true;
                        player98Button.BackColor = Color.Aqua;
                    }
                    if (player100Button.BackColor != Color.Gray)
                    {
                        player100Button.Enabled = true;
                        player100Button.BackColor = Color.Aqua;
                    }
                }
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

        private void player100Button_Click(object sender, EventArgs e)
        {
            playerShips.Add(100);
            placedCount++;
            player100Button.BackColor = Color.Gray;
            player100Button.Enabled = false;
            shipCheck[100] = true;

            if (secondPlaced == true)
            {
                currentPlacedInt = 100;
                secondPlaced = false;
                while (directionCheck < 100)
                {
                    directionCheck = directionCheck + 10;
                    if (currentPlacedInt + directionCheck == firstPlacedInt)
                    {
                        vertical = true;
                    }
                }
                if (vertical != true)
                {
                    horizontal = true;
                }
                if (player89Button.BackColor != Color.Gray)
                {
                    player89Button.BackColor = Color.DarkBlue;
                    player89Button.Enabled = false;
                }
            }
            else if (firstPlaced == true)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (player90Button.BackColor != Color.Gray)
                {
                    player90Button.Enabled = true;
                    player90Button.BackColor = Color.Aqua;
                }
                if (player99Button.BackColor != Color.Gray)
                {
                    player99Button.Enabled = true;
                    player99Button.BackColor = Color.Aqua;
                }
                firstPlaced = false;
                firstPlacedInt = 100;
                secondPlaced = true;
            }

            resetButton.Enabled = true;

            if (placedCount == shipSpaces)
            {
                shipsPlaced++;
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                if (patrolBoatPlaced == false)
                {
                    patrolBoatButton.Enabled = true;
                }
                if (submarinePlaced == false)
                {
                    submarineButton.Enabled = true;
                }
                if (destroyerPlaced == false)
                {
                    destroyerButton.Enabled = true;
                }
                if (battleshipPlaced == false)
                {
                    battleshipButton.Enabled = true;
                }
                if (carrierPlaced == false)
                {
                    carrierButton.Enabled = true;
                }
                if (shipsPlaced == 5)
                {
                    allShipsPlaced = true;
                    computerButtonsEnabled_Click(sender, e);
                }
                resetButton.Enabled = true;
            }
        }

 
        //runs all the buttons on the computer's side of the board when the game is active they are all roughly the same
        private void computer1Button_Click(object sender, EventArgs e)
        {
            //disables you from shooting the same space twice
            computer1Button.Enabled = false;
            //checks if the enemy ship is in this spot
            if (enemyShips.Contains(1))
            {
                //removes the ships space number from the list 
                enemyShips.Remove(1);
                //changes the colour to red to represent a hit
                computer1Button.BackColor = Color.Red;
            }
            //runs if there is no ship in this spot
            else
            {
                //changes the colour to white to represent a miss
                computer1Button.BackColor = Color.White;
                //runs the computer move button so the computer can shoot back if you miss
                computerMove_Click(sender, e);
            }

            //checks to see if the enemy has no ships left on the board
            if (enemyShips.Count == 0)
            {
                //disables all the buttons
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                //enables the reset button
                resetButton.Enabled = true;

                //changes the text of a label to tell you that you won
                displayLabel.Text = "You Win";
                //makes the label visable
                displayLabel.Visible = true;
            }
            //checks to see if you have ran out of ships
            if (playerShips.Count == 0)
            {
                //disables all the buttons
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;
                
                //enables the reset button
                resetButton.Enabled = true;

                //changes the text of a label to tell you that you lost
                displayLabel.Text = "You Lose";
                //makes the label visable
                displayLabel.Visible = true;
            }
        }
        private void computer2Button_Click(object sender, EventArgs e)
        {
            computer2Button.Enabled = false;
            if (enemyShips.Contains(2))
            {
                enemyShips.Remove(2);
                computer2Button.BackColor = Color.Red;
            }
            else
            {
                computer2Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer3Button_Click(object sender, EventArgs e)
        {
            computer3Button.Enabled = false;
            if (enemyShips.Contains(3))
            {
                enemyShips.Remove(3);
                computer3Button.BackColor = Color.Red;
            }
            else
            {
                computer3Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer4Button_Click(object sender, EventArgs e)
        {
            computer4Button.Enabled = false;
            if (enemyShips.Contains(4))
            {
                enemyShips.Remove(4);
                computer4Button.BackColor = Color.Red;
            }
            else
            {
                computer4Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer5Button_Click(object sender, EventArgs e)
        {
            computer5Button.Enabled = false;
            if (enemyShips.Contains(5))
            {
                enemyShips.Remove(5);
                computer5Button.BackColor = Color.Red;
            }
            else
            {
                computer5Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer6Button_Click(object sender, EventArgs e)
        {
            computer6Button.Enabled = false;
            if (enemyShips.Contains(6))
            {
                enemyShips.Remove(6);
                computer6Button.BackColor = Color.Red;
            }
            else
            {
                computer6Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer7Button_Click(object sender, EventArgs e)
        {
            computer7Button.Enabled = false;
            if (enemyShips.Contains(7))
            {
                enemyShips.Remove(7);
                computer7Button.BackColor = Color.Red;
            }
            else
            {
                computer7Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer8Button_Click(object sender, EventArgs e)
        {
            computer8Button.Enabled = false;
            if (enemyShips.Contains(8))
            {
                enemyShips.Remove(8);
                computer8Button.BackColor = Color.Red;
            }
            else
            {
                computer8Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer9Button_Click(object sender, EventArgs e)
        {
            computer9Button.Enabled = false;
            if (enemyShips.Contains(9))
            {
                enemyShips.Remove(9);
                computer9Button.BackColor = Color.Red;
            }
            else
            {
                computer9Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer10Button_Click(object sender, EventArgs e)
        {
            computer10Button.Enabled = false;
            if (enemyShips.Contains(10))
            {
                enemyShips.Remove(10);
                computer10Button.BackColor = Color.Red;
            }
            else
            {
                computer10Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer11Button_Click(object sender, EventArgs e)
        {
            computer11Button.Enabled = false;
            if (enemyShips.Contains(11))
            {
                enemyShips.Remove(11);
                computer11Button.BackColor = Color.Red;
            }
            else
            {
                computer11Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer12Button_Click(object sender, EventArgs e)
        {
            computer12Button.Enabled = false;
            if (enemyShips.Contains(12))
            {
                enemyShips.Remove(12);
                computer12Button.BackColor = Color.Red;
            }
            else
            {
                computer12Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer13Button_Click(object sender, EventArgs e)
        {
            computer13Button.Enabled = false;
            if (enemyShips.Contains(13))
            {
                enemyShips.Remove(13);
                computer13Button.BackColor = Color.Red;
            }
            else
            {
                computer13Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer14Button_Click(object sender, EventArgs e)
        {
            computer14Button.Enabled = false;
            if (enemyShips.Contains(14))
            {
                enemyShips.Remove(14);
                computer14Button.BackColor = Color.Red;
            }
            else
            {
                computer14Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer15Button_Click(object sender, EventArgs e)
        {
            computer15Button.Enabled = false;
            if (enemyShips.Contains(15))
            {
                enemyShips.Remove(15);
                computer15Button.BackColor = Color.Red;
            }
            else
            {
                computer15Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer16Button_Click(object sender, EventArgs e)
        {
            computer16Button.Enabled = false;
            if (enemyShips.Contains(16))
            {
                enemyShips.Remove(16);
                computer16Button.BackColor = Color.Red;
            }
            else
            {
                computer16Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer17Button_Click(object sender, EventArgs e)
        {
            computer17Button.Enabled = false;
            if (enemyShips.Contains(17))
            {
                enemyShips.Remove(17);
                computer17Button.BackColor = Color.Red;
            }
            else
            {
                computer17Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer18Button_Click(object sender, EventArgs e)
        {
            computer18Button.Enabled = false;
            if (enemyShips.Contains(18))
            {
                enemyShips.Remove(18);
                computer18Button.BackColor = Color.Red;
            }
            else
            {
                computer18Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer19Button_Click(object sender, EventArgs e)
        {
            computer19Button.Enabled = false;
            if (enemyShips.Contains(19))
            {
                enemyShips.Remove(19);
                computer19Button.BackColor = Color.Red;
            }
            else
            {
                computer19Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer20Button_Click(object sender, EventArgs e)
        {
            computer20Button.Enabled = false;
            if (enemyShips.Contains(20))
            {
                enemyShips.Remove(20);
                computer20Button.BackColor = Color.Red;
            }
            else
            {
                computer20Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer21Button_Click(object sender, EventArgs e)
        {
            computer21Button.Enabled = false;
            if (enemyShips.Contains(21))
            {
                enemyShips.Remove(21);
                computer21Button.BackColor = Color.Red;
            }
            else
            {
                computer21Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer22Button_Click(object sender, EventArgs e)
        {
            computer22Button.Enabled = false;
            if (enemyShips.Contains(22))
            {
                enemyShips.Remove(22);
                computer22Button.BackColor = Color.Red;
            }
            else
            {
                computer22Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer23Button_Click(object sender, EventArgs e)
        {
            computer23Button.Enabled = false;
            if (enemyShips.Contains(23))
            {
                enemyShips.Remove(23);
                computer23Button.BackColor = Color.Red;
            }
            else
            {
                computer23Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer24Button_Click(object sender, EventArgs e)
        {
            computer24Button.Enabled = false;
            if (enemyShips.Contains(24))
            {
                enemyShips.Remove(24);
                computer24Button.BackColor = Color.Red;
            }
            else
            {
                computer24Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer25Button_Click(object sender, EventArgs e)
        {
            computer25Button.Enabled = false;
            if (enemyShips.Contains(25))
            {
                enemyShips.Remove(25);
                computer25Button.BackColor = Color.Red;
            }
            else
            {
                computer25Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer26Button_Click(object sender, EventArgs e)
        {
            computer26Button.Enabled = false;
            if (enemyShips.Contains(26))
            {
                enemyShips.Remove(26);
                computer26Button.BackColor = Color.Red;
            }
            else
            {
                computer26Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer27Button_Click(object sender, EventArgs e)
        {
            computer27Button.Enabled = false;
            if (enemyShips.Contains(27))
            {
                enemyShips.Remove(27);
                computer27Button.BackColor = Color.Red;
            }
            else
            {
                computer27Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer28Button_Click(object sender, EventArgs e)
        {
            computer28Button.Enabled = false;
            if (enemyShips.Contains(28))
            {
                enemyShips.Remove(28);
                computer28Button.BackColor = Color.Red;
            }
            else
            {
                computer28Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer29Button_Click(object sender, EventArgs e)
        {
            computer29Button.Enabled = false;
            if (enemyShips.Contains(29))
            {
                enemyShips.Remove(29);
                computer29Button.BackColor = Color.Red;
            }
            else
            {
                computer29Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer30Button_Click(object sender, EventArgs e)
        {
            computer30Button.Enabled = false;
            if (enemyShips.Contains(30))
            {
                enemyShips.Remove(30);
                computer30Button.BackColor = Color.Red;
            }
            else
            {
                computer30Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer31Button_Click(object sender, EventArgs e)
        {
            computer31Button.Enabled = false;
            if (enemyShips.Contains(31))
            {
                enemyShips.Remove(31);
                computer31Button.BackColor = Color.Red;
            }
            else
            {
                computer31Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer32Button_Click(object sender, EventArgs e)
        {
            computer32Button.Enabled = false;
            if (enemyShips.Contains(32))
            {
                enemyShips.Remove(32);
                computer32Button.BackColor = Color.Red;
            }
            else
            {
                computer32Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer33Button_Click(object sender, EventArgs e)
        {
            computer33Button.Enabled = false;
            if (enemyShips.Contains(33))
            {
                enemyShips.Remove(33);
                computer33Button.BackColor = Color.Red;
            }
            else
            {
                computer33Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer34Button_Click(object sender, EventArgs e)
        {
            computer34Button.Enabled = false;
            if (enemyShips.Contains(34))
            {
                enemyShips.Remove(34);
                computer34Button.BackColor = Color.Red;
            }
            else
            {
                computer34Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer35Button_Click(object sender, EventArgs e)
        {
            computer35Button.Enabled = false;
            if (enemyShips.Contains(35))
            {
                enemyShips.Remove(35);
                computer35Button.BackColor = Color.Red;
            }
            else
            {
                computer35Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer36Button_Click(object sender, EventArgs e)
        {
            computer36Button.Enabled = false;
            if (enemyShips.Contains(36))
            {
                enemyShips.Remove(36);
                computer36Button.BackColor = Color.Red;
            }
            else
            {
                computer36Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer37Button_Click(object sender, EventArgs e)
        {
            computer37Button.Enabled = false;
            if (enemyShips.Contains(37))
            {
                enemyShips.Remove(37);
                computer37Button.BackColor = Color.Red;
            }
            else
            {
                computer37Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer38Button_Click(object sender, EventArgs e)
        {
            computer38Button.Enabled = false;
            if (enemyShips.Contains(38))
            {
                enemyShips.Remove(38);
                computer38Button.BackColor = Color.Red;
            }
            else
            {
                computer38Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer39Button_Click(object sender, EventArgs e)
        {
            computer39Button.Enabled = false;
            if (enemyShips.Contains(39))
            {
                enemyShips.Remove(39);
                computer39Button.BackColor = Color.Red;
            }
            else
            {
                computer39Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer40Button_Click(object sender, EventArgs e)
        {
            computer40Button.Enabled = false;
            if (enemyShips.Contains(40))
            {
                enemyShips.Remove(40);
                computer40Button.BackColor = Color.Red;
            }
            else
            {
                computer40Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer41Button_Click(object sender, EventArgs e)
        {
            computer41Button.Enabled = false;
            if (enemyShips.Contains(41))
            {
                enemyShips.Remove(41);
                computer41Button.BackColor = Color.Red;
            }
            else
            {
                computer41Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer42Button_Click(object sender, EventArgs e)
        {
            computer42Button.Enabled = false;
            if (enemyShips.Contains(42))
            {
                enemyShips.Remove(42);
                computer42Button.BackColor = Color.Red;
            }
            else
            {
                computer42Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer43Button_Click(object sender, EventArgs e)
        {
            computer43Button.Enabled = false;
            if (enemyShips.Contains(43))
            {
                enemyShips.Remove(43);
                computer43Button.BackColor = Color.Red;
            }
            else
            {
                computer43Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer44Button_Click(object sender, EventArgs e)
        {
            computer44Button.Enabled = false;
            if (enemyShips.Contains(44))
            {
                enemyShips.Remove(44);
                computer44Button.BackColor = Color.Red;
            }
            else
            {
                computer44Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer45Button_Click(object sender, EventArgs e)
        {
            computer45Button.Enabled = false;
            if (enemyShips.Contains(45))
            {
                enemyShips.Remove(45);
                computer45Button.BackColor = Color.Red;
            }
            else
            {
                computer45Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer46Button_Click(object sender, EventArgs e)
        {
            computer46Button.Enabled = false;
            if (enemyShips.Contains(46))
            {
                enemyShips.Remove(46);
                computer46Button.BackColor = Color.Red;
            }
            else
            {
                computer46Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer47Button_Click(object sender, EventArgs e)
        {
            computer47Button.Enabled = false;
            if (enemyShips.Contains(47))
            {
                enemyShips.Remove(47);
                computer47Button.BackColor = Color.Red;
            }
            else
            {
                computer47Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer48Button_Click(object sender, EventArgs e)
        {
            computer48Button.Enabled = false;
            if (enemyShips.Contains(48))
            {
                enemyShips.Remove(48);
                computer48Button.BackColor = Color.Red;
            }
            else
            {
                computer48Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer49Button_Click(object sender, EventArgs e)
        {
            computer49Button.Enabled = false;
            if (enemyShips.Contains(49))
            {
                enemyShips.Remove(49);
                computer49Button.BackColor = Color.Red;
            }
            else
            {
                computer49Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer50Button_Click(object sender, EventArgs e)
        {
            computer50Button.Enabled = false;
            if (enemyShips.Contains(50))
            {
                enemyShips.Remove(50);
                computer50Button.BackColor = Color.Red;
            }
            else
            {
                computer50Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer51Button_Click(object sender, EventArgs e)
        {
            computer51Button.Enabled = false;
            if (enemyShips.Contains(51))
            {
                enemyShips.Remove(51);
                computer51Button.BackColor = Color.Red;
            }
            else
            {
                computer51Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer52Button_Click(object sender, EventArgs e)
        {
            computer52Button.Enabled = false;
            if (enemyShips.Contains(52))
            {
                enemyShips.Remove(52);
                computer52Button.BackColor = Color.Red;
            }
            else
            {
                computer52Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer53Button_Click(object sender, EventArgs e)
        {
            computer53Button.Enabled = false;
            if (enemyShips.Contains(53))
            {
                enemyShips.Remove(53);
                computer53Button.BackColor = Color.Red;
            }
            else
            {
                computer53Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer54Button_Click(object sender, EventArgs e)
        {
            computer54Button.Enabled = false;
            if (enemyShips.Contains(54))
            {
                enemyShips.Remove(54);
                computer54Button.BackColor = Color.Red;
            }
            else
            {
                computer54Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer55Button_Click(object sender, EventArgs e)
        {
            computer55Button.Enabled = false;
            if (enemyShips.Contains(55))
            {
                enemyShips.Remove(55);
                computer55Button.BackColor = Color.Red;
            }
            else
            {
                computer55Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer56Button_Click(object sender, EventArgs e)
        {
            computer56Button.Enabled = false;
            if (enemyShips.Contains(56))
            {
                enemyShips.Remove(56);
                computer56Button.BackColor = Color.Red;
            }
            else
            {
                computer56Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer57Button_Click(object sender, EventArgs e)
        {
            computer57Button.Enabled = false;
            if (enemyShips.Contains(57))
            {
                enemyShips.Remove(57);
                computer57Button.BackColor = Color.Red;
            }
            else
            {
                computer57Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer58Button_Click(object sender, EventArgs e)
        {
            computer58Button.Enabled = false;
            if (enemyShips.Contains(58))
            {
                enemyShips.Remove(58);
                computer58Button.BackColor = Color.Red;
            }
            else
            {
                computer58Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer59Button_Click(object sender, EventArgs e)
        {
            computer59Button.Enabled = false;
            if (enemyShips.Contains(59))
            {
                enemyShips.Remove(59);
                computer59Button.BackColor = Color.Red;
            }
            else
            {
                computer59Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer60Button_Click(object sender, EventArgs e)
        {
            computer60Button.Enabled = false;
            if (enemyShips.Contains(60))
            {
                enemyShips.Remove(60);
                computer60Button.BackColor = Color.Red;
            }
            else
            {
                computer60Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer61Button_Click(object sender, EventArgs e)
        {
            computer61Button.Enabled = false;
            if (enemyShips.Contains(61))
            {
                enemyShips.Remove(61);
                computer61Button.BackColor = Color.Red;
            }
            else
            {
                computer61Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer62Button_Click(object sender, EventArgs e)
        {
            computer62Button.Enabled = false;
            if (enemyShips.Contains(62))
            {
                enemyShips.Remove(62);
                computer62Button.BackColor = Color.Red;
            }
            else
            {
                computer62Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer63Button_Click(object sender, EventArgs e)
        {
            computer63Button.Enabled = false;
            if (enemyShips.Contains(63))
            {
                enemyShips.Remove(63);
                computer63Button.BackColor = Color.Red;
            }
            else
            {
                computer63Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer64Button_Click(object sender, EventArgs e)
        {
            computer64Button.Enabled = false;
            if (enemyShips.Contains(64))
            {
                enemyShips.Remove(64);
                computer64Button.BackColor = Color.Red;
            }
            else
            {
                computer64Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer65Button_Click(object sender, EventArgs e)
        {
            computer65Button.Enabled = false;
            if (enemyShips.Contains(65))
            {
                enemyShips.Remove(65);
                computer65Button.BackColor = Color.Red;
            }
            else
            {
                computer65Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer66Button_Click(object sender, EventArgs e)
        {
            computer66Button.Enabled = false;
            if (enemyShips.Contains(66))
            {
                enemyShips.Remove(66);
                computer66Button.BackColor = Color.Red;
            }
            else
            {
                computer66Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer67Button_Click(object sender, EventArgs e)
        {
            computer67Button.Enabled = false;
            if (enemyShips.Contains(67))
            {
                enemyShips.Remove(67);
                computer67Button.BackColor = Color.Red;
            }
            else
            {
                computer67Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer68Button_Click(object sender, EventArgs e)
        {
            computer68Button.Enabled = false;
            if (enemyShips.Contains(68))
            {
                enemyShips.Remove(68);
                computer68Button.BackColor = Color.Red;
            }
            else
            {
                computer68Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer69Button_Click(object sender, EventArgs e)
        {
            computer69Button.Enabled = false;
            if (enemyShips.Contains(69))
            {
                enemyShips.Remove(69);
                computer69Button.BackColor = Color.Red;
            }
            else
            {
                computer69Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer70Button_Click(object sender, EventArgs e)
        {
            computer70Button.Enabled = false;
            if (enemyShips.Contains(70))
            {
                enemyShips.Remove(70);
                computer70Button.BackColor = Color.Red;
            }
            else
            {
                computer70Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer71Button_Click(object sender, EventArgs e)
        {
            computer71Button.Enabled = false;
            if (enemyShips.Contains(71))
            {
                enemyShips.Remove(71);
                computer71Button.BackColor = Color.Red;
            }
            else
            {
                computer71Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer72Button_Click(object sender, EventArgs e)
        {
            computer72Button.Enabled = false;
            if (enemyShips.Contains(72))
            {
                enemyShips.Remove(72);
                computer72Button.BackColor = Color.Red;
            }
            else
            {
                computer72Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer73Button_Click(object sender, EventArgs e)
        {
            computer73Button.Enabled = false;
            if (enemyShips.Contains(73))
            {
                enemyShips.Remove(73);
                computer73Button.BackColor = Color.Red;
            }
            else
            {
                computer73Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer74Button_Click(object sender, EventArgs e)
        {
            computer74Button.Enabled = false;
            if (enemyShips.Contains(74))
            {
                enemyShips.Remove(74);
                computer74Button.BackColor = Color.Red;
            }
            else
            {
                computer74Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer75Button_Click(object sender, EventArgs e)
        {
            computer75Button.Enabled = false;
            if (enemyShips.Contains(75))
            {
                enemyShips.Remove(75);
                computer75Button.BackColor = Color.Red;
            }
            else
            {
                computer75Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer76Button_Click(object sender, EventArgs e)
        {
            computer76Button.Enabled = false;
            if (enemyShips.Contains(76))
            {
                enemyShips.Remove(76);
                computer76Button.BackColor = Color.Red;
            }
            else
            {
                computer76Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer77Button_Click(object sender, EventArgs e)
        {
            computer77Button.Enabled = false;
            if (enemyShips.Contains(77))
            {
                enemyShips.Remove(77);
                computer77Button.BackColor = Color.Red;
            }
            else
            {
                computer77Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer78Button_Click(object sender, EventArgs e)
        {
            computer78Button.Enabled = false;
            if (enemyShips.Contains(78))
            {
                enemyShips.Remove(78);
                computer78Button.BackColor = Color.Red;
            }
            else
            {
                computer78Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer79Button_Click(object sender, EventArgs e)
        {
            computer79Button.Enabled = false;
            if (enemyShips.Contains(79))
            {
                enemyShips.Remove(79);
                computer79Button.BackColor = Color.Red;
            }
            else
            {
                computer79Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer80Button_Click(object sender, EventArgs e)
        {
            computer80Button.Enabled = false;
            if (enemyShips.Contains(80))
            {
                enemyShips.Remove(80);
                computer80Button.BackColor = Color.Red;
            }
            else
            {
                computer80Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer81Button_Click(object sender, EventArgs e)
        {
            computer81Button.Enabled = false;
            if (enemyShips.Contains(81))
            {
                enemyShips.Remove(81);
                computer81Button.BackColor = Color.Red;
            }
            else
            {
                computer81Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer82Button_Click(object sender, EventArgs e)
        {
            computer82Button.Enabled = false;
            if (enemyShips.Contains(82))
            {
                enemyShips.Remove(82);
                computer82Button.BackColor = Color.Red;
            }
            else
            {
                computer82Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer83Button_Click(object sender, EventArgs e)
        {
            computer83Button.Enabled = false;
            if (enemyShips.Contains(83))
            {
                enemyShips.Remove(83);
                computer83Button.BackColor = Color.Red;
            }
            else
            {
                computer83Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer84Button_Click(object sender, EventArgs e)
        {
            computer84Button.Enabled = false;
            if (enemyShips.Contains(84))
            {
                enemyShips.Remove(84);
                computer84Button.BackColor = Color.Red;
            }
            else
            {
                computer84Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer85Button_Click(object sender, EventArgs e)
        {
            computer85Button.Enabled = false;
            if (enemyShips.Contains(85))
            {
                enemyShips.Remove(85);
                computer85Button.BackColor = Color.Red;
            }
            else
            {
                computer85Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer86Button_Click(object sender, EventArgs e)
        {
            computer86Button.Enabled = false;
            if (enemyShips.Contains(86))
            {
                enemyShips.Remove(86);
                computer86Button.BackColor = Color.Red;
            }
            else
            {
                computer86Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer87Button_Click(object sender, EventArgs e)
        {
            computer87Button.Enabled = false;
            if (enemyShips.Contains(87))
            {
                enemyShips.Remove(87);
                computer87Button.BackColor = Color.Red;
            }
            else
            {
                computer87Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer88Button_Click(object sender, EventArgs e)
        {
            computer88Button.Enabled = false;
            if (enemyShips.Contains(88))
            {
                enemyShips.Remove(88);
                computer88Button.BackColor = Color.Red;
            }
            else
            {
                computer88Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer89Button_Click(object sender, EventArgs e)
        {
            computer89Button.Enabled = false;
            if (enemyShips.Contains(89))
            {
                enemyShips.Remove(89);
                computer89Button.BackColor = Color.Red;
            }
            else
            {
                computer89Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer90Button_Click(object sender, EventArgs e)
        {
            computer90Button.Enabled = false;
            if (enemyShips.Contains(90))
            {
                enemyShips.Remove(90);
                computer90Button.BackColor = Color.Red;
            }
            else
            {
                computer90Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer91Button_Click(object sender, EventArgs e)
        {
            computer91Button.Enabled = false;
            if (enemyShips.Contains(91))
            {
                enemyShips.Remove(91);
                computer91Button.BackColor = Color.Red;
            }
            else
            {
                computer91Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer92Button_Click(object sender, EventArgs e)
        {
            computer92Button.Enabled = false;
            if (enemyShips.Contains(92))
            {
                enemyShips.Remove(92);
                computer92Button.BackColor = Color.Red;
            }
            else
            {
                computer92Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer93Button_Click(object sender, EventArgs e)
        {
            computer93Button.Enabled = false;
            if (enemyShips.Contains(93))
            {
                enemyShips.Remove(93);
                computer93Button.BackColor = Color.Red;
            }
            else
            {
                computer93Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer94Button_Click(object sender, EventArgs e)
        {
            computer94Button.Enabled = false;
            if (enemyShips.Contains(94))
            {
                enemyShips.Remove(94);
                computer94Button.BackColor = Color.Red;
            }
            else
            {
                computer94Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer95Button_Click(object sender, EventArgs e)
        {
            computer95Button.Enabled = false;
            if (enemyShips.Contains(95))
            {
                enemyShips.Remove(95);
                computer95Button.BackColor = Color.Red;
            }
            else
            {
                computer95Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer96Button_Click(object sender, EventArgs e)
        {
            computer96Button.Enabled = false;
            if (enemyShips.Contains(96))
            {
                enemyShips.Remove(96);
                computer96Button.BackColor = Color.Red;
            }
            else
            {
                computer96Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer97Button_Click(object sender, EventArgs e)
        {
            computer97Button.Enabled = false;
            if (enemyShips.Contains(97))
            {
                enemyShips.Remove(97);
                computer97Button.BackColor = Color.Red;
            }
            else
            {
                computer97Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer98Button_Click(object sender, EventArgs e)
        {
            computer98Button.Enabled = false;
            if (enemyShips.Contains(98))
            {
                enemyShips.Remove(98);
                computer98Button.BackColor = Color.Red;
            }
            else
            {
                computer98Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer99Button_Click(object sender, EventArgs e)
        {
            computer99Button.Enabled = false;
            if (enemyShips.Contains(99))
            {
                enemyShips.Remove(99);
                computer99Button.BackColor = Color.Red;
            }
            else
            {
                computer99Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }
        private void computer100Button_Click(object sender, EventArgs e)
        {
            computer100Button.Enabled = false;
            if (enemyShips.Contains(100))
            {
                enemyShips.Remove(100);
                computer100Button.BackColor = Color.Red;
            }
            else
            {
                computer100Button.BackColor = Color.White;
                computerMove_Click(sender, e);
            }

            if (enemyShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Win";
                displayLabel.Visible = true;
            }
            if (playerShips.Count == 0)
            {
                foreach (Button button in this.Controls.OfType<Button>())
                    button.Enabled = false;

                resetButton.Enabled = true;

                displayLabel.Text = "You Lose";
                displayLabel.Visible = true;
            }
        }

    }
}
