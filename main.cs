namespace WindowsFormsApplication2
{
public partial class Main : Form
{
    clsDB x = new clsDB();

    public Main()
    {
        InitializeComponent();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        string query = "INSERT INTO tbl_info (u_lastname, u_firstname, u_middlename) VALUES (@lastname, @firstname, @middlename)";
        var parameters = new Dictionary<string, object>
        {
            { "@lastname", atxtLN.Text },
            { "@firstname", atxtFN.Text },
            { "@middlename", atxtFN.Text }
        };
        x.SQLDB(query, parameters);
        fillgrid();
    }

    private void Main_Load(object sender, EventArgs e)
    {
        x.SQLDB("SELECT * FROM tbl_info");
        dgv1.DataSource = x.mDataSet.Tables[0];
        fillgrid();
    }

    void fillgrid()
    {
        x.SQLDB("SELECT * FROM tbl_info");
        dgv1.DataSource = null;
        dgv1.DataSource = x.mDataSet.Tables[0];
    }

    void search()
    {
        string query = "SELECT * FROM tbl_info WHERE u_id LIKE @id ORDER BY u_id";
        var parameters = new Dictionary<string, object>
        {
            { "@id", etxtID.Text + "%" }
        };
        x.SQLDB(query, parameters);
        if (x.mDataSet.Tables[0].Rows.Count > 0)
        {
            x.mDataAdapter.Fill(x.mDataSet, "tbl_info");
            dgv1.DataSource = x.mDataSet.Tables["tbl_info"].DefaultView;

            etxtLN.Text = dgv1.Rows[dgv1.CurrentRow.Index].Cells["u_lastname"].Value.ToString();
            etxtFN.Text = dgv1.Rows[dgv1.CurrentRow.Index].Cells["u_firstname"].Value.ToString();
            etxtMN.Text = dgv1.Rows[dgv1.CurrentRow.Index].Cells["u_middlename"].Value.ToString();
        }
        else if (etxtID.Text == "Type User ID to Edit")
        {
            etxtLN.Text = "";
            etxtFN.Text = "";
            etxtMN.Text = "";
        }
        else
        {
            etxtLN.Text = "";
            etxtFN.Text = "";
            etxtMN.Text = "";
        }
    }

    private void etxtID_TextChanged(object sender, EventArgs e)
    {

    }

    private void etxtID_Enter(object sender, EventArgs e)
    {
        etxtID.Text = "";
        etxtID.ForeColor = Color.Black;
    }

    private void etxtID_Leave(object sender, EventArgs e)
    {
        if (etxtID.Text == "")
        {
            etxtID.ForeColor = Color.Gray;
            etxtID.Text = "Type User ID to Edit";

            x.SQLDB("SELECT * FROM tbl_info");
            dgv1.DataSource = x.mDataSet.Tables[0];
            fillgrid();
        }
    }

    private void etxtID_KeyUp(object sender, KeyEventArgs e)
    {
        search();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        string query = "UPDATE tbl_info SET u_lastname = @lastname, u_firstname = @firstname, u_middlename = @middlename WHERE u_id = @id";
        var parameters = new Dictionary<string, object>
        {
            { "@lastname", etxtLN.Text },
            { "@firstname", etxtFN.Text },
            { "@middlename", etxtMN.Text },
            { "@id", etxtID.Text }
        };
        x.SQLDB(query, parameters);
        MessageBox.Show("Operation Successful!");
        fillgrid();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        string query = "DELETE FROM tbl_info WHERE u_id = @id";
        var parameters = new Dictionary<string, object>
        {
            { "@id", dtxtID.Text }
        };
        x.SQLDB(query, parameters);
        MessageBox.Show("Operation Successful!");
        fillgrid();
    }
}
}