using System;
using System.Windows.Forms;

namespace WindowsRegistrationForm
{
    public class RegistrationForm : Form
    {
        private TextBox firstNameTextBox, lastNameTextBox, emailTextBox, passwordTextBox;
        private RadioButton genderMaleRadioButton, genderFemaleRadioButton;
        private ComboBox countryComboBox;
        private CheckBox termsCheckBox;
        private Button registerButton;

        public RegistrationForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            Size = new System.Drawing.Size(400, 300);
            Text = "Registration Form";

            //creating form components
            firstNameTextBox = new TextBox();
            lastNameTextBox = new TextBox();
            emailTextBox = new TextBox();
            passwordTextBox = new TextBox();
            genderMaleRadioButton = new RadioButton
            {
                Text = "Male"
           };
            genderFemaleRadioButton = new RadioButton 
            { 
                Text="Femsale"            
            };
            countryComboBox = new ComboBox();
            termsCheckBox = new CheckBox();
            registerButton = new Button();

            //setting up the layout
            TableLayoutPanel mainTable = new TableLayoutPanel
            {
                ColumnCount=2,
                RowCount=9,
                Padding = new Padding(10),
                Dock = DockStyle.Fill
            };


            //adding form components to the main table
            mainTable.Controls.Add(new Label { Text = "First Name:" });
            mainTable.Controls.Add(firstNameTextBox);

            mainTable.Controls.Add(new Label { Text = "Last Name:" });
            mainTable.Controls.Add(lastNameTextBox); 

            mainTable.Controls.Add(new Label { Text = "Email:" });
            mainTable.Controls.Add(emailTextBox); 

            mainTable.Controls.Add(new Label { Text = "Password:" });
            //hiding password characters
            passwordTextBox.UseSystemPasswordChar = true;
            mainTable.Controls.Add(passwordTextBox);

            mainTable.Controls.Add(new Label { Text = "Gender:" });
            mainTable.Controls.Add(CreateFlowLayoutPanel(genderMaleRadioButton,genderFemaleRadioButton)); 

            mainTable.Controls.Add(new Label { Text = "Country:" });
            //adding combo box items
            countryComboBox.Items.AddRange(new string[] { "Kenya", "Uganda", "Tanzania" });
            mainTable.Controls.Add(countryComboBox); 

            mainTable.Controls.Add(new Label { Text = "I agree to the terms." });
            mainTable.Controls.Add(termsCheckBox);

            registerButton.Text = "Register";
            mainTable.Controls.Add(registerButton);
            mainTable.SetColumnSpan(registerButton,2);

               
            //adding the main table to the form
            Controls.Add(mainTable);

            //event handling
            registerButton.Click += RegisterButtonClicked;
        }

        private FlowLayoutPanel CreateFlowLayoutPanel(params Control[] controls)
        {
            FlowLayoutPanel panel = new FlowLayoutPanel
            {
                FlowDirection = FlowDirection.LeftToRight
            };
            panel.Controls.AddRange(controls);
            return panel;
        }

        private void RegisterButtonClicked(object sender, EventArgs e)
        {
            //registration logic
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            string email = emailTextBox.Text;
            string password = passwordTextBox.Text;
            string gender = genderMaleRadioButton.Checked ? "Male" : "Female";
            string country = countryComboBox.Text;
            bool termsAccepted = termsCheckBox.Checked;

            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || !termsAccepted)
            {
                MessageBox.Show("Please fill in all fields and accept the terms.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Registration successful:\nFirst Name: {firstName}\nLast Name: {lastName}\nEmail: {email}\nGender: {gender}\nCountry: {country}\nTerms Accepted: {termsAccepted}");

        }

        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new RegistrationForm());
        }
    }
}