using System.Diagnostics;

namespace ResetNetworkAdapter;

public partial class RestEthernetForm : Form
{
    private bool _adapterHasBeenResetSuccesFully = false;
 
    public RestEthernetForm()
    {
        InitializeComponent();
    }

    private async void btnReset_Click(object sender, EventArgs e)
    {
        if(_adapterHasBeenResetSuccesFully)
        {
            this.Close();
            return;
        }

        // 1. Reset Ethernet adapter
        await ResetEthernetAdapterAsync();

        // 2. Wait for internet connection
        await WaitForInternetConnectionAsync();

        // 3. Display message
        btnReset.Text = "Connected!";
    }

    private Task ResetEthernetAdapterAsync()
    {
        btnReset.Text = "Resetting Adapter...";
        return Task.Run(() =>
        {
            // Replace "Ethernet" with your adapter's name if different
            var adapterName = "Ethernet";
            var adpterDisable = new ProcessStartInfo("netsh", $"interface set interface \"{adapterName}\" admin=disable")
            {
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            };
            var adapterEnable = new ProcessStartInfo("netsh", $"interface set interface \"{adapterName}\" admin=enable")
            {
                Verb = "runas",
                CreateNoWindow = true,
                UseShellExecute = true
            };
            try
            {
                Process.Start(adpterDisable)?.WaitForExit();
                Task.Delay(2000).Wait(); // Wait 2 seconds before enabling
                Process.Start(adapterEnable)?.WaitForExit();
            }
            catch
            {
                this.Close();
            }
        });
    }

    private async Task WaitForInternetConnectionAsync()
    {
        using var httpClient = new HttpClient();
        while(true)
        {
            try
            {
                var response = await httpClient.GetAsync("https://www.microsoft.com");
                if(response.IsSuccessStatusCode)
                    break;
            }
            catch
            {
                // Ignore exceptions and retry
            }
            await Task.Delay(2000); // Wait 2 seconds before retrying
        }
        _adapterHasBeenResetSuccesFully = true;
    }
}
