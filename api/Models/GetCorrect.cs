using System.Diagnostics;

public class getCorrect {
    public static async Task<string> get(String wattage) {
         Process p = new Process();
        // Redirect the output stream of the child process.
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = true;
        p.StartInfo.FileName = "python/run.sh";
        p.StartInfo.Arguments = wattage;
        p.Start();
        // Do not wait for the child process to exit before
        // reading to the end of its redirected stream.
        // p.WaitForExit();
        // Read the output stream first and then wait.
        string output = p.StandardOutput.ReadToEnd();
        
        p.WaitForExitAsync();

        int[] clientIds = new[] { 123};
        foreach (var id  in clientIds)
        {
            if (output.Contains(id.ToString()))
            {
                return id.ToString();
            }    
        }

        Random rnd = new Random();
        return clientIds[rnd.Next(0,clientIds.Length)].ToString();
    }
}