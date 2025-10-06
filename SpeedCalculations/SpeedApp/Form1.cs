using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SpeedCalculations;

namespace SpeedApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) //вычислить
        {
            textBoxResult.Clear();

            // Определяем, какие поля заполнены
            bool hasDistance = !string.IsNullOrWhiteSpace(textBoxDistance.Text);
            bool hasTime = !string.IsNullOrWhiteSpace(textBoxTime.Text);
            bool hasSpeed = !string.IsNullOrWhiteSpace(textBoxSpeed.Text);

            double distance = 1;
            double time = 1;
            double speed = 1;

            if (hasDistance && !SpeedCalculation.TryParseInput(textBoxDistance.Text, out distance))
            {
                MessageBox.Show("Введите корректное значение расстояния!");
                return;
            }

            if (hasTime && !SpeedCalculation.TryParseInput(textBoxTime.Text, out time))
            {
                MessageBox.Show("Введите корректное значение времени!");
                return;
            }

            if (hasSpeed && !SpeedCalculation.TryParseInput(textBoxSpeed.Text, out speed))
            {
                MessageBox.Show("Введите корректное значение скорости!");
                return;
            }

            try
            {
                //расстояние и время — вычисляем скорость
                if (hasDistance && hasTime && !hasSpeed)
                {
                    double result = SpeedCalculation.Speed(distance, time);
                    textBoxResult.Text = $"Скорость: {result:F2} км/ч";
                }
                //скорость и время — вычисляем расстояние
                else if (hasSpeed && hasTime && !hasDistance)
                {
                    double result = SpeedCalculation.Distance(speed, time);
                    textBoxResult.Text = $"Расстояние: {result:F2} км";
                }
                //расстояние и скорость — вычисляем время
                else if (hasDistance && hasSpeed && !hasTime)
                {
                    double result = SpeedCalculation.Time(distance, speed);
                    textBoxResult.Text = $"Время: {result:F2} ч";
                }
                else
                {
                    MessageBox.Show("Введите ровно две из трёх величин: расстояние, время, скорость.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e) //очистить
        {
            textBoxDistance.Clear();
            textBoxTime.Clear();
            textBoxSpeed.Clear();
            textBoxResult.Clear();
        }
    }
}
