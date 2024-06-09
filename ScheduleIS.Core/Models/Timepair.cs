namespace ScheduleIS.Core.Models
{
    public class Timepair
    {
        private Timepair(int id, string startPair, string endPair)
        {
            Id = id;
            StartPair = startPair;
            EndPair = endPair;
        }
        public int Id { get; }
        public string StartPair { get; }
        public string EndPair { get; }

        public static (Timepair Timepair, string error) Create(int id, string startPair, string endPair)
        {
            var error = string.Empty;

            if (!(CheckTime(startPair) || CheckTime(endPair)))
            {
                error = "Time is not correct!";
            }

            var timepair = new Timepair(id, startPair, endPair);

            return (timepair, error);
        }

        public static bool CheckTime(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                var tmp = str.Split(":");
                int val1 = Convert.ToInt32(tmp[0]);
                int val2 = Convert.ToInt32(tmp[1]);


                if ((val2 < 0 || val2 > 59) || (val1 < 0 || val1 > 24) || string.IsNullOrEmpty(str))
                {
                    return false;
                }
            }
            return true;
        }
       
    }
}
