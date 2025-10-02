using System;
using System.Security.Cryptography.X509Certificates;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    public void display()
    {
        Console.WriteLine($"Name: {_name}\nJobs:");
        foreach (Job job in _jobs)
        {
            job.DisplayJobInfo();
        }
    }

}