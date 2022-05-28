namespace api.Util
{
    public class Registration
    {

        public const int MonthOffset = 3;

        public static int CurrentRegistrationYear
        {
            get
            {
                var now = DateTime.Now;
                return now.AddMonths(MonthOffset).Year;
            }
        }

        public static bool IsActiveYear(int year)
        {
            var now = DateTime.Now;
            return year == now.Year || year == CurrentRegistrationYear;
        }
    }
}
