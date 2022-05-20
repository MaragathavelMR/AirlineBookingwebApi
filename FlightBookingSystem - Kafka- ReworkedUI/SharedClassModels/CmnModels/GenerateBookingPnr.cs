using System;
using System.Collections.Generic;
using System.Text;

namespace SharedClassModels.CmnModels
{
    public class GenerateBookingPnr : IGenerateBookingPnr
    {
        public GenerateBookingPnr()
        {
        }
        public int GeneratePnr()
        {
            Random random = new Random();
            int pnrid = random.Next();
            return pnrid;            
        }
    }
}
