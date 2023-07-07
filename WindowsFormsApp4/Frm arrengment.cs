﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;

namespace IMS
{
    public partial class Frm_arrengment : Form
    {
        public Frm_arrengment()
        {
            InitializeComponent();
        }
        public static string user { get; set; }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        private void Frm_arrengment_Load(object sender, EventArgs e)
        {
            user = frm_mid.User_name;
            String SQLQUERY = "SELECT [USER],[USER_NAME] FROM M_USER_MANAGEMENT WHERE [USER]='" + user + "'";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {

                SqlCommand comm = new SqlCommand(SQLQUERY, conn);
                conn.Open();
                SqlDataReader dr1 = comm.ExecuteReader();
                SqlDataAdapter dr = new SqlDataAdapter(comm);
                while (dr1.Read())
                {
                    txt_username.Text = dr1["USER_NAME"].ToString();
                    txt_oldpassword.Text = dr1["USER"].ToString();
                }
                dr1.Close();
                conn.Close();

            }
            loaddata();
        }

        private void btn_create_user_Click(object sender, EventArgs e)
        {
            Frm_create_user user = new Frm_create_user();
            user.MdiParent = frm_mid.ActiveForm;
            user.Show();
            this.Hide();
        }

        private void btn_forgot_Click(object sender, EventArgs e)
        {
            frm_forgot create = new frm_forgot();
            create.MdiParent = frm_mid.ActiveForm; 
            create.Show();
            this.Hide();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            frm_login login = new frm_login();
            login.Show();
            this.Close();
            frm_mid.ActiveForm.Close();
        }
        DataTable dt = new DataTable();
        public void loaddata()
        {
            String SQLQUERY = "SELECT [IMAGE] FROM M_IMAGE WHERE [USER]='" + user + "'";
            using (SqlConnection conn = new SqlConnection(ConnString))
            {

                SqlCommand comm = new SqlCommand(SQLQUERY, conn);
                conn.Open();
                //SqlDataReader dr1 = comm.ExecuteReader();
                //SqlDataAdapter dr = new SqlDataAdapter(comm);
                //dr.Fill(dt);
                object result =comm.ExecuteScalar();
                if (result !=DBNull.Value && result != null)
                {
                    Byte[] imagedata = (byte[])result;
                    using (MemoryStream ms = new MemoryStream(imagedata))
                    {
                        Image image = Image.FromStream(ms);
                        imagepath = result;
                        picBox.Image = image;
                    }
                }
                else
                {
                    string path = @"C:\Users\admin\Downloads\icons8-test-account-100.png";
                    picBox.ImageLocation = path;
                }

                conn.Close();

            }
        }
        public object imagepath { get; set; }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (imagepath != null)
            {
                MessageBox.Show("DO YOU WANT DELETE", "MESSAGE", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                String SQLQUERY = "DELETE FROM M_IMAGE WHERE  [USER]='" + user + "'";
                using (SqlConnection conn = new SqlConnection(ConnString))
                {

                    SqlCommand comm = new SqlCommand(SQLQUERY, conn);
                    conn.Open();
                    comm.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("DELETED SUCCESSFULLY");
                }
            }
            else
            {
                MessageBox.Show("ICON CANNOT BE DELETE");
            }
        }
        public string image { get; set; }
        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files |*.jpg;*.jpeg;*.png;*.gif;*.bmp|All File(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                image = openFileDialog.FileName;
                picBox.ImageLocation = image;



            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (picBox.Image != null)
            {


                using (SqlConnection conn = new SqlConnection(ConnString))
                {



                    // Query = @"INSERT INTO [M_USER_MANAGEMENT]   PASSWORD,USER_NAME,[USER],IMAGE_PATH VALUES '" + txt_confirmpassword.Text + "','" + txt_username.Text.Trim() +"','"+txt_oldpassword.Text+ "', @Image ";
                    // Query = @"INSERT INTO [M_USER_MANAGEMENT] (PASSWORD, USER_NAME, [USER] ,ACTIVE) VALUES (@Password, @UserName, @User,1)";


                    conn.Open();
                    SqlCommand comm = new SqlCommand();



                    Image image = picBox.Image;
                    byte[] imageBytes;
                    using (MemoryStream ms = new MemoryStream())
                    {
                        image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        imageBytes = ms.ToArray();
                    }
                    comm.Connection = conn;
                    String Query1 = @"INSERT INTO [M_IMAGE] ([USER], IMAGE ,ACTIVE) VALUES ( '" + txt_oldpassword.Text + "' , @IMAGE ,1)";
                    comm.Parameters.AddWithValue("@IMAGE", imageBytes);
                    comm.CommandText = Query1;
                    comm.ExecuteNonQuery();
                    MessageBox.Show("PROFILE SUCCESSFULLY GENERATED");
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("PICTURE IS NOT APPLICABLE");
            }
        }
    }
}
