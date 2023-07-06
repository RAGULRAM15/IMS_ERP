using System;
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

namespace IMS
{
    public partial class Frm_create_user : Form
    {
        public Frm_create_user()
        {
            InitializeComponent();
        }
        String ConnString = @"Data Source=DESKTOP-4DTMDPH;Initial Catalog=IMS;Integrated Security=True";
        public string user { get; set; }
        private void Frm_create_user_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            loaddata();
            user = frm_mid.User_name;
           

        }

        private void Frm_create_user_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.X && e.Alt)
            {
                clear();
                this.Close();
            }
        }
        public void clear()
        {
            txt_confirmpassword.Text = "";
            txt_newpassword.Text = "";
            txt_oldpassword.Text = "";
            txt_username.Text = "";
        }
        public string value { get; set; }
        private void btnlogin_Click(object sender, EventArgs e)
        {
            if (txt_newpassword.Text == txt_confirmpassword.Text && txt_username.Text !="")
            {
               value = txt_oldpassword.Text;

                try
                {
                    String Query;

                    using (SqlConnection conn = new SqlConnection(ConnString))
                    {



                        // Query = @"INSERT INTO [M_USER_MANAGEMENT]   PASSWORD,USER_NAME,[USER],IMAGE_PATH VALUES '" + txt_confirmpassword.Text + "','" + txt_username.Text.Trim() +"','"+txt_oldpassword.Text+ "', @Image ";
                        Query = @"INSERT INTO [M_USER_MANAGEMENT] (PASSWORD, USER_NAME, [USER] ,ACTIVE) VALUES (@Password, @UserName, @User,1)";


                        conn.Open();
                        SqlCommand comm = new SqlCommand();
                        comm.Parameters.AddWithValue("@Password", txt_confirmpassword.Text);
                        comm.Parameters.AddWithValue("@UserName", txt_username.Text.Trim());
                        comm.Parameters.AddWithValue("@User", txt_oldpassword.Text);
                        comm.Connection = conn;
                        StringBuilder SB = new StringBuilder();
                        SB.Append(Query);
                        //else
                        //{
                        //    comm.Parameters.AddWithValue("@Image", DBNull.Value);
                        //}
                        //comm.Parameters.AddWithValue("@Image", null);
                        comm.CommandText = SB.ToString();



                        if (picBox.Image != null)
                        {
                            




                            Image image = picBox.Image;
                            byte[] imageBytes;
                            using (MemoryStream ms = new MemoryStream())
                            {
                                image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                                imageBytes = ms.ToArray();
                            }
                            String Query1 = @"INSERT INTO [M_IMAGE] ([USER], IMAGE ,ACTIVE) VALUES ( '"+value+"' , @IMAGE ,1)";
                            comm.Parameters.AddWithValue("@IMAGE", imageBytes);
                            SB.Append(Query1);

                        }

                        comm.CommandText = SB.ToString();
                        comm.ExecuteNonQuery();
                        conn.Close();
                    }
                    MessageBox.Show("USER SUCCESSFULLY GENERATED");
                    clear();
                    this.Close();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                    
                
            }
            else
            {
                MessageBox.Show("CONFIRM PASSWORD NOT A SAME ");
            }
        }
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
                object result = comm.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    Byte[] imagedata = (byte[])result;
                    using (MemoryStream ms = new MemoryStream(imagedata))
                    {
                        Image image = Image.FromStream(ms);
                        picBox.Image = image;
                    }
                }
                else
                    {
                        picBox.Image = null;
                    }
                
                conn.Close();

            }
        }
        public string imagepath { get; set; }
        private void btn_upload_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files |*.jpg;*.jpeg;*.png;*.gif;*.bmp|All File(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagepath = openFileDialog.FileName;
                picBox.ImageLocation = imagepath;



            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
               
        }
        private void imageCreate()
        {
            
        }

    }
    }
