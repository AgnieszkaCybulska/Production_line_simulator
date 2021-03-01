using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Production_line_simulator
{
    public partial class Production : Form
    {
        public Production(Login log)
        {
            InitializeComponent();

            loginWindow = log;
            pizza1.Height = pizza2.Height = pizza3.Height = pizzaHeight;
            pizza1.Width = pizza2.Width = pizza3.Width = pizzaWidth;
            pizza1.Left = -200;
            pizza2.Left = -500;
            pizza3.Left = -800;

            Random random = new Random();
            nextFailure = random.Next(100, 500);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //oven animation
            if(panel1.Location.Y == 0)
            {
                panel1.Top = 2;
            }
            else
            {
                panel1.Top = 0;
            }

            //conveyor belt animation
            string nameAnimationFrame = "_" + animationFrame.ToString("D4");    //padding with zeroes
            conveyor_belt.BackgroundImage = (Image)Production_line_simulator.Properties.Resources.ResourceManager.GetObject(nameAnimationFrame);
      
            animationFrame++;
            if(animationFrame > 36)
            {
                animationFrame = 0;
            }

            //pizza animation
            pizza1.Left += 4;
            pizza2.Left += 4;
            pizza3.Left += 4;

            move_pizza(pizza1);
            move_pizza(pizza2);
            move_pizza(pizza3);
        }
        private void move_pizza(PictureBox pizza)
        {
            if (pizza.Location.X >= this.Width)
            {
                pizza.Left = -200;
                pizza.Height = pizzaHeight;
                pizza.Width = pizzaWidth;
            }
        }

        private void move_ventilator(PictureBox ventPicture, bool ventilator)
        {
            string vent = "ventilator" + ventilatorFrame.ToString("D4");
            if (ventilator == true)
            {
                ventPicture.BackgroundImage = (Image)Production_line_simulator.Properties.Resources.ResourceManager.GetObject(vent);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            //ventilator animation
            move_ventilator(vent1, vent1Active);
            move_ventilator(vent2, vent2Active);
            move_ventilator(vent3, vent3Active);
            ventilatorFrame++;

            if (ventilatorFrame > 19)
            {
                ventilatorFrame = 0;
            }

            //fire animation
            if(turnFire)
            {
                string nameFire = "fire" + fireAnimation.ToString("D4");
                fire_pictureBox.BackgroundImage = (Image)Production_line_simulator.Properties.Resources.ResourceManager.GetObject(nameFire);
                fire_pictureBox.Visible = true;
                fireAnimation++;
                if(fireAnimation > 16)
                {
                    fireAnimation = 0;
                }
            }

            //information
            energy = (change_speed.Value * 0.35 + (double)ovenTemperature.Value * 0.3 + activeVents * 20) / 240 * 100;
            cpuCounter++;
            
            if(cpuCounter == 100)
            {
                processorConsumption = (int)cpu.NextValue();
                cpuCounter = 0;
            }
            string info = "";
            info += "Active ventilators: " + activeVents + "\n";
            info += "Oven temperature: " + ovenTemperature.Value + "°C\n";
            info += "Conveyor belt speed: " + (change_speed.Value + 10) + "%\n";
            info += "Size of pizza: " + change_size.Value + "g\n";
            info += "Processor consumption: " + processorConsumption + "%\n";
            info += "Energy consumption: " + (int)energy + "%";
            info_richTextBox.Text = info;

            //failure randomization
            Random random = new Random();
            failureCounter++;
            if(failureCounter > 3000)
            {
                failureCounter = 0;
                nextFailure = random.Next(100, 500);
            }
            if(failureCounter == nextFailure)
            {
                draw_failure();
            }

            //periodic confirmation of activity
            if(failureCounter % 100 == 0)
            {
                timeCounter--;
                if(timeCounter < 0)
                {
                    timeCounter = 10;
                    confirmationRequired = !confirmationRequired;
                }
                confirm_activity();
            }
            
            //failure information
            if(failure_activation() == "")
            {
                failureinfo_richTextBox.Text = "No current problems.";
                alarm_pictureBox.BackgroundImage = (Image)Production_line_simulator.Properties.Resources.alarm_off;
                
                if (confirmationRequired && timeCounter <= 3 && turnAlarm == false)
                {
                    alarmSound.PlayLooping();
                    turnAlarm = true;
                }
                else if(!(confirmationRequired && (timeCounter <= 3)))
                {
                    alarmSound.Stop();
                    turnAlarm = false;
                }
                timeFailureCounter = 10;
            }
            else
            {
                failureinfo_richTextBox.Text = "Time to fix the failure: " + timeFailureCounter + "s\n" + failure_activation();
                alarm_pictureBox.BackgroundImage = (Image)Production_line_simulator.Properties.Resources.alarm_on;

                if(turnAlarm == false)
                {
                    alarmSound.PlayLooping();
                    turnAlarm = true;
                }
                if(timeFailureCounter == 0)
                {
                    turnFire = true;
                }
                if(timeFailureCounter == -2)
                {
                    this.Close();
                }
                if (failureCounter % 50 == 0)
                {
                    timeFailureCounter--;
                }
            }
        }

        private void draw_failure()
        {
            Random random = new Random();

            //turn on/turn off the ventilature
            if(nextFailure % 3 == 0)
            {
                vent1_button.PerformClick();
            }
            if(nextFailure % 4 == 0)
            {
                vent2_button.PerformClick();
            }
            if(nextFailure % 5 == 0)
            {
                vent3_button.PerformClick();
            }

            //random oven temperature
            ovenTemperature.Value = random.Next(230, 620);

            //random conveyor belt speed
            change_speed.Value = random.Next(0, 90);

            //random size of pizza
            change_size.Value = random.Next(140, 280);
        }
        private string failure_activation()
        {
            string failureInfo = "";
            if(ovenTemperature.Value < 300 && activeVents == 3)
            {
                failureInfo += "Temperature is too low! Increase the oven temperature or turn off one ventilator.\n";
            }
            if(ovenTemperature.Value < 270)
            {
                failureInfo += "The oven temperature is too low, increase the oven temperature.\n";
            }
            if(ovenTemperature.Value > 500 && activeVents == 0)
            {
                failureInfo += "Temperature is too high! Decrease the oven temperature or turn on the ventilators.\n";
            }
            if(ovenTemperature.Value > 520)
            {
                failureInfo += "The oven temperature is too high, decrease the oven temperature.\n";
            }

            if(change_speed.Value >= 80 && activeVents == 0 && change_size.Value > 240)
            {
                failureInfo += "Conveyor belt speed is too high and bread is too large! Reduce the speed of the belt, reduce the size of pizza or turn on one ventilator.\n";
            }
            if(change_speed.Value == 90)
            {
                if(activeVents < 2)
                {
                    failureInfo += "Conveyor belt speed too high! Turn on two fans or reduce speed.\n";
                }
                if(ovenTemperature.Value > 480 && change_size.Value > 240 && activeVents < 3)
                {
                    failureInfo += "Conveyor belt speed is too high and pizza is too large! Turn on the three ventilators or reduce the speed or the size of pizza or the temperature of the oven.\n";
                }
            }

            if(energy > 85)
            {
                failureInfo += "The energy consumption is too high!!! Reduce production parameters.\n";
            }
            return failureInfo;
        }

        private void confirm_activity()
        {
            if (confirmationRequired)
            {
                confirm_activity_button.BackColor = Color.Crimson;
                activity_richTextBox.ForeColor = Color.Red;
                activity_richTextBox.Text = "Time to confirm activity: " + timeCounter + "s";

                if (timeCounter == 0)
                {
                    this.Close();
                }
            }
            else
            {
                confirm_activity_button.BackColor = Color.GreenYellow;
                activity_richTextBox.ForeColor = Color.White;
                activity_richTextBox.Text = "Time to next activity confirmation: " + timeCounter + "s";
            }
        }
        private void confirm_activity_button_Click(object sender, EventArgs e)
        {
            if (confirmationRequired)
            {
                timeCounter = 10;
                confirmationRequired = false;
                confirm_activity();

                if (failure_activation() == "")
                {
                    alarmSound.Stop();
                }
            }
        }

        private void change_size_ValueChanged(object sender, EventArgs e)
        {
            pizzaHeight = change_size.Value * 32/100;
            pizzaWidth = change_size.Value * 68 / 100;
            change_pizza_size(pizza1);
            change_pizza_size(pizza2);
            change_pizza_size(pizza3);
        }

        private void change_pizza_size(PictureBox pizza)
        {
            if(pizza.Location.X >= this.Width || pizza.Location.X < -pizzaHeight)
            {
                pizza.Height = pizzaHeight;
                pizza.Width = pizzaWidth;
            }
        }

        private void change_speed_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = 100 - change_speed.Value;
        }

        private void vent1_button_Click(object sender, EventArgs e)
        {
            vent1Active = vent_button_support(vent1_button);
        }

        private void vent2_button_Click(object sender, EventArgs e)
        {
            vent2Active = vent_button_support(vent2_button);
        }

        private void vent3_button_Click(object sender, EventArgs e)
        {
            vent3Active = vent_button_support(vent3_button);
        }

        private bool vent_button_support(Button vent_button)
        {
            bool ventActive;

            if (vent_button.BackColor == Color.DarkOliveGreen)
            {
                vent_button.BackColor = Color.GreenYellow;
                vent_button.Text = "I";
                ventActive = true;
                activeVents++;
            }
            else
            {
                vent_button.BackColor = Color.DarkOliveGreen;
                vent_button.Text = "O";
                ventActive = false;
                activeVents--;
            }
            return ventActive;
        }

        private void Production_FormClosing(object sender, FormClosingEventArgs e)
        {
            alarmSound.Stop();
            loginWindow.Visible = loginWindow.Enabled = true;
            loginWindow.login_textBox.Text = loginWindow.password_textBox.Text = "";
        }
    }
}
