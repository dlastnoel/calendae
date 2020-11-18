﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Code_Secret_SOEMS.Helpers;

namespace Code_Secret_SOEMS.Models
{
    class Event
    {
        public DatabaseHelper dbHelper = new DatabaseHelper();

        public void loadEvents(DataGridView myDataGridView)
        {
            dbHelper.selectData("SELECT * FROM events");
            dbHelper.populateDataGridView(myDataGridView);
        }
    }
}