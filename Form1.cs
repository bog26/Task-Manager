using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tasks.Model;

namespace Tasks
{
    public partial class Form1 : Form
    {
        private tmDBContext tmContext;
        const int indexIDColumn = 0; //bol 
        public Form1()
        {
            InitializeComponent();
            this.tmContext = new tmDBContext();
            var statuses = this.tmContext.Statuses.ToList();
            foreach(Status s in statuses)
            {
                cboStatus.Items.Add(s);
            }
            refreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void refreshData()
        {
            BindingSource binding = new BindingSource();
            var query = from t in tmContext.Tasks
                        orderby t.DueDate
                        select new { t.Id, Task = t.Name, Status = t.Status.Name, t.DueDate };
            binding.DataSource = query.ToList();
            dataGridView1.DataSource = binding;
            dataGridView1.Refresh();

        }
        private void cmdCreate_Click(object sender, EventArgs e)
        {
            if(cboStatus.SelectedItem != null && txtTask.Text!=String.Empty)
            {
                var newTask = new Model.Task
                {
                    Name = txtTask.Text,
                    StatusId = (cboStatus.SelectedItem as Status).Id,
                    DueDate = dateTimePicker1.Value
                };
                tmContext.Tasks.Add(newTask);
                tmContext.SaveChanges();
                refreshData();

            }
            else
            {
                MessageBox.Show("Please enter all data");
            }
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmdDeleteTask_Click(object sender, EventArgs e)
        {
            //insert validation here, like in create click...
            //also refactor this line:
            //int IDColumn = 0; //bol 
            var t = tmContext.Tasks.Find((int)dataGridView1.SelectedCells[indexIDColumn].Value);
            tmContext.Tasks.Remove(t);
            tmContext.SaveChanges();
            refreshData();

        }

        private void cmdUpdateTask_Click(object sender, EventArgs e)
        {
            if(cmdUpdateTask.Text == "Update")
            {
                txtTask.Text = dataGridView1.SelectedCells[1].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView1.SelectedCells[3].Value;
                foreach(Status s in cboStatus.Items)
                {
                    if(s.Name == dataGridView1.SelectedCells[2].Value.ToString())
                    {
                        cboStatus.SelectedItem = s;
                    }
                }
                cmdUpdateTask.Text = "Save";
            }
            else if (cmdUpdateTask.Text == "Save")
            {
                var t = tmContext.Tasks.Find((int)dataGridView1.SelectedCells[0].Value);
                t.Name = txtTask.Text;
                t.StatusId = (cboStatus.SelectedItem as Status).Id;
                t.DueDate = dateTimePicker1.Value;
                tmContext.SaveChanges();
                refreshData();
                cmdUpdateTask.Text = "Update";
                txtTask.Text = string.Empty;
                dateTimePicker1.Value = DateTime.Now;
                cboStatus.Text = "please select";
            }
            
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            cmdUpdateTask.Text = "Update";
            txtTask.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Now;
            cboStatus.Text = "please select";
        }
    }
}
