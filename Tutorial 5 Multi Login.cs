  koneksi.Open();
            if(TxtNama.Text == "" || TxtKata_Sandi.Text == "")
            {
                MessageBox.Show("Mohon masukan nama atau kata sandi anda terlebih dahulu !");
            }
            else
            {
                SqlDataAdapter dtap = new SqlDataAdapter("select Nama,Kata_Sandi,Jabatan from Pegawai where Nama = '" + TxtNama.Text + "' AND Kata_Sandi = '" + TxtKata_Sandi.Text + "'", koneksi);
                DataTable dt = new DataTable();
                dtap.Fill(dt);
                if(dt.Rows.Count > 0)
                {
                    foreach(DataRow dr in dt.Rows)
                    {
                        if(dr["Jabatan"].ToString() == "Admin")
                        {
                            this.Hide();
                            Form_Admin fa = new Form_Admin();
                            fa.Show();
                        }
                        else if(dr["Jabatan"].ToString() == "Pegawai")
                        {
                            this.Hide();
                            Form_Pegawai fg = new Form_Pegawai();
                            fg.Show();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Nama atau Kata Sandi anda salah mohon kontak admin!");
                }
                koneksi.Close();
