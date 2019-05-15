using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace smsmapp
{
    public partial class Default : ContentPage
    {
        private HttpClient client = new HttpClient();

        public Default()
        {
            InitializeComponent();
        }

        public class Checks
        {
            public int contact
            {
                get;
                set;
            }

            public int deacon
            {
                get;
                set;
            }

            public int newsletter
            {
                get;
                set;
            }
        }


        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            // myValue.Text = getEmail.Text;
            // Get resources'

            var content = await client.GetStringAsync("http://[URL HERE]/checkemail.php?email=" + getEmail.Text);
            var posts = JsonConvert.DeserializeObject<Checks>(content);
            myValue.Text = "Contact " + posts.contact + ", Deacon " + posts.deacon + ", Newletter " + posts.newsletter;

        }
    }
}
