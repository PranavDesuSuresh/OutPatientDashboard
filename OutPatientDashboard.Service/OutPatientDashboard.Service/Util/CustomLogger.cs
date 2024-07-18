﻿namespace OutPatientDashboard.Service.Util
{
    public interface ICustomLogger
    {
        public void Error(Exception ex);

        public void Error(string message);

        public void Info(string message);

        public void Debug(string message);
    }

    public class CustomLogger : ICustomLogger
    {
        public async void Error(Exception ex)
        {
            // log4net or micorsoft exception handling here
            // Keeping a saperate class helps do custom logging like sending to prometheus
        }

        public async void Error(string message)
        {
            // log4net or micorsoft exception handling here
            // Keeping a saperate class helps do custom logging like sending to prometheus
        }

        public async void Info(string message)
        {
            // log4net or micorsoft exception handling here
            // Keeping a saperate class helps do custom logging like sending to prometheus
        }

        public async void Debug(string message)
        {
            // log4net or micorsoft exception handling here
            // Keeping a saperate class helps do custom logging like sending to prometheus
        }
    }
}