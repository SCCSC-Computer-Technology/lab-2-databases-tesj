// Thomas Speich
// CPT-206-A01S
// Lab-2
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T_Speich_CPT_206_A01S_Lab_2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cityBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.cityBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.populationDBDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'populationDBDataSet.City' table. You can move, or remove it, as needed.
            this.cityTableAdapter.Fill(this.populationDBDataSet.City);

        }

        //sorts by city ascending
        private void cityAscendingButton_Click(object sender, EventArgs e)
        {
            cityTableAdapter.FillByCityAscending(this.populationDBDataSet.City);
        }
        //sorts by city desscending
        private void cityDescendingButton_Click(object sender, EventArgs e)
        {
            cityTableAdapter.FillByCityDescending(this.populationDBDataSet.City);
        }
        //sorts by population ascending
        private void populationAscendingButton_Click(object sender, EventArgs e)
        {
            cityTableAdapter.FillByPopulationAscending(this.populationDBDataSet.City);
        }
        //sorts by population desscending
        private void populationDescendingButton_Click(object sender, EventArgs e)
        {
            cityTableAdapter.FillByPopulationDescending(this.populationDBDataSet.City);
        }

        private void populationMinButton_Click(object sender, EventArgs e)
        {
            //declare variables
            string name = "";
            int population = 0;

            try
            {
                //get the record with the least population
                DataRow record = cityTableAdapter.GetDataByMinPopulation().Rows[0];

                try
                {
                    //assign values of record to name and population variables
                    name = record[0].ToString();
                    population = Convert.ToInt32(record[1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Unable to retrieve the city with the smallest population");
                return;
            }

            //display the city with the smallest population
            MessageBox.Show($"Smallest Population\n{name}    {population:N0}");
        }
        private void populationMaxButton_Click(object sender, EventArgs e)
        {
            //declare variables
            string name = "";
            int population = 0;


            try
            {
                //get the record with the least population
                DataRow record = cityTableAdapter.GetDataByMaxPopulation().Rows[0];

                try
                {
                    //assign values of record to name and population variables
                    name = record[0].ToString();
                    population = Convert.ToInt32(record[1]);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
            }
            catch
            {
                MessageBox.Show("Unable to retrieve the city with the largest population");
                return;
            }

            //display the city with the greatest population
            MessageBox.Show($"Largest Population\n{name}    {population:N0}");
        }

        private void populationSumButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Total Population\n{cityTableAdapter.GetPopulationSum().Value:N0}");
        }

        private void populationAverageButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"Average Population\n{cityTableAdapter.GetPopulationAverage().Value:N0}");
        }
    }
}
