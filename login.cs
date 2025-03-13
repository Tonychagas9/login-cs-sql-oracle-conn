public partial class Login : Form
{
    clsDB x = new clsDB();

    public Login()
    {
        InitializeComponent();
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        string query = "SELECT * FROM tbl_accounts WHERE u_username = @username AND u_password = @password";
        var parameters = new Dictionary<string, object>
        {
            { "@username", txtUser.Text },
            { "@password", txtPass.Text }
        };
        x.SQLDB(query, parameters);
        if (x.mDataSet.Tables[0].Rows.Count > 0)
        {
            Main a = new Main();
            this.Hide();
            a.Show();
        }
        else
        {
            MessageBox.Show("Wrong username or password");
        }
    }
}