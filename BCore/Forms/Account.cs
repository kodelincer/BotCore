﻿using BCore.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BCore.Forms
{
    public partial class Account : Form
    {
        private readonly ApplicationDbContext db;

        public Account()
        {
            InitializeComponent();
            db = new ApplicationDbContext();
        }

        private async void Account_Load(object sender, EventArgs e)
        {
            tb_username.Text = (await db.BSettings.Where(s => s.Key == "username").FirstOrDefaultAsync()).Value;
            tb_password.Text = (await db.BSettings.Where(s => s.Key == "password").FirstOrDefaultAsync()).Value;
        }

        private async void btn_save_Click(object sender, EventArgs e)
        {
            var username = await db.BSettings.Where(s => s.Key == "username").FirstOrDefaultAsync();
            username.Value = tb_username.Text.Trim();
            db.BSettings.Update(username);
            var password = await db.BSettings.Where(s => s.Key == "password").FirstOrDefaultAsync();
            password.Value = tb_password.Text.Trim();
            db.BSettings.Update(password);
            await db.SaveChangesAsync();
            this.Close();
        }
    }
}