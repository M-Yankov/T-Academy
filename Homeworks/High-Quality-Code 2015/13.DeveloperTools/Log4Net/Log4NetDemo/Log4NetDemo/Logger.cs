namespace Log4NetDemo
{
    using System;
    using log4net;
    using log4net.Config;

    public class Logger
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(Logger));
        public static void Main()
        {
            BasicConfigurator.Configure();

            int tens = 0;
            int endOfLoop = 50;

            for (int i = 0; i < endOfLoop; i++)
            {
                logger.Debug("i = " + i);

                if (i % 10 == 0 && i != 0)
                {
                    tens = i;
                    logger.Info("First ten counts changed to: " + tens);
                }

                if (i == endOfLoop - 2)
                {
                    logger.Warn("You are at last iteration!");
                }
            }

            if (tens > 40)
            {
                logger.Error("Index was out of range!");
                
            }

            logger.Fatal("Exit from the program!");
            
        }
    }
}
