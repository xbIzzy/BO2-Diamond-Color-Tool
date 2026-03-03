using System;
using XDevkit;
using JRPC_Client;
using System.Linq;
using System.Windows.Forms;

namespace BO2_Diamond_Color_Tool
{
    public partial class Form1 : Form
    {
        IXboxConsole Console;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Console.Connect(out Console))
            {
                label4.Text = "Connected";
                Console.XNotify("Made By xblzzy");
            }
            else
            {
                label4.Text = "Failed";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int R = int.Parse(textBox1.Text);
            int G = int.Parse(textBox2.Text);
            int B = int.Parse(textBox3.Text);

            float RFloat = R / 255f;
            float GFloat = G / 255f;
            float BFloat = B / 255f;

            byte[] RBytes = BitConverter.GetBytes(RFloat).Reverse().ToArray();
            byte[] GBytes = BitConverter.GetBytes(GFloat).Reverse().ToArray();
            byte[] BBytes = BitConverter.GetBytes(BFloat).Reverse().ToArray();
            byte[] Color = (RBytes).Concat(GBytes).Concat(BBytes).ToArray();

            Console.SetMemory(0xA881B620, Color);
            Console.SetMemory(0xA881B800, Color);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            byte[] Original =  {
                0x3E, 0xCC, 0xCC, 0xCD,
                0x3E, 0xCC, 0xCC, 0xCD,
                0x3E, 0xCC, 0xCC, 0xCD
            };

            Console.SetMemory(0xA881B620, Original);
            Console.SetMemory(0xA881B800, Original);
        }
    }
}
